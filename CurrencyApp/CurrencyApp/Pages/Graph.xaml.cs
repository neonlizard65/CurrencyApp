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

namespace CurrencyApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Graph : ContentPage
    {
        public Graph()
        {
            InitializeComponent();



            //Подключение и загрузка данных из ЦБ
            DailyInfoSoapClient client = new DailyInfoSoapClient(DailyInfoSoapClient.EndpointConfiguration.DailyInfoSoap); //Клиент
            var curstoday = client.GetCursOnDate(DateTime.Now);  //Ежедневный курс валют
            var dynamic = client.GetCursDynamic(DateTime.Now, DateTime.Now, "USD"); //Потом нашишем
            DataTable dt = XElementToDataTable(curstoday.Nodes[0]); //Таблица из исходящая из xml



            //Пример того, как можно найти конкретный элемент (и его поле) в таблице
            /*  
              DataRow[] rows = dt.Select("Vname = 'Доллар США'");
              string course = rows[0].ItemArray[2].ToString();
              Price.Text = course; */


            //Перебор всех строк в таблице, добавление в список всех валют
            List<DataRow> dr = new List<DataRow>();
            List<ValuteDataValuteCursOnDate> AllValutes = new List<ValuteDataValuteCursOnDate>();

            //Конвертируем строки таблицы в элементы нашего созданного класса валют из xml файла (через наш конструктор)
            foreach (DataRow x in dt.Rows)
            {
                dr.Add(x);
                AllValutes.Add(new ValuteDataValuteCursOnDate(
                    x[0].ToString(),
                    ushort.Parse(x[1].ToString()),
                    decimal.Parse(x[2].ToString()),
                    x[4].ToString())
                    );
            }
            ListView1.ItemsSource = AllValutes; //Источник данных - список со всеми валютами
        }

        //Метод конвертирования из XML схемы в таблицу
        public DataTable XElementToDataTable(XElement element)
        {
            DataSet ds = new DataSet();
            ds.ReadXml(new StringReader(element.ToString()));
            return ds.Tables[0];
        }
    }
}