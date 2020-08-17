using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OneForDotNet.Core;
using OneForDotNet.Core.Models;
using OneForDotNet.Models;

namespace OneForDotNet.WebAPI.Controllers {
    [Route("oneapi/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase {
        [HttpGet]
        public async Task<ModelBase> Get() {
            return await CoreMethod.GetHome();
        }
    }
}
