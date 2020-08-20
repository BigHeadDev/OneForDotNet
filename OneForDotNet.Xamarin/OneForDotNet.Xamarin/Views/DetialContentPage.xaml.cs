using OneForDotNet.Models;
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
    public partial class DetialContentPage : ContentPage {
        public DetialContentPage(DetailContentViewModel vm) {
            InitializeComponent();
            this.BindingContext = vm;
            strings.FormattedText = new FormattedString();
            foreach (var para in vm.Content.Paragraphs) {
                strings.FormattedText.Spans.Add(new Span() { Text = para+ "\r\n\r\n", FontSize=20,CharacterSpacing=2});
            }
        }
    }
}