using FrancoHandling_Lib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrancoHandling_Lib
{
    public class UnloadingEntity
    {
        public static List<UnloadingModel.UnloadingList> GetUnloadingList()
        {
            return DbTransaction.DbToList<UnloadingModel.UnloadingList>("sp_GetUnloadingList", true);
        }

        public static UnloadingModel.UnloadingDetail GetUnloadingDetail(Int64 lo_ID)
        {
            return DbTransaction.DbToList<UnloadingModel.UnloadingDetail>("sp_GetUnloadingDetail", new { LO_ID = lo_ID }, true)[0];
        }

        public static string SubmitUnloading(UnloadingModel.UnloadingDetail item)
        {
            string res = DbTransaction.DbToString("sp_SubmitUnloading",
                            new
                            {
                                LO_ID = item.LO_ID,
                                UnloadingDate = item.UnloadingDate,
                                MeasurementMethods = item.MeasurementMethods,
                                EIJKBautHeight = item.EIJKBautHeight,
                                EIJKBautActual = item.EIJKBautActual,
                                SensitivityVolume = item.SensitivityVolume,
                                ReceiptVolume = item.ReceiptVolume,
                                UnloadingNote = item.UnloadingNote,
                                BASTNumber = item.BASTNumber,
                                BASTFileName = item.BASTFileName,
                                BASTFileBytes = item.BASTFileBytes,
                                CreationBy = item.CreationBy
                            }, true);

            return res;
        }
    }
}
