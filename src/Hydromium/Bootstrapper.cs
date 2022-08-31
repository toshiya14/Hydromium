using ShibaSoft.Hydromium.Views;
using ShibaSoft.Hydromium.ViewModels;
using Stylet;
using StyletIoC;

namespace ShibaSoft.Hydromium;

public class Bootstrapper : Bootstrapper<MainViewModel>
{
    protected override void ConfigureIoC(IStyletIoCBuilder builder)
    {
        // Configure the IoC container in here
    }

    protected override void Configure()
    {
        // Perform any other configuration before the application starts
    }
}
