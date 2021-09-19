using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CurrencyApp
{
    public partial class App : Application
    {
        public App()
        {
            // Connection to internet is available
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            MainPage = new NavigationPage(new MainPage());
            Application.Current.UserAppTheme = OSAppTheme.Light;
        }

        protected override void OnStart()
        {
            var current = Connectivity.NetworkAccess;
            if (current != NetworkAccess.Internet)
            {
                var result = MainPage.DisplayAlert("Ошибка", "Отсутствует соединение к интернету", "", "Закрыть").ContinueWith(task =>
               {
                   if (task.Result == true || task.Result == false)
                   {
                       System.Diagnostics.Process.GetCurrentProcess().Kill();
                   }
               }
               );

            }
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
