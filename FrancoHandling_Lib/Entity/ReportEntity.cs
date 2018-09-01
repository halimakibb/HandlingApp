using System;
using System.Data;
using System.Collections.Generic;
using FrancoHandling_Lib.Model;

namespace FrancoHandling_Lib.Entity
{
    public class ReportEntity
    {
        public List<ReportModel.OAT> GetDataOAT(DateTime PeriodeStart, DateTime PeriodeEnd, Int32 TBBM, string Force, string Unity)
        {
            List<ReportModel.OAT> list = new List<ReportModel.OAT>();
            list = DbTransaction.DbToList<ReportModel.OAT>("dbo.sp_RepOAT_Transporter", 
                new {
                    Start = PeriodeStart,
                    End = PeriodeEnd,
                    TBBM = TBBM,
                    Force = Force,
                    Unity = Unity
                }, true);
            return list;
        }

        public DataTable GetDataReportOAT(DateTime PeriodeStart, DateTime PeriodeEnd, Int32 TBBM, string Force, string Unity)
        {
            return DbTransaction.DbToDataTable("dbo.sp_RepOAT_Transporter",
                new
                {
                    Start = PeriodeStart,
                    End = PeriodeEnd,
                    TBBM = TBBM,
                    Force = Force,
                    Unity = Unity
                }, true);
        }

        public DataTable GetDataReportHandlingFee(DateTime PeriodeStart, DateTime PeriodeEnd, Int32 TBBM, string Force, string Unity)
        {
            return DbTransaction.DbToDataTable("dbo.sp_RepHandlingFee",
                new
                {
                    Start = PeriodeStart,
                    End = PeriodeEnd,
                    TBBM = TBBM,
                    Force = Force,
                    Unity = Unity
                }, true);
        }

        public string GetRegion (string TBBM_ID)
        {
            return DbTransaction.DbToString(@"SELECT r.Description FROM tblM_TBBM tbbm
INNER JOIN tblM_Region r ON r.Region_ID_PK = tbbm.Region_ID_FK AND r.IsActive = 1
WHERE TBBM_ID_PK = @TBBM_ID_PK", new { TBBM_ID_PK = TBBM_ID }, false);
        }
    }
}
