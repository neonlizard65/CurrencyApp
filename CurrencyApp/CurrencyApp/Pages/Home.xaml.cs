using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CurrencyApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
    {
        public Home()
        {
            InitializeComponent();
        }
        

        private void ShutUp_Clicked(object sender, EventArgs e)
        {
            if (ShutUp.Text == "OFF FACE")
                ShutUp.Text = "Выключи и иди делай уроки";
            if (ShutUp.Text== "Выключи и иди делай уроки")
                ShutUp.Text = "OFF FACE";
        }
    }
}