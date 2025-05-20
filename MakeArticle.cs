using Newtonsoft.Json.Linq;
using System.Configuration;

namespace DailyArticle
{  
    class MakeArticle
    {
        private static string apiKey = ConfigurationManager.AppSettings["GuardianApiKey"];
        private string linkUrl = "https://www.theguardian.com/";

        private Article currentArticle;
        private Loading loading;
        private Form parentForm;
        private MakeJson makeJson;
        private Article getResultArticle;
                
        public MakeArticle (Form parent)
        {
            this.parentForm = parent;
            this.makeJson = new MakeJson();
            currentArticle = new Article();
        }

        public Article GetArticle()
        {
            // GetArticle
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
            currentArticle.id = json["response"]?["results"]?[0]?["id"]?.ToString();
            currentArticle.title = json["response"]?["results"]?[0]?["webTitle"]?.ToString();
            currentArticle.webDate = json["response"]?["results"]?[0]?["webPublicationDate"]?.ToString();
            currentArticle.webUrl = json["response"]?["results"]?[0]?["webUrl"]?.ToString();
            linkUrl = currentArticle.webUrl;

            // 본문 응답 후 html요소 제거
            string resBody = json["response"]?["results"]?[0]?["fields"]?["body"]?.ToString();
            currentArticle.articleBody = makeJson.ParseHTML(resBody);

            return currentArticle;
        }
    }
}
