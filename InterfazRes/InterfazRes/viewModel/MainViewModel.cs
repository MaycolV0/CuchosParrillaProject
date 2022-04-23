using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;
using System.Text;


namespace InterfazRes.viewModel
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel()
        {
            Picks = GetPicks();
        }
        public List<Pick> Picks { get; set; }
        public ICommand OrderCommand => new Command(() => Application.Current.MainPage.Navigation.PushModalAsync(new OrderPage()));

        private List<Pick> GetPicks()
        {
            return new List<Pick>
            {
                new Pick
                {
                    Title = "Burgers", Image = "https://imgur.com/4ungu9J.png", Description = "Ordene una hamburguesa clásica o vegana!!"
                },
                new Pick
                {
                    Title = "Pollo", Image = "https://imgur.com/aWv6nPS.png", Description = "Ordene pollo asado, apanado o teriyaki!"
                },
                new Pick
                {
                    Title = "Tex-Mex", Image = "https://imgur.com/5w8iLhO.png", Description = "Ordene unos tacos!"
                },
                new Pick
                {
                    Title = "Crepes", Image = "https://imgur.com/yI3IZpT.png", Description = "Ordene un crepe!"
                }
            };
        }
    }

    public class Pick
    {
        public string Title { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }

    }

    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
