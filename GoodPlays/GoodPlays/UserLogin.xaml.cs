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
	public partial class UserLogin : ContentPage
	{
		public UserLogin ()
		{
			InitializeComponent ();
		}

        async void SignUpButton(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignUp());
        }

        async void LoginButton(object sender, EventArgs e)
        {
            var user = new User
            {
                Username = entry_username.Text,
                Password = entry_password.Text
            };

            var isValid = CorrectCredentials(user);
            if (isValid)
            {
                App.IsUserLoggedIn = true;
                Navigation.InsertPageBefore(new MainPage(), this);
                await Navigation.PopAsync();
            }
            else
            {
                label_message.Text = "Login Failed";
                entry_password.Text = string.Empty;
            }
        }

        bool CorrectCredentials(User user)
        {
            return user.Username == Test.Username && user.Password == Test.Password;
        }
    }
}