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
    private IWindowManager WindowManager { get; }
    private IContainer Container { get; }

    public void CreateView()
    {
        var page = this.Container.Get<PageViewModel>();
        WindowManager.ShowWindow(page);
        page.Config = page.Config with { PageUrl = "https://bilibili.com" };
    }
}
