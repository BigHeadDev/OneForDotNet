using System;
using System.Collections.Generic;
using System.Text;

namespace OneForDotNet.Core.Models {
    public class ModelBase {
        public ModelBase() {
            Ts = new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds();
        }
        public string Status { get; set; }
        public long Ts { private get; set; }
        public Object Data { get; set; }
    }
}
