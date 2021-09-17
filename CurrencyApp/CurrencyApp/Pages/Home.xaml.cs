using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Data;
using ServiceReference1;
using System.Xml.Linq;
using System.IO;
using static CurrencyApp.CBNews;
using Xamarin.Essentials;

namespace CurrencyApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
    {
        List<NewsInfoNews> AllNews = new List<NewsInfoNews>();
        public Home()
        {
            InitializeComponent();

            //Подклчение и загрузка данных их ЦБ
            DailyInfoSoapClient client = new DailyInfoSoapClient(DailyInfoSoapClient.EndpointConfiguration.DailyInfoSoap);
            DateTime weekago = DateTime.Now;
            weekago = weekago.Subtract(new TimeSpan(7, 0, 0, 0));
            var weeklynews = client.NewsInfo(weekago, DateTime.Now);
            DataTable dt = XElementToDataTable(weeklynews.Nodes[0]);

            List<DataRow> drlist = new List<DataRow>();
            foreach (DataRow dr in dt.Rows)
            {
                drlist.Add(dr);
            }


            foreach (DataRow x in dt.Rows)
            {
                drlist.Add(x);
                AllNews.Add(new NewsInfoNews(
                    Convert.ToDateTime(x[1].ToString()),
                    x[2].ToString(),
                    x[3].ToString())
                    );
            }

            NewsList.ItemsSource = AllNews;
        }
        

        private void ShutUp_Clicked(object sender, EventArgs e)
        {
            if (ShutUp.Text == "OFF FACE")
                ShutUp.Text = "Выключи и иди делай уроки";
            if (ShutUp.Text== "Выключи и иди делай уроки")
                ShutUp.Text = "OFF FACE";
        }

        public DataTable XElementToDataTable(XElement element)
        {
            DataSet ds = new DataSet();
            ds.ReadXml(new StringReader(element.ToString()));
            return ds.Tables[0];
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            try
            {
                await Browser.OpenAsync(((sender as ListView).SelectedItem as NewsInfoNews).Url, BrowserLaunchMode.SystemPreferred);
            }
            catch
            {
                // An unexpected error occured. No browser may be installed on the device.
            }
        }
    }
}