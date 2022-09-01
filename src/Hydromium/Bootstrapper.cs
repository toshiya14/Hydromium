using ShibaSoft.Hydromium.Views;
using ShibaSoft.Hydromium.ViewModels;
using Stylet;
using StyletIoC;
using Microsoft.Web.WebView2.Core;
using System;
using System.IO;

namespace ShibaSoft.Hydromium;

public class Bootstrapper : Bootstrapper<MainViewModel>
{
    protected override void ConfigureIoC(IStyletIoCBuilder builder)
    {
        var appDataRootPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        var appDataPath = Path.Combine(appDataRootPath, "ShibaSoft", "Hydromium");
        var browserUserDataPath = Path.Combine(appDataPath, "UserProfiles");

        // Configure the IoC container in here
        builder.Bind<CoreWebView2Environment>()
            .ToInstance(
                CoreWebView2Environment.CreateAsync(
                    browserExecutableFolder: Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "WebView2"),
                    userDataFolder: browserUserDataPath
                ).Result
            );
    }

    protected override void Configure()
    {
        // Perform any other configuration before the application starts
    }
}
