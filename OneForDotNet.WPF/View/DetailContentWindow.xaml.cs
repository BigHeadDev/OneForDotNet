using HandyControl.Controls;
using OneForDotNet.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace OneForDotNet.WPF.View {
    /// <summary>
    /// DetailContentWindow.xaml 的交互逻辑
    /// </summary>
    public partial class DetailContentWindow : BlurWindow {
        public DetailContentWindow(DetailContent content,string titleDrect) {
            InitializeComponent();
            txtTitle.Text = content.Title;
            this.Title = titleDrect +" - "+ content.Title;
            txtSubTitle.Text = content.Subtitle;
            content.Paragraphs.ForEach(s => {
                Run myRun = new Run(s);
                document.Blocks.Add(new Paragraph(myRun));
            });
            document.Blocks.Add(new Paragraph(new Run(content.Editor)));
        }
    }
}
