﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace InterfazRes
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            Task.Run(RotateImage);
        }
        private async void RotateImage()
        {
            while (true)
            {
                await BannerImg.RelRotateTo(369, 10000, Easing.Linear);
            }
        }
    }
}
