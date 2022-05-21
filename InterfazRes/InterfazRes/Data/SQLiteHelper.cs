using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using InterfazRes.Models;
using System.Threading.Tasks;

namespace InterfazRes.Data
{
    public class SQLiteHelper
    {
        SQLiteAsyncConnection db;

        public SQLiteHelper(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<Usuario>().Wait();
            db.CreateTableAsync<Producto>().Wait();
        }

        public Task<int> SaveUsuarioAsync(Usuario usr)
        {
            if (usr.IdUsuario != 0)
            {
                return db.UpdateAsync(usr);
            }
            else
            {
                return db.InsertAsync(usr);
            }
        }

        public Task<int> SaveProductoAsync(Producto producto)
        {
            if (producto.IdProducto != 0)
            {
                return db.UpdateAsync(producto);
            }
            else
            {
                return db.InsertAsync(producto);
            }
        }

        public Task<int> DeleteUsuarioAsync(Usuario usr)
        {
            return db.DeleteAsync(usr);
        }
        public Task<int> DeleteProductoAsync(Producto producto)
        {
            return db.DeleteAsync(producto);
        }

        /// <summary>
        /// Recuperar todos los alumnos
        /// </summary>
        /// <returns></returns>
        public Task<List<Usuario>> GetUsuariosAsync()
        {
            return db.Table<Usuario>().ToListAsync();
        }
        /// <summary>
        /// Recupera alumnos por id
        /// </summary>
        /// <param name="IdUsuario">id del alumno que se requiere</param>
        /// <returns></returns>
        public Task<Usuario> GetUsuarioIdAsync(int IdUsuario)
        {
            return db.Table<Usuario>().Where(a => a.IdUsuario == IdUsuario).FirstOrDefaultAsync();
        }

        public Task<List<Producto>> GetProductoAsync()
        {
            return db.Table<Producto>().ToListAsync();
        }

        public Task<Producto> GetProductoIdAsync(int IdProducto)
        {
            return db.Table<Producto>().Where(a => a.IdProducto == IdProducto).FirstOrDefaultAsync();
        }
    }
}
