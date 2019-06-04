using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GoodPlays
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UserLists : ContentPage
	{
		public UserLists ()
		{
			InitializeComponent ();
		}

        async void LogoutButton(object sender, EventArgs e)
        {
            App.IsUserLoggedIn = false;
            Navigation.InsertPageBefore(new UserLogin(), this);
            await Navigation.PopAsync();
        }

        async void SearchGames(object sender, EventArgs e)
        {
            Navigation.InsertPageBefore(new Search(), this);
            await Navigation.PopAsync();
        }

        async void Main(object sender, EventArgs e)
        {
            Navigation.InsertPageBefore(new MainPage(), this);
            await Navigation.PopAsync();
        }
    }
}