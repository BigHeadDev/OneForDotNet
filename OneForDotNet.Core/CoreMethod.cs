using OneForDotNet.Core.Models;
using OneForDotNet.Core.Service;
using System;
using System.Threading.Tasks;

namespace OneForDotNet.Core {
    public static class CoreMethod {
        private static ApiService service = new ApiService();
        public static async Task<ModelBase> GetHome() {
            var home = await service.GetHome();
            return home;
        }
    }
}
