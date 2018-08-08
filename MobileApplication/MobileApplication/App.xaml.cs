using Prism;
using Prism.Ioc;
using MobileApplication.ViewModels;
using MobileApplication.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prism.Unity;
using MobileApplication.DependencyInjection;
using MobileApplication.Abstractions.VersionInfoService;
using MobileApplication.Abstractions.VersionInfo;
using MobileApplication.VersionInfoAndroid.VersionInfo;
using MobileApplication.Infrastructure.Repositories;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MobileApplication
{
    public partial class App : PrismApplication
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage>();
            containerRegistry.RegisterSingleton<IVersionInfoRepository<VersionInfo>, AndoidVersionInfoRepository>();
            containerRegistry.RegisterSingleton<IVersionInfoService<IVersionInfo>, VersionInfoService>();
            containerRegistry.RegisterSingleton<IReadOnlyVersionInfoService<IVersionInfo>, VersionInfoService>();
        }
    }
}
