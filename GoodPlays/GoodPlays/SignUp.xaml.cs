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
	public partial class SignUp : ContentPage
	{
		public SignUp ()
		{
			InitializeComponent ();
		}

        async void SignUpButton(object sender, EventArgs e)
        {
            var user = new User()
            {
                Username = entry_username.Text,
                Password = entry_password.Text,
                Email = entry_email.Text
            };

            //Add user to database

            var successSignUp = ValidDetails(user);
            if (successSignUp)
            {
                var rootPage = Navigation.NavigationStack.FirstOrDefault();
                if(rootPage != null)
                {
                    App.IsUserLoggedIn = true;
                    Navigation.InsertPageBefore(new MainPage(), Navigation.NavigationStack.First());
                    await Navigation.PopToRootAsync();
                }
                else
                {
                    label_message.Text = "Sign up failed";
                }
            }
        }

        bool ValidDetails(User user)
        {
            return (!string.IsNullOrWhiteSpace(user.Username) && !string.IsNullOrWhiteSpace(user.Password) && !string.IsNullOrWhiteSpace(user.Email) && user.Email.Contains("@"));
        }
    }
}