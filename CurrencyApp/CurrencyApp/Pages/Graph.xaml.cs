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

namespace CurrencyApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Graph : ContentPage
    {
        List<ValuteDataValuteCursOnDate> AllValutes = new List<ValuteDataValuteCursOnDate>();
        List<ValuteDataEnumValutes> valuteCodes = new List<ValuteDataEnumValutes>();
        public Graph()
        {
            InitializeComponent();

            //Подключение и загрузка данных из ЦБ
            DailyInfoSoapClient client = new DailyInfoSoapClient(DailyInfoSoapClient.EndpointConfiguration.DailyInfoSoap); //Клиент

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

            //Пример того, как можно найти конкретный элемент (и его поле) в таблице
            /*  
              DataRow[] rows = dt.Select("Vname = 'Доллар США'");
              string course = rows[0].ItemArray[2].ToString();
              Price.Text = course; */

            ListView1.ItemsSource = AllValutes;
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
            Navigation.PushAsync(new NavigationPage(new Graphs(ref context, ref valuteCodes)));
        }
    }
}
