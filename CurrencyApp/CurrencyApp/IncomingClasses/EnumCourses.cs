using System;
using System.Collections.Generic;
using System.Text;

namespace CurrencyApp.IncomingClasses
{
    class EnumCourses
    {

        // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://web.cbr.ru/")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://web.cbr.ru/", IsNullable = false)]
        public partial class EnumValutesResult
        {

            private diffgram diffgramField;

            private string[] textField;

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

            /// <remarks/>
            [System.Xml.Serialization.XmlTextAttribute()]
            public string[] Text
            {
                get
                {
                    return this.textField;
                }
                set
                {
                    this.textField = value;
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

            private ValuteData valuteDataField;

            private string[] textField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Namespace = "")]
            public ValuteData ValuteData
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

            /// <remarks/>
            [System.Xml.Serialization.XmlTextAttribute()]
            public string[] Text
            {
                get
                {
                    return this.textField;
                }
                set
                {
                    this.textField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
        public partial class ValuteData
        {

            private ValuteDataEnumValutes[] enumValutesField;

            private string[] textField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("EnumValutes")]
            public ValuteDataEnumValutes[] EnumValutes
            {
                get
                {
                    return this.enumValutesField;
                }
                set
                {
                    this.enumValutesField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlTextAttribute()]
            public string[] Text
            {
                get
                {
                    return this.textField;
                }
                set
                {
                    this.textField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class ValuteDataEnumValutes
        {

            private string vcodeField;

            private string vnameField;

            private string vEngnameField;

            private uint vnomField;

            private string vcommonCodeField;

            private ushort vnumCodeField;

            private bool vnumCodeFieldSpecified;

            private string vcharCodeField;

            private string[] textField;

            private string idField;

            private byte rowOrderField;

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
            public string Vname
            {
                get
                {
                    return this.vnameField;
                }
                set
                {
                    this.vnameField = value;
                }
            }

            /// <remarks/>
            public string VEngname
            {
                get
                {
                    return this.vEngnameField;
                }
                set
                {
                    this.vEngnameField = value;
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
            public string VcommonCode
            {
                get
                {
                    return this.vcommonCodeField;
                }
                set
                {
                    this.vcommonCodeField = value;
                }
            }

            /// <remarks/>
            public ushort VnumCode
            {
                get
                {
                    return this.vnumCodeField;
                }
                set
                {
                    this.vnumCodeField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool VnumCodeSpecified
            {
                get
                {
                    return this.vnumCodeFieldSpecified;
                }
                set
                {
                    this.vnumCodeFieldSpecified = value;
                }
            }

            /// <remarks/>
            public string VcharCode
            {
                get
                {
                    return this.vcharCodeField;
                }
                set
                {
                    this.vcharCodeField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlTextAttribute()]
            public string[] Text
            {
                get
                {
                    return this.textField;
                }
                set
                {
                    this.textField = value;
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

            public ValuteDataEnumValutes(string vcode, string vcharcode, ushort vnumcode, uint nom, string vname)
            {
                Vcode = vcode;
                VcharCode = vcharcode;
                VnumCode = vnumcode;
                Vnom = nom;
                Vname = vname;

            }
        }


    }
}
