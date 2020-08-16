using OneForDotNet.Core.Config;
using OneForDotNet.Core.Helper;
using OneForDotNet.Core.Interface;
using OneForDotNet.Core.Models;
using OneForDotNet.Core.Spider;
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
    }
}
