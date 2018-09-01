using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FrancoHandling_App.Code;
using System.Data;
using FrancoHandling_Lib;
using FrancoHandling_Lib.Model;
using FrancoHandling_Lib.Entity;
using DevExpress.Web;

namespace FrancoHandling_App.Pages
{
    public partial class InputUnloading : System.Web.UI.Page {
        List<UnloadingModel.UnloadingList> liUnloadingList
        {
            get { return Newtonsoft.Json.JsonConvert.DeserializeObject<List<UnloadingModel.UnloadingList>>(hf.Contains("liUnloadingList") ? (string)hf["liUnloadingList"] : string.Empty); }
            set { hf["liUnloadingList"] = Newtonsoft.Json.JsonConvert.SerializeObject(value); }
        }
        List<MasterDataModel.MasterDataTransporter> liTransporter
        {
            get { return Newtonsoft.Json.JsonConvert.DeserializeObject<List<MasterDataModel.MasterDataTransporter>>( hf.Contains("liTransporter") ? (string)hf["liTransporter"] : string.Empty); }
            set { hf["liTransporter"] = Newtonsoft.Json.JsonConvert.SerializeObject(value); }
        }

        List<MasterDataModel.MasterDataKendaraan> liVehicleType
        {
            get { return Newtonsoft.Json.JsonConvert.DeserializeObject<List<MasterDataModel.MasterDataKendaraan>>(hf.Contains("liVehicleType") ? (string)hf["liVehicleType"] : string.Empty); }
            set { hf["liVehicleType"] = Newtonsoft.Json.JsonConvert.SerializeObject(value); }
        }

        List<MasterDataModel.MasterDataKendaraan> liVehicleNumber
        {
            get { return Newtonsoft.Json.JsonConvert.DeserializeObject<List<MasterDataModel.MasterDataKendaraan>>(hf.Contains("liVehicleNumber") ? (string)hf["liVehicleNumber"] : string.Empty); }
            set { hf["liVehicleNumber"] = Newtonsoft.Json.JsonConvert.SerializeObject(value); }
        }

        List<MasterDataModel.MasterDataDriver> liDriver
        {
            get { return Newtonsoft.Json.JsonConvert.DeserializeObject<List<MasterDataModel.MasterDataDriver>>(hf.Contains("liDriver") ? (string)hf["liDriver"] : string.Empty); }
            set { hf["liDriver"] = Newtonsoft.Json.JsonConvert.SerializeObject(value); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && !IsCallback)
            {
                UserProfile.SetAuthorization(UserProfile.USER_INTERNAL);
                LoadInitUnloadingList();
            }
        }

        private void LoadInitUnloadingList()
        {
            liUnloadingList = UnloadingEntity.GetUnloadingList();

            var arrUnloadingList = liUnloadingList.GroupBy(x => new { x.SPPB_ID, x.NoSPP });

            litUnloadingList.Text = string.Empty;

            foreach (var itemGroup in arrUnloadingList)
            {
                Int64 sppbID = itemGroup.Key.SPPB_ID;
                string sppbNo = itemGroup.Key.NoSPP;

                litUnloadingList.Text += @"
                                    <div class=""panel-group"" id=""accordion"+ sppbID.ToString() + @""">
                                      <div class=""panel panel-default"">
                                        <div class=""panel-heading"">
                                          <h4 class=""panel-title"">
                                            <a class=""btn-block"" data-toggle=""collapse"" style=""color:#337AB7"" data-parent=""#accordion" + sppbID.ToString() + @""" href=""#collapse" + sppbID.ToString() + @""">
                                            <span class='glyphicon glyphicon-chevron-down'></span> " + sppbNo + @"</a>
                                          </h4>
                                        </div>
                                        <div id=""collapse" + sppbID.ToString() + @""" class=""panel-collapse collapse"">
                                            <div class=""panel-body"">
                                    ";

                foreach (var item in itemGroup)
                {
                    litUnloadingList.Text += @"
                                                <button type = ""button"" class=""btn btn-default"" style=""min-width:200px; margin:0 10px"" onclick=""cpUnloadingDetail.PerformCallback('"+item.Item_ID+"|"+item.ItemDesc+"|"+item.TBBMName+"|"+item.SPSHName+"|"+item.QuantityVolume+ "|" + item.LO_ID + @"');"">
                                                     <strong>" + item.NoDO + @"</strong><br /><span class='glyphicon glyphicon-download-alt'></span><br />" + item.ItemDesc+@"<br /><span class='glyphicon glyphicon-send'></span><br />"+item.TBBMName+@"<br /><span class='glyphicon glyphicon-arrow-down'></span><br />"+item.SPSHName
                                               +"</button>";
                }
                

                litUnloadingList.Text += @"                            
                                            </div>
                                        </div>
                                      </div>
                                    </div>
                                 ";


            }

        }

        private void SearchUnloadingList(string searchTxt)
        {
            string searchType = searchTxt.Split('|')[0];
            searchTxt = searchTxt.Split('|')[1];

            var arrUnloadingList = searchType == "SPPB" ? 
                                        liUnloadingList.Where(x => x.NoSPP.ToLower().Contains(searchTxt.ToLower())).GroupBy(x => new { x.SPPB_ID, x.NoSPP })
                                      : liUnloadingList.Where(x => x.NoDO.ToLower().Contains(searchTxt.ToLower())).GroupBy(x => new { x.SPPB_ID, x.NoSPP })
                                        ;

            litUnloadingList.Text = string.Empty;

            foreach (var itemGroup in arrUnloadingList)
            {
                Int64 sppbID = itemGroup.Key.SPPB_ID;
                string sppbNo = itemGroup.Key.NoSPP;

                litUnloadingList.Text += @"
                                    <div class=""panel-group"" id=""accordion" + sppbID.ToString() + @""">
                                      <div class=""panel panel-default"">
                                        <div class=""panel-heading"">
                                          <h4 class=""panel-title"">
                                            <a class=""btn-block"" data-toggle=""collapse"" style=""color:#337AB7"" data-parent=""#accordion" + sppbID.ToString() + @""" href=""#collapse" + sppbID.ToString() + @""">
                                            <span class='glyphicon glyphicon-chevron-down'></span> " + sppbNo + @"</a>
                                          </h4>
                                        </div>
                                        <div id=""collapse" + sppbID.ToString() + @""" class=""panel-collapse collapse"+ (searchType == "LO" ? " in" : "") + @""">
                                            <div class=""panel-body"">
                                    ";

                foreach (var item in itemGroup)
                {
                    litUnloadingList.Text += @"
                                                <button type = ""button"" class=""btn btn-default"" style=""min-width:200px; margin:0 10px"" onclick=""cpUnloadingDetail.PerformCallback('" + item.Item_ID + "|" + item.ItemDesc + "|" + item.TBBMName + "|" + item.SPSHName + "|" + item.QuantityVolume + "|" + item.LO_ID + @"');"">
                                                    <strong>" + item.NoDO + @"</strong><br /><span class='glyphicon glyphicon-download-alt'></span><br />" + item.ItemDesc + @"</strong><br /><span class='glyphicon glyphicon-send'></span><br />" + item.TBBMName + @"<br /><span class='glyphicon glyphicon-arrow-down'></span><br />" + item.SPSHName
                                               + "</button>";
                }


                litUnloadingList.Text += @"                            
                                            </div>
                                        </div>
                                      </div>
                                    </div>
                                 ";


            }

        }

        private void GetDataCmb()
        {
            liTransporter = MasterDataEntity.GetMasterDataTransporter_CMB(0);
            liVehicleType = MasterDataEntity.GetMasterDataVehicleType_CMB(0, 0);
            liVehicleNumber = MasterDataEntity.GetMasterDataVehicleNumber_CMB(0, 0);
            liDriver = MasterDataEntity.GetMasterDataDriver_CMB();
        }

        protected void cpUnloadingDetail_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            string[] param = e.Parameter.Split('|');
            Int64 itemID = Convert.ToInt64(param[0]);
            string itemDesc = param[1];
            string tbbmName = param[2];
            string spshName = param[3];
            Int64 quantityVolume = Convert.ToInt64(param[4]);
            Int64 lo_ID = Convert.ToInt64(param[5]);

            lblItemDesc.Text = itemDesc;
            lblTBBMName.Text = tbbmName;
            lblSPSHName.Text = spshName;
            
            hf["LO_ID"] = lo_ID;

            txtVolumePengiriman.Text = quantityVolume.ToString();
            seVolumePenerimaan.Value = quantityVolume;
            txtLosses.Text = "0";
            seVolumePenerimaan.MinValue = 0;
            seVolumePenerimaan.MaxValue = quantityVolume;

            UnloadingModel.UnloadingDetail detail = UnloadingEntity.GetUnloadingDetail(lo_ID);

            //txtNoLO.Text = detail.NoLO;
            //txtLODate.Text = detail.LODate.ToString("dd-MMM-yyyy");
            txtNoDO.Text = detail.NoDO;
            txtDODate.Text = detail.DODate.ToString("dd-MMM-yyyy");
            txtNoPO.Text = detail.NoPO;
            txtPODate.Text = detail.PODate.ToString("dd-MMM-yyyy");
            txtNoOrder.Text = detail.NoOrder;
            txtOrderDate.Text = detail.OrderDate.ToString("dd-MMM-yyyy");

            txtTransporter.Text = detail.TransporterName;
            txtVehicleType.Text = detail.VehicleType;
            txtDriver.Text = detail.DriverName;
            txtVehicleNumber.Text = detail.VehicleNumber;
            txtDONote.Text = detail.DONote;
            
            cpUnloadingDetail.ClientVisible = true;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Alert alert = new Alert();

            try
            {
                if (Session["BASTFileName"] != null && Session["BASTFileBytes"] != null)
                {
                    UnloadingModel.UnloadingDetail item = new UnloadingModel.UnloadingDetail();
                    item.LO_ID = Convert.ToInt64(hf["LO_ID"]);
                    item.UnloadingDate = deUnloading.Date == DateTime.MinValue ? Convert.ToDateTime("1/1/1900") : deUnloading.Date;
                    item.MeasurementMethods = txtMetodePengukuran.Text;
                    item.EIJKBautHeight = Convert.ToInt64(seTinggiEijkBoot.Value ?? 0);
                    item.EIJKBautActual = Convert.ToInt64(seAktualEijkBoot.Value ?? 0);
                    item.SensitivityVolume = Convert.ToInt64(seVolumeKepekaan.Value ?? 0);
                    item.ReceiptVolume = Convert.ToInt64(seVolumePenerimaan.Value ?? 0);
                    item.UnloadingNote = txtUnloadingNote.Text;
                    item.BASTNumber = txtNoBAST.Text;
                    item.CreationBy = UserProfile.Username;
                    
                    item.BASTFileName = Convert.ToString(Session["BASTFileName"]);
                    item.BASTFileBytes = (byte[])Session["BASTFileBytes"];
                    Session["BASTFileName"] = null;
                    Session["BASTFileBytes"] = null;


                    string res = UnloadingEntity.SubmitUnloading(item);

                    if (res.ToLower().Contains("success"))
                        alert.MessageString("success", res, Page, GetType());
                    else
                        alert.MessageString("error", res, Page, GetType());

                    ASPxEdit.ClearEditorsInContainer(Page, true);
                    cpUnloadingDetail.ClientVisible = false;
                    cpUnloadingList.ClientVisible = true;

                    LoadInitUnloadingList();
                }
                else
                    alert.MessageString("warning", "Upload BAST is required.", Page, GetType());
            }
            catch (Exception ex)
            {
                alert.MessageString("error", ex.Message, Page, GetType());
            }
            
            
        }

        protected void cpUnloadingList_Callback(object sender, CallbackEventArgsBase e)
        {
            SearchUnloadingList(e.Parameter);
        }

        protected void ucBAST_FileUploadComplete(object sender, FileUploadCompleteEventArgs e)
        {
            Session["BASTFileName"] = e.UploadedFile.FileName;
            Session["BASTFileBytes"] = e.UploadedFile.FileBytes;
            e.CallbackData = e.UploadedFile.FileName;
        }
    }
}