using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrancoHandling_Lib.Model;

namespace FrancoHandling_Lib.Entity
{
    public class SP3MEntity
    {
        public List<SP3MModel.SP3MRealization> GetRealization(string Year)
        {
            return DbTransaction.DbToList<SP3MModel.SP3MRealization>("dbo.sp_GetRealization_Report", new { Year = Year }, true);
        }
    }
}
