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
// JSON file
using System.IO;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;


namespace DailyArticle
{
    public partial class FormArticleView : Form
    {
        private static string apiKey = ConfigurationManager.AppSettings["GuardianApiKey"];
        private string linkUrl = "https://www.theguardian.com/";

        // 캐럿 제어
        [DllImport("user32.dll")] // 대괄호 -> 특성(attribute) 제어 문법
        static extern bool HideCaret(IntPtr hWnd);
                
        // 리스트 화면 전환
        private bool isLoading = false;
        private bool isFavorite = false;
        
        private Article currentArticle;
        private Loading loading;
        private MakeArticle makeArticle;
        private MakeJson makeJson;


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
        public void ShowArticle(Article article)
        {
            txtTitle.Text = article.title;
            lblDate.Text = "Publication date: " + article.webDate;
            txtArticle.Text = article.articleBody;
            linkUrl = article.webUrl;
        }
        public void setArticle (Article article)
        {
            // 폼 컨트롤
            txtTitle.Text = article.title;
            lblDate.Text = "Publication date: " + article.webDate;
            txtArticle.Text = article.articleBody;            
        }

        public void ShowArticle ()
        {
            // API 응답 기사
            loading.showLoading();
            currentArticle = makeArticle.GetArticle();
            setArticle(currentArticle);
            makeJson.SaveArticle(currentArticle);
            loading.showLoading();
        }

        public FormArticleView()
        {
            makeJson = new MakeJson();
            InitializeComponent();
            tip.SetToolTip(btnChange, "새로운 기사 요청");
            tip.SetToolTip(btnFavorite, "즐겨찾기 추가/제거");
            tip.SetToolTip(btnHistory, "최근 본 기사 목록 보기");
            tip.SetToolTip(btnFavoriteList, "즐겨찾기 기사 목록 보기");
        }        

        private void Form1_Load(object sender, EventArgs e)
        {
            makeArticle = new MakeArticle(this);
            loading = new Loading(this);
            loading.InitOverlay();

            // 폰트 적용
            LoadFonts();
            txtTitle.Font = titleFont;       // 제목에 Bold
            txtArticle.Font = bodyFont;     // 본문에 Regular

            ShowArticle();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            ShowArticle();
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

        private void txtArticle_MouseDown(object sender, MouseEventArgs e)
        {
            HideCaret(txtArticle.Handle);
        }

        private void txtArticle_Enter(object sender, EventArgs e)
        {
            HideCaret(txtArticle.Handle);
        }

        private void btnCalendar_Click(object sender, EventArgs e)
        {

        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            FormReadList form2 = new FormReadList(this, true);
            form2.Show();
            this.Hide();
        }

        private void btnFavoriteList_Click(object sender, EventArgs e)
        {
            FormReadList form2 = new FormReadList(this, false);
            form2.Show();
            this.Hide();
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

        private void btnFavorite_Click(object sender, EventArgs e)
        {
            isFavorite = !isFavorite;
            string path = Path.Combine(Application.StartupPath, "favoriteList.json");
            if (isFavorite)
            {                
                List<Article> favList = new List<Article>();

                if (File.Exists(path))
                {
                    string json = File.ReadAllText(path);
                    // 직렬화
                    favList = JsonConvert.DeserializeObject<List<Article>>(json) ?? new List<Article>();
                }

                if (!favList.Any(a => a.id == currentArticle.id))
                {
                    favList.Add(currentArticle);

                    string newJson = JsonConvert.SerializeObject(favList, Formatting.Indented);
                    File.WriteAllText(path, newJson);
                }

                btnFavorite.ForeColor = Color.Gold;                
                MessageBox.Show("즐겨찾기에 추가되었습니다!");
            }
            else
            {
                // 즐겨찾기에서 제거
                if (File.Exists(path))
                {
                    string json = File.ReadAllText(path);
                    List<Article> favList = JsonConvert.DeserializeObject<List<Article>>(json) ?? new List<Article>();

                    // 현재 기사 ID를 제외한 새 리스트 생성
                    favList = favList.Where(a => a.id != currentArticle.id).ToList();

                    string newJson = JsonConvert.SerializeObject(favList, Formatting.Indented);
                    File.WriteAllText(path, newJson);
                }

                btnFavorite.ForeColor = SystemColors.ControlLight;
                MessageBox.Show("즐겨찾기에서 제외되었습니다.");
            }


        }
    }
}
