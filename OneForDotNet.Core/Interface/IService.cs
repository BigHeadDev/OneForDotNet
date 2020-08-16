using OneForDotNet.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OneForDotNet.Core.Interface {
    public interface IService {
        Task<ModelBase> GetHome();
    }
}
