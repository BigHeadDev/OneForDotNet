using System;
using System.Collections.Generic;
using System.Text;

namespace OneForDotNet.Models {
    public class Home {
        public List<One> Ones { get; set; }
        public List<OneArticle> Articles { get; set; }
        public List<OneQuestion> Questions { get; set; }
    }
}
