using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using OneForDotNet.Models;
using OneForDotNet.Xamarin.Helper;
using OneForDotNet.Xamarin.Models;
using OneForDotNet.Xamarin.Views;
using System;
using System.Net.Http;
using Xamarin.Forms;

namespace OneForDotNet.Xamarin.ViewModels {
    public class HomeViewModel :ViewModelBase{
        public HomeViewModel() {
            InitialData();
        }
        private HttpClient client = new HttpClient();
        private int offset = 1;
        private int carouselPosition=0;
        public int CarouselPosition {
            get {
                return carouselPosition;
            }
            set {
                Set(ref carouselPosition, value);
            }
        }

        private Home home;
        public Home Home {
            get {
                return home;
            }
            set {
                Set(ref home, value);
            }
        }



        private string title = "主页";
        public string Title {
            get { return title; }
            set { Set(ref title, value); }
        }
        private RelayCommand<ItemTappedEventArgs> articleSelectedCommand = null;
        public RelayCommand<ItemTappedEventArgs> ArticleSelectedCommand {
            get {
                return articleSelectedCommand ?? new RelayCommand<ItemTappedEventArgs>(async (args) => {
                    var content = await client.GetFromJsonAsync<DetailContentBase>(Config.Url.GetArticleUrl((args.Item as OneArticle).Id));
                    if (content.Status=="OK") {
                        DetailContentViewModel vm = new DetailContentViewModel(content.Data,"文章");
                        await App.GlobalNavigation.PushAsync(new DetialContentPage(vm));
                    }
                });
            }
        }
        private RelayCommand<ItemTappedEventArgs> questionSelectedCommand = null;
        public RelayCommand<ItemTappedEventArgs> QuestionSelectedCommand {
            get {
                return questionSelectedCommand ?? new RelayCommand<ItemTappedEventArgs>(async (args) => {
                    var content = await client.GetFromJsonAsync<DetailContentBase>(Config.Url.GetQuestionUrl((args.Item as OneQuestion).Id));
                    if (content.Status == "OK") {
                        DetailContentViewModel vm = new DetailContentViewModel(content.Data, "问题");
                        await App.GlobalNavigation.PushAsync(new DetialContentPage(vm));
                    }
                });
            }
        }

        private async void InitialData() {
            var result = await client.GetFromJsonAsync<HomeBase>(Config.Url.Home);
            if (result.Status=="OK") {
                Home = result.Data;
            }
            Device.StartTimer(TimeSpan.FromSeconds(5), (Func<bool>)(() => {
                if (CarouselPosition == 0) {
                    offset = 1;
                } else if (CarouselPosition == Home.Ones.Count - 1) {
                    offset = -offset;
                }
                CarouselPosition += offset;
                return true;
            }));
        }
    }
}
