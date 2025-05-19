using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// json
using System.IO;
using Newtonsoft.Json;
using System.Linq.Expressions;

namespace DailyArticle
{
    public partial class FromReadList : Form
    {
        private static bool isHistory = true; // default 
        private static bool isBackButtonClicked = false;
        Form1 form1;
        public FromReadList()
        {
            InitializeComponent();
            isHistory = true;
            isBackButtonClicked = false;
        }

        public FromReadList(Form1 form, bool selectedMenu)
        {
            InitializeComponent();
            this.form1 = form;
            isHistory = selectedMenu;
            isBackButtonClicked = false;
        }


        public void showList(string fileName)
        {
            string path = Path.Combine(Application.StartupPath, fileName);
            listView1.Items.Clear(); // 초기화

            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);

                List<Article> articles = JsonConvert.DeserializeObject<List<Article>>(json);

                foreach (var article in articles)
                {
                    ListViewItem item = new ListViewItem(article.title); // 첫 번째 열
                    item.SubItems.Add(article.requestedTime);            // 두 번째 열
                    item.Tag = article;

                    listView1.Items.Add(item);
                }
            }
            if (isHistory)
            {
                btnShowHistory.ForeColor = SystemColors.ControlText;
                btnShowFavorite.ForeColor = SystemColors.ControlLight;
            }
            else
            {
                btnShowFavorite.ForeColor = SystemColors.ControlText;
                btnShowHistory.ForeColor = SystemColors.ControlLight;
            }
        }
        private void FromReadList_Load(object sender, EventArgs e)
        {
            if (isHistory) // 최근 본 기사
            {
                showList("readArticle.json");
            }
            else // 즐겨찾기
            {
                showList("favoriteList.json");
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            isBackButtonClicked = true;
            this.Close();
            form1.Show();
        }

        private void FromReadList_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isBackButtonClicked)
            {
                // 뒤로가기 앱 종료 미동작

            }
            else
            {
                Application.Exit();
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnShowHistory_Click(object sender, EventArgs e)
        {
            isHistory = true;
            showList("readArticle.json");
        }

        private void btnShowFavorite_Click(object sender, EventArgs e)
        {
            isHistory = false;
            showList("favoriteList.json");
        }

        private void btnViewArticle_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("기사를 선택해주세요.");
                return;
            }

            // 선택한 항목에서 Article 꺼내기
            var selectedItem = listView1.SelectedItems[0];
            var article = (Article)selectedItem.Tag;

            // Form1에 기사 전달
            form1.ShowArticle(article);

            // 폼 전환
            form1.Show();
            this.Hide();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("삭제할 항목을 선택해주세요.");
                return;
            }

            // 선택한 항목
            var selectedItem = listView1.SelectedItems[0];
            var selectedArticle = (Article)selectedItem.Tag;

            // 파일명 결정
            string fileName = isHistory ? "readArticle.json" : "favoriteList.json";
            string path = Path.Combine(Application.StartupPath, fileName);

            if (!File.Exists(path)) return;

            // JSON 로드 후 필터링
            var json = File.ReadAllText(path);
            var list = JsonConvert.DeserializeObject<List<Article>>(json) ?? new List<Article>();

            // ID 기준으로 제외
            list = list.Where(a => a.id != selectedArticle.id).ToList();

            // 다시 저장
            File.WriteAllText(path, JsonConvert.SerializeObject(list, Formatting.Indented));

            // ListView에서도 제거
            listView1.Items.Remove(selectedItem);

            MessageBox.Show("삭제되었습니다.");
        }

    }
}
