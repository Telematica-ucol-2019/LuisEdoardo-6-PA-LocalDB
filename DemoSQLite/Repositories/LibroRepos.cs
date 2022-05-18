using DemoSQLite.Model;
using SQLite;
using SQLiteNetExtensions.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace DemoSQLite.Repositories
{
    public class LibroRepos
    {
        SQLiteConnection connection;
        public LibroRepos()
        {
            connection = new SQLiteConnection(Constants.Constants.DatabasePath, Constants.Constants.Flags);
            connection.CreateTable<Libro>();
        }

        public void Init()
        {
            connection.CreateTable<Libro>();
        }
        public void InsertOrUpdate(Libro libro)
        {
            if (libro.Id == 0)
            {
                Debug.WriteLine($"Id antes de registrar {libro.Id}");
                connection.InsertWithChildren(libro);
                Debug.WriteLine($"Id despues de registrar {libro.Id}");
            }
            else
            {
                Debug.WriteLine($"Id antes de actualizar {libro.Id}");
                connection.Update(libro);
                App.FechaPublicacionDb.InsertOrUpdate(libro.FechaPublicacion);
                Debug.WriteLine($"Id despues de actualizar {libro.Id}");
            }
        }

        public Libro GetById(int Id)
        {
            return connection.Table<Libro>().FirstOrDefault(item => item.Id == Id);

        }

        public List<Libro> GetAll()
        {

            return connection.GetAllWithChildren<Libro>().ToList();
        }


        public void DeleteItem(int Id)
        {
            Libro libro = GetById(Id);
            connection.Delete(libro);
        }

    }
}

