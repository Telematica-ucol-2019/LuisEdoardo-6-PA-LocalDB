using DemoSQLite.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoSQLite.Repositories
{
    public class FechaPublicacionRepos
    {
        SQLiteConnection connection;
        public FechaPublicacionRepos()
        {
            connection = new SQLiteConnection(Constants.Constants.DatabasePath, Constants.Constants.Flags);
            connection.CreateTable<FechaPublicacion>();
        }

        public void Init()
        {
            connection.CreateTable<FechaPublicacion>();
        }
        public void InsertOrUpdate(FechaPublicacion publi)
        {
            if (publi.Id == 0)
            {

                connection.Insert(publi);

            }
            else
            {

                connection.Update(publi);

            }
        }

        public FechaPublicacion GetById(int Id)
        {
            return connection.Table<FechaPublicacion>().FirstOrDefault(item => item.Id == Id);
        }

        public List<FechaPublicacion> GetAll()
        {

            return connection.Table<FechaPublicacion>().ToList();
        }


        public void DeleteItem(int Id)
        {
            FechaPublicacion publi = GetById(Id);
            connection.Delete(publi);
        }
    }
}
