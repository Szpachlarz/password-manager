using Microsoft.AspNet.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PasswordManager.Domain.Models;
using PasswordManager.Domain.Services;
using PasswordManager.Domain.Services.AuthenticationServices;
using PasswordManager.EntityFramework.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.WPF.HostBuilders
{
    public static class AddServicesHostBuilderExtensionscs
    {
        public static IHostBuilder AddServices(this IHostBuilder host)
        {
            host.ConfigureServices(services =>
            {
                services.AddSingleton<IPasswordHasher, PasswordHasher>();
                services.AddSingleton<IAuthenticationService, AuthenticationService>();
                services.AddSingleton<IDataService<UserAccount>, AccountDataService>();
                services.AddSingleton<IAccountService, AccountDataService>();
            });

            return host;
        }
    }
}
