using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using password_manager.WPF.State.Accounts;
using password_manager.WPF.State.Authenticators;
using password_manager.WPF.State.Navigators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace password_manager.WPF.HostBuilders
{
    public static class AddStoresHostBuilderExtensions
    {
        public static IHostBuilder AddStores(this IHostBuilder host)
        {
            host.ConfigureServices(services =>
            {
                services.AddSingleton<INavigator, Navigator>();
                services.AddSingleton<IAuthenticator, Authenticator>();
                services.AddSingleton<IAccountStore, AccountStore>();
            });

            return host;
        }
    }
}
