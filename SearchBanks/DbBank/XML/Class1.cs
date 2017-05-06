using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbBank.XML
{

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class banks
    {

        private banksBankid[] bankidField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("bank-id")]
        public banksBankid[] bankid
        {
            get
            {
                return this.bankidField;
            }
            set
            {
                this.bankidField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class banksBankid
    {

        private byte idbankField;

        private System.DateTime dateField;

        private System.DateTime timeField;

        private banksBankidUsd usdField;

        private banksBankidEur eurField;

        private banksBankidRur rurField;

        private string[] textField;

        /// <remarks/>
        public byte idbank
        {
            get
            {
                return this.idbankField;
            }
            set
            {
                this.idbankField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
        public System.DateTime date
        {
            get
            {
                return this.dateField;
            }
            set
            {
                this.dateField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "time")]
        public System.DateTime time
        {
            get
            {
                return this.timeField;
            }
            set
            {
                this.timeField = value;
            }
        }

        /// <remarks/>
        public banksBankidUsd usd
        {
            get
            {
                return this.usdField;
            }
            set
            {
                this.usdField = value;
            }
        }

        /// <remarks/>
        public banksBankidEur eur
        {
            get
            {
                return this.eurField;
            }
            set
            {
                this.eurField = value;
            }
        }

        /// <remarks/>
        public banksBankidRur rur
        {
            get
            {
                return this.rurField;
            }
            set
            {
                this.rurField = value;
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
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class banksBankidUsd
    {

        private ushort sellField;

        private ushort buyField;

        /// <remarks/>
        public ushort sell
        {
            get
            {
                return this.sellField;
            }
            set
            {
                this.sellField = value;
            }
        }

        /// <remarks/>
        public ushort buy
        {
            get
            {
                return this.buyField;
            }
            set
            {
                this.buyField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class banksBankidEur
    {

        private ushort sellField;

        private ushort buyField;

        /// <remarks/>
        public ushort sell
        {
            get
            {
                return this.sellField;
            }
            set
            {
                this.sellField = value;
            }
        }

        /// <remarks/>
        public ushort buy
        {
            get
            {
                return this.buyField;
            }
            set
            {
                this.buyField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class banksBankidRur
    {

        private decimal sellField;

        private decimal buyField;

        /// <remarks/>
        public decimal sell
        {
            get
            {
                return this.sellField;
            }
            set
            {
                this.sellField = value;
            }
        }

        /// <remarks/>
        public decimal buy
        {
            get
            {
                return this.buyField;
            }
            set
            {
                this.buyField = value;
            }
        }
    }


}
