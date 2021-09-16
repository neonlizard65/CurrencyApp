using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Xamarin.Forms;
using ServiceReference1;
using System.Xml.Linq;
using System.IO;

namespace CurrencyApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            DailyInfoSoapClient client = new DailyInfoSoapClient(DailyInfoSoapClient.EndpointConfiguration.DailyInfoSoap);
            var curstoday = client.GetCursOnDate(DateTime.Now);

            DataTable dt = XElementToDataTable(curstoday.Nodes[0]);


            /*StringBuilder sb = new StringBuilder();
            foreach (var x in curstoday.Nodes)
            {
                sb.Append(x.ToString());
            }
            */

            DataRow[] rows = dt.Select("Vname = 'Доллар США'");
            string course = rows[0].ItemArray[2].ToString();
            Price.Text = course;
        }

        public DataTable XElementToDataTable(XElement element)
        {
            DataSet ds = new DataSet();
            ds.ReadXml(new StringReader(element.ToString()));
            return ds.Tables[0];
        }
    }
}
