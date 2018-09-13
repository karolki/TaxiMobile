using System;
using Autofac;
using TaxiMobile.Contracts.Repository;
using TaxiMobile.Contracts.Services;
using TaxiMobile.Contracts.Services.Other;
using TaxiMobile.Repositories;
using TaxiMobile.Repository;
using TaxiMobile.Services;
using TaxiMobile.Services.Other;
using TaxiMobile.ViewModels;

namespace TaxiMobile.Utility
{
    public class AppContainer
    {
        private static IContainer _container;

        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            //ViewModels
            builder.RegisterType<MainViewModel>().SingleInstance() ;
            builder.RegisterType<MenuViewModel>().SingleInstance();
            builder.RegisterType<StartViewModel>().SingleInstance();
            builder.RegisterType<LoginViewModel>().SingleInstance();
            builder.RegisterType<RegisterViewModel>().SingleInstance();
            builder.RegisterType<DriverDetailViewModel>().SingleInstance();
            //services - data
            builder.RegisterType<DriverDataService>().As<IDriverDataService>().SingleInstance();
            builder.RegisterType<TaxiDataService>().As<ITaxiDataService>().SingleInstance();
            builder.RegisterType<NavigationService>().As<INavigationService>().SingleInstance();
            builder.RegisterType<DialogService>().As<IDialogService>().SingleInstance();
            builder.RegisterType<PhoneService>().As<IPhoneService>().SingleInstance();
            ////services - general
            //builder.RegisterType<Dri>().As<IConnectionService>();
            //builder.RegisterType<NavigationService>().As<INavigationService>();
            //builder.RegisterType<AuthenticationService>().As<IAuthenticationService>();
            //builder.RegisterType<DialogService>().As<IDialogService>();
            //builder.RegisterType<PhoneService>().As<IPhoneService>();
            //builder.RegisterType<SettingsService>().As<ISettingsService>().SingleInstance();

            //General
            builder.RegisterType<MockDriverRepository>().As<IDriverRepository>().SingleInstance();
            builder.RegisterType<TaxiRepository>().As<ITaxiRepository>().SingleInstance();
            builder.RegisterType<GenericRepository>().As<IGenericRepository>().SingleInstance();
            _container = builder.Build();
        }

        public static object Resolve(Type typeName)
        {
            return _container.Resolve(typeName);
        }

        public static T Resolve<T>()
        {
            return _container.Resolve<T>();
        }
    }
}
