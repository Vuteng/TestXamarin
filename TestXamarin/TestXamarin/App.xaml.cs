using Prism;

using Prism.Ioc;
using TestXamarin.ViewModels;
using TestXamarin.Views;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;

namespace TestXamarin
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
            containerRegistry.RegisterSingleton<IDatabase, Database>();
            containerRegistry.Register<ITasks, Tasks>();
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<AddNewTaskView, AddNewTaskViewModel>();
            containerRegistry.RegisterForNavigation<DetailedTaskView, DetailedTaskViewModel>();
        }

    }
}
