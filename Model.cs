using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace XMLSerialize
{
    [Serializable]
    public class CDATA : IXmlSerializable
    {
        private string text;

        public CDATA()
        {
        }

        public CDATA(string text)
        {
            this.text = text;
        }

        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(System.Xml.XmlReader reader)
        {
            this.text = reader.ReadString();
        }

        public void WriteXml(System.Xml.XmlWriter writer)
        {
            writer.WriteCData(this.text);
        }
    }

    [Serializable]
    public class Results
    {
        public Results()
        {
            Comment = String.Empty;
        }
        [XmlElement(ElementName = "financialYear")]
        public int FinancialYear { get; set; }
        [XmlElement(ElementName = "TEP")]
        public decimal TEP { get; set; }

        private string comment;
        [XmlIgnore]
        public string Comment
        {
            get
            {
                return comment;
            }
            set
            {
                comment = value;
                CDataComment = new CDATA(comment);
            }
        }
        [XmlElement(ElementName = "comment", Type = typeof(CDATA))]
        public CDATA CDataComment { get; set; }
    }

    [Serializable]
    public class RequestStatus
    {
        public RequestStatus()
        {
            CancellationReason = String.Empty;
            RequestStatusEnum = RequestStatusEnum.PENDING;
        }
        [XmlAttribute(AttributeName = "cancellationReason")]
        public string CancellationReason { get; set; }
        [XmlText]
        public RequestStatusEnum RequestStatusEnum { get; set; }
    }

    [Serializable]
    public class Status
    {
        public Status()
        {
            RequestID = String.Empty;
            RequestStatus = new RequestStatus();
            TestStatus = String.Empty;
        }
        [XmlElement(ElementName = "requestID")]
        public string RequestID { get; set; }
        [XmlElement(ElementName = "requestStatus")]
        public RequestStatus RequestStatus { get; set; }
        [XmlElement(ElementName = "testStatus")]
        public string TestStatus { get; set; }
    }

    [Serializable]
    [XmlRoot(ElementName = "root")]
    public class Model : IXmlSerializable
    {
        public Model()
        {
            Results = new Results();
            Status = new Status();
            PDF = new byte[] { };
        }
        [XmlElement(ElementName = "results")]
        public Results Results { get; set; }
        [XmlElement(ElementName = "status")]
        public Status Status { get; set; }
        [XmlIgnore]
        public byte[] PDF { get; set; }
    }

    [Serializable]
    public enum RequestStatusEnum
    {
        PENDING,
        ORDERED,
        FAILED,
        REJECTED,
        COMPLETED
    }
}
