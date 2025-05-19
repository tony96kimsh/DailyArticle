using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyArticle
{
    public class Article
    {
        // 자동 구현 속성 문법 사용
        public string id { get; set; }
        public string title { get; set; }
        public string webUrl { get; set; }
        public string webDate { get; set; }
        public string articleBody { get; set; }
        public string requestedTime { get; set; }
    }
}
