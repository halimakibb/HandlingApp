using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrancoHandling_Lib.Model
{
    public class SPPBModel
    {
        public class SPPB
        {
            public long SPP_ID_PK { get; set; }

            public long SP3M_ID_FK { get; set; }

            public string NoSP3M { get; set; }

            public string SPSH_ID_FK { get; set; }

            public int? Transporter_ID_FK { get; set; }

            public int? Vehicle_ID_FK { get; set; }

            public int? Driver_ID_FK { get; set; }

            public string SPSHName { get; set; }

            public string SPSHAddress { get; set; }

            public int TBBM_ID_FK { get; set; }

            public string TBBMName { get; set; }

            public string TBBMAddress { get; set; }

            public string Force { get; set; }

            public string Unity { get; set; }

            public string NoSA { get; set; }

            public string NoSP2M { get; set; }
            
            public string TransporterName { get; set; }

            public string DriverName { get; set; }

            public string VehicleNumber { get; set; }

            public long? VehicleCapacity { get; set; }
           
            public string NoSPP { get; set; }

            public DateTime? DeliveryDate { get; set; }

            public DateTime? OrderDate { get; set; }

            public string OrderBy { get; set; }

            public string Note { get; set; }

            public byte Status { get; set; }

            public string StatusDesc { get; set; }

            public bool IsActive { get; set; }

            public DateTime CreationDate { get; set; }

            public string CreationBy { get; set; }

            public DateTime UpdateDate { get; set; }

            public string UpdateBy { get; set; }            
            
        }


        public class SPPBItem
        {
            public long SPP_ID { get; set; }
            public long SPP_Items_ID_PK { get; set; }
            public long Product_ID_FK { get; set; }
            public string ProductName { get; set; }            
            public double QtySPP { get; set; }
            public double QtyUsed { get; set; }
            public double QtySP3M { get; set; }
            public double QuantityVolume { get; set; }
            public double PriceUnit { get; set; }
            public double SubTotal { get; set; }
            public bool IsActive { get; set; }
            public DateTime CreationDate { get; set; }
            public string CreationBy { get; set; }
            public DateTime UpdateDate { get; set; }
            public string UpdateBy { get; set; }

        }
        
    }
}
