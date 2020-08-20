using GalaSoft.MvvmLight;
using OneForDotNet.Models;

namespace OneForDotNet.Xamarin.Models {
    public class HomeBase:ObservableObject {
        public string Status { get; set; }
        public long Ts { get; set; }
        public Home Data { get; set; }
    }
}
