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
using Xamarin.Essentials;

namespace CurrencyApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Convertor : ContentPage
    {
        List<ValuteDataValuteCursOnDate> AllValutes = new List<ValuteDataValuteCursOnDate>(); //Все валюты
        public Convertor()
        {
            var current = Connectivity.NetworkAccess;
            if (current == NetworkAccess.Internet)
            {
                InitializeComponent();

                //Подключение и загрузка данных из ЦБ
                DailyInfoSoapClient client = new DailyInfoSoapClient(DailyInfoSoapClient.EndpointConfiguration.DailyInfoSoap); //Клиент
                var curstoday = client.GetCursOnDate(DateTime.Now); //Ежедневный курс валют 
                DataTable dt = XElementToDataTable(curstoday.Nodes[0]); //Таблица из исходящая из xml

                //Добавляем рубль, чтобы можно было с ним работать
                AllValutes.Add(new ValuteDataValuteCursOnDate(
                        "Российский рубль",
                        1,
                        1,
                        "RUB",
                        643));
            
                //Конвертируем строки таблицы в элементы нашего созданного класса валют из xml файла (через наш конструктор)
                foreach (DataRow x in dt.Rows)
                {
                    AllValutes.Add(new ValuteDataValuteCursOnDate(
                        x[0].ToString(),
                        ushort.Parse(x[1].ToString()),
                        decimal.Parse(x[2].ToString()),
                        x[4].ToString(),
                        ushort.Parse(x[3].ToString()))
                        );
                }

                //Пикерам настраиваем источник данных список с валютами
                CurrencyPicker1.ItemsSource = AllValutes;
                CurrencyPicker2.ItemsSource = AllValutes;
            }
            else
            {

            }
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
                decimal multiplier = Convert.ToDecimal(Valute1.Text); //Поле ввода
                //Элементы пикера являются объектами списка валют, который составляет источник данных пикера
                ValuteDataValuteCursOnDate val1 = (ValuteDataValuteCursOnDate)CurrencyPicker1.SelectedItem;
                ValuteDataValuteCursOnDate val2 = (ValuteDataValuteCursOnDate)CurrencyPicker2.SelectedItem;

                Valute2.Text = ((val1.Vcurs / val1.Vnom) * multiplier / (val2.Vcurs / val2.Vnom)).ToString("F4"); //Вывод
            }
            catch
            {

            }
        }

        private void Swap_Clicked(object sender, EventArgs e)
        {
            var tempval = CurrencyPicker1.SelectedItem;
            CurrencyPicker1.SelectedItem = CurrencyPicker2.SelectedItem;
            CurrencyPicker2.SelectedItem = tempval;
            string temptext;
            temptext = Valute1.Text;
            Valute1.Text = Valute2.Text;
            Valute2.Text = temptext;
        }

        private void sbros_Clicked(object sender, EventArgs e)
        {
            Valute1.Text = null;
            Valute2.Text = null;
            CurrencyPicker1.SelectedIndex = -1;
            CurrencyPicker2.SelectedIndex = -1;
        }
    }    
}