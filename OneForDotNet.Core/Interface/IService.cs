using OneForDotNet.Core.Models;
using OneForDotNet.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OneForDotNet.Core.Interface {
    public interface IService {
        Task<ModelBase> GetHome();
        Task<ModelBase> GetArticle(int id);
        Task<ModelBase> GetQuestion(int id);
    }
}
