﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PasswordManager.Domain.Models;
using PasswordManager.Domain.Services.AuthenticationServices;
using PasswordManager.Domain.Services;
using PasswordManager.Domain.Services.RecordServices;
using PasswordManager.EntityFramework.Services;
using PasswordManager.WPF.State.Accounts;
using PasswordManager.WPF.State.Authenticators;
using PasswordManager.WPF.State.Navigators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using PasswordManager.WPF.State.Assets;

namespace PasswordManager.WPF.HostBuilders
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
                services.AddSingleton<RecordStore>();
            });

            return host;
        }
    }
}
