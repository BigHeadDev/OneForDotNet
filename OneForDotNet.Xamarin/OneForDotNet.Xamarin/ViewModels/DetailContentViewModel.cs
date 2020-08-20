using GalaSoft.MvvmLight;
using OneForDotNet.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OneForDotNet.Xamarin.ViewModels {
    public class DetailContentViewModel : ViewModelBase {
        private DetailContent content;
        public DetailContent Content {
            get {
                return content;
            }
            set {
                Set(ref content, value);
            }
        }

        private string title;
        public string Title {
            get {
                return title;
            }
            set {
                Set(ref title, value);
            }
        }

        public DetailContentViewModel(DetailContent content,string titleDrec) {
            Content = content;
            Title= $"One·{titleDrec} - " + content.Title;
        }
    }
}
