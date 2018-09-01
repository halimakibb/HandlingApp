using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrancoHandling_Lib.Model
{
    public class ReportModel
    {
        public class OAT
        {
            public int RowNumber{ get; set; }
            public DateTime DeliveryDate { get; set; }
            public string NoDO { get; set; }            
            public string NoSP3M { get; set; }
            public string NoLO { get; set; }
            public string ProductName { get; set; }
            public string Unity { get; set; }
            public string Transportir { get; set; }
            public DateTime InvoiceDate { get; set; }
            public float Distance { get; set; }
            public float NormalDistance { get; set; }
            public float NormalPrice { get; set; }
            public float NormalTotal { get; set; }
            public float OverDistance { get; set; }
            public float OverPrice { get; set; }
            public float OverTotal { get; set; }
            public float SubTotal { get; set; }

            public float Pertamax { get; set; }
            public float PertaminaDex { get; set; }
            public float Kerosine { get; set; }
            public float MT88 { get; set; }
            public float HSD { get; set; }
            public float Turbo { get; set; }

        }
    }
}
