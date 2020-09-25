using System;
using System.Collections.Generic;
using System.Text;

namespace OneForDotNet.Models {
    public class ModelBase {
        public ModelBase() {
            Ts = new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds();
        }
        public string Status { get; set; }
        public long Ts {  get; private set; }
        public string Copyright { get; set; } = "V1.0.0 By 大头，仅供学习参考";
        public Object Data { get; set; }
    }
}
