using System;
using System.Threading.Tasks;
using TaxiMobile.Contracts.Services.Other;
using TaxiMobile.Utility;
using TaxiMobile.Views;
using Xamarin.Forms;

namespace TaxiMobile
{
	public partial class App : Application
	{

		public App ()
		{
			InitializeComponent();
            
            AppContainer.RegisterDependencies();
            InitializeNavigation();
        }

        private async Task InitializeNavigation()
        {
            var navigationService = AppContainer.Resolve<INavigationService>();
            await navigationService.InitializeAsync();
        }

        protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
