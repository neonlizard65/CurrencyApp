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


            //Подклчение и загрузка данных их ЦБ
            DailyInfoSoapClient client = new DailyInfoSoapClient(DailyInfoSoapClient.EndpointConfiguration.DailyInfoSoap);
            var curstoday = client.GetCursOnDate(DateTime.Now);
            DataTable dt = XElementToDataTable(curstoday.Nodes[0]);




            DataRow[] rows = dt.Select("Vname = 'Доллар США'");
            string course = rows[0].ItemArray[2].ToString();
            Price.Text = course;

            List<DataRow> rows1 = new List<DataRow>();
            List<ValuteDataValuteCursOnDate> AllValutes = new List<ValuteDataValuteCursOnDate>();
            foreach (DataRow x in dt.Rows)
            {
                rows1.Add(x);
                AllValutes.Add(new ValuteDataValuteCursOnDate(
                    x[0].ToString(),
                    ushort.Parse(x[1].ToString()),
                    decimal.Parse(x[2].ToString()),
                    x[4].ToString())
                    );
            }
            ListView1.ItemsSource = AllValutes;

        }

        public DataTable XElementToDataTable(XElement element)
        {
            DataSet ds = new DataSet();
            ds.ReadXml(new StringReader(element.ToString()));
            return ds.Tables[0];
        }
    }
}