using OneForDotNet.Core.Config;
using OneForDotNet.Core.Helper;
using OneForDotNet.Core.Interface;
using OneForDotNet.Core.Models;
using OneForDotNet.Core.Spider;
using OneForDotNet.Models;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace OneForDotNet.Core.Service {
    public class ApiService:IService {
        public async Task<ModelBase> GetHome() {
            ModelBase model = new ModelBase();
            var result = await HttpHelper.HttpGet(Url.Home);
            model.Status = result.Status;
            if (result.Status=="OK") {
                HomeSpider spider = new HomeSpider(result.Result);
                model.Data = new Home() {
                    Ones = spider.GetOnes(),
                    Articles = spider.GetArticles(),
                    Questions = spider.GetQuestions()
                };
            }
            return model;
        }

        public async Task<ModelBase> GetArticle(int id) {
            ModelBase model = new ModelBase();
            var result = await HttpHelper.HttpGet(Url.GetArticleUrl(id));
            model.Status = result.Status;
            if (result.Status=="OK") {
                ArticleSpider spider = new ArticleSpider(result.Result);
                model.Data = spider.GetArticle();
            }
            return model;
        }

        public async Task<ModelBase> GetQuestion(int id) {
            ModelBase model = new ModelBase();
            var result = await HttpHelper.HttpGet(Url.GetQuestionUrl(id));
            model.Status = result.Status;
            if (result.Status == "OK") {
                QuestionSpider spider = new QuestionSpider(result.Result);
                model.Data = spider.GetQuestion();
            }
            return model;
        }

    }
}
