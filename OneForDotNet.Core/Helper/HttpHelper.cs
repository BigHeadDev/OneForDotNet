using OneForDotNet.Core.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OneForDotNet.Core.Helper {
    public static class HttpHelper {
        static HttpHelper() {
            client = new HttpClient();
        }

        private static HttpClient client;

        public static async Task<HttpResult> HttpGet(string url) {
            HttpResult result = new HttpResult();
            var response = await client.GetAsync(url);
            if (response!=null) {
                result.Status = response.StatusCode.ToString();
                if (response.IsSuccessStatusCode) {
                    result.Result = await response.Content.ReadAsStreamAsync();
                }
            }
            return result;
        }
    }
}
