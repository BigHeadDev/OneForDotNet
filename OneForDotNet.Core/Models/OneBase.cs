using OneForDotNet.Core.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneForDotNet.Core.Models {
    public class OneBase {
        public string Href { get; set; }
        public string Vol { get; set; }
        public string Title { get; set; }
        public string Id {
            get {
                return Href.Split(new char[] { '/' }).Last();
            }
        }
    }
}
