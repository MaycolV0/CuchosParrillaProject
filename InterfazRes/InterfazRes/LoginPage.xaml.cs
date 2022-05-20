using InterfazRes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InterfazRes
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            llenarDatos();
        }

        public async void Login_Clicked(object sender, EventArgs e)
        {

            if (validarDatos())
            {
                Usuario usr = new Usuario
                {
                    NombreUsuario = EntryNombre.Text,
                    Correo = EntryCorreo.Text,
                    Telefono = EntryNumero.Text,
                };
                await App.SQLiteDB.SaveUsuarioAsync(usr);
                await DisplayAlert("Login", "Ingreso realizado correctamente (Datos registrados).", "Ok");
                LimpiarControles();
                await Navigation.PushModalAsync(new MainPage());
                llenarDatos();
            }
            else
            {
                await DisplayAlert("Advertencia", "Ingrese todos los datos", "Ok");
            }
        }

        public async void llenarDatos()
        {
            var usuariosList = await App.SQLiteDB.GetUsuariosAsync();
            if (usuariosList != null)
            {
                listUsuarios.ItemsSource = usuariosList;
            }
        }

        public bool validarDatos()
        {
            bool respuesta;
            if (string.IsNullOrEmpty(EntryNombre.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(EntryCorreo.Text))
            {
                respuesta = false;
            }
            else if(string.IsNullOrEmpty(EntryNumero.Text))
            {
                respuesta = false;
            }
            else
            {
                respuesta = true;
            }
            return respuesta;
        }

        private async void btnActualizar_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(EntryIdUsuario.Text))
            {
                Usuario usuario = new Usuario()
                {
                    IdUsuario = Convert.ToInt32(EntryIdUsuario.Text),
                    NombreUsuario = EntryNombre.Text,
                    Correo = EntryCorreo.Text,
                    Telefono = EntryNumero.Text,
                };
                await App.SQLiteDB.SaveUsuarioAsync(usuario);
                await DisplayAlert("Registro", "Se actualizo de manera exitosa", "Ok");
                LimpiarControles();
                EntryIdUsuario.IsVisible = false;
                btnActualizar.IsVisible = false;
                btnLogin.IsVisible = false;
                btnEliminar.IsVisible = false;
                Login.IsVisible = true;
                llenarDatos();
            } 
        }

        private async void listUsuarios_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var obj = (Usuario)e.SelectedItem;
            Login.IsVisible = false;
            btnLogin.IsVisible = true;
            btnActualizar.IsVisible = true;
            btnEliminar.IsVisible = true;

            if (!string.IsNullOrEmpty(obj.IdUsuario.ToString()))
            {
                var usuario = await App.SQLiteDB.GetUsuarioIdAsync(obj.IdUsuario);
                if(usuario != null)
                {
                    EntryIdUsuario.Text = usuario.IdUsuario.ToString();
                    EntryNombre.Text = usuario.NombreUsuario;
                    EntryCorreo.Text = usuario.Correo;
                    EntryNumero.Text = usuario.Telefono;
                }
            }
        }

        private async void btnLogin_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(EntryIdUsuario.Text))
            {
                Usuario usuario = new Usuario()
                {
                    IdUsuario = Convert.ToInt32(EntryIdUsuario.Text),
                    NombreUsuario = EntryNombre.Text,
                    Correo = EntryCorreo.Text,
                    Telefono = EntryNumero.Text,
                };
                await App.SQLiteDB.SaveUsuarioAsync(usuario);
                LimpiarControles();
                EntryIdUsuario.IsVisible = false;
                btnActualizar.IsVisible = false;
                btnLogin.IsVisible = false;
                btnEliminar.IsVisible = false;
                Login.IsVisible = true;
                llenarDatos();
                await Navigation.PushModalAsync(new MainPage());
            }
        }

        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            var usuario = await App.SQLiteDB.GetUsuarioIdAsync(Convert.ToInt32(EntryIdUsuario.Text));

            if (usuario != null)
            {
                await App.SQLiteDB.DeleteUsuarioAsync(usuario);
                await DisplayAlert("Advertencia", "Se elimino correctamente el usuario", "Ok");
                LimpiarControles();
                llenarDatos();
                EntryIdUsuario.IsVisible = false;
                btnActualizar.IsVisible = false;
                btnLogin.IsVisible = false;
                btnEliminar.IsVisible = false;
                Login.IsVisible = true;
            }
        }

        public void LimpiarControles()
        {
            EntryIdUsuario.Text = "";
            EntryNombre.Text = "";
            EntryCorreo.Text = "";
            EntryNumero.Text = "";
        }
    }
}