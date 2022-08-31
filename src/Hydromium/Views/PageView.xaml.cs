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
using System.Windows.Shapes;

namespace ShibaSoft.Hydromium.Views;
/// <summary>
/// PageView.xaml 的交互逻辑
/// </summary>
public partial class PageView : Window
{
    public PageView()
    {
        InitializeComponent();
        this.Browser.NavigationCompleted += Browser_NavigationCompleted;
    }

    private void Browser_NavigationCompleted(object sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs e)
    {
        this.Browser.UpdateWindowPos();
    }
}
