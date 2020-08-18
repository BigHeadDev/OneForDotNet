using OneForDotNet.Core;
using OneForDotNet.Models;
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
    public partial class MainWindow : Window {
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
    }
}
