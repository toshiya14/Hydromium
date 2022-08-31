using ShibaSoft.Hydromium.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShibaSoft.Hydromium.ViewModels;

public class MainViewModel
{
    public List<Tuple<PageViewModel, PageView>> Pages { get; set; } = new ();
    public void CreateView()
    {
        var window = new PageView();
        var viewmodel = new PageViewModel();
        window.Show();
        window.DataContext = viewmodel;
        this.Pages.Add(new Tuple<PageViewModel, PageView>(viewmodel, window));
    }
}
