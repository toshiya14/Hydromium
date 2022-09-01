using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using ShibaSoft.Hydromium.Events;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.Wpf;
using ShibaSoft.Hydromium.Models;
using Stylet;

namespace ShibaSoft.Hydromium.ViewModels;
public class PageViewModel : Screen
{
    public IWindowManager WindowManager { get; set; }

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
        if (e.PropertyName == nameof(this.Config))
        {
            this.EventAggregator.Publish(new PageSourceChangedEvent { InstanceId = this.Config.Id, Url = this.Config.PageUrl });
        }
    }
}
