using DemoSQLite.Repositories;
using DemoSQLite.View;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DemoSQLite
{
    public partial class App : Application
    {

        #region Repository
        private static LibroRepos _LibrosDb;
        public static LibroRepos LibrosDb
        {
            get
            {
                if (_LibrosDb == null)
                {
                    _LibrosDb = new LibroRepos();
                }
                return _LibrosDb;

            }
        }

        private static FechaPublicacionRepos _FechaPublicacionDb;
        public static FechaPublicacionRepos FechaPublicacionDb
        {
            get
            {
                if (_FechaPublicacionDb == null)
                {
                    _FechaPublicacionDb = new FechaPublicacionRepos();
                }
                return _FechaPublicacionDb;

            }
        }

        #endregion
        public App()
        {


            InitializeComponent();

            FechaPublicacionDb.Init();
            LibrosDb.Init();

            MainPage = new NavigationPage(new Inicio());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
