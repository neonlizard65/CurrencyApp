using CurrencyApp.IncomingClasses;
using Microcharts;
using ServiceReference1;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static CurrencyApp.CurrentCurrencyClass;
using static CurrencyApp.IncomingClasses.EnumCourses;

namespace CurrencyApp.Pages.GpaphPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Graphs : ContentPage
    {
        public Graphs(ref ValuteDataValuteCursOnDate context, ref List<ValuteDataEnumValutes> enumvalutes)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            //Подключение и загрузка данных из ЦБ
            DailyInfoSoapClient client = new DailyInfoSoapClient(DailyInfoSoapClient.EndpointConfiguration.DailyInfoSoap); //Клиент

            List<ValuteDataValuteCursDynamic> dynamicList = new List<ValuteDataValuteCursDynamic>();
            DateTime d1 = DateTime.Now;
            DateTime d2 = d1.Subtract(new TimeSpan(9, 0, 0, 0));

            string currentValute = null;

            foreach(var x in enumvalutes)
            {
                if(x.VnumCode == context.Vcode)
                {
                    currentValute = x.Vcode;
                }
            }

            var dynamic = client.GetCursDynamic(d2, d1, currentValute);
            DataTable dtDynamic = XElementToDataTable(dynamic.Nodes[0]); //Таблица из исходящая из xml
            foreach (DataRow x in dtDynamic.Rows)
            {
                dynamicList.Add(new ValuteDataValuteCursDynamic(
                    Convert.ToDateTime(x[0].ToString()),
                    x[1].ToString(),
                    uint.Parse(x[2].ToString()),
                    decimal.Parse(x[3].ToString())
                    ));
            }
            int length = dynamicList.Count;
            ChartEntry[] entries = new ChartEntry[length];
            int count = 0;
            float min = 10000000000;
            float max = 0;
            foreach (var item in dynamicList)
            {
                entries[count] = new ChartEntry(float.Parse(item.Vcurs.ToString()))
                {
                    Label = item.CursDate.ToString("dd/MM/yyyy"), //Колонка(Надпись с низу)
                    ValueLabel = item.Vcurs.ToString(), //Цифры у точки на графике
                    Color = SKColor.Parse("#3498db") //Цвет точки
                };
                if(count == 0)
                {
                    min = Convert.ToSingle(item.Vcurs);
                }
                else
                {
                    if(min > Convert.ToSingle(item.Vcurs))
                    {
                        min = Convert.ToSingle(item.Vcurs);
                    }
                    if (max < Convert.ToSingle(item.Vcurs))
                    {
                        max = Convert.ToSingle(item.Vcurs);
                    }
                    
                }
                count++;
            }
            min = min - ((max - min)/2);

            chartViewBar.Chart = new LineChart { Entries = entries, LabelTextSize = 12, LineMode = LineMode.Straight, LabelOrientation = Orientation.Horizontal, ValueLabelOrientation = Orientation.Horizontal, MinValue=min };//Вывод графика с параметрами
        }

        public DataTable XElementToDataTable(XElement element)
        {
            DataSet ds = new DataSet();
            ds.ReadXml(new StringReader(element.ToString()));
            return ds.Tables[0];
        }
    }
}