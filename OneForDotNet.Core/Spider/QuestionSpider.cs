using HtmlAgilityPack;
using OneForDotNet.Core.Config;
using OneForDotNet.Core.Models;
using OneForDotNet.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;

namespace OneForDotNet.Core.Spider {
    public class QuestionSpider {
        private HtmlDocument document = new HtmlDocument();
        public QuestionSpider(Stream html) {
            document.Load(html);
        }
        public DetailContent GetQuestion() {
            var root = document.DocumentNode.SelectSingleNode(Xpath.DetialContentRoot);
            root.InnerHtml = HttpUtility.HtmlDecode(root.InnerHtml);
            string title = root.SelectSingleNode("h4[1]").InnerText.Trim();
            string subTitle = root.SelectSingleNode("div[@class='cuestion-contenido']").InnerText.Trim();
            string editor = root.SelectSingleNode("p[@class='cuestion-editor']").InnerText.Trim();
            List<string> paragraphs = new List<string>();
            var paraRoor = root.SelectNodes("div[@class='cuestion-contenido']").Descendants("p");
            foreach (var item in paraRoor) {
                paragraphs.Add(item.InnerText);
            }
            return new DetailContent() {
                Title = title,
                Subtitle = subTitle,
                Paragraphs = paragraphs,
                Editor = editor
            };
        }
    }
}
