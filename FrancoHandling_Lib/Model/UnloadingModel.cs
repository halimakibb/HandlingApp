using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrancoHandling_Lib.Model
{
    public class UnloadingModel
    {
        public class UnloadingList
        {
            public Int64 SPPB_ID { get; set; }
            public string NoSPP { get; set; }
            public Int64 LO_ID { get; set; }
            public string NoLO { get; set; }
            public string NoDO { get; set; }
            public int TBBM_ID { get; set; }
            public string TBBMName { get; set; }
            public int SPSH_ID { get; set; }
            public string SPSHName { get; set; }
            public Int64 Item_ID { get; set; }
            public string ItemDesc { get; set; }
            public int QuantityVolume { get; set; }

        }

        public class UnloadingDetail
        {
            public Int64 LO_ID { get; set; }
            public string NoLO { get; set; }
            public DateTime LODate { get; set; }
            public string NoDO { get; set; }
            public DateTime DODate { get; set; }
            public string NoPO { get; set; }
            public DateTime PODate { get; set; }
            public string NoOrder { get; set; }
            public DateTime OrderDate { get; set; }
            public string TransporterName { get; set; }
            public string VehicleType { get; set; }
            public string VehicleNumber { get; set; }
            public string DriverName { get; set; }
            public string DONote { get; set; }
            public DateTime UnloadingDate { get; set; }
            public string MeasurementMethods { get; set; }
            public Int64 EIJKBautHeight { get; set; }
            public Int64 EIJKBautActual { get; set; }
            public Int64 SensitivityVolume { get; set; }
            public Int64 ReceiptVolume { get; set; }
            public string BASTNumber { get; set; }
            public string BASTFileName { get; set; }
            public byte[] BASTFileBytes { get; set; }
            public string UnloadingNote { get; set; }
            public string CreationBy { get; set; }
        }
    }
}
