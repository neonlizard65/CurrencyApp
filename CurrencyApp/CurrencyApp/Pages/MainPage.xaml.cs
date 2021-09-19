using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Xamarin.Forms;
using ServiceReference1;
using System.Xml.Linq;
using System.IO;
using static CurrencyApp.CurrentCurrencyClass;
using Xamarin.Essentials;


namespace CurrencyApp
{
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            CurrentPage = Children[1];
        }

    }
}
