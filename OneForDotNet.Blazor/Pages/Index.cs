using Microsoft.AspNetCore.Components;
using OneForDotNet.Blazor.Model;
using OneForDotNet.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace OneForDotNet.Blazor.Pages {
    public partial class Index {
        [Inject]
        public HttpClient Client { get; set; }
        private List<One> Ones = new List<One>();
        private List<OneArticle> Articles = new List<OneArticle>();
        private List<OneQuestion> Questions = new List<OneQuestion>();
        protected override async Task OnInitializedAsync() {
            var result = await Client.GetFromJsonAsync<HomeBase>("http://192.168.0.211:8080/oneapi/home");
            if (result.Status=="OK") {
                Ones = result.Data.Ones;
                Articles = result.Data.Articles;
                Questions = result.Data.Questions;
            }
            await base.OnInitializedAsync();
        }
    }
}
