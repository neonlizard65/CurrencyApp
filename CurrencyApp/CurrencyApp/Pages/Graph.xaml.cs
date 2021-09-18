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
            
            //Ежедневный курс валют
            var curstoday = client.GetCursOnDate(DateTime.Now);  
            DataTable dtNow = XElementToDataTable(curstoday.Nodes[0]); //Таблица из исходящая из xml

            //Перебор всех строк в таблице, добавление в список всех валют
            List<ValuteDataValuteCursOnDate> AllValutes = new List<ValuteDataValuteCursOnDate>();

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
            ListView1.ItemsSource = AllValutes; //Источник данных - список со всеми валютами


            var valcodes = client.EnumValutes(false);
            DataTable dtValutes = XElementToDataTable(valcodes.Nodes[0]); //Таблица из исходящая из xml
            List<ValuteDataEnumValutes> valuteCodes = new List<ValuteDataEnumValutes>();
            bool flag = false;
            foreach (DataRow x in dtValutes.Rows)
            {               
                foreach(ValuteDataValuteCursOnDate y in AllValutes)
                {
                    if(x[6].ToString() == y.VchCode)
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

            List<ValuteDataValuteCursDynamic> dynamicList = new List<ValuteDataValuteCursDynamic>();
            DateTime d1 = new DateTime(2021, 5, 2);
            DateTime d2 = new DateTime(2021, 7, 2);
            var dynamic = client.GetCursDynamic(d1, d2, "R01239");
            DataTable dtDynamic = XElementToDataTable(dynamic.Nodes[0]); //Таблица из исходящая из xml
            foreach (DataRow x in dtDynamic.Rows)
            {
                dynamicList.Add(new ValuteDataValuteCursDynamic(
                    Convert.ToDateTime(x[0].ToString()),
                    x[1].ToString(),
                    byte.Parse(x[2].ToString()),
                    decimal.Parse(x[3].ToString())
                    ));
            }

            //Пример того, как можно найти конкретный элемент (и его поле) в таблице
            /*  
              DataRow[] rows = dt.Select("Vname = 'Доллар США'");
              string course = rows[0].ItemArray[2].ToString();
              Price.Text = course; */
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