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
                new Pick{Title="", Image="IMG01.png", Description="", Price=""},
                new Pick{Title="", Image="IMG04.png", Description="", Price=""},
                new Pick{Title="", Image="IMG05.png", Description="", Price=""}
            };
        }
    }
}
