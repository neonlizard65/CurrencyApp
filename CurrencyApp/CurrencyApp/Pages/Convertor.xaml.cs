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
    public partial class Convertor : ContentPage
    {
        List<ValuteDataValuteCursOnDate> AllValutes = new List<ValuteDataValuteCursOnDate>(); //Все валюты
        public Convertor()
        {
            InitializeComponent();

            //Подключение и загрузка данных из ЦБ
            DailyInfoSoapClient client = new DailyInfoSoapClient(DailyInfoSoapClient.EndpointConfiguration.DailyInfoSoap); //Клиент
            var curstoday = client.GetCursOnDate(DateTime.Now); //Ежедневный курс валют 
            DataTable dt = XElementToDataTable(curstoday.Nodes[0]); //Таблица из исходящая из xml

            //Перебор всех строк в таблице, добавление в список всех валют
            List<DataRow> drlist = new List<DataRow>(); 
            foreach(DataRow dr in dt.Rows)
            {
                drlist.Add(dr);
            }

            //Добавляем рубль, чтобы можно было с ним работать
            AllValutes.Add(new ValuteDataValuteCursOnDate(
                    "Российский рубль",
                    1,
                    1,
                    "RUB"));
            
            //Конвертируем строки таблицы в элементы нашего созданного класса валют из xml файла (через наш конструктор)
            foreach (DataRow x in dt.Rows)
            {
                drlist.Add(x);
                AllValutes.Add(new ValuteDataValuteCursOnDate(
                    x[0].ToString(),
                    ushort.Parse(x[1].ToString()),
                    decimal.Parse(x[2].ToString()),
                    x[4].ToString())
                    );
            }

            //Пикерам настраиваем источник данных список с валютами
            CurrencyPicker1.ItemsSource = AllValutes;
            CurrencyPicker2.ItemsSource = AllValutes;
        }

        //Метод конвертирования из XML схемы в таблицу
        public DataTable XElementToDataTable(XElement element)
        {   
            DataSet ds = new DataSet();
            ds.ReadXml(new StringReader(element.ToString()));
            return ds.Tables[0];
        }

        //СДЕЛАТЬ: ограничение ввода (только числа), дизайн
        private void Convert_Btn_Clicked(object sender, EventArgs e)
        {   //Обработчик нажатия кнопки "Конвертировать"
            try
            {
                decimal firstVal = Convert.ToDecimal(Valute1.Text); //Поле ввода
                //Элементы пикера являются объектами списка валют, который составляет источник данных пикера
                ValuteDataValuteCursOnDate val1 = (ValuteDataValuteCursOnDate)CurrencyPicker1.SelectedItem;
                ValuteDataValuteCursOnDate val2 = (ValuteDataValuteCursOnDate)CurrencyPicker2.SelectedItem;
                
                Valute2.Text = ((val1.Vcurs / val1.Vnom) * firstVal / (val2.Vcurs / val2.Vnom)).ToString("F4"); //Вывод
            }
            catch
            {

            }
        }
    }    
}