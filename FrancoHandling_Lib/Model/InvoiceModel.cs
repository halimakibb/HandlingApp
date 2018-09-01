using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrancoHandling_Lib.Model
{
    public class InvoiceModel
    {
        public class InvoiceHeader
        {
            public int Invoice_ID { get; set; }
            public int Type { get; set; }
            public string InvoiceNumber { get; set; }
            public DateTime InvoiceDate { get; set; }
            public string ApproveBy { get; set; }
            public string Note { get; set; }
            public int Status { get; set; }
            public string StatusDesc { get; set; }
            public int IsActive { get; set; }
            public DateTime CreationDate { get; set; }
            public string CreationBy { get; set; }
            public DateTime UpdateDate { get; set; }
            public string UpdateBy { get; set; }
        }

        public class InvoiceItem
        {
            public int Invoice_ID { get; set; }
            public int LO_ID { get; set; }
            public string NoLO { get; set; }
            public string NoDO { get; set; }
            public string DODate { get; set; }
            public int Product_ID { get; set; }
            public string ProductName { get; set; }
            public float QuantityVolume { get; set; }
            public float PriceUnit { get; set; }
            public float SubTotal { get; set; }
            public byte IsActive { get; set; }
            public DateTime CreationDate { get; set; }
            public string CreationBy { get; set; }
            public DateTime UpdateDate { get; set; }
            public string UpdateBy { get; set; }
        }

        public class InvoiceReport
        {
            public string InvoiceNumber { get; set; }
            public string InvoiceDate { get; set; }
            public string WorkPeriod { get; set; }
            public string ProductName { get; set; }
            public Int64 InvoiceQuantity { get; set; }
            public Decimal InvoiceUnitPrice { get; set; }
            public Decimal InvoiceTotalPrice { get; set; }
            public Int64 BASTQuantity { get; set; }
            public Decimal BASTUnitPrice { get; set; }
            public Decimal BASTTotalPrice { get; set; }
        }
    }
}
