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
                new Pick{Title="Camarones", Image="https://imgur.com/HFqbpnv.png", Description="Camarones apanados con salsa de la casa. ", Price="13,900"},
                new Pick{Title="Hamburguesa Clásica", Image="https://imgur.com/4ungu9J.png", Description="Pan brioche con sésamo, carne de 100g...", Price="13,900"},
                new Pick{Title="Hamburguesa Clásica #2", Image="https://imgur.com/P2zxWmU.png", Description="Queso americano, lechuga, carne de 80g...", Price="15,900"},
                new Pick{Title="Pollo Apanado", Image="https://imgur.com/aWv6nPS.png", Description="Pollo apanado, gaseosa y papas a la francesa.", Price="10,900"},
                new Pick{Title="Pollo Apanado #2", Image="https://imgur.com/AmDySlJ.png", Description="Pollo apanado, papas a la francesa.", Price="8,000"},
                new Pick{Title="Salchichas", Image="https://imgur.com/rgcnPVX.png", Description="Salchichas, papas a la francesa.", Price="8,000"},
                new Pick{Title="Taco Ensalada", Image="https://imgur.com/6lwfVzv.png", Description="Base de tortilla de maíz, tomáte, queso...", Price="9,900"},
                new Pick{Title="Tacos", Image="https://imgur.com/5w8iLhO.png", Description="Tortillas de maíz crocante, con trozos de pollo y carne...", Price="18,900"},
                new Pick{Title="Crepe", Image="https://imgur.com/yI3IZpT.png", Description="Fresas, durazno, mango, crema chantilly.", Price="13,900"}
            };
        }
    }
}
