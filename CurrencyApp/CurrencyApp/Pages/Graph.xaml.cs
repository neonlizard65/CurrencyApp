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
using static CurrencyApp.CurrentCurrencyClass;
using static CurrencyApp.IncomingClasses.EnumCourses;
using CurrencyApp.IncomingClasses;
using Microcharts;
using Microcharts.Forms;
using SkiaSharp;
using CurrencyApp.Pages.GpaphPages;
using Xamarin.Essentials;

namespace CurrencyApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Graph : ContentPage
    {
        //Подключение и загрузка данных из ЦБ
        DailyInfoSoapClient client = new DailyInfoSoapClient(DailyInfoSoapClient.EndpointConfiguration.DailyInfoSoap); //Клиент
        List<ValuteDataValuteCursOnDate> AllValutes = new List<ValuteDataValuteCursOnDate>();
        List<ValuteDataEnumValutes> valuteCodes = new List<ValuteDataEnumValutes>();
        public Graph()
        {
            var current = Connectivity.NetworkAccess;
            if (current == NetworkAccess.Internet)
            {
                InitializeComponent();
                GetData();
                ListView1.ItemsSource = AllValutes;
            }
        }
        //Метод конвертирования из XML схемы в таблицу
        public DataTable XElementToDataTable(XElement element)
        {
            DataSet ds = new DataSet();
            ds.ReadXml(new StringReader(element.ToString()));
            return ds.Tables[0];
        }

        private void ListView1_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ValuteDataValuteCursOnDate context = ((sender as ListView).SelectedItem as ValuteDataValuteCursOnDate);
            Page newnav = new NavigationPage(new Graphs(ref context, ref valuteCodes));
            Navigation.PushAsync(newnav);
            newnav.Title = context.VchCode;
        }

        private void GetData()
        {
            //Ежедневный курс валют
            var curstoday = client.GetCursOnDate(DateTime.Now);
            DataTable dtNow = XElementToDataTable(curstoday.Nodes[0]); //Таблица из исходящая из xml

            //Конвертируем строки таблицы в элементы нашего созданного класса валют из xml файла (через наш конструктор)
            foreach (DataRow x in dtNow.Rows)
            {
                AllValutes.Add(new ValuteDataValuteCursOnDate(
                    x[0].ToString(),
                    ushort.Parse(x[1].ToString()),
                    decimal.Parse(x[2].ToString()),
                    x[4].ToString(),
                    ushort.Parse(x[3].ToString())
                    ));
            }

            var valcodes = client.EnumValutes(false);
            DataTable dtValutes = XElementToDataTable(valcodes.Nodes[0]); //Таблица из исходящая из xml
            bool flag = false;
            foreach (DataRow x in dtValutes.Rows)
            {
                foreach (ValuteDataValuteCursOnDate y in AllValutes)
                {
                    if (x[6].ToString() == y.VchCode)
                    {
                        flag = true;
                        break;
                    }
                }
                if (flag)
                {
                    valuteCodes.Add(new ValuteDataEnumValutes(
                        x[0].ToString(),
                        x[6].ToString(),
                        ushort.Parse(x[5].ToString()),
                        uint.Parse(x[3].ToString()),
                        x[1].ToString()
                        ));
                }
                flag = false;
            }
        }

        private async void RefreshView1_Refreshing(object sender, EventArgs e)
        {
            await Task.Delay(2000);
            GetData();
            RefreshView1.IsRefreshing = false;
        }
    }
}
