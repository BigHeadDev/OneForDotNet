using OneForDotNet.Core.Models;
using OneForDotNet.Core.Service;
using OneForDotNet.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace OneForDotNet.Core {
    public static class CoreMethod {
        private static ApiService service = new ApiService();
        private static EFService efService = new EFService();
        private static DateTime updateTime;
        public static async Task<ModelBase> GetHome() {
            ModelBase home = new ModelBase();
            if (DateTime.Now.DayOfYear-updateTime.DayOfYear>0) {
                home = await service.GetHome();
                await efService.UpdateHome(home.Data as Home);
                updateTime = DateTime.Now;
            } else {
                home = await efService.GetHome();
            }
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
