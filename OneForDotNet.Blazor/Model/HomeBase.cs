using OneForDotNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneForDotNet.Blazor.Model {
    public class HomeBase {
        public string Status { get; set; }
        public long Ts { get; set; }
        public Home Data { get; set; }
    }
}
