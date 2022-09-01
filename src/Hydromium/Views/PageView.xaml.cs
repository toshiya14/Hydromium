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
using Microsoft.Web.WebView2.Core;
using ShibaSoft.Hydromium.Models;
using ShibaSoft.Hydromium.ViewModels;
using Stylet;

namespace ShibaSoft.Hydromium.Views;
/// <summary>
/// PageView.xaml 的交互逻辑
/// </summary>
public partial class PageView : Window, IHandle<PageChangedEvent>
{
    public PageView(IEventAggregator eventAggregator)
    {
        InitializeComponent();
        eventAggregator.Subscribe(this);
    }


    public void Handle(PageChangedEvent e)
    {
        var page = this.DataContext as PageViewModel;
        if (page is not null && page.Config.Id == e.PageInstanceId)
        {
            if (page.Source is not null) {
                this.NavigateTo(page.Source);
            }
        }
    }

    public async void NavigateTo(string url)
    {
        if (this.Browser.CoreWebView2 is null)
        {
            var env = await CoreWebView2Environment.CreateAsync(
                userDataFolder: ""
            );
            await this.Browser.EnsureCoreWebView2Async(env);
        }
        this.Browser.CoreWebView2.Navigate(url);
    }
}
