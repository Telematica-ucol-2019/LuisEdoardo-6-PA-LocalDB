using Bogus;
using DemoSQLite.Model;
using DemoSQLite.Repositories;
using DemoSQLite.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace DemoSQLite.ViewMode
{
    public class InicioViewModel : BaseViewModel
    {
        
        public ObservableCollection<Libro> Libros { get; set; }

        public ICommand cmdAgregaLibro { get; set; }
        public ICommand cmdModificaLibro { get; set; }

        public InicioViewModel()
        {
            Libros = new ObservableCollection<Libro>();
            cmdAgregaLibro = new Command(() => cmdAgregaLibroMetodo());
            cmdModificaLibro = new Command<Libro>((item) => cmdModificaLibroMetodo(item));

        }

        private void cmdModificaLibroMetodo(Libro libro)
        {
            App.Current.MainPage.Navigation.PushAsync(new MattoContacto(libro));
        }

        private void cmdAgregaLibroMetodo()
        {

            Libro libro = new Faker<Libro>()
                .RuleFor(c => c.Titulo, f => f.Name.FindName())
                .RuleFor(c => c.Editorial, f => f.Company.CompanyName())
                .RuleFor(c => c.Autor, f => f.Name.FullName())
                .RuleFor(c => c.Descripcion, f => f.Lorem.Paragraph());


            Random rnd = new Random();
            DateTime datetoday = DateTime.Now;

            int rndYear = rnd.Next(1995, datetoday.Year);
            int rndMonth = rnd.Next(1, 12);
            int rndDay = rnd.Next(1, 31);

            DateTime generateDate = new DateTime(rndYear, rndMonth, rndDay);

            Debug.WriteLine($"FECHA ALEATORIA {generateDate}");

            libro.FechaPublicacion = new FechaPublicacion() { Publicacion = generateDate };




            App.Current.MainPage.Navigation.PushAsync(new MattoContacto(libro));

        }

        public void GetAll()

        {
            if (Libros != null)
            {
                Libros.Clear();
                App.LibrosDb.GetAll().ForEach(item => Libros.Add(item));
            }
            else
            {
                Libros = new ObservableCollection<Libro>(App.LibrosDb.GetAll());

            }
            OnPropertyChanged();
        }

    
    }
}
