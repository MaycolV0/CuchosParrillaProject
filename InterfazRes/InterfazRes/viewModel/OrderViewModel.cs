using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace InterfazRes.viewModel
{
    public class OrderViewModel : BaseViewModel
    {
        public OrderViewModel()
        {
            MenuList = GetMenu();
        }
        public List<Pick> MenuList { get; set; }
        //public ICommand BackCommand => new Command(() => ApplicationException.Current.MainPage.Navigation.PopAsync());

        public List<Pick> GetMenu()
        {
            return new List<Pick>
            {
                new Pick{Title="", Image="https://imgur.com/HFqbpnv.png", Description="", Price=""},
                new Pick{Title="", Image="https://imgur.com/4ungu9J.png", Description="", Price=""},
                new Pick{Title="", Image="https://imgur.com/P2zxWmU.png", Description="", Price=""},
                new Pick{Title="", Image="https://imgur.com/aWv6nPS.png", Description="", Price=""},
                new Pick{Title="", Image="https://imgur.com/AmDySlJ.png", Description="", Price=""},
                new Pick{Title="", Image="https://imgur.com/rgcnPVX.png", Description="", Price=""},
                new Pick{Title="", Image="https://imgur.com/6lwfVzv.png", Description="", Price=""},
                new Pick{Title="", Image="https://imgur.com/5w8iLhO.png", Description="", Price=""},
                new Pick{Title="", Image="https://imgur.com/yI3IZpT.png", Description="", Price=""}
            };
        }
    }
}
