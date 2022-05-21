using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace InterfazRes.Models
{
    public class Producto
    {
        [PrimaryKey, AutoIncrement]
        public int IdProducto { get; set; }
        [MaxLength(50)]
        public string DireccionDomicilio { get; set; }
        [MaxLength(50)]
        public string Devuelta { get; set; }
        [MaxLength(50)]
        public string NombreProducto { get; set; }
        [MaxLength(50)]
        public string NombreBebida { get; set; }
    }
}
