using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OneForDotNet.Core;
using OneForDotNet.Core.Models;
using OneForDotNet.Models;

namespace OneForDotNet.WebAPI.Controllers {
    [Route("oneapi/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase {
        [HttpGet]
        public async Task<ModelBase> Get(int id) {
            return await CoreMethod.GetArticle(id);
        }
    }
}
