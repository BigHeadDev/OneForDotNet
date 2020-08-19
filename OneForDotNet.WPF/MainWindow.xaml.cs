using HandyControl.Controls;
using OneForDotNet.Core;
using OneForDotNet.Models;
using OneForDotNet.WPF.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OneForDotNet.WPF {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : BlurWindow {
        public MainWindow() {
            InitializeComponent();
            InitialData();
        }
        private async void InitialData() {
            var result = await CoreMethod.GetHome();
            if (result.Status == "OK") {
                var home = result.Data as Home;
                carousel.ItemsSource = home.Ones;
                carousel.PageIndex = 0;
                listArticle.ItemsSource = home.Articles;
                listQuestion.ItemsSource = home.Questions;
            }
        }

        private async void listArticle_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            var content = await CoreMethod.GetArticle(Convert.ToInt32((e.AddedItems[0] as OneArticle).Id));
            if (content.Status=="OK") {
                new DetailContentWindow(content.Data as DetailContent,"One · 文章") { Owner = this}.Show();
            }
        }

        private async void listQuestion_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            var content = await CoreMethod.GetArticle(Convert.ToInt32((e.AddedItems[0] as OneQuestion).Id));
            if (content.Status == "OK") {
                new DetailContentWindow(content.Data as DetailContent, "One · 问题").Show();
            }
        }


        private void ScrollViewer_Loaded(object sender, RoutedEventArgs e) {
            listArticle.AddHandler(MouseWheelEvent, new RoutedEventHandler(MyMouseWheel), true);
            listQuestion.AddHandler(MouseWheelEvent, new RoutedEventHandler(MyMouseWheel), true);
        }
        private void MyMouseWheel(object sender, RoutedEventArgs e) {

            MouseWheelEventArgs eargs = (MouseWheelEventArgs)e;

            double x = (double)eargs.Delta;

            double y = scroll.VerticalOffset;

            scroll.ScrollToVerticalOffset(y - x);
        }
    }
}
