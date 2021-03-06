﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GoodPlays
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
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

        async void UserProfile(object sender, EventArgs e)
        {
            Navigation.InsertPageBefore(new UserLists(), this);
            await Navigation.PopAsync();
        }
    }
}
