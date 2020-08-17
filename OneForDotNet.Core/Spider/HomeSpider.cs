using HtmlAgilityPack;
using OneForDotNet.Core.Config;
using OneForDotNet.Core.Models;
using OneForDotNet.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace OneForDotNet.Core.Spider {
    public class HomeSpider {
        private HtmlDocument document = new HtmlDocument();
        public HomeSpider(Stream html) {
            document.Load(html);
        }
        public List<One> GetOnes() {
            List<One> ones = new List<One>();
            var root = document.DocumentNode.SelectSingleNode(Xpath.OneRoot);
            if (root != null) {
                var childs = root.SelectNodes("div");
                foreach (var item in childs) {
                    var imgNode = item.SelectSingleNode("a");
                    var detailNode = item.SelectSingleNode("div[@class='fp-one-cita-wrapper']");
                    var dateNodes = detailNode.SelectNodes("div[@class='fp-one-titulo-pubdate']/p");
                    var titletNode = detailNode.SelectSingleNode("div[@class='fp-one-cita']/a");
                    ones.Add(new One() {
                        Href = imgNode.Attributes["href"].Value,
                        ImageUrl = imgNode.FirstChild.Attributes["src"].Value,
                        Date = $"{dateNodes[1].InnerText} {dateNodes[2].InnerText}",
                        Title = titletNode.InnerText,
                        Vol = dateNodes[0].InnerText
                    });
                }
            }
            return ones;
        }
        public List<OneArticle> GetArticles() {
            List<OneArticle> articles = new List<OneArticle>();
            var root = document.DocumentNode.SelectSingleNode(Xpath.ArticleRoot);
            if (root != null) {
                var today = root.SelectSingleNode("div[@class='corriente']");
                var todayDetail = today.SelectSingleNode("p[@class='one-articulo-titulo']/a");
                articles.Add(new OneArticle() {
                    Vol = today.SelectSingleNode("p[@class='one-titulo']").InnerText.Trim(),
                    Href = todayDetail.Attributes["href"].Value,
                    Title = todayDetail.FirstChild.InnerText.Trim(),
                    Author = todayDetail.SelectSingleNode("small").InnerText.Remove(0,1)
                });
                var childs = root.Descendants("li");
                foreach (var item in childs) {
                    var detail = item.SelectSingleNode("a");
                    articles.Add(new OneArticle() {
                        Vol = item.SelectSingleNode("span").InnerText,
                        Href = detail.Attributes["href"].Value,
                        Title = detail.FirstChild.InnerText.Trim(),
                        Author = detail.SelectSingleNode("small").InnerText.Remove(0, 1)
                    });
                }
            }
            return articles;
        }
        public List<OneQuestion> GetQuestions() {
            List<OneQuestion> questions = new List<OneQuestion>();
            var root = document.DocumentNode.SelectSingleNode(Xpath.QuestionRoot);
            if (root != null) {
                var today = root.SelectSingleNode("div[@class='corriente']");
                var todayDetail = today.SelectSingleNode("p[@class='one-cuestion-titulo']/a");
                questions.Add(new OneQuestion() {
                    Vol = today.SelectSingleNode("p[@class='one-titulo']").InnerText.Trim(),
                    Href = todayDetail.Attributes["href"].Value,
                    Title = todayDetail.FirstChild.InnerText.Trim()
                });
                var childs = root.Descendants("li");
                foreach (var item in childs) {
                    var detail = item.SelectSingleNode("a");
                    questions.Add(new OneQuestion() {
                        Vol = item.SelectSingleNode("span").InnerText,
                        Href = detail.Attributes["href"].Value,
                        Title = detail.FirstChild.InnerText.Trim()
                    });
                }
            }
            return questions;
        }
    }
}
