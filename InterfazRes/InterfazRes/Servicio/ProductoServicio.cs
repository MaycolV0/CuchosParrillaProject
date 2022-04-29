using InterfazRes.viewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace InterfazRes.Servicio
{
    public class ProductoServicio
    {
        public ObservableCollection<ProductoServicio> productos
        {
            get;
            set;
        }

        public ProductoServicio()
        {
            if (this.productos == null)
            { 
                productos = new ObservableCollection<ProductoModel>();
            }
        }

        public ObservableCollection<ProductoModel> consultar()
        {
            return productos;
        }

        public void Guardar(ProductoModel modelo)
        {
            productos.Add(modelo);
        }

        public void Modificar(ProductoModel modelo)
        {
            for (int i = 0; i < productos.Count; i++)
            {
                if (productos [i].Id == modelo.Id)
                {
                    productos[i] = modelo;
                }
            }
        }

        public void Eliminar(string idProducto)
        {
            ProductoModel modelo = productos.FirstOrDefault(p => p.Id == idProducto);
            productos.Remove(modelo);
        }

        public static implicit operator ProductoServicio(ProductoModel v)
        {
            throw new NotImplementedException();
        }
    }
}
