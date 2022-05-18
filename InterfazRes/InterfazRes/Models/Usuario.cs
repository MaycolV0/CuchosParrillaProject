using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace InterfazRes.Models
{
    public class Usuario
    {
        [PrimaryKey, AutoIncrement]
        public int IdUsuario { get; set; }
        [MaxLength(50)]
        public string NombreUsuario { get; set; }
        [MaxLength(50)]

        public string Correo { get; set; }
        [MaxLength(50)]

        public string Telefono { get; set; }
    }
}
