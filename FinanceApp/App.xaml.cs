using FinanceApp.ViewModels;
using FinanceApp.Views;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Prism;
using Prism.Ioc;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;

namespace FinanceApp
{
    public partial class App
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

       
            await NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<PostPage, PostPageViewModel>();
        }

        protected async override void OnStart()
        {
            base.OnStart();

            string androidAppSecret = "a96940b8-abc3-441a-af4e-0398931021dd";
            //  string iOSAppSecret = "";

            AppCenter.Start($"android={androidAppSecret}", typeof(Crashes), typeof(Analytics));

            bool didAppCrashed = await Crashes.HasCrashedInLastSessionAsync();

            if(didAppCrashed)
            {
                var crashReport = await Crashes.GetLastSessionCrashReportAsync();

            }


            //throw (new System.Exception("app_crashed"));

        }
    }
}
