using Koschä.Activation;
using Koschä.Contracts.Services;
using Koschä.Core.Contracts.Services;
using Koschä.Core.Services;
using Koschä.Helpers;
using Koschä.Models;
using Koschä.Services;
using Koschä.ViewModels;
using Koschä.Views;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.UI.Xaml;

namespace Koschä;

// To learn more about WinUI 3, see https://docs.microsoft.com/windows/apps/winui/winui3/.
public partial class App : Application
{
    // The .NET Generic Host provides dependency injection, configuration, logging, and other services.
    // https://docs.microsoft.com/dotnet/core/extensions/generic-host
    // https://docs.microsoft.com/dotnet/core/extensions/dependency-injection
    // https://docs.microsoft.com/dotnet/core/extensions/configuration
    // https://docs.microsoft.com/dotnet/core/extensions/logging
    public IHost Host
    {
        get;
    }

    public static T GetService<T>()
        where T : class
    {
        if ((App.Current as App)!.Host.Services.GetService(typeof(T)) is not T service)
        {
            throw new ArgumentException($"{typeof(T)} needs to be registered in ConfigureServices within App.xaml.cs.");
        }

        return service;
    }

    public static WindowEx MainWindow { get; } = new MainWindow();

    public App()
    {
        InitializeComponent();

        Host = Microsoft.Extensions.Hosting.Host.
        CreateDefaultBuilder().
        UseContentRoot(AppContext.BaseDirectory).
        ConfigureServices((context, services) =>
        {
            // Default Activation Handler
            services.AddTransient<ActivationHandler<LaunchActivatedEventArgs>, DefaultActivationHandler>();

            // Other Activation Handlers

            // Services
            services.AddSingleton<ILocalSettingsService, LocalSettingsService>();
            services.AddSingleton<IThemeSelectorService, ThemeSelectorService>();
            services.AddTransient<INavigationViewService, NavigationViewService>();

            services.AddSingleton<IActivationService, ActivationService>();
            services.AddSingleton<IPageService, PageService>();
            services.AddSingleton<INavigationService, NavigationService>();

            // Core Services
            services.AddSingleton<ISampleDataService, SampleDataService>();
            services.AddSingleton<IFileService, FileService>();

            // Views and ViewModels
            services.AddTransient<SettingsViewModel>();
            services.AddTransient<SettingsPage>();
            services.AddTransient<KGR200500ViewModel>();
            services.AddTransient<KGR200500Page>();
            services.AddTransient<KGR480490ViewModel>();
            services.AddTransient<KGR480490Page>();
            services.AddTransient<KGR47XViewModel>();
            services.AddTransient<KGR47XPage>();
            services.AddTransient<KGR460ViewModel>();
            services.AddTransient<KGR460Page>();
            services.AddTransient<KGR450ViewModel>();
            services.AddTransient<KGR450Page>();
            services.AddTransient<KGR440ViewModel>();
            services.AddTransient<KGR440Page>();
            services.AddTransient<KGR43XViewModel>();
            services.AddTransient<KGR43XPage>();
            services.AddTransient<KGR420ViewModel>();
            services.AddTransient<KGR420Page>();
            services.AddTransient<KGR410ViewModel>();
            services.AddTransient<KGR410Page>();
            services.AddTransient<BereicheViewModel>();
            services.AddTransient<BereichePage>();
            services.AddTransient<ÜbersichtViewModel>();
            services.AddTransient<ÜbersichtPage>();
            services.AddTransient<ShellPage>();
            services.AddTransient<ShellViewModel>();

            // Configuration
            services.Configure<LocalSettingsOptions>(context.Configuration.GetSection(nameof(LocalSettingsOptions)));
        }).
        Build();

        UnhandledException += App_UnhandledException;
    }

    private void App_UnhandledException(object sender, Microsoft.UI.Xaml.UnhandledExceptionEventArgs e)
    {
        // TODO: Log and handle exceptions as appropriate.
        // https://docs.microsoft.com/windows/windows-app-sdk/api/winrt/microsoft.ui.xaml.application.unhandledexception.
    }

    protected async override void OnLaunched(LaunchActivatedEventArgs args)
    {
        base.OnLaunched(args);

        await App.GetService<IActivationService>().ActivateAsync(args);
    }
}
