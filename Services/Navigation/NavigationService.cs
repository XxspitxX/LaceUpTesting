using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaceUpTesting.Services.Navigation
{
    public class MauiNavigationService : INavigationService
    {

        public MauiNavigationService()
        {
        }

        public Task InitializeAsync() =>
            NavigateToAsync("//Main/Catalog");

        public Task NavigateToAsync(string route, IDictionary<string, object> routeParameters = null)
        {
            var shellNavigation = new ShellNavigationState(route);

            return routeParameters != null
                ? Shell.Current.GoToAsync(shellNavigation, routeParameters)
                : Shell.Current.GoToAsync(shellNavigation);
        }

        public Task PopAsync() =>
            Shell.Current.GoToAsync("..");
    }
}
