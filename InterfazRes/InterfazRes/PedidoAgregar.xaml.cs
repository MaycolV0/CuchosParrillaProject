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
    public partial class PedidoAgregar : ContentPage
    {
        public PedidoAgregar()
        {
            InitializeComponent();
            llenarDatos();
        }

        public async void llenarDatos()
        {
            var productoList = await App.SQLiteDB.GetProductoAsync();
            if (productoList != null)
            {
                listProductos.ItemsSource = productoList;
            }
        }

        private async void btnActualizar_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(EntryIdProducto.Text))
            {
                Producto producto = new Producto()
                {
                    IdProducto = Convert.ToInt32(EntryIdProducto.Text),
                    DireccionDomicilio = EntryDireccion.Text,
                    Devuelta = EntryDevuelta.Text,
                    NombreProducto = nombreComida.Items[nombreComida.SelectedIndex],
                    NombreBebida = nombreBebida.Items[nombreBebida.SelectedIndex],
                };
                await App.SQLiteDB.SaveProductoAsync(producto);
                await DisplayAlert("Registro", "Se actualizo de manera exitosa", "Ok");
                LimpiarControles();
                EntryIdProducto.IsVisible = false;
                btnActualizar.IsVisible = false;
                btnEliminar.IsVisible = false;
                Registrar.IsVisible = true;
                llenarDatos();
            }
        }

        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            var producto = await App.SQLiteDB.GetProductoIdAsync(Convert.ToInt32(EntryIdProducto.Text));

            if (producto != null)
            {
                await App.SQLiteDB.DeleteProductoAsync(producto);
                await DisplayAlert("Advertencia", "Se elimino correctamente el producto", "Ok");
                LimpiarControles();
                llenarDatos();
                EntryIdProducto.IsVisible = false;
                btnActualizar.IsVisible = false;
                btnEliminar.IsVisible = false;
                Registrar.IsVisible = true;
            }
        }

        private async void Registrar_Clicked(object sender, EventArgs e)
        {
            if (validarDatos())
            {
                Producto producto = new Producto
                {
                    DireccionDomicilio = EntryDireccion.Text,
                    Devuelta = EntryDevuelta.Text,
                    NombreProducto = nombreComida.Items[nombreComida.SelectedIndex],
                    NombreBebida = nombreBebida.Items[nombreBebida.SelectedIndex],
                };
                await App.SQLiteDB.SaveProductoAsync(producto);
                await DisplayAlert("Compra", "Producto registrado correctamente.", "Ok");
                LimpiarControles();
                llenarDatos();
            }
            else
            {
                await DisplayAlert("Advertencia", "Ingrese todos los datos", "Ok");
            }
        }
        public bool validarDatos()
        {
            bool respuesta;
            if (string.IsNullOrEmpty(EntryDireccion.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(EntryDevuelta.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(nombreComida.Items[nombreComida.SelectedIndex]))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(nombreBebida.Items[nombreBebida.SelectedIndex]))
            {
                respuesta = false;
            }
            else
            {
                respuesta = true;
            }
            return respuesta;
        }

        private async void listProductos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var obj = (Producto)e.SelectedItem;
            Registrar.IsVisible = false;
            btnActualizar.IsVisible = true;
            btnEliminar.IsVisible = true;

            if (!string.IsNullOrEmpty(obj.IdProducto.ToString()))
            {
                var producto = await App.SQLiteDB.GetProductoIdAsync(obj.IdProducto);
                if (producto != null)
                {
                    EntryIdProducto.Text = producto.IdProducto.ToString();
                    EntryDevuelta.Text = producto.Devuelta.ToString();
                    EntryDireccion.Text = producto.DireccionDomicilio;
                    nombreComida.SelectedItem = producto.NombreProducto;
                    nombreBebida.SelectedItem = producto.NombreBebida;
                }
            }
        }
        public void LimpiarControles()
        {
            EntryIdProducto.Text = "";
            EntryDireccion.Text = "";
            EntryDevuelta.Text = "";
            nombreComida.SelectedItem = "Selecciona tu Comida";
            nombreBebida.SelectedItem = "Selecciona tu Bebida";
        }

    }
}