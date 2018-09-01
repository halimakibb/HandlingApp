using FrancoHandling_Lib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrancoHandling_Lib.Entity
{
    public class LOEntity
    {
        public static List<LOModel.LOList> GetLOList()
        {
            return DbTransaction.DbToList<LOModel.LOList>("sp_GetLOList", true);
        }

        public static string SubmitLO(LOModel.LO item)
        {
            string res = DbTransaction.DbToString("sp_SubmitLO",
                            new
                            {
                                SPP_Items_ID = item.SPP_Items_ID,
                                Transporter_ID = item.Transporter_ID,
                                Vehicle_ID = item.Vehicle_ID,
                                Driver_ID = item.Driver_ID,
                                NoLo = item.NoLO,
                                LODate = item.LODate,
                                NoDO = item.NoDO,
                                DODate = item.DODate,
                                CustomerPO_Number = item.CustomerPO_Number,
                                CustomerDate = item.CustomerDate,
                                OrderNumber = item.OrderNumber,
                                OrderDate = item.OrderDate,
                                DeliveryNote = item.DeliveryNote,
                                CreationBy = item.CreationBy
                            }, true);

            return res;
        }

        public static List<LOModel.LO> GetLO()
        {
            return DbTransaction.DbToList<LOModel.LO>("dbo.sp_GetLO_CMB", true);
        }

        public static LOModel.LO GetLODetail(Int64 spp_ID)
        {
            List<LOModel.LO> li = DbTransaction.DbToList<LOModel.LO>("sp_GetLODetail", new { SPP_ID = spp_ID }, true);

            return li.Count>0 ? li[0] : null;
        }
    }
}
