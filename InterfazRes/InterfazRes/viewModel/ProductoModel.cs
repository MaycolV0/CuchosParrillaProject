using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace InterfazRes.viewModel
{
    public class ProductoModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string nombre = "")
        { 
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombre));
        }


        private int id;

        public int Id
        {
            get { return id; }
            set { id = value;
                OnPropertyChanged();
            }
        }

        private string nombre;
       
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Mensaje));
            }
        }

        private float precio;

        public float Precio
        {
            get { return precio; }
            set { precio = value;
                OnPropertyChanged();
                //OnPropertyChanged(nameof(NombreCompleto));
            }
        }

        private string mensaje;

        public string Mensaje
        {
            get {return $"El nombre del producto es: {Nombre}"; 
            }

        }

    }
}
