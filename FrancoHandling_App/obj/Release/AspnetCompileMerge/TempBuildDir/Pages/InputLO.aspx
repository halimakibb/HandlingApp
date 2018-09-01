<%@ Page Title="LOADING ORDER" Language="C#" AutoEventWireup="true" MasterPageFile="~/Layout.master" CodeBehind="InputLO.aspx.cs" Inherits="FrancoHandling_App.Pages.InputLO" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v17.1, Version=17.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
<script type="text/javascript">

    function OnTransporterChanged(s, e) {
        cmbVehicleType.SetEnabled(false);
        cmbVehicleNumber.SetEnabled(false);
        cmbDriver.SetEnabled(false);
        cmbVehicleType.PerformCallback(s.GetValue().toString());
        cmbVehicleNumber.ClearItems();
        cmbDriver.PerformCallback(s.GetValue().toString());
    }

    function OnVehicleTypeChanged(s, e) {
        cmbVehicleNumber.SetEnabled(false);
        cmbVehicleNumber.PerformCallback(cmbTransporter.GetValue().toString() + '|' + s.GetValue().toString());
    }

    
</script>

<div class="container">
    <div class="row">
        <div class="page-header">
            <h1>Loading Order</h1>
        </div>
    </div>

    <dx:BootstrapCallbackPanel runat="server" ID="cpLOList" ClientInstanceName="cpLOList" OnCallback="cpLOList_Callback">
        <ClientSideEvents EndCallback="function(s,e){lp.Hide(); txtSearch.Focus();}"/>
        <ContentCollection>
            <dx:ContentControl>
                <div class="row">
                    <div class="col-md-1"></div>
                    <div class="col-md-10">          
                        <dx:BootstrapButtonEdit runat="server" ID="txtSearch" ClientInstanceName="txtSearch" NullText="Search SPPB . . .">
                            <ClientSideEvents 
                                TextChanged="function(s,e){lp.Show(); cpLOList.PerformCallback(s.GetText());}"
                                ButtonClick="function(s,e){lp.Show(); cpLOList.PerformCallback(s.GetText());}"
                                KeyDown="function(s,e){
                                        if (e.htmlEvent.keyCode == 13)
                                        {
                                            ASPxClientUtils.PreventEventAndBubble(e.htmlEvent);
                                            lp.Show(); 
                                            cpLOList.PerformCallback(s.GetText());
                                        }}" />
                            <ClearButton DisplayMode="Always" />
                            <Buttons>
                                <dx:BootstrapEditButton IconCssClass="fa fa-search" Text="Search" Position="Right" />
                            </Buttons>
                        </dx:BootstrapButtonEdit>
                    </div>
                    <div class="col-md-1"></div>
                </div>
                <hr />
                <div class="row">
                    <div class="col-md-1"></div>
                    <div class="col-md-10">          
                        <asp:Literal runat="server" ID="litLOList"></asp:Literal>      
                    </div>
                    <div class="col-md-1"></div>
                </div>
            </dx:ContentControl>
        </ContentCollection>
    </dx:BootstrapCallbackPanel>
    
    
    <dx:BootstrapCallbackPanel runat="server" ID="cpLODetail" ClientInstanceName="cpLODetail" ClientVisible="false"
        OnCallback="cpLODetail_Callback">
        <ClientSideEvents EndCallback="function(s,e){cpLOList.SetVisible(false); s.SetVisible(true);}"/>
        <ContentCollection>
            <dx:ContentControl>
                <dx:ASPxHiddenField runat="server" ID="hf"></dx:ASPxHiddenField>
                <div class="row">
                    <div class="col-md-12" style="text-align:center">
                        <dx:ASPxLabel runat="server" ID="lblItemDesc" Font-Bold="true"></dx:ASPxLabel>
                        <br />
                        <span class='glyphicon glyphicon-send'></span>
                        <br />
                        <dx:ASPxLabel runat="server" ID="lblTBBMName"></dx:ASPxLabel>
                        <br />
                        <span class='glyphicon glyphicon-arrow-down'></span>
                        <br />
                        <dx:ASPxLabel runat="server" ID="lblSPSHName"></dx:ASPxLabel>
                    </div>
                </div>
                <hr />
<%--                <div class="row">
                    <div class="col-md-2"></div>
                    <div class="col-md-6">
                        <dx:BootstrapTextBox runat="server" ID="txtLO" Caption="Nomor LO" ValidationSettings-RequiredField-IsRequired="true"></dx:BootstrapTextBox>
                    </div>
                    <div class="col-md-2">
                        <dx:BootstrapDateEdit runat="server" ID="deLO" Caption="Tanggal LO" ValidationSettings-RequiredField-IsRequired="true"><ClientSideEvents GotFocus="function(s,e){s.ShowDropDown();}"/></dx:BootstrapDateEdit>
                    </div>
                    <div class="col-md-2"></div>
                </div>

                <br />--%>
                
                <div class="row">
                    <div class="col-md-2"></div>
                    <div class="col-md-6">
                        <dx:BootstrapTextBox runat="server" ID="txtDO" Caption="Nomor Delivery" ValidationSettings-RequiredField-IsRequired="true"></dx:BootstrapTextBox>
                    </div>
                    <div class="col-md-2">
                        <dx:BootstrapDateEdit runat="server" ID="deDO" Caption="Tanggal Delivery" ValidationSettings-RequiredField-IsRequired="true"><ClientSideEvents GotFocus="function(s,e){s.ShowDropDown();}"/></dx:BootstrapDateEdit>
                    </div>
                    <div class="col-md-2"></div>
                </div>

                <br />
                
                <div class="row">
                    <div class="col-md-2"></div>
                    <div class="col-md-6">
                        <dx:BootstrapTextBox runat="server" ID="txtPO" Caption="Nomor PO" ValidationSettings-RequiredField-IsRequired="true"></dx:BootstrapTextBox>
                    </div>
                    <div class="col-md-2">
                        <dx:BootstrapDateEdit runat="server" ID="dePO" Caption="Tanggal PO" ValidationSettings-RequiredField-IsRequired="true"><ClientSideEvents GotFocus="function(s,e){s.ShowDropDown();}"/></dx:BootstrapDateEdit>
                    </div>
                    <div class="col-md-2"></div>
                </div>

                <br />
                
                <div class="row">
                    <div class="col-md-2"></div>
                    <div class="col-md-6">
                        <dx:BootstrapTextBox runat="server" ID="txtOrder" Caption="Nomor Order" ValidationSettings-RequiredField-IsRequired="true"></dx:BootstrapTextBox>
                    </div>
                    <div class="col-md-2">
                        <dx:BootstrapDateEdit runat="server" ID="deOrder" Caption="Tanggal Order" ValidationSettings-RequiredField-IsRequired="true"><ClientSideEvents GotFocus="function(s,e){s.ShowDropDown();}"/></dx:BootstrapDateEdit>
                    </div>
                    <div class="col-md-2"></div>
                </div>
                
                <br />
                <hr />
                
                <div class="row">
                    <div class="col-md-3"></div>
                    <div class="col-md-6">
                        <dx:BootstrapComboBox runat="server" ID="cmbTransporter" ClientInstanceName="cmbTransporter" Caption="Transportir" 
                            ValueField="Transporter_ID" ValueType="System.Int32" TextField="TransporterName" ValidationSettings-RequiredField-IsRequired="true" EnableSynchronization="False"
                            >
                            <ClientSideEvents SelectedIndexChanged="OnTransporterChanged"/>
                        </dx:BootstrapComboBox>
                    </div>
                    <div class="col-md-3"></div>
                </div>

                <br />

                <div class="row">
                    <div class="col-md-3"></div>
                    <div class="col-md-6">
                        <dx:BootstrapComboBox runat="server" ID="cmbVehicleType" ClientInstanceName="cmbVehicleType" Caption="Tipe Kendaraan" ValueField="Type_ID" ValueType="System.Int32" TextField="VehicleType" ValidationSettings-RequiredField-IsRequired="true"
                            ClientEnabled="false" EnableSynchronization="False"
                            OnCallback="cmbVehicleType_Callback" >
                            <ClientSideEvents SelectedIndexChanged="OnVehicleTypeChanged"
                                             EndCallback="function(s,e){s.SetEnabled(true);}"/>
                        </dx:BootstrapComboBox>
                    </div>
                    <div class="col-md-3"></div>
                </div>
                
                <br />

                <div class="row">
                    <div class="col-md-3"></div>
                    <div class="col-md-6">
                        <dx:BootstrapComboBox runat="server" ID="cmbVehicleNumber" ClientInstanceName="cmbVehicleNumber" Caption="Nomor Kendaraan" 
                            ValueField="Vehicle_ID" ValueType="System.Int32" TextField="Number" ValidationSettings-RequiredField-IsRequired="true" EnableSynchronization="False"
                            ClientEnabled="false"
                            OnCallback="cmbVehicleNumber_Callback">
                            <ClientSideEvents EndCallback="function(s,e){s.SetEnabled(true);}"/>
                        </dx:BootstrapComboBox>
                    </div>
                    <div class="col-md-3"></div>
                </div>
                
                <br />

                <div class="row">
                    <div class="col-md-3"></div>
                    <div class="col-md-6">
                        <dx:BootstrapComboBox runat="server" ID="cmbDriver" ClientInstanceName="cmbDriver" Caption="Driver" 
                            ValueField="Driver_ID" ValueType="System.Int32" TextField="Name" ValidationSettings-RequiredField-IsRequired="true" EnableSynchronization="False"
                            ClientEnabled="false"
                            OnCallback="cmbDriver_Callback">
                            <ClientSideEvents EndCallback="function(s,e){s.SetEnabled(true);}"/>
                        </dx:BootstrapComboBox>
                    </div>
                    <div class="col-md-3"></div>
                </div>

                <br />
                
                <div class="row">
                    <div class="col-md-3"></div>
                    <div class="col-md-6">
                        <dx:BootstrapMemo runat="server" ID="txtDONote" Caption="Delivery Note" CssClasses-Control="MemoNoResize" ValidationSettings-RequiredField-IsRequired="true" ></dx:BootstrapMemo>
                    </div>
                    <div class="col-md-3"></div>
                </div>

                <br /><br />
                <div class="row">
                    <div class="col-md-12" style="text-align:center">
                        <dx:BootstrapButton runat="server" ID="btnSubmit" CssClasses-Control="btn-success" Text="Submit" Width="150px" OnClick="btnSubmit_Click">
                            <ClientSideEvents Click="function(s,e){ 
                                                        if(ASPxClientEdit.ValidateGroup(null)) 
                                                        {
                                                            lpModal.Show();
                                                            e.processOnServer = true;
                                                        }
                                                        else 
                                                        {
                                                            e.processOnServer = false; 
                                                            Alert('warning', 'Warning', 'Some required fields is still empty or have a wrong format. Please check again.');
                                                        }
                                                    }"/>
                        </dx:BootstrapButton>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-md-12" style="text-align:center">
                        <dx:BootstrapButton runat="server" ID="btnCancel" Text="Cancel" AutoPostBack="false" Width="150px">
                            <ClientSideEvents Click="function(s,e){ ASPxClientEdit.ClearEditorsInContainer(null); cpLODetail.SetVisible(false); cpLOList.SetVisible(true); }" />
                        </dx:BootstrapButton>
                    </div>
                </div>
            </dx:ContentControl>
        </ContentCollection>
    </dx:BootstrapCallbackPanel>
     
   
</div>
</asp:Content>