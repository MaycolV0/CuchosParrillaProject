using System;
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

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new PedidoAgregar());
        }

        [Obsolete]
        private void BtnUrl_Clicked(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri("https://wa.me/+573046580943/?text=Hola"));
        }
    }
}