using HtmlAgilityPack;
using OneForDotNet.Core.Config;
using OneForDotNet.Core.Models;
using OneForDotNet.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OneForDotNet.Core.Spider {
    public class ArticleSpider {
        private HtmlDocument document = new HtmlDocument();
        public ArticleSpider(Stream html) {
            document.Load(html);
        }
        public DetailContent GetArticle() {
            var root = document.DocumentNode.SelectSingleNode(Xpath.DetialContentRoot);
            string title = root.SelectSingleNode("h2[@class='articulo-titulo']").InnerText.Trim();
            string author = root.SelectSingleNode("p[@class='articulo-autor']").InnerText.Trim();
            string editor = root.SelectSingleNode("p[@class='articulo-editor']").InnerText.Trim();
            List<string> paragraphs = new List<string>();
            var paraRoor = root.SelectSingleNode("div[@class='articulo-contenido']").Descendants("p");
            foreach (var item in paraRoor) {
                paragraphs.Add(item.InnerText);
            }
            return new DetailContent() {
                Title = title,
                Subtitle = author,
                Paragraphs = paragraphs,
                Editor = editor
            };
        }
    }
}
