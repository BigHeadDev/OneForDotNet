using System;
using System.Collections.Generic;
using System.Text;

namespace OneForDotNet.Xamarin.Config {
    public static class Url {
        private readonly static string api = "http://4ubb9173y5p5.hong-kong-server1.core-hosting.net/oneapi/";
        public readonly static string Home = $"{api}home";
        private readonly static string article = string.Concat(api, "article?id={0}");
        private readonly static string question = string.Concat(api, "question?id={0}");

        public static string GetArticleUrl(string id) {
            return string.Format(article, id);
        }
        public static string GetQuestionUrl(string id) {
            return string.Format(question, id);
        }
    }
}
