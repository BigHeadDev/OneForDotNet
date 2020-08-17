using OneForDotNet.Core.Models;
using OneForDotNet.Core.Service;
using OneForDotNet.Models;
using System;
using System.Threading.Tasks;

namespace OneForDotNet.Core {
    public static class CoreMethod {
        private static ApiService service = new ApiService();
        public static async Task<ModelBase> GetHome() {
            var home = await service.GetHome();
            return home;
        }

        public static async Task<ModelBase> GetArticle(int id) {
            var artcile = await service.GetArticle(id);
            return artcile;
        }

        public static async Task<ModelBase> GetQuestion(int id) {
            var question = await service.GetQuestion(id);
            return question;
        }
    }
}
