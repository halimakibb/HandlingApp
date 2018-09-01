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
    public partial class InputLO : System.Web.UI.Page {

        List<LOModel.LOList> liLOList
        {
            get { return Newtonsoft.Json.JsonConvert.DeserializeObject<List<LOModel.LOList>>(hf.Contains("liLOList") ? (string)hf["liLOList"] : string.Empty); }
            set { hf["liLOList"] = Newtonsoft.Json.JsonConvert.SerializeObject(value); }
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
                LoadInitLOList();
                LoadInitCmb();
            }
            else if (IsPostBack && !IsCallback)
            {
                LoadInitCmb();
            }
        }
        
        private void LoadInitLOList()
        {
            liLOList = LOEntity.GetLOList();

            var arrLOList = liLOList.GroupBy(x => new { x.SPPB_ID, x.NoSPP });

            litLOList.Text = string.Empty;

            foreach (var itemGroup in arrLOList)
            {
                Int64 sppbID = itemGroup.Key.SPPB_ID;
                string sppbNo = itemGroup.Key.NoSPP;

                litLOList.Text += @"
                                    <div class=""panel-group"" id=""accordion" + sppbID.ToString() + @""">
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
                    litLOList.Text += @"
                                                <button type = ""button"" class=""btn btn-default"" style=""min-width:200px; margin:0 10px"" onclick=""cpLODetail.PerformCallback('" + item.Item_ID + "|" + item.ItemDesc + "|" + item.TBBMName + "|" + item.SPSHName + "|" + item.QuantityVolume + "|" + sppbID.ToString() + @"');"">
                                                    <strong>" + item.ItemDesc + @"</strong><br /><span class='glyphicon glyphicon-send'></span><br />" + item.TBBMName + @"<br /><span class='glyphicon glyphicon-arrow-down'></span><br />" + item.SPSHName
                                               + "</button>";
                }


                litLOList.Text += @"                            
                                            </div>
                                        </div>
                                      </div>
                                    </div>
                                 ";


            }

        }

        private void SearchLOList(string searchTxt)
        {
            var arrLOList = liLOList.Where(x=>x.NoSPP.ToLower().Contains(searchTxt.ToLower())).GroupBy(x => new { x.SPPB_ID, x.NoSPP });

            litLOList.Text = string.Empty;

            foreach (var itemGroup in arrLOList)
            {
                Int64 sppbID = itemGroup.Key.SPPB_ID;
                string sppbNo = itemGroup.Key.NoSPP;

                litLOList.Text += @"
                                    <div class=""panel-group"" id=""accordion" + sppbID.ToString() + @""">
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
                    litLOList.Text += @"
                                                <button type = ""button"" class=""btn btn-default"" style=""min-width:200px; margin:0 10px"" onclick=""cpLODetail.PerformCallback('" + item.Item_ID + "|" + item.ItemDesc + "|" + item.TBBMName + "|" + item.SPSHName + "|" + item.QuantityVolume + "|" + sppbID.ToString() + @"');"">
                                                    <strong>" + item.ItemDesc + @"</strong><br /><span class='glyphicon glyphicon-send'></span><br />" + item.TBBMName + @"<br /><span class='glyphicon glyphicon-arrow-down'></span><br />" + item.SPSHName
                                               + "</button>";
                }


                litLOList.Text += @"                            
                                            </div>
                                        </div>
                                      </div>
                                    </div>
                                 ";


            }

        }

        private void GetDataCmb()
        {
            liTransporter = MasterDataEntity.GetMasterDataTransporter_CMB();
            liVehicleType = MasterDataEntity.GetMasterDataVehicleType_CMB(0);
            liVehicleNumber = MasterDataEntity.GetMasterDataVehicleNumber_CMB(0,0);
            liDriver = MasterDataEntity.GetMasterDataDriver_CMB();
        }

        private void LoadInitCmb()
        {
            GetDataCmb();

            cmbTransporter.DataSource = liTransporter;
            cmbTransporter.DataBind();
            
            cmbVehicleType.DataSource = liVehicleType;
            cmbVehicleType.DataBind();
            
            cmbVehicleNumber.DataSource = liVehicleNumber;
            cmbVehicleNumber.DataBind();
            
            cmbDriver.DataSource = liDriver;
            cmbDriver.DataBind();
        }

        protected void cpLODetail_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            string[] param = e.Parameter.Split('|');
            Int64 itemID = Convert.ToInt64(param[0]);
            string itemDesc = param[1];
            string tbbmName = param[2];
            string spshName = param[3];
            int quantityVolume = Convert.ToInt32(param[4]);
            Int64 sppb_ID = Convert.ToInt64(param[5]);

            lblItemDesc.Text = itemDesc;
            lblTBBMName.Text = tbbmName;
            lblSPSHName.Text = spshName;
            hf["qty"] = quantityVolume;
            hf["itemID"] = itemID;

            LOModel.LO loDetail = LOEntity.GetLODetail(sppb_ID);

            cmbTransporter.DataSource = liTransporter;
            cmbTransporter.DataBind();

            if(loDetail != null)
            {
                if (loDetail.Transporter_ID != 0)
                {
                    cmbTransporter.Value = loDetail.Transporter_ID;

                    if (loDetail.Type_ID != 0)
                    {
                        cmbVehicleType.ClientEnabled = true;
                        cmbVehicleType.DataSource = liVehicleType.Where(x => x.Transporter_ID == loDetail.Transporter_ID).GroupBy(x => new { x.Type_ID, x.VehicleType }).Select(x => x.First()).Distinct().ToList();
                        cmbVehicleType.DataBind();

                        cmbVehicleType.Value = loDetail.Type_ID;

                        if (loDetail.Vehicle_ID != 0)
                        {
                            cmbVehicleNumber.ClientEnabled = true;
                            cmbVehicleNumber.DataSource = liVehicleNumber.Where(x => x.Transporter_ID == loDetail.Transporter_ID && x.Type_ID == loDetail.Type_ID).ToList();
                            cmbVehicleNumber.DataBind();

                            cmbVehicleNumber.Value = loDetail.Vehicle_ID;
                        }
                    }

                    if (loDetail.Driver_ID != 0)
                    {
                        cmbDriver.ClientEnabled = true;
                        cmbDriver.DataSource = liDriver.Where(x => x.Transporter_ID == loDetail.Transporter_ID).ToList();
                        cmbDriver.DataBind();

                        cmbDriver.Value = loDetail.Driver_ID;
                    }
                }
            }

            cpLODetail.ClientVisible = true;
        }

        protected void cmbVehicleType_Callback(object sender, CallbackEventArgsBase e)
        {
            int transporter_ID = Convert.ToInt32(e.Parameter);
            int quantityVolume = Convert.ToInt32(hf["qty"].ToString());

            cmbVehicleType.DataSource = liVehicleType.Where(x => x.Transporter_ID == transporter_ID).GroupBy(x => new { x.Type_ID, x.VehicleType }).Select(x => x.First()).Distinct().ToList();
            cmbVehicleType.DataBind();   
        }

        protected void cmbVehicleNumber_Callback(object sender, CallbackEventArgsBase e)
        {
            int transporter_ID = Convert.ToInt32(e.Parameter.Split('|')[0]);
            Int16 vehicleType_ID = Convert.ToInt16(e.Parameter.Split('|')[1]);

            cmbVehicleNumber.DataSource = liVehicleNumber.Where(x => x.Transporter_ID == transporter_ID && x.Type_ID == vehicleType_ID).ToList();
            cmbVehicleNumber.DataBind();
        }

        protected void cmbDriver_Callback(object sender, CallbackEventArgsBase e)
        {
            int transporter_ID = Convert.ToInt32(e.Parameter);

            cmbDriver.DataSource = liDriver.Where(x => x.Transporter_ID == transporter_ID).ToList();
            cmbDriver.DataBind();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Alert alert = new Alert();

            try
            {

                LOModel.LO item = new LOModel.LO();
                item.SPP_Items_ID = Convert.ToInt64(hf["itemID"]);
                item.Transporter_ID = Convert.ToInt32(cmbTransporter.Value);
                item.Vehicle_ID = Convert.ToInt32(cmbVehicleNumber.Value);
                item.Driver_ID = Convert.ToInt32(cmbDriver.Value);
                item.DeliveryNote = txtDONote.Text;
                item.NoLO = "0";    //txtLO.Text;
                item.LODate = Convert.ToDateTime("1900/01/01"); // deLO.Date;
                item.NoDO = txtDO.Text;
                item.DODate = deDO.Date == DateTime.MinValue ? Convert.ToDateTime("1/1/1900") : deDO.Date;
                item.CustomerPO_Number = txtPO.Text;
                item.CustomerDate = dePO.Date == DateTime.MinValue ? Convert.ToDateTime("1/1/1900") : dePO.Date;
                item.OrderNumber = txtOrder.Text;
                item.OrderDate = deOrder.Date == DateTime.MinValue ? Convert.ToDateTime("1/1/1900") : deOrder.Date;
                item.CreationBy = UserProfile.Username;

                string res = LOEntity.SubmitLO(item);

                if ( res.ToLower().Contains("success"))
                    alert.MessageString("success", res, Page, GetType());
                else
                    alert.MessageString("error", res, Page, GetType());

                ASPxEdit.ClearEditorsInContainer(Page, true);
                cpLODetail.ClientVisible = false;
                cpLOList.ClientVisible = true;

                LoadInitLOList();

                //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "RefreshLOlist", "cpLOList.PerformCallback();", true);

            }
            catch (Exception ex)
            {
                alert.MessageString("error", ex.Message, Page, GetType());
            }
            
            
        }

        protected void cpLOList_Callback(object sender, CallbackEventArgsBase e)
        {
            SearchLOList(e.Parameter);
        }
    }
}