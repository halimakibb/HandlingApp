using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrancoHandling_Lib;
using FrancoHandling_Lib.Model;


namespace FrancoHandling_Lib.Entity
{
    public class InvoiceEntity
    {
        public List<InvoiceModel.InvoiceHeader> GetInvoice_Header()
        {
            return DbTransaction.DbToList<InvoiceModel.InvoiceHeader>("dbo.sp_GetInvoice_Header", true);
        }

        public List<InvoiceModel.InvoiceHeader> GetInvoice_Header(string InvoiceNumber)
        {
            return DbTransaction.DbToList<InvoiceModel.InvoiceHeader>("dbo.sp_GetInvoice_HeaderByNumber", new { InvoiceNumber = InvoiceNumber }, true);
        }

        public List<LOModel.LOItem> GetLO_ToInvoice()
        {
            return DbTransaction.DbToList<LOModel.LOItem>("dbo.sp_GetLO_ToInvoice", true);
        }

        public List<InvoiceModel.InvoiceReport> GetInvoice_Report(string Year)
        {
            return DbTransaction.DbToList<InvoiceModel.InvoiceReport>("dbo.sp_GetInvoice_Report", new { Year = Year }, true);
        }

    }
}
