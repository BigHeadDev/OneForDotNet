using System;
using System.Collections.Generic;
using System.Text;

namespace OneForDotNet.Models {
    public class DetailContent {
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public List<string> Paragraphs { get; set; }
        public string Editor { get; set; }
    }
}
