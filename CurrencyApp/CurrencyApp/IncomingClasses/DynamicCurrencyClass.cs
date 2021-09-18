using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyApp.IncomingClasses
{

    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://web.cbr.ru/")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://web.cbr.ru/", IsNullable = false)]
    public partial class GetCursDynamicResult
    {

        private diffgram diffgramField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1")]
        public diffgram diffgram
        {
            get
            {
                return this.diffgramField;
            }
            set
            {
                this.diffgramField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1", IsNullable = false)]
    public partial class diffgram
    {

        private ValuteDataValuteCursDynamic[] valuteDataField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Namespace = "")]
        [System.Xml.Serialization.XmlArrayItemAttribute("ValuteCursDynamic", IsNullable = false)]
        public ValuteDataValuteCursDynamic[] ValuteData
        {
            get
            {
                return this.valuteDataField;
            }
            set
            {
                this.valuteDataField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ValuteDataValuteCursDynamic
    {

        private System.DateTime cursDateField;

        private string vcodeField;

        private uint vnomField;

        private decimal vcursField;

        private string idField;

        private byte rowOrderField;

        /// <remarks/>
        public System.DateTime CursDate
        {
            get
            {
                return this.cursDateField;
            }
            set
            {
                this.cursDateField = value;
            }
        }

        /// <remarks/>
        public string Vcode
        {
            get
            {
                return this.vcodeField;
            }
            set
            {
                this.vcodeField = value;
            }
        }

        /// <remarks/>
        public uint Vnom
        {
            get
            {
                return this.vnomField;
            }
            set
            {
                this.vnomField = value;
            }
        }

        /// <remarks/>
        public decimal Vcurs
        {
            get
            {
                return this.vcursField;
            }
            set
            {
                this.vcursField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1")]
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "urn:schemas-microsoft-com:xml-msdata")]
        public byte rowOrder
        {
            get
            {
                return this.rowOrderField;
            }
            set
            {
                this.rowOrderField = value;
            }
        }

        public ValuteDataValuteCursDynamic(DateTime date, string vcode, uint vnom, decimal vcurs)
        {
            CursDate = date;
            Vcode = vcode;
            Vnom = vnom;
            Vcurs = vcurs;
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class ValuteData
    {

        private ValuteDataValuteCursDynamic[] valuteCursDynamicField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ValuteCursDynamic")]
        public ValuteDataValuteCursDynamic[] ValuteCursDynamic
        {
            get
            {
                return this.valuteCursDynamicField;
            }
            set
            {
                this.valuteCursDynamicField = value;
            }
        }
    }


}
