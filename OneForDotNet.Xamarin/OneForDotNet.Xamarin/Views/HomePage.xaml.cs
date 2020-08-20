using OneForDotNet.Xamarin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OneForDotNet.Xamarin.Views {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage {
        public HomePage() {
            InitializeComponent();
            this.BindingContext = new HomeViewModel();
        }

        private void cv_SizeChanged(object sender, EventArgs e) {
            
        }
    }
}