using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.Wpf;
using ShibaSoft.Hydromium.Models;
using Stylet;

namespace ShibaSoft.Hydromium.ViewModels;
public class PageViewModel : Screen
{
    public IWindowManager WindowManager { get; set; }

    public string Source { get; set; }

    public PageConfig Config { get; set; }

    private IEventAggregator EventAggregator { get; }

    public PageViewModel(IEventAggregator eventAggregator)
    {
        EventAggregator = eventAggregator;
        this.PropertyChanged += PageViewModel_PropertyChanged;
        this.Config = new PageConfig();
    }

    private void PageViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        this.EventAggregator.Publish(new PageChangedEvent { PageInstanceId = this.Config.Id });
    }
}
