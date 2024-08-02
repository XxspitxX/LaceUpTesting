using LaceUpTesting.Services.AppEnvironmentService;
using LaceUpTesting.Services.Navigation;

namespace LaceUpTesting
{
    public partial class App : Application
    {
        private readonly INavigationService _navigationService;
        private readonly IAppEnvironmentService _appEnvironmentService;
        public App(INavigationService navigationService, IAppEnvironmentService appEnvironmentService)
        {

            _navigationService = navigationService;
            _appEnvironmentService = appEnvironmentService;

            InitializeComponent();
            InitApp();
            MainPage = new AppShell(navigationService);
        }

        private void InitApp()
        {
          _appEnvironmentService.UpdateDependencies();
        }
    }
}
