using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaxiMobile.Contracts.Services;
using TaxiMobile.Contracts.Services.Other;
using TaxiMobile.Utility;
using TaxiMobile.ViewModels;
using TaxiMobile.Views;
using Xamarin.Forms;

namespace TaxiMobile.Services.Other
{
    public class NavigationService : INavigationService
    { 
    private readonly IDriverDataService _driverDataService;
    private readonly Dictionary<Type, Type> _mappings;

    protected Application CurrentApplication => Application.Current;

    public NavigationService(IDriverDataService driverDataService)
    {
        _driverDataService = driverDataService;
        _mappings = new Dictionary<Type, Type>();

        CreatePageViewModelMappings();
    }

    public async Task InitializeAsync()
    {
            await NavigateToAsync<StartViewModel>();
    }

    public Task NavigateToAsync<TViewModel>() where TViewModel : BaseViewModel
    {
        return InternalNavigateToAsync(typeof(TViewModel), null);
    }

    public Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : BaseViewModel
        {
        return InternalNavigateToAsync(typeof(TViewModel), parameter);
    }

    public Task NavigateToAsync(Type viewModelType)
    {
        return InternalNavigateToAsync(viewModelType, null);
    }

    public async Task ClearBackStack()
    {
        await CurrentApplication.MainPage.Navigation.PopToRootAsync();
    }

    public Task NavigateToAsync(Type viewModelType, object parameter)
    {
        return InternalNavigateToAsync(viewModelType, parameter);
    }

    public async Task NavigateBackAsync()
    {
        if (CurrentApplication.MainPage is StartView mainPage)
        {
            await mainPage.Detail.Navigation.PopAsync();
        }
        else if (CurrentApplication.MainPage != null)
        {
            await CurrentApplication.MainPage.Navigation.PopAsync();
        }
    }

    public virtual Task RemoveLastFromBackStackAsync()
    {
        if (CurrentApplication.MainPage is StartView mainPage)
        {
            mainPage.Detail.Navigation.RemovePage(
                mainPage.Detail.Navigation.NavigationStack[mainPage.Detail.Navigation.NavigationStack.Count - 2]);
        }

        return Task.FromResult(true);
    }

    public async Task PopToRootAsync()
    {
        if (CurrentApplication.MainPage is StartView mainPage)
        {
            await mainPage.Detail.Navigation.PopToRootAsync();
        }
    }

    protected virtual async Task InternalNavigateToAsync(Type viewModelType, object parameter)
    {
        Page page = CreateAndBindPage(viewModelType, parameter);

        if (page is StartView)
        {
            CurrentApplication.MainPage = page;
        }
            else if (CurrentApplication.MainPage is StartView)
        {
            var mainPage = CurrentApplication.MainPage as StartView;

            if (mainPage.Detail is TaxiNavigationPage navigationPage)
            {
                var currentPage = navigationPage.CurrentPage;

                if (currentPage.GetType() != page.GetType())
                {
                    await navigationPage.PushAsync(page);
                }
            }
            else
            {
                navigationPage = new TaxiNavigationPage(page);
                mainPage.Detail = navigationPage;
            }

            mainPage.IsPresented = false;
        }
        else
        {
            var navigationPage = CurrentApplication.MainPage as TaxiNavigationPage;

            if (navigationPage != null)
            {
                await navigationPage.PushAsync(page);
            }
            else
            {
                CurrentApplication.MainPage = new TaxiNavigationPage(page);
            }
        }

        await (page.BindingContext as BaseViewModel).InitializeAsync(parameter);
    }

        protected Type GetPageTypeForViewModel(Type viewModelType)
        {
            if (!_mappings.ContainsKey(viewModelType))
            {
                throw new KeyNotFoundException($"No map for ${viewModelType} was found on navigation mappings");
            }

            return _mappings[viewModelType];
        }

        protected Page CreateAndBindPage(Type viewModelType, object parameter)
        {
            Type pageType = GetPageTypeForViewModel(viewModelType);

            if (pageType == null)
            {
                throw new Exception($"Mapping type for {viewModelType} is not a page");
            }
            Page page = Activator.CreateInstance(pageType) as Page;
            BaseViewModel viewModel = AppContainer.Resolve(viewModelType) as BaseViewModel;
            page.BindingContext = viewModel;

            return page;
        }

        private void CreatePageViewModelMappings()
        {
            _mappings.Add(typeof(LoginViewModel), typeof(LoginView));
            _mappings.Add(typeof(MainViewModel), typeof(MainView));
            _mappings.Add(typeof(MenuViewModel), typeof(MenuView));
            _mappings.Add(typeof(StartViewModel), typeof(StartView));
            _mappings.Add(typeof(RegisterViewModel), typeof(RegisterView));
            _mappings.Add(typeof(DriverDetailViewModel), typeof(DriverDetailView));
        }
    }
}
