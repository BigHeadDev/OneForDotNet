using System;
using System.Collections.Generic;
using System.Text;

namespace OneForDotNet.Core.Config {
    internal static class Url {
        public readonly static string Home="http://wufazhuce.com/";
        private readonly static string article = string.Concat(Home, "article/{0}");
        private readonly static string question= string.Concat(Home, "question/{0}");

        public static string GetArticleUrl(int id) {
            return string.Format(article, id);
        }
        public static string GetQuestionUrl(int id) {
            return string.Format(question, id);
        }
    }
}
