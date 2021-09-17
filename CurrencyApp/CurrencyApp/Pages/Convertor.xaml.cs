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
        List<ValuteDataValuteCursOnDate> AllValutes = new List<ValuteDataValuteCursOnDate>();
        public Convertor()
        {
            InitializeComponent();

            //Подклчение и загрузка данных их ЦБ
            DailyInfoSoapClient client = new DailyInfoSoapClient(DailyInfoSoapClient.EndpointConfiguration.DailyInfoSoap);
            var curstoday = client.GetCursOnDate(DateTime.Now);
            DataTable dt = XElementToDataTable(curstoday.Nodes[0]);

            List<DataRow> drlist = new List<DataRow>();
            foreach(DataRow dr in dt.Rows)
            {
                drlist.Add(dr);
            }

            AllValutes.Add(new ValuteDataValuteCursOnDate(
                    "Российский рубль",
                    1,
                    1,
                    "RUB"));
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
            CurrencyPicker1.ItemsSource = AllValutes;
            CurrencyPicker2.ItemsSource = AllValutes;

        }

        public DataTable XElementToDataTable(XElement element)
        {
            DataSet ds = new DataSet();
            ds.ReadXml(new StringReader(element.ToString()));
            return ds.Tables[0];
        }

        private void Convert_Btn_Clicked(object sender, EventArgs e)
        {
            try
            {
                decimal firstVal = Convert.ToDecimal(Valute1.Text);
                ValuteDataValuteCursOnDate val1 = (ValuteDataValuteCursOnDate)CurrencyPicker1.SelectedItem;
                ValuteDataValuteCursOnDate val2 = (ValuteDataValuteCursOnDate)CurrencyPicker2.SelectedItem;
                Valute2.Text = ((val1.Vcurs / val2.Vcurs) * firstVal).ToString("F4");
            }
            catch
            {

            }
        }
    }    
}