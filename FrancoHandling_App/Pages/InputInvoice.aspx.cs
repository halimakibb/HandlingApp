using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using FrancoHandling_Lib;
using FrancoHandling_Lib.Model;
using FrancoHandling_Lib.Entity;
using DevExpress.Web.Bootstrap;
using DevExpress.Web;

namespace FrancoHandling_App.Pages
{
    public partial class InputInvoice : System.Web.UI.Page
    {
        Alert alert = new Alert();
        string ResponseQuery = string.Empty;
        List<InvoiceModel.InvoiceHeader> ListInvoice= new List<InvoiceModel.InvoiceHeader>();
        List<InvoiceModel.InvoiceItem> ListInvoiceItem = new List<InvoiceModel.InvoiceItem>();
        InvoiceEntity GetDataInvoice = new InvoiceEntity();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Header.DataBind();

            if (!Page.IsPostBack)
            {
                //set autorization page
                UserProfile.SetAuthorization(new string[] { UserProfile.USER_INTERNAL });

                //set invoice parameter
                hfInvoiceType.Value = (string)Request.QueryString["InvoiceType"] ?? "0";
                hfInvoiceNumber.Value = (string)Request.QueryString["InvoiceNumber"] ?? string.Empty;
                hfStatus.Value = string.IsNullOrEmpty((string)Request.QueryString["Status"]) ? string.Empty : Request.QueryString["Status"].ToUpper();
                
                //set data on load
                SetDataOnoad(hfInvoiceNumber.Value.ToString());
            }
        }

        protected void SetEnabled(bool Enable)
        {
            if (Enable)
            {
                txtInvoiceNumber.ClientEnabled = true;
                dateInvoice.ClientEnabled = true;
                txtNote.ClientEnabled = true;
                txtApproveBy.ClientEnabled = true;
                gridInvoiceItem.Enabled = true;
                gridInvoiceItem.Columns["CmdInvoiceItem"].Visible = true;
                btnAdd.ClientEnabled = true;
                btnSaveHeader.ClientEnabled = true;
                btnSave.ClientVisible = true;
                btnSubmit.ClientVisible = true;
                btnClose.ClientVisible = true;
            }
            else
            {
                txtInvoiceNumber.ClientEnabled = false;
                dateInvoice.ClientEnabled = false;
                txtNote.ClientEnabled = false;
                txtApproveBy.ClientEnabled = false;
                gridInvoiceItem.Enabled = false;
                gridInvoiceItem.Columns["CmdInvoiceItem"].Visible = false;
                btnAdd.ClientEnabled = false;
                btnSaveHeader.ClientEnabled = false;
                btnSave.ClientVisible = false;
                btnSubmit.ClientVisible = false;
                btnClose.ClientVisible = true;
            }
        }

        protected void SetEnabledButton(List<MasterDataModel.MasterDataRole> Roles, string Status)
        {
            foreach (MasterDataModel.MasterDataRole role in Roles)
            {
                if ((role.RoleName == UserProfile.USER_INTERNAL && Status.Contains("SAVED")) 
                    || (hfInvoiceType.Value == "0" && string.IsNullOrEmpty(hfStatus.Value.ToString())))
                {
                    btnAdd.ClientVisible = true;
                    btnSaveHeader.ClientVisible = true;
                    btnSave.ClientVisible = true;
                    btnSubmit.ClientVisible = true;
                    return;
                }                
                else
                {
                    btnAdd.ClientVisible = false;
                    btnSaveHeader.ClientVisible = false;
                    btnSave.ClientVisible = false;
                    btnSubmit.ClientVisible = false;
                }
            }
        }

        protected void SetDataOnoad(string InvoiceNumber)
        {
            //set data invoice by invoice id
            ListInvoice = GetDataInvoice.GetInvoice_Header(InvoiceNumber ?? string.Empty);
            foreach(InvoiceModel.InvoiceHeader item in ListInvoice)
            {
                txtInvoiceNumber.Text = item.InvoiceNumber;
                txtApproveBy.Text = item.ApproveBy ?? string.Empty;
                txtNote.Text = item.Note ?? string.Empty;
                
                if (item.InvoiceDate != DateTime.Parse("1/1/1900"))
                    dateInvoice.Value = item.InvoiceDate;
                else
                    dateInvoice.Value = null;

                break;
            }

            //set gridview LO as Invoice Item
            gridInvoiceItem.DataBind();

            //set invoice is editable
            if (hfStatus.Value.ToString().Contains("SAVED"))
            {
                SetEnabled(true);
                SetEnabledButton(UserProfile.Roles, hfStatus.Value.ToString());
            }
            else
            {
                //new entry
                if (string.IsNullOrEmpty(hfInvoiceNumber.Value.ToString()))
                {
                    SetEnabled(true);
                    SetEnabledButton(UserProfile.Roles, hfStatus.Value.ToString());
                }
                else
                {
                    SetEnabled(false);
                    SetEnabledButton(UserProfile.Roles, hfStatus.Value.ToString());
                }
            }

        }

        protected List<InvoiceModel.InvoiceItem> GetDatainvoiceItem(string InvoiceNumber)
        {
            ListInvoiceItem = DbTransaction.DbToList<InvoiceModel.InvoiceItem>("dbo.sp_GetInvoice_Items", new { InvoiceNumber = InvoiceNumber }, true);                
            return ListInvoiceItem;
        }
        
        protected void btnSaveHeader_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtInvoiceNumber.Text)
                || string.IsNullOrEmpty(dateInvoice.Text))
            {
                alert.MessageString(Alert.WARNING, "Simpan Invoice", "Please Input Mandatory Fields", Page, GetType());
                return;
            }

            try
            {
                ResponseQuery = DbTransaction.DbToString("dbo.sp_AddInvoice_Header", new { 
                    Type = hfInvoiceType.Value,
                    InvoiceNumber = txtInvoiceNumber.Text,
                    InvoiceDate = dateInvoice.Date == DateTime.MinValue ? Convert.ToDateTime("1/1/1900") : dateInvoice.Date,
                    ApproveBy = txtApproveBy.Text,
                    Note = txtNote.Text,
                    Status = 1,
                    Username = UserProfile.Username,
                    InvoiceId = 0
                }, true);

                //show notification
                if (ResponseQuery.Contains("Success"))
                    alert.MessageString(Alert.SUCCESS, "Simpan Invoice", ResponseQuery, this.Page, GetType());
                else
                    alert.MessageString(Alert.WARNING, "Simpan Invoice", ResponseQuery, this.Page, GetType());
            }
            catch (Exception ex)
            {
                alert.MessageString(Alert.ERROR, "Simpan Invoice", ex.Message, this.Page, GetType());
            }
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //initialize invoice item
                string InvoiceItem = string.Empty;
                ListInvoiceItem = GetDatainvoiceItem(txtInvoiceNumber.Text ?? string.Empty);

                //warning if invoice item is empty
                if (ListInvoiceItem.Count == 0)
                {
                    alert.MessageString(Alert.WARNING, "Simpan Invoice", "Data Invoice Item belum diinput", this.Page, GetType());
                    return;
                }

                //get data invoice item
                foreach (InvoiceModel.InvoiceItem item in ListInvoiceItem)
                {
                    InvoiceItem += string.Format("{0}|", item.LO_ID);
                }

                //set product item
                if (!string.IsNullOrEmpty(InvoiceItem))
                    InvoiceItem = InvoiceItem.Remove(InvoiceItem.Length - 1);

                //insert data to database
                ResponseQuery = DbTransaction.DbToString("dbo.sp_AddInvoice", new
                {
                    Type = hfInvoiceType.Value
                    ,InvoiceNumber = txtInvoiceNumber.Text
                    ,ApproveBy = txtApproveBy.Text ?? string.Empty
                    ,InvoiceDate = dateInvoice.Date == DateTime.MinValue ? Convert.ToDateTime("1/1/1900") : dateInvoice.Date
                    ,Note = txtNote.Text ?? string.Empty
                    ,Status = 1
                    ,Userlogin = UserProfile.Username
                    ,InvoiceItem = InvoiceItem
                }, true);

                //show notification
                if (ResponseQuery.Contains("Success"))
                    alert.MessageString(Alert.SUCCESS, "Simpan Invoice", ResponseQuery, this.Page, GetType());
                else
                    alert.MessageString(Alert.WARNING, "Simpan Invoice", ResponseQuery, this.Page, GetType());
            }
            catch (Exception ex)
            {
                alert.MessageString(Alert.ERROR, "Simpan Invoice", ex.Message, Page, GetType());
            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                //insert data to database
                ResponseQuery = DbTransaction.DbToString("dbo.sp_SubmitInvoice", new
                {
                    @InvoiceNumber = txtInvoiceNumber.Text,
                    Userlogin = UserProfile.Username
                }, true);

                //show notification
                if (ResponseQuery.Contains("Success"))
                {
                    alert.MessageString(Alert.SUCCESS, "Submit Invoice Item", ResponseQuery, this.Page, GetType());
                    hfStatus.Value = "Submit";
                    SetDataOnoad(txtInvoiceNumber.Text);      
                }
                else
                    alert.MessageString(Alert.WARNING, "Submit Invoice Item", ResponseQuery, this.Page, GetType());
            }
            catch(Exception ex)
            {
                alert.MessageString(Alert.ERROR, ex.Message, Page, GetType());
            }
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/ListInvoice.aspx", false);
        }        

        protected void gridInvoiceItem_DataBinding(object sender, EventArgs e)
        {
            string InvoiceNumber = txtInvoiceNumber.Text ?? string.Empty;
            gridInvoiceItem.DataSource = GetDatainvoiceItem(InvoiceNumber);
        }
            
        protected void gridAddLO_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            if (e.Parameters == "Checked")
            {
                //initialize variable
                string InvoiceItem = string.Empty;
                string NoDO = string.Empty;
                float? Product_ID;
                string ProductName = string.Empty;
                float? QuantityVolume;
                float? PriceUnit;
                string strItem = string.Empty;
                List<Object> SelectItems = gridAddLO.GetSelectedFieldValues("LO_ID");
                foreach (object LoID in SelectItems)
                {
                    //set item selected
                    NoDO = gridAddLO.GetRowValuesByKeyValue(LoID, "NoDO").ToString();
                    Product_ID = Convert.ToInt16(gridAddLO.GetRowValuesByKeyValue(LoID, "Product_ID").ToString());
                    ProductName = gridAddLO.GetRowValuesByKeyValue(LoID, "ProductName").ToString();
                    QuantityVolume = Convert.ToInt32(gridAddLO.GetRowValuesByKeyValue(LoID, "QuantityVolume").ToString());
                    PriceUnit = Convert.ToInt64(gridAddLO.GetRowValuesByKeyValue(LoID, "PriceUnit").ToString());

                    //string item
                    strItem = LoID.ToString() + ';' + NoDO + ';' + Product_ID + ';' + QuantityVolume + ';' + PriceUnit;

                    ////add data to list
                    //ListInvoiceItem.Add(new InvoiceModel.InvoiceItem
                    //{
                    //    LO_ID = Convert.ToInt16(item),
                    //    NoLO = NoLO,
                    //    Product_ID = Convert.ToInt16(Product_ID),
                    //    ProductName = ProductName,
                    //    QuantityVolume = Convert.ToInt32(QuantityVolume),
                    //    PriceUnit = Convert.ToInt64(PriceUnit)
                    //});

                    //concatenate data LO
                    InvoiceItem += string.Format("{0}|", strItem);
                }

                //set product item
                if (!string.IsNullOrEmpty(InvoiceItem))
                    InvoiceItem = InvoiceItem.Remove(InvoiceItem.Length - 1);

                //insert data to database
                ResponseQuery = DbTransaction.DbToString("dbo.sp_AddInvoice_Item", new
                {
                    Type = hfInvoiceType.Value,
                    InvoiceNumber = txtInvoiceNumber.Text,
                    ApproveBy = txtApproveBy.Text ?? string.Empty,
                    InvoiceDate = dateInvoice.Date == DateTime.MinValue ? Convert.ToDateTime("1/1/1900") : dateInvoice.Date,
                    Note = txtNote.Text ?? string.Empty,
                    Status = 1,
                    Userlogin = UserProfile.Username,
                    InvoiceItem = InvoiceItem
                }, true);

                //show notification
                gridAddLO.JSProperties["cpRes"] = ResponseQuery;
            }
        }
        
        protected void popupAddLO_Load(object sender, EventArgs e)
        {
            try
            {
                //gridAddLO.DataSource = GetDataInvoice.GetLO_ToInvoice();
                gridAddLO.DataBind();                
            }
            catch (Exception ex)
            {
                alert.MessageString(Alert.ERROR, ex.Message, Page, GetType());
            }
        }

        protected void gridInvoiceItem_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            try
            {
                int key = Convert.ToInt16(e.Keys[0]);
                BootstrapPopupControl popup = popupAddLO;
                BootstrapGridView grid = (BootstrapGridView)popup.FindControl("gridAddLO");

                //execute data to database
                ResponseQuery = DbTransaction.DbToString("dbo.sp_DeleteInvoice_Item", new
                {
                    InvoiceNumber = txtInvoiceNumber.Text,
                    LO_ID = key,
                    userlogin = UserProfile.Username
                }, true);

                //set gridview invoice item
                e.Cancel = true;
                gridInvoiceItem.DataBind();

                //show notification
                gridInvoiceItem.JSProperties["cpRes"] = ResponseQuery;
            }
            catch(Exception ex)
            {
                gridInvoiceItem.JSProperties["cpRes"] = ex.Message;
            }
        }
     
        protected void gridAddLO_DataBinding(object sender, EventArgs e)
        {
            gridAddLO.DataSource = GetDataInvoice.GetLO_ToInvoice();
            ListInvoiceItem = GetDatainvoiceItem(txtInvoiceNumber.Text ?? string.Empty);

            if (ListInvoiceItem.Count == 0)
                gridAddLO.Selection.UnselectAll();
            else
            {
                foreach (InvoiceModel.InvoiceItem item in ListInvoiceItem)
                {
                    if (ListInvoiceItem.FirstOrDefault() == item)
                        gridAddLO.Selection.UnselectAll();

                    gridAddLO.Selection.SelectRowByKey(item.LO_ID);
                }
            }
        }
        
        protected void popupAddLO_Callback(object sender, CallbackEventArgsBase e)
        {           
            try
            {
                 if(e.Parameter=="Load")
                 {
                     gridAddLO.DataBind();
                 }
                
            }
            catch (Exception ex)
            {
                alert.MessageString(Alert.ERROR, ex.Message, Page, GetType());
            }
        }

        protected void gridInvoiceItem_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            try
            {                
                //update list
                int LoID = Convert.ToInt16(e.Keys[0]);
                int ProdukID = Convert.ToInt16(e.Keys[1]);
                ResponseQuery = DbTransaction.DbToString("dbo.sp_EditInvoice_Items", new
                {
                    InvoiceNumber = txtInvoiceNumber.Text,
                    @Lo_ID_FK = LoID,
                    @Product_ID_FK = ProdukID,
                    @Price = Convert.ToInt32(e.NewValues["PriceUnit"]),                    
                    Userlogin = UserProfile.Username
                }, true);

                //set gridview invoice item
                e.Cancel = true;
                //gridInvoiceItem.DataBind();
                gridInvoiceItem.CancelEdit();

                //show notification
                gridInvoiceItem.JSProperties["cpRes"] = ResponseQuery;
            }
            catch (Exception ex)
            {
                gridInvoiceItem.JSProperties["cpRes"] = ex.Message;
            }
        }
    }
}