using GalaSoft.MvvmLight;
using OneForDotNet.Models;

namespace OneForDotNet.Xamarin.Models {
    public class DetailContentBase :ObservableObject{
        public string Status { get; set; }
        public long Ts { get; set; }
        public DetailContent Data { get; set; }
    }
}
