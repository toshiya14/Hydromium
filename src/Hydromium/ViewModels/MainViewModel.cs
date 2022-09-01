using ShibaSoft.Hydromium.Models;
using ShibaSoft.Hydromium.Views;
using Stylet;
using StyletIoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShibaSoft.Hydromium.ViewModels;

public class MainViewModel : Screen
{
    public MainViewModel(IWindowManager wndmgr, IContainer container) {
        WindowManager = wndmgr;
        Container = container;
    }
    private List<Tuple<PageConfig, PageView>> Pages { get; set; } = new();
    private IWindowManager WindowManager { get; }
    private IContainer Container { get; }

    public void CreateView()
    {
        var page = this.Container.Get<PageViewModel>();
        WindowManager.ShowWindow(page);
        page.Source = "https://bilibili.com";
    }
}
