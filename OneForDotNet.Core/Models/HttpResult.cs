using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OneForDotNet.Core.Models {
    public class HttpResult {
        public string Status { get; set; } = "404";
        public Stream Result { get; set; }
    }
}
