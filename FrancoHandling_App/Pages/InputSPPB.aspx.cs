using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using FrancoHandling_Lib.Model;
using FrancoHandling_Lib;
using FrancoHandling_Lib.Entity;


namespace FrancoHandling_App.Pages
{
    public partial class InputSPPB : System.Web.UI.Page
    {
        int SPP_ID = 0;
        string NoSPP = string.Empty;
        string StatusSPP = string.Empty;
        string ResponseQuery = string.Empty;
        string JsonProductItem = string.Empty;
        Alert alert = new Alert();


        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Header.DataBind();

            if (!Page.IsPostBack)
            {
                //clear session
                //Session.Remove("force");
                //Session.Remove("unity");
                Session.Remove("driver");
                Session.Remove("vehicle");

                //set autorization page
                UserProfile.SetAuthorization(new string[] { UserProfile.USER_EKSTERNAL, UserProfile.USER_INTERNAL });

                //set spp id and spp number
                NoSPP = string.Empty;
                SPP_ID = string.IsNullOrEmpty((string)Request.QueryString["SPP_ID"]) ? 0 : Convert.ToInt16(Request.QueryString["SPP_ID"]);
                StatusSPP = string.IsNullOrEmpty((string)Request.QueryString["StatusDesc"]) ? string.Empty : Request.QueryString["StatusDesc"].ToString().ToUpper();

                //binding spp control
                SetDataOnLoad();
                BindingSPP(SPP_ID);

                ////set grid product spp
                //gvProductSP3M.DataSource = ListProductSP3M(SP3M_ID);
                //gvProductSP3M.DataBind();

                //set sp3m is editable
                if (StatusSPP.Contains("SAVED"))
                {
                    SetEnabled(true);
                    SetEnabledButton(UserProfile.Roles, StatusSPP);
                    btnClose.ClientVisible = true;
                    btnCancel.ClientVisible = false;
                }
                else
                {
                    //new entry
                    if (SPP_ID == 0)
                    {
                        SetEnabled(true);
                        SetEnabledButton(UserProfile.Roles, StatusSPP);
                    }
                    else
                    {
                        SetEnabled(false);
                        SetEnabledButton(UserProfile.Roles, StatusSPP);
                    }
                }
            }
        }


        protected void SetDataOnLoad()
        {
            //set sp3m
            cmbSP3M.DataSource = ListSP3M();
            cmbSP3M.DataBind();

            //set tbbm
            cmbDeliveryFrom.DataSource = ListTBBM();
            cmbDeliveryFrom.DataBind();

            //set transporter
            cmbTransporter.DataSource = ListTransporter();
            cmbTransporter.DataBind();

            //set spsh
            cmbDeliveryTo.DataSource = ListSPSH();
            cmbDeliveryTo.DataBind();
            
            //set vehiclenumber
            cmbVehicleNumber.DataSource = ListVehicle(null);
            cmbVehicleNumber.DataBind();

            //set driver
            cmbDriver.DataSource = ListDriver(null);
            cmbDriver.DataBind();
        }

        protected void SetEnabled(bool Enable)
        {
            if (Enable)
            {
                txtSPP_Number.ClientEnabled = true;
                txtForce.ClientEnabled = true;
                txtUnity.ClientEnabled = true;
                txtSA_Number.ClientEnabled = true;
                txtSP2M_Number.ClientEnabled = true;
                txtNote.ClientEnabled = true;
                cmbSP3M.ClientEnabled = true;
                gvProductSP3M.Enabled = true;
                gvProductSP3M.Columns["CommandColumnProduct"].Visible = true;
                cmbTransporter.ClientEnabled = true;
                //if (cmbDriver != null) cmbDriver.ClientVisible = true;
                //if (cmbVehicleNumber != null) cmbVehicleNumber.ClientVisible = true;
                //if (txtDriver != null) txtDriver.ClientVisible = false;
                //if (txtVehicleNumber != null) txtVehicleNumber.ClientVisible = false;
                dateDelivery.ClientEnabled = true;
                cmbDeliveryFrom.ClientEnabled = true;
                cmbDeliveryTo.ClientEnabled = true;
                txtAddressFrom.ClientEnabled = true;
                txtAddressTo.ClientEnabled = true;
                btnSave.ClientVisible = true;
                btnSubmit.ClientVisible = true;
                btnCancel.ClientVisible = true;
                btnClose.ClientVisible = false;
            }
            else
            {
                txtSPP_Number.ClientEnabled = false;
                txtForce.ClientEnabled = false;
                txtUnity.ClientEnabled = false;
                txtSA_Number.ClientEnabled = false;
                txtSP2M_Number.ClientEnabled = false;
                txtNote.ClientEnabled = false;
                cmbSP3M.ClientEnabled = false;
                gvProductSP3M.Enabled = false;
                gvProductSP3M.Columns["CommandColumnProduct"].Visible = false;
                cmbTransporter.ClientEnabled = false;
                //if (cmbDriver != null) cmbDriver.ClientVisible = false;
                //if (cmbVehicleNumber != null) cmbVehicleNumber.ClientVisible = false;
                //if (txtDriver != null) txtDriver.ClientVisible = true;
                //if (txtVehicleNumber != null) txtVehicleNumber.ClientVisible = true;
                dateDelivery.ClientEnabled = false;
                cmbDeliveryFrom.ClientEnabled = false;
                cmbDeliveryTo.ClientEnabled = false;
                txtAddressFrom.ClientEnabled = false;
                txtAddressTo.ClientEnabled = false;
                btnSave.ClientVisible = false;
                btnSubmit.ClientVisible = false;
                btnCancel.ClientVisible = false;
                btnClose.ClientVisible = true;
            }
        }

        protected void SetEnabledButton(List<MasterDataModel.MasterDataRole> Roles, string Status)
        {
            foreach (MasterDataModel.MasterDataRole role in Roles)
            {
                if (role.RoleName == UserProfile.USER_INTERNAL && Status.Contains("SAVED"))
                {
                    btnSubmit.ClientVisible = true;
                    btnReject.ClientVisible = true;
                    return;
                }
                else if (role.RoleName == UserProfile.USER_INTERNAL && Status.Contains("SUBMIT"))
                {
                    btnApprove.ClientVisible = true;
                    btnClarify.ClientVisible = true;
                    btnReject.ClientVisible = true;
                    return;
                }
                else
                {
                    btnApprove.ClientVisible = false;
                    btnClarify.ClientVisible = false;
                    btnReject.ClientVisible = false;
                }
            }
        }


        protected void BindingSPP(int SPP_ID)
        {
            List<SPPBModel.SPPB> _ListSPP = new List<SPPBModel.SPPB>();
            _ListSPP = ListSPP(SPP_ID);
            if (_ListSPP.Count > 0)
            {
                //set textbox
                txtSPP_Number.Text = _ListSPP[0].NoSPP;
                txtForce.Text = _ListSPP[0].Force;
                txtUnity.Text = _ListSPP[0].Unity;
                txtSA_Number.Text = _ListSPP[0].NoSA;
                txtSP2M_Number.Text = _ListSPP[0].NoSP2M;
                txtNote.Text = _ListSPP[0].Note;

                //set datetime control
                if (_ListSPP[0].DeliveryDate != DateTime.Parse("1/1/1900"))
                    dateDelivery.Value = _ListSPP[0].DeliveryDate;
                else
                    dateDelivery.Value = null;
                
                ////set force
                //if (!string.IsNullOrEmpty((string)_ListSPP[0].Force))
                //{
                //    cmbForce.DataSource = MasterDataEntity.GetMasterDataForce();
                //    cmbForce.DataBind();
                //    if (cmbForce.Items.Count > 0)
                //    {
                //        if (_ListSPP[0].Force != null)
                //        {
                //            cmbForce.Items.FindByValue(_ListSPP[0].Force.ToString()).Selected = true;
                //            Session["force"] = _ListSPP[0].Force;
                //        }
                //    }
                //}

                ////set unity
                //if (!string.IsNullOrEmpty((string)_ListSPP[0].Unity))
                //{
                //    cmbUnity.DataSource = MasterDataEntity.GetMasterDataUnity();
                //    cmbUnity.DataBind();
                //    if (cmbUnity.Items.Count > 0)
                //    {
                //        if (_ListSPP[0].Unity != null)
                //        {
                //            cmbUnity.Items.FindByValue(_ListSPP[0].Unity.ToString()).Selected = true;
                //            Session["unity"] = _ListSPP[0].Unity;
                //        }
                //    }
                //}

                //set combobox transporter
                if (cmbTransporter.Items.Count > 0)
                {
                    if (_ListSPP[0].Transporter_ID_FK != null)
                    {
                        cmbTransporter.Items.FindByValue(_ListSPP[0].Transporter_ID_FK.ToString()).Selected = true;

                        //set driver
                        cmbDriver.DataSource = ListDriver(Convert.ToInt32(cmbTransporter.SelectedItem.Value));
                        cmbDriver.DataBind();
                        if (cmbDriver.Items.Count > 0)
                        {
                            if (_ListSPP[0].Driver_ID_FK != null)
                            {
                                cmbDriver.Items.FindByValue(_ListSPP[0].Driver_ID_FK.ToString()).Selected = true;
                                //txtDriver.Text = _ListSPP[0].Driver_ID_FK.ToString();
                                Session["driver"] = _ListSPP[0].Driver_ID_FK;
                            }
                        }

                        //set vehicle
                        cmbVehicleNumber.DataSource = ListVehicle(Convert.ToInt32(cmbTransporter.SelectedItem.Value));
                        cmbVehicleNumber.DataBind();
                        if (cmbVehicleNumber.Items.Count > 0)
                        {
                            if (_ListSPP[0].Vehicle_ID_FK != null)
                            {
                                cmbVehicleNumber.Items.FindByValue(_ListSPP[0].Vehicle_ID_FK.ToString()).Selected = true;
                                //txtVehicleNumber.Text = _ListSPP[0].Vehicle_ID_FK.ToString();
                                txtCapacity.Text = _ListSPP[0].VehicleCapacity.ToString();
                                Session["vehicle"] = _ListSPP[0].Vehicle_ID_FK;
                            }
                        }
                    }
                }

                //set deliveryform ot tbbm
                if (cmbDeliveryFrom.Items.Count > 0)
                {
                    if (_ListSPP[0].TBBM_ID_FK > 0)
                    {
                        cmbDeliveryFrom.Items.FindByValue(_ListSPP[0].TBBM_ID_FK.ToString()).Selected = true;
                        txtAddressFrom.Text = _ListSPP[0].TBBMAddress ?? string.Empty;
                    }
                }

                //set deliveryto or spsh
                if (cmbDeliveryTo.Items.Count > 0)
                {
                    if (_ListSPP[0].SPSH_ID_FK != null)
                    {
                        cmbDeliveryTo.Items.FindByValue(_ListSPP[0].SPSH_ID_FK.ToString()).Selected = true;
                        txtAddressTo.Text = _ListSPP[0].SPSHAddress ?? string.Empty;
                    }
                }

                //set sp3m
                if (cmbSP3M.Items.Count > 0)
                {
                    int SP3M_ID = Convert.ToInt32(_ListSPP[0].SP3M_ID_FK);
                    cmbSP3M.Items.FindByValue(SP3M_ID.ToString()).Selected = true;
                    gvProductSP3M.DataSource = ListSP3MItemBySPP(SPP_ID);
                    gvProductSP3M.DataBind();
                }
                    
            }
        }

        protected void BindingSP3M(int SP3M_ID)
        {
            List<SP3MModel.SP3M> List_SP3M = new List<SP3MModel.SP3M>();
            List_SP3M = ListSP3M(SP3M_ID);
            if (List_SP3M.Count > 0)
            {
                txtForce.Text = List_SP3M[0].NoSA;
                txtUnity.Text = List_SP3M[0].NoSP2M;
                txtSA_Number.Text = List_SP3M[0].NoSA;
                txtSP2M_Number.Text = List_SP3M[0].NoSP2M;

                ////set force
                //if (!string.IsNullOrEmpty((string)List_SP3M[0].Force))
                //{
                //    cmbForce.DataSource = MasterDataEntity.GetMasterDataForce();
                //    cmbForce.DataBind();
                //    if (cmbForce.Items.Count > 0)
                //    {
                //        if (List_SP3M[0].Force != null)
                //        {
                //            cmbForce.Items.FindByValue(List_SP3M[0].Force.ToString()).Selected = true;
                //            Session["force"] = List_SP3M[0].Force;
                //        }
                //    }
                //}

                ////set unity
                //if (!string.IsNullOrEmpty((string)List_SP3M[0].Unity))
                //{
                //    cmbUnity.DataSource = MasterDataEntity.GetMasterDataUnity();
                //    cmbUnity.DataBind();
                //    if (cmbUnity.Items.Count > 0)
                //    {
                //        if (List_SP3M[0].Unity != null)
                //        {
                //            cmbUnity.Items.FindByValue(List_SP3M[0].Unity.ToString()).Selected = true;
                //            Session["unity"] = List_SP3M[0].Unity;
                //        }
                //    }
                //}
            }
        }

        protected List<SP3MModel.SP3M> ListSP3M(int SP3M_ID)
        {
            return DbTransaction.DbToList<SP3MModel.SP3M>("dbo.sp_GetSP3M_ByIDSP3M", new { SP3M_ID = SP3M_ID }, true);
        }

        protected List<SPPBModel.SPPB> ListSPP(int SPP_ID)
        {
            return DbTransaction.DbToList<SPPBModel.SPPB>("dbo.sp_GetSPP_ByIDSPP", new { SPP_ID = SPP_ID }, true);
        }

        protected List<SP3MModel.SP3M> ListSP3M()
        {
            List<SP3MModel.SP3M> _ListSP3M = new List<SP3MModel.SP3M>();
            _ListSP3M = DbTransaction.DbToList<SP3MModel.SP3M>("dbo.sp_GetSP3M_ForSPP", true);

            //add null items
            _ListSP3M.Add(new SP3MModel.SP3M
            {
                SP3M_ID_PK = 0,
                NoSP3M = string.Empty
            });

            return _ListSP3M;
        }
        
        protected List<SP3MModel.SP3MProduct> ListSP3MItem(int SP3M_ID)
        {
            List<SP3MModel.SP3MProduct> _ListSP3MItem = new List<SP3MModel.SP3MProduct>();
            _ListSP3MItem = DbTransaction.DbToList<SP3MModel.SP3MProduct>("dbo.sp_GetSP3MItem_ForSPP", new { SP3M_ID = SP3M_ID }, true);
            
            //set data to session
            JsonProductItem = JsonConvert.SerializeObject(_ListSP3MItem);
            Session["JsonProductItem"] = JsonProductItem;

            return _ListSP3MItem;
        }

        protected List<SP3MModel.SP3MProduct> ListSP3MItemBySPP(int SPP_ID)
        {
            List<SP3MModel.SP3MProduct> _ListSP3MItemBySPP = new List<SP3MModel.SP3MProduct> ();
            _ListSP3MItemBySPP = DbTransaction.DbToList<SP3MModel.SP3MProduct>("sp_GetSPPItemByIDSPP", new { SPP_ID = SPP_ID }, true);

            //set data to session
            JsonProductItem = JsonConvert.SerializeObject(_ListSP3MItemBySPP);
            Session["JsonProductItem"] = JsonProductItem;

            return _ListSP3MItemBySPP;
        }

        protected List<MasterDataModel.MasterDataSPSH> ListSPSH()
        {
            List<MasterDataModel.MasterDataSPSH> _ListSPSH = new List<MasterDataModel.MasterDataSPSH>();
            _ListSPSH = MasterDataEntity.GetMasterDataSPSH_CMB();

            //add null items
            _ListSPSH.Add(new MasterDataModel.MasterDataSPSH
            { 
                SPSH_ID = string.Empty,
                Name = ""
            });

            return _ListSPSH;
        }
        
        protected List<MasterDataModel.MasterDataTransporter> ListTransporter()
        {
            List<MasterDataModel.MasterDataTransporter> _ListTransporter = new List<MasterDataModel.MasterDataTransporter>();
            _ListTransporter = MasterDataEntity.GetMasterDataTransporter_CMB();

            //add null items
            _ListTransporter.Add(new MasterDataModel.MasterDataTransporter
            {
                Transporter_ID = 0,
                TransporterName = ""
            });

            return _ListTransporter;
        }

        protected List<MasterDataModel.MasterDataTBBM> ListTBBM()
        {
            List<MasterDataModel.MasterDataTBBM> _ListTBBM = new List<MasterDataModel.MasterDataTBBM>();
            _ListTBBM = MasterDataEntity.GetMasterDataTBBM_CMB();

            //add null items
            _ListTBBM.Add(new MasterDataModel.MasterDataTBBM
            {
                TBBM_ID_PK = 0,
                Name = ""
            });

            return _ListTBBM;
        }

        protected List<MasterDataModel.MasterDataKendaraan> ListVehicle(int? TransportirId)
        {
            List<MasterDataModel.MasterDataKendaraan> _ListVehicle = new List<MasterDataModel.MasterDataKendaraan>();
            _ListVehicle = DbTransaction.DbToList<MasterDataModel.MasterDataKendaraan>("dbo.sp_GetMasterDataVehicleNumber_CMB", new {
                transporter_ID = TransportirId
            }, true);

            //add null items
            _ListVehicle.Add(new MasterDataModel.MasterDataKendaraan {
                Vehicle_ID = 0,
                Number = ""
            });


            //hf["vehicle"] = Newtonsoft.Json.JsonConvert.SerializeObject(_ListVehicle);
            return _ListVehicle;
        }
        
        protected List<MasterDataModel.MasterDataKendaraan> ListVehicle()
        {
            List<MasterDataModel.MasterDataKendaraan> _ListVehicle = new List<MasterDataModel.MasterDataKendaraan>();
            _ListVehicle = DbTransaction.DbToList<MasterDataModel.MasterDataKendaraan>("dbo.sp_GetMasterDataVehicle", true);
                       
            return _ListVehicle;
        }

        protected List<MasterDataModel.MasterDataDriver> ListDriver(int? TransportirId)
        {
            List<MasterDataModel.MasterDataDriver> _ListDriver = new List<MasterDataModel.MasterDataDriver>();
            _ListDriver = DbTransaction.DbToList<MasterDataModel.MasterDataDriver>("dbo.sp_GetMasterDataDriver_CMB", new {
                transporter_ID = TransportirId
            }, true);

            //add null items
            _ListDriver.Add(new MasterDataModel.MasterDataDriver{
                Driver_ID = 0,
                Name = ""
            });

            //hf["driver"] = Newtonsoft.Json.JsonConvert.SerializeObject(_ListDriver);
            return _ListDriver;
        }
        
        protected void cpSP3M_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            int param = Convert.ToInt32(e.Parameter);
            if (param > 0)
            {
                List<SP3MModel.SP3M> List_SP3M = new List<SP3MModel.SP3M>();
                List_SP3M = ListSP3M(param);
                if (List_SP3M.Count > 0)
                {
                    txtForce.Text = List_SP3M[0].Force;
                    txtUnity.Text = List_SP3M[0].Unity;
                    txtSA_Number.Text = List_SP3M[0].NoSA;
                    txtSP2M_Number.Text = List_SP3M[0].NoSP2M;

                    ////set force
                    //Session["force"] = List_SP3M[0].Force.ToString();
                    //if (!string.IsNullOrEmpty((string)List_SP3M[0].Force))
                    //{
                    //    cmbForce.DataSource = MasterDataEntity.GetMasterDataForce();
                    //    cmbForce.DataBind();
                    //if (cmbForce.Items.Count > 0)
                    //{
                    //    if (List_SP3M[0].Force != null)
                    //    {
                    //        cmbForce.Items.FindByValue(List_SP3M[0].Force.ToString()).Selected = true;
                    //    }
                    //}
                    //}

                    ////set unity
                    //Session["unity"] = List_SP3M[0].Unity.ToString();
                    //if (!string.IsNullOrEmpty((string)List_SP3M[0].Unity))
                    //{
                    //    cmbUnity.DataSource = MasterDataEntity.GetMasterDataUnity();
                    //    cmbUnity.DataBind();
                    //if (cmbUnity.Items.Count > 0)
                    //{
                    //    if (List_SP3M[0].Unity != null)
                    //    {
                    //        cmbUnity.Items.FindByValue(List_SP3M[0].Unity.ToString()).Selected = true;
                    //    }
                    //}
                    //}
                }
            }
            //BindingSP3M(param);
        }

        protected void cpSP3MProduct_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            int param = Convert.ToInt32(e.Parameter);

            if (param > 0)
            {
                gvProductSP3M.DataSource = ListSP3MItem(param);
                gvProductSP3M.DataBind();
                gvProductSP3M.CancelEdit();
            }
            else
            {
                gvProductSP3M.DataSource = null;
                gvProductSP3M.DataBind();
                gvProductSP3M.CancelEdit();
            }
        }
  
        protected void cpAddressFrom_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            foreach (MasterDataModel.MasterDataTBBM item in ListTBBM())
            {
                if (item.TBBM_ID_PK == Convert.ToInt32(e.Parameter))
                {
                    txtAddressFrom.Text = string.IsNullOrEmpty(item.Address) ? string.Empty : item.Address.ToString();
                    return;
                }
            }
        }

        protected void cpAddressTo_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            foreach (MasterDataModel.MasterDataSPSH item in ListSPSH())
            {
                if (item.SPSH_ID == (string)e.Parameter)
                {
                    txtAddressTo.Text = string.IsNullOrEmpty(item.Address) ? string.Empty : item.Address.ToString();
                    return;
                }
            }
        }
        
        protected void cpVehicleNumber_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            int param = Convert.ToInt32(e.Parameter);
            
            //set vehicle
            cmbVehicleNumber.DataSource = ListVehicle(param);
            cmbVehicleNumber.DataBind();
        }

        protected void cpDriver_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            int param = Convert.ToInt32(e.Parameter);

            //set driver
            cmbDriver.DataSource = ListDriver(param);
            cmbDriver.DataBind();
        }

        protected void cpCapacity_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            txtCapacity.Text = string.Empty;
            foreach (MasterDataModel.MasterDataKendaraan item in ListVehicle())
            {
                if (item.Vehicle_ID == Convert.ToInt16(e.Parameter))
                {
                    txtCapacity.Text = string.Format("{0} {1}", item.Capacity, item.UnitCapacity);
                    return;
                }
            }
        }               
      
       
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string ProductItems = string.Empty;
            List<SP3MModel.SP3MProduct> _ListSP3MItem = new List<SP3MModel.SP3MProduct>();

            if(gvProductSP3M.IsEditing== true)
            {
                alert.MessageString(Alert.WARNING, "Simpan SPPB", "Data Produk sedang dalam proses edit. <br> Simpan/ batalkan terlebih dahulu perubahannya !!!", this.Page, GetType());
                gvProductSP3M.Focus();
                return;
            }

            try
            {
                //get data product item
                JsonProductItem = (string)Session["JsonProductItem"];
                if (string.IsNullOrEmpty(JsonProductItem))
                    _ListSP3MItem = ListSP3MItem(Convert.ToInt32(cmbSP3M.SelectedItem.Value));
                else
                    _ListSP3MItem = JsonConvert.DeserializeObject<List<SP3MModel.SP3MProduct>>(JsonProductItem);

                foreach (SP3MModel.SP3MProduct item in _ListSP3MItem)
                {
                    ProductItems += string.Format("{0};{1};{2};{3}|", item.Product_ID_FK, item.QuantityVolume, item.PriceUnit, item.SubTotal);
                }

                //set product item
                if (!string.IsNullOrEmpty(ProductItems))
                    ProductItems = ProductItems.Remove(ProductItems.Length - 2);
                
                if (StatusSPP.Contains("SAVED"))
                {
                    //insert data to database
                    ResponseQuery = DbTransaction.DbToString("dbo.sp_AddSPP", new
                    {
                        SP3M_ID_FK = cmbSP3M.SelectedItem.Value,
                        TBBM_ID_FK = cmbDeliveryFrom.SelectedItem == null ? 0 : cmbDeliveryFrom.SelectedItem.Value,
                        SPSH_ID_FK = cmbDeliveryTo.SelectedItem == null ? 0 : cmbDeliveryTo.SelectedItem.Value,
                        Transporter_ID_FK = cmbTransporter.SelectedItem == null ? 0 : cmbTransporter.SelectedItem.Value,
                        Vehicle_ID_FK = cmbVehicleNumber.SelectedItem == null ? 0 : cmbVehicleNumber.SelectedItem.Value,
                        Driver_ID_FK = cmbDriver.SelectedItem == null ? 0 : cmbDriver.SelectedItem.Value,
                        NoSPP = txtSPP_Number.Text ?? string.Empty,
                        Force = txtForce.Text ?? string.Empty,
                        Unity = txtUnity.Text ?? string.Empty,
                        NoSA = txtSA_Number.Text ?? string.Empty,
                        NoSP2M = txtSP2M_Number.Text ?? string.Empty,
                        DeliveryDate = dateDelivery.Date == DateTime.MinValue ? Convert.ToDateTime("1/1/1900") : dateDelivery.Date,
                        OrderBy = txtUnity.Text == null ? string.Empty : txtUnity.Text,
                        Note = txtNote.Text ?? string.Empty,
                        Status = 1,
                        Userlogin = UserProfile.Username,
                        ProductItem = ProductItems ?? string.Empty,
                    }, true);
                }
                else
                {
                    //edit data sppb to database
                    ResponseQuery = DbTransaction.DbToString("dbo.sp_EditSPP", new
                    {
                        SP3M_ID_FK = cmbSP3M.SelectedItem.Value,
                        TBBM_ID_FK = cmbDeliveryFrom.SelectedItem == null ? 0 : cmbDeliveryFrom.SelectedItem.Value,
                        SPSH_ID_FK = cmbDeliveryTo.SelectedItem == null ? 0 : cmbDeliveryTo.SelectedItem.Value,
                        Transporter_ID_FK = cmbTransporter.SelectedItem == null ? 0 : cmbTransporter.SelectedItem.Value,
                        Vehicle_ID_FK = cmbVehicleNumber.SelectedItem == null ? 0 : cmbVehicleNumber.SelectedItem.Value,
                        Driver_ID_FK = cmbDriver.SelectedItem == null ? 0 : cmbDriver.SelectedItem.Value,
                        NoSPP = txtSPP_Number.Text ?? string.Empty,
                        Force = txtForce.Text ?? string.Empty,
                        Unity = txtUnity.Text ?? string.Empty,
                        NoSA = txtSA_Number.Text ?? string.Empty,
                        NoSP2M = txtSP2M_Number.Text ?? string.Empty,
                        DeliveryDate = dateDelivery.Date == DateTime.MinValue ? Convert.ToDateTime("1/1/1900") : dateDelivery.Date,
                        OrderBy = txtUnity.Text == null ? string.Empty : txtUnity.Text,
                        Note = txtNote.Text ?? string.Empty,
                        Status = 1,
                        Userlogin = UserProfile.Username,
                        ProductItem = ProductItems ?? string.Empty,
                    }, true);
                }

                //show notification
                if (ResponseQuery.Contains("Success"))
                    alert.MessageString(Alert.SUCCESS, "Simpan SPPB", ResponseQuery, this.Page, GetType());
                else
                    alert.MessageString(Alert.WARNING, "Simpan SPPB", ResponseQuery, this.Page, GetType());
            }
            catch(Exception ex)
            {
                alert.MessageString(Alert.ERROR, "Simpan SPPB", ex.Message, this.Page, GetType());
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                SPP_ID = string.IsNullOrEmpty((string)Request.QueryString["SPP_ID"]) ? 0 : Convert.ToInt16(Request.QueryString["SPP_ID"]);

                ResponseQuery = DbTransaction.DbToString("dbo.sp_SubmitSPP", new
                {
                    SPP_ID = SPP_ID,
                    nospp = txtSPP_Number.Text.Trim(),
                    userlogin = UserProfile.Username
                }, true);

                if (ResponseQuery.Contains("Success"))
                {
                    alert.MessageString(Alert.SUCCESS, "Submit SPP", ResponseQuery, this.Page, GetType());
                    SetEnabled(false);
                    SetEnabledButton(UserProfile.Roles, StatusSPP);

                    //approve when user is internal
                    foreach (MasterDataModel.MasterDataRole role in UserProfile.Roles)
                    {
                        if (role.RoleName == UserProfile.USER_INTERNAL)
                        {
                            ResponseQuery = DbTransaction.DbToString("dbo.sp_ApproveSPP", new
                            {
                                SPP_ID = SPP_ID,
                                nospp = txtSPP_Number.Text.Trim(),
                                userlogin = UserProfile.Username
                            }, true);

                            if (ResponseQuery.Contains("Success"))
                            {
                                alert.MessageString(Alert.SUCCESS, "Approve SPP", ResponseQuery, this.Page, GetType());
                                SetEnabled(false);
                                SetEnabledButton(UserProfile.Roles, StatusSPP);
                            }
                            else
                                alert.MessageString(Alert.WARNING, "Approve SPP", ResponseQuery, this.Page, GetType());
                        }

                    }
                }
                else
                    alert.MessageString(Alert.WARNING, "Submit SPP", ResponseQuery, this.Page, GetType());   
                
            }
            catch(Exception ex)
            {
                alert.MessageString(Alert.ERROR, "Submit SPPB", ex.Message, this.Page, GetType());
            }
        }
        
        protected void btnClose_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/ListSPPB.aspx", false);
        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            try
            {
                //set spp id
                //set variable from query string
                SPP_ID = string.IsNullOrEmpty((string)Request.QueryString["SPP_ID"]) ? 0 : Convert.ToInt16(Request.QueryString["SPP_ID"]);

                ResponseQuery = DbTransaction.DbToString("dbo.sp_ApproveSPP", new
                {
                    SPP_ID = SPP_ID,
                    nospp = txtSPP_Number.Text.Trim(),
                    userlogin = UserProfile.Username
                }, true);

                if (ResponseQuery.Contains("Success"))
                {
                    alert.MessageString(Alert.SUCCESS, "Approve SPPB", ResponseQuery, this.Page, GetType());
                    SetEnabled(false);
                    SetEnabledButton(UserProfile.Roles, StatusSPP);
                }
                else
                    alert.MessageString(Alert.WARNING, "Approve SPPB", ResponseQuery, this.Page, GetType());
            }
            catch (Exception ex)
            {
                alert.MessageString(Alert.ERROR, "Approve SPPB", ex.Message, this.Page, GetType());
            }
        }

        protected void btnClarify_Click(object sender, EventArgs e)
        {
            try
            {
                //set spp id
                //set variable from query string
                SPP_ID = string.IsNullOrEmpty((string)Request.QueryString["SPP_ID"]) ? 0 : Convert.ToInt16(Request.QueryString["SPP_ID"]);

                ResponseQuery = DbTransaction.DbToString("dbo.sp_ClarifySPP", new
                {
                    SPP_ID = SPP_ID,
                    nospp = txtSPP_Number.Text.Trim(),
                    userlogin = UserProfile.Username
                }, true);

                if (ResponseQuery.Contains("Success"))
                {
                    alert.MessageString(Alert.SUCCESS, "Clarify SPPB", ResponseQuery, this.Page, GetType());
                    SetEnabled(false);
                    SetEnabledButton(UserProfile.Roles, StatusSPP);
                }
                else
                    alert.MessageString(Alert.WARNING, "Clarify SPPB", ResponseQuery, this.Page, GetType());
            }
            catch (Exception ex)
            {
                alert.MessageString(Alert.ERROR, "Clarify SPPB", ex.Message, this.Page, GetType());
            }
        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            try
            {
                //set spp id
                //set variable from query string
                SPP_ID = string.IsNullOrEmpty((string)Request.QueryString["SPP_ID"]) ? 0 : Convert.ToInt16(Request.QueryString["SPP_ID"]);

                ResponseQuery = DbTransaction.DbToString("dbo.sp_RejectSPP", new
                {
                    SPP_ID = SPP_ID,
                    nospp = txtSPP_Number.Text.Trim(),
                    userlogin = UserProfile.Username
                }, true);

                if (ResponseQuery.Contains("Success"))
                {
                    alert.MessageString(Alert.SUCCESS, "Reject SPPB", ResponseQuery, this.Page, GetType());
                    SetEnabled(false);
                    SetEnabledButton(UserProfile.Roles, StatusSPP);
                }
                else
                    alert.MessageString(Alert.WARNING, "Reject SPPB", ResponseQuery, this.Page, GetType());
            }
            catch (Exception ex)
            {
                alert.MessageString(Alert.ERROR, "Reject SPPB", ex.Message, this.Page, GetType());
            }
        }

        protected void gvProductSP3M_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {            
            List<SP3MModel.SP3MProduct> _ListSP3MItem = new List<SP3MModel.SP3MProduct>();

            try
            {
                //convert jsonProductItem to list
                JsonProductItem = (string)Session["JsonProductItem"];
                _ListSP3MItem = JsonConvert.DeserializeObject<List<SP3MModel.SP3MProduct>>(JsonProductItem);

                //update list  
                int SP3MItem_ID = Convert.ToInt16(e.Keys[0]);
                foreach (SP3MModel.SP3MProduct item in _ListSP3MItem)
                {
                    if (item.SP3M_Items_ID_PK == SP3MItem_ID)
                    {
                        item.QuantityVolume = Convert.ToInt32(e.NewValues["QuantityVolume"]);
                        item.SubTotal = Convert.ToDecimal(e.NewValues["SubTotal"]);
                        break;
                    }
                }
                //convert list to jsonProductItem
                //set data to session
                JsonProductItem = JsonConvert.SerializeObject(_ListSP3MItem);
                Session["JsonProductItem"] = JsonProductItem;

                //refresh grid
                gvProductSP3M.DataSource = _ListSP3MItem;
                gvProductSP3M.DataBind();
                e.Cancel = true;
                gvProductSP3M.CancelEdit();
                alert.MessageString(Alert.SUCCESS, "Update Product", "Success Update Data Quantity Product SP3M", this.Page, GetType());
            }
            catch (Exception ex)
            {
                alert.MessageString(Alert.ERROR, "Update Product", ex.Message, this.Page, GetType());
            }
        }

        protected void cmbDriver_TextChanged(object sender, EventArgs e)
        {
            Session["driver"] = cmbDriver.SelectedItem.Value;
        }

        protected void cmbVehicleNumber_TextChanged(object sender, EventArgs e)
        {
            Session["vehicle"]= cmbVehicleNumber.SelectedItem.Value;
        }

        protected void cmbVehicleNumber_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            int param = Convert.ToInt32(e.Parameter);
            cmbVehicleNumber.DataSource = ListVehicle(param);
            cmbVehicleNumber.DataBind();
        }

        protected void cmbDriver_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            int param = Convert.ToInt32(e.Parameter);
            //set driver
            cmbDriver.DataSource = ListDriver(param);
            cmbDriver.DataBindItems();
        }
                
    }
}