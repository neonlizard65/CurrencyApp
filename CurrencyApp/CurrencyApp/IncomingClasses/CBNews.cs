using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyApp
{
    public class CBNews
    {

        // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://web.cbr.ru/")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://web.cbr.ru/", IsNullable = false)]
        public partial class NewsInfoResult
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

            private NewsInfoNews[] newsInfoField;

            /// <remarks/>
            [System.Xml.Serialization.XmlArrayAttribute(Namespace = "")]
            [System.Xml.Serialization.XmlArrayItemAttribute("News", IsNullable = false)]
            public NewsInfoNews[] NewsInfo
            {
                get
                {
                    return this.newsInfoField;
                }
                set
                {
                    this.newsInfoField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class NewsInfoNews
        {

            private ushort doc_idField;

            private System.DateTime docDateField;

            private string titleField;

            private string urlField;

            private string idField;

            private byte rowOrderField;

            /// <remarks/>
            public ushort Doc_id
            {
                get
                {
                    return this.doc_idField;
                }
                set
                {
                    this.doc_idField = value;
                }
            }

            /// <remarks/>
            public System.DateTime DocDate
            {
                get
                {
                    return this.docDateField;
                }
                set
                {
                    this.docDateField = value;
                }
            }

            /// <remarks/>
            public string Title
            {
                get
                {
                    return this.titleField;
                }
                set
                {
                    this.titleField = value;
                }
            }

            /// <remarks/>
            public string Url
            {
                get
                {
                    return this.urlField;
                }
                set
                {
                    this.urlField = value;
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

            public NewsInfoNews(DateTime date, string title, string url)
            {
                DocDate = date;
                Title = title;
                Url = "https://www.cbr.ru" + url;
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
        public partial class NewsInfo
        {

            private NewsInfoNews[] newsField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("News")]
            public NewsInfoNews[] News
            {
                get
                {
                    return this.newsField;
                }
                set
                {
                    this.newsField = value;
                }
            }
        }


    }
}
