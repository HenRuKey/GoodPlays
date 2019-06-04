using GoodPlaysLib.models;
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
	public partial class Search : ContentPage
	{
		public Search ()
		{
			InitializeComponent ();
            BindingContext = new SearchPageViewModel();
		}
        async void LogoutButton(object sender, EventArgs e)
        {
            App.IsUserLoggedIn = false;
            Navigation.InsertPageBefore(new UserLogin(), this);
            await Navigation.PopAsync();
        }

        async void Main(object sender, EventArgs e)
        {
            Navigation.InsertPageBefore(new MainPage(), this);
            await Navigation.PopAsync();
        }

        async void UserProfile(object sender, EventArgs e)
        {
            Navigation.InsertPageBefore(new UserLists(), this);
            await Navigation.PopAsync();
        }

        private void ListItemTapped(object sender, ItemTappedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
        }

        async void ListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (((ListView)sender).SelectedItem is Game game)
            {
                var page = new GameDetails
                {
                    BindingContext = game
                };
                await Navigation.PushAsync(page);
            }
        }
    }
}