using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using InterfazRes.Models;

namespace InterfazRes.Data
{
    public class SQLiteHelper
    {
        SQLiteAsyncConnection db;

        public SQLiteHelper(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync <Usuario>().Wait();
        }
    }
}
