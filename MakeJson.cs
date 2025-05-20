using System;
using Newtonsoft.Json;
using System.Text.RegularExpressions;


namespace DailyArticle
{
    class MakeJson
    {
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

        public void SaveArticle(Article article)
        {
            string path = Path.Combine(Application.StartupPath, "readArticle.json");

            List<Article> articleList = new List<Article>();

            // 기존 파일이 있다면 불러오기
            if (File.Exists(path))
            {
                string existingJson = File.ReadAllText(path);
                articleList = JsonConvert.DeserializeObject<List<Article>>(existingJson) ?? new List<Article>();
            }

            article.requestedTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");


            // 리스트에 추가
            articleList.Add(article);

            // 전체를 다시 JSON으로 직렬화
            string newJson = JsonConvert.SerializeObject(articleList, Formatting.Indented);
            File.WriteAllText(path, newJson);
        }
    }
}
