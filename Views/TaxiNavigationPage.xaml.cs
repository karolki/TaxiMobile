using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TaxiMobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TaxiNavigationPage : NavigationPage
	{
		public TaxiNavigationPage ()
		{
			InitializeComponent ();
		}

        public TaxiNavigationPage(Page root) : base(root)
        {
            InitializeComponent();
        }
    }
}