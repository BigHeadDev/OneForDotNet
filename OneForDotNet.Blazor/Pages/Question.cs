using Microsoft.AspNetCore.Components;
using OneForDotNet.Blazor.Model;
using OneForDotNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace OneForDotNet.Blazor.Pages {
    public partial class Question {
        [Parameter]
        public string Id { get; set; }
        [Inject]
        public HttpClient Client { get; set; }

        private DetailContent content = new DetailContent() {
            Paragraphs = new List<string>()
        };
        protected override async Task OnParametersSetAsync() {
            var result = await Client.GetFromJsonAsync<DetailContentBase>($"http://192.168.0.211:8080/oneapi/question?id={Id}");
            if (result.Status == "OK") {
                content = result.Data;
            }
            await base.OnParametersSetAsync();
        }
    }
}
