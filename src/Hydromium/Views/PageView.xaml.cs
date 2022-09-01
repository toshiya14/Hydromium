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
using ShibaSoft.Hydromium.Events;
using Microsoft.Web.WebView2.Core;
using ShibaSoft.Hydromium.Models;
using ShibaSoft.Hydromium.ViewModels;
using Stylet;
using StyletIoC;
using Microsoft.Web.WebView2.Wpf;

namespace ShibaSoft.Hydromium.Views;
/// <summary>
/// PageView.xaml 的交互逻辑
/// </summary>
public partial class PageView : Window, IHandle<PageSourceChangedEvent>
{
    private string PageUrl { get; set; }
    private WebView2 Browser { get; set; }

    public PageView(IEventAggregator eventAggregator, IContainer container)
    {
        this.EventAggregator = eventAggregator;
        this.Container = container;
        this.Browser = new WebView2();

        InitializeComponent();
        this.RootWrap.Children.Add(this.Browser);
        this.InitializingFlag.Visibility = Visibility.Visible;

        this.Closing += PageView_Closing;
        this.Loaded += PageView_Loaded;
    }

    private async void PageView_Loaded(object sender, RoutedEventArgs e)
    {
        this.EventAggregator.Subscribe(this);

        try
        {
            var env = this.Container.Get<CoreWebView2Environment>();
            this.Browser.CoreWebView2InitializationCompleted += Browser_CoreWebView2InitializationCompleted;
            if (this.Browser.CoreWebView2 is null)
            {
                await this.Browser.EnsureCoreWebView2Async(env);
            }
        }
        catch (Exception ex)
        {
            // TODO: error handler.
            MessageBox.Show(ex.Message);
        }
    }

    private void Browser_CoreWebView2InitializationCompleted(object sender, CoreWebView2InitializationCompletedEventArgs e)
    {
        this.InitializingFlag.Visibility = Visibility.Collapsed;
        if (this.PageUrl is not null)
        {
            this.NavigateTo(this.PageUrl);
        }
    }

    private void PageView_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    {
        this.EventAggregator.Unsubscribe(this);
    }

    public IEventAggregator EventAggregator { get; }
    private IContainer Container { get; }

    public void Handle(PageSourceChangedEvent e)
    {
        var page = this.DataContext as PageViewModel;
        if (page is not null && e.InstanceId == page.Config.Id)
        {
            if (e.Url is not null)
            {
                this.NavigateTo(e.Url);
            }
        }
    }

    public void NavigateTo(string url)
    {
        if (this.PageUrl != url)
        {
            this.PageUrl = url;
            if (this.Browser.CoreWebView2 is not null)
            {
                this.Browser.CoreWebView2.Navigate(url);
            }
        }
    }
}
