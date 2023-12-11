using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PasswordManager.Domain.Services.RecordServices;
using PasswordManager.WPF.State.Accounts;
using PasswordManager.WPF.State.Authenticators;
using PasswordManager.WPF.State.Navigators;
using PasswordManager.WPF.ViewModels;
using PasswordManager.WPF.ViewModels.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordManager.Domain.Models;

namespace PasswordManager.WPF.HostBuilders
{
    public static class AddViewModelsHostBuilderExtensions
    {
        public static IHostBuilder AddViewModels(this IHostBuilder host)
        {
            host.ConfigureServices(services =>
            {
                //services.AddTransient(CreateHomeViewModel);
                services.AddTransient<MainViewModel>();

                services.AddSingleton<CreateViewModel<UserPanelViewModel>>(services => () => CreateUserPanelViewModel(services));
                services.AddSingleton<CreateViewModel<LoginViewModel>>(services => () => CreateLoginViewModel(services));
                services.AddSingleton<CreateViewModel<RegisterViewModel>>(services => () => CreateRegisterViewModel(services));
                services.AddSingleton<CreateViewModel<AddRecordViewModel>>(services => () => CreateAddRecordViewModel(services));
                services.AddSingleton<CreateViewModel<EditRecordViewModel>>(services => () => CreateEditRecordViewModel(services));
                services.AddSingleton<CreateViewModel<TagsViewModel>>(services => () => CreateTagsViewModel(services));

                services.AddSingleton<IViewModelFactory, ViewModelFactory>();

                services.AddSingleton<ViewModelDelegateRenavigator<UserPanelViewModel>>();
                services.AddSingleton<ViewModelDelegateRenavigator<AddRecordViewModel>>();
                services.AddSingleton<ViewModelDelegateRenavigator<EditRecordViewModel>>();
                services.AddSingleton<ViewModelDelegateRenavigator<LoginViewModel>>();
                services.AddSingleton<ViewModelDelegateRenavigator<RegisterViewModel>>();
                services.AddSingleton<ViewModelDelegateRenavigator<TagsViewModel>>();
            });

            return host;
        }

        private static AddRecordViewModel CreateAddRecordViewModel(IServiceProvider services)
        {
            return new AddRecordViewModel(
                //services.GetRequiredService<RecordFormViewModel>(),
                services.GetRequiredService<IAccountStore>(),
                services.GetRequiredService<IRecordService>(),
                services.GetRequiredService<ViewModelDelegateRenavigator<UserPanelViewModel>>());
        }
        private static EditRecordViewModel CreateEditRecordViewModel(IServiceProvider services)
        {
            return new EditRecordViewModel(
                //services.GetRequiredService<RecordFormViewModel>(),
                services.GetRequiredService<IAccountStore>(),
                services.GetRequiredService<IRecordService>(),
                services.GetRequiredService<ViewModelDelegateRenavigator<UserPanelViewModel>>());
        }
        
        private static UserPanelViewModel CreateUserPanelViewModel(IServiceProvider services)
        {
            return new UserPanelViewModel(                
                services.GetRequiredService<ViewModelDelegateRenavigator<AddRecordViewModel>>(),
                services.GetRequiredService<ViewModelDelegateRenavigator<EditRecordViewModel>>(),
                services.GetRequiredService<IRecordService>(),
                services.GetRequiredService<IAccountStore>(),
                services.GetRequiredService<IAuthenticator>(),
                services.GetRequiredService<ViewModelDelegateRenavigator<LoginViewModel>>());
        }

        private static TagsViewModel CreateTagsViewModel(IServiceProvider services)
        {
            return new TagsViewModel(
                services.GetRequiredService<ViewModelDelegateRenavigator<UserPanelViewModel>>());
        }

        private static LoginViewModel CreateLoginViewModel(IServiceProvider services)
        {
            return new LoginViewModel(
                services.GetRequiredService<IAuthenticator>(),
                services.GetRequiredService<ViewModelDelegateRenavigator<UserPanelViewModel>>(),
                services.GetRequiredService<ViewModelDelegateRenavigator<RegisterViewModel>>());
        }

        private static RegisterViewModel CreateRegisterViewModel(IServiceProvider services)
        {
            return new RegisterViewModel(
                services.GetRequiredService<IAuthenticator>(),
                services.GetRequiredService<ViewModelDelegateRenavigator<LoginViewModel>>(),
                services.GetRequiredService<ViewModelDelegateRenavigator<LoginViewModel>>());
        }
    }
}
