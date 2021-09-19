using System;
using System.Collections.Generic;
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
        //Подклчение и загрузка данных их ЦБ
        DailyInfoSoapClient client = new DailyInfoSoapClient(DailyInfoSoapClient.EndpointConfiguration.DailyInfoSoap);
        public Home()
        {
            var current = Connectivity.NetworkAccess;
            if (current == NetworkAccess.Internet)
            {
                InitializeComponent();

                //https://coolors.co/2c302e-474a48-909590-9ae19d-537a5a
                //https://coolors.co/e8c547-30323d-4d5061-5c80bc-cdd1c4
                //https://coolors.co/ed6a5a-f4f1bb-9bc1bc-5d576b-e6ebe0
                //https://coolors.co/f55d3e-878e88-f7cb15-ffffff-76bed0

                GetData();
                NewsList.ItemsSource = AllNews;
            }
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

        private async void RefreshView_Refreshing(object sender, EventArgs e)
        {
            await Task.Delay(2000);
            GetData();
            RefreshView1.IsRefreshing = false;
        }

        private void GetData()
        {
            DateTime weekago = DateTime.Now;
            weekago = weekago.Subtract(new TimeSpan(7, 0, 0, 0));
            var weeklynews = client.NewsInfo(weekago, DateTime.Now);
            DataTable dt = XElementToDataTable(weeklynews.Nodes[0]);

            foreach (DataRow x in dt.Rows)
            {
                AllNews.Add(new NewsInfoNews(
                    Convert.ToDateTime(x[1].ToString()),
                    x[2].ToString(),
                    x[3].ToString())
                    );
            }
        }
    }
}