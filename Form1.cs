using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Newtonsoft.Json.Linq; // json parsing ref
using System.Text.RegularExpressions; // html 요소 제거용
using System.Diagnostics; // link 선택 시 브라우저 동작용
using System.Runtime.InteropServices; // 캐럿 제어
using System.Configuration;
using System.Security.Cryptography.X509Certificates;
//폰트
using System.Drawing.Text;
using System.Runtime.InteropServices;


namespace DailyArticle
{
    public partial class Form1 : Form
    {
        private static string apiKey = ConfigurationManager.AppSettings["GuardianApiKey"];

        private string linkUrl = "https://www.theguardian.com/";

        // 캐럿 제어
        [DllImport("user32.dll")] // 대괄호 -> 특성(attribute) 제어 문법
        static extern bool HideCaret(IntPtr hWnd);
        private Form overlay;
        private bool isLoading = false;


        //폰트적용
        PrivateFontCollection semiFonts = new PrivateFontCollection();
        Font titleFont;
        Font bodyFont;

        public void LoadFonts()
        {
            // 1. Regular 스타일 로드
            string regularPath = Path.Combine(Application.StartupPath, "fonts", "Merriweather_24pt_SemiCondensed-Regular.ttf");
            if (File.Exists(regularPath)) semiFonts.AddFontFile(regularPath);

            // 2. Bold 스타일 로드
            string boldPath = Path.Combine(Application.StartupPath, "fonts", "Merriweather_24pt_SemiCondensed-Bold.ttf");
            if (File.Exists(boldPath)) semiFonts.AddFontFile(boldPath);

            // 3. Font 생성
            if (semiFonts.Families.Length > 0)
            {
                FontFamily family = semiFonts.Families[0];
                titleFont = new Font(family, 20f, FontStyle.Bold);
                bodyFont = new Font(family, 14f, FontStyle.Regular);
            }
            else
            {
                // fallback
                titleFont = new Font("맑은 고딕", 20f, FontStyle.Bold);
                bodyFont = new Font("맑은 고딕", 14f, FontStyle.Regular);
            }
        }



        public string ParseHTML(string resBody)
        {
            string articleBody = resBody;

            // 1. <p> → 줄바꿈으로
            articleBody = Regex.Replace(articleBody, @"<\/?p.*?>", "\n");

            // 2. <br>, <br/> → 줄바꿈
            articleBody = Regex.Replace(articleBody, @"<br\s*/?>", "\n", RegexOptions.IgnoreCase);

            // 3. 나머지 모든 태그 제거
            articleBody = Regex.Replace(articleBody, @"<.*?>", "");

            // 4. 필요 시 공백 정리 (줄바꿈 2번 이상이면 하나로)
            articleBody = Regex.Replace(articleBody, @"\n{2,}", "\n\n").Trim();

            return articleBody;
        }

        public void InitOverlay()
        {
            // 로딩 폼 생성
            overlay = new Form();
            overlay.FormBorderStyle = FormBorderStyle.None;
            overlay.BackColor = Color.Black;
            overlay.Opacity = 0.7;
            overlay.ShowInTaskbar = false;
            overlay.StartPosition = FormStartPosition.Manual;
            // 작업 표시줄 제외한 화면 영역 기준으로 덮기
            overlay.Size = this.ClientSize;
            overlay.Location = this.PointToScreen(Point.Empty);
            overlay.TopMost = true;

            // Alt + F4 시 앱 종료
            overlay.FormClosing += (s, e) =>
            {
                Application.Exit();
            };

            // 라벨 생성
            Label lbl = new Label();
            lbl.Text = "Loading...";
            lbl.Font = new Font("Merriweather 24pt SemiCondensed", 16, FontStyle.Bold);
            lbl.ForeColor = Color.White; // 검정 배경 위에 흰 글자            
            lbl.BackColor = Color.Black;
            lbl.AutoSize = true;

            // 라벨은 위치 계산이 되기 전이므로 Load 이벤트에서 위치 설정
            overlay.Load += (s, args) =>
            {
                lbl.Location = new Point(
                    (overlay.ClientSize.Width - lbl.Width) / 2,
                    (overlay.ClientSize.Height - lbl.Height) / 2
                );
            };

            overlay.Controls.Add(lbl);
        }
        public void showLoading()
        {
            if (overlay == null || overlay.IsDisposed)
            {
                InitOverlay();
            }

            if (overlay.Visible)
            {
                overlay.Hide();
            }
            else
            {
                overlay.Show();
            }
        }
        public void showArticle()
        {
            showLoading();
            // Guardian Open API 요청 URL 구성
            string today = DateTime.Now.ToString("yyyy-MM-dd"); // 오늘 날짜: 2025-05-17 같은 형식

            string url = $"https://content.guardianapis.com/search" +     // Guardian 검색 엔드포인트
                         $"?api-key={apiKey}" +                            // API 키
                         $"&from-date={today}" +                           // 오늘 날짜부터
                         $"&to-date={today}" +                             // 오늘 날짜까지 (즉, 하루만)
                         $"&order-by=relevance" +                          // 중요도 높은 뉴스 우선 정렬
                         $"&page-size=1" +                                 // 가장 중요한 1개만 가져오기
                         $"&show-fields=body";                             // 기사 본문 포함

            HttpClient client = new HttpClient();// HTTP 요청
            HttpResponseMessage response = client.GetAsync(url).Result; // 동기식 요청            
            string result = response.Content.ReadAsStringAsync().Result; // 동기식 응답

            // JSON Parse
            JObject json = JObject.Parse(result);
            // 뉴턴소프트 제이슨 문법 : json은 [키값], 배열의 경우 [인덱스]로 진입
            string resWebTitle = json["response"]?["results"]?[0]?["webTitle"]?.ToString();
            string resWebPublicationDate = json["response"]?["results"]?[0]?["webPublicationDate"]?.ToString();
            string resWebUrl = json["response"]?["results"]?[0]?["webUrl"]?.ToString();
            linkUrl = resWebUrl;

            // 본문 응답 후 html요소 제거
            string resBody = json["response"]?["results"]?[0]?["fields"]?["body"]?.ToString();
            string articleBody = ParseHTML(resBody);


            txtTitle.Text = resWebTitle;
            lblDate.Text = "Publication date: " + resWebPublicationDate;
            txtAriticle.Text = articleBody;

            showLoading();
        }
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            // 폰트 적용
            LoadFonts();
            txtTitle.Font = titleFont;       // 제목에 Bold
            txtAriticle.Font = bodyFont;     // 본문에 Regular


            showArticle(); // 뉴스 로딩

            // 최초 진입 요청
            showArticle();

            //btnChange.FlatStyle = FlatStyle.Flat;
            //btnChange.FlatAppearance.BorderSize = 0;

            // 추가 기능 (진행중)
            //btnCalendar.Visible = false;
            //btnHistory.Visible = false;
            //btnFavoriteList.Visible = false;

            InitOverlay();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            showArticle();
        }

        private void txtAriticle_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            try
            {
                System.Diagnostics.Process.Start(new ProcessStartInfo
                {
                    FileName = linkUrl,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("링크를 열 수 없습니다: " + ex.Message);
            }
        }

        private void txtAriticle_MouseDown(object sender, MouseEventArgs e)
        {
            HideCaret(txtAriticle.Handle);
        }

        private void txtAriticle_Enter(object sender, EventArgs e)
        {
            HideCaret(txtAriticle.Handle);
        }

        private void btnCalendar_Click(object sender, EventArgs e)
        {

        }

        private void btnHistory_Click(object sender, EventArgs e)
        {

        }

        private void btnFavoriteList_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(new ProcessStartInfo
                {
                    FileName = "https://github.com/tony96kimsh/DailyArticle",
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("링크를 열 수 없습니다: " + ex.Message);
            }
        }
    }
}
