using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OneForDotNet.Xamarin.Helper {
    public static class HttpExtension {
        public static async Task<T> GetFromJsonAsync<T>(this HttpClient client,string url) {
            var result = await HttpGet(client,url);
            T obj = default(T);
            if (!string.IsNullOrEmpty(result)) {
                obj = JsonSerializer.Deserialize<T>(result);
            }
            return obj;
        }

        private static async Task<string> HttpGet(HttpClient client,string url) {
            string result = string.Empty;
            var response = await client.GetAsync(url);
            if (response != null) {
                if (response.IsSuccessStatusCode) {
                    result = await response.Content.ReadAsStringAsync();
                }
            }
            return result;
        }
    }
}
