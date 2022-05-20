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

        public Task<int> DeleteUsuarioAsync(Usuario usr)
        {
            return db.DeleteAsync(usr);
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
    }
}
