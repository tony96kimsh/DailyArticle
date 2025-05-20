using Newtonsoft.Json.Linq;
using System.Configuration;
using System.Diagnostics.Eventing.Reader;
using System.Security.Cryptography.X509Certificates;

namespace DailyArticle
{  
    class MakeArticle
    {
        private static string apiKey = ConfigurationManager.AppSettings["GuardianApiKey"];
        private string linkUrl = "https://www.theguardian.com/";       

        private MakeJson makeJson;

        // buffer List
        private List<Article> articleBuffer = new List<Article>();
        private int currentIndex = 0;

        public MakeArticle (Form parent)
        {
            this.makeJson = new MakeJson();
        }

        public void FetchArticles()
        {
            string today = DateTime.Now.ToString("yyyy-MM-dd");

            string url = $"https://content.guardianapis.com/search" +     // Guardian 검색 엔드포인트
                         $"?api-key={apiKey}" +                            // API 키
                         $"&from-date={today}" +                           // 오늘 날짜부터
                         $"&to-date={today}" +                             // 오늘 날짜까지 (즉, 하루만)
                         $"&order-by=relevance" +                          // 중요도 높은 뉴스 우선 정렬
                         $"&page-size=10" +                                 // 가장 중요한 10개 가져오기(최대)
                         $"&show-fields=body";                             // 기사 본문 포함

            HttpClient client = new HttpClient();// HTTP 요청
            HttpResponseMessage response = client.GetAsync(url).Result; // 동기식 요청            
            string result = response.Content.ReadAsStringAsync().Result; // 동기식 응답

            JObject json = JObject.Parse(result);

            // 버퍼 초기화
            articleBuffer.Clear();
            currentIndex = 0;

            var results = json["response"]?["results"];

            if (results != null)
            {
                foreach (var item in results)
                {
                    string resId = item["id"]?.ToString();
                    string title = item["webTitle"]?.ToString();
                    string webDate = item["webPublicationDate"]?.ToString();
                    string webUrl = item["webUrl"]?.ToString();
                    string body = item["fields"]?["body"]?.ToString();
                    string articleBody = makeJson.ParseHTML(body);

                    var article = new Article
                    {
                        id = resId,
                        title = title,
                        webDate = webDate,
                        webUrl = webUrl,
                        articleBody = articleBody,
                        requestedTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                    };

                    articleBuffer.Add(article);
                }
            }            
        }

        public Article GetArticle()
        {
            if (articleBuffer.Count == 0 || currentIndex >= articleBuffer.Count)
            {
                FetchArticles(); // 새로 10개 가져오기
            }

            if (articleBuffer.Count == 0)
            {
                return null; // 실패한 경우
            }

            return articleBuffer[currentIndex++];
        }
    }
}
