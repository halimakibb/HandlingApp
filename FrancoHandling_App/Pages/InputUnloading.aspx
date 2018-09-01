<%@ Page Title="UNLOADING" Language="C#" AutoEventWireup="true" MasterPageFile="~/Layout.master" CodeBehind="InputUnloading.aspx.cs" Inherits="FrancoHandling_App.Pages.InputUnloading" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v17.1, Version=17.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
<script type="text/javascript">


    function OnVolumeChanged(s, e)
    {
        var volPengiriman = parseInt(txtVolumePengiriman.GetText());
        var volPenerimaan = parseInt(s.GetText());
        
        if (s.GetText() == "") {
            txtLosses.SetText(volPengiriman);
        }
        else if (volPenerimaan < 0) {
            s.SetText("0");
            txtLosses.SetText(volPengiriman);
        }
        else if (volPenerimaan > volPengiriman) {
            s.SetText(volPengiriman);
            txtLosses.SetText("0");
        }
        else txtLosses.SetText(volPengiriman - volPenerimaan);
    }
    
</script>

<div class="container">
    <div class="row">
        <div class="page-header">
            <h1>Unloading</h1>
        </div>
    </div>
    
    <dx:BootstrapCallbackPanel runat="server" ID="cpUnloadingList" ClientInstanceName="cpUnloadingList" OnCallback="cpUnloadingList_Callback">
        <ClientSideEvents EndCallback="function(s,e){lp.Hide(); txtSearch.Focus();}"/>
        <ContentCollection>
            <dx:ContentControl>
                <div class="row">
                    <div class="col-md-1"></div>
                    <div class="col-md-2">
                        <dx:BootstrapComboBox runat="server" ID="cmbSearchType" ClientInstanceName="cmbSearchType">
                            <ClientSideEvents ValueChanged="function(s,e){txtSearch}"/>
                            <Items>
                                <dx:BootstrapListEditItem Text="Search SPPB" Value="SPPB" Selected="true"/>
                                <dx:BootstrapListEditItem Text="Search DO" Value="NoDO" />
                            </Items>
                        </dx:BootstrapComboBox>
                    </div>
                    <div class="col-md-8"> 
                        <dx:BootstrapButtonEdit runat="server" ID="txtSearch" ClientInstanceName="txtSearch" NullText="Search . . .">
                            <ClientSideEvents 
                                TextChanged="function(s,e){lp.Show(); cpUnloadingList.PerformCallback(cmbSearchType.GetValue() +'|'+ s.GetText());}"
                                ButtonClick="function(s,e){lp.Show(); cpUnloadingList.PerformCallback(cmbSearchType.GetValue() +'|'+ s.GetText());}"
                                KeyDown="function(s,e){
                                        if (e.htmlEvent.keyCode == 13)
                                        {
                                            ASPxClientUtils.PreventEventAndBubble(e.htmlEvent);
                                            lp.Show(); 
                                            cpUnloadingList.PerformCallback(cmbSearchType.GetValue() +'|'+ s.GetText());
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
                        <asp:Literal runat="server" ID="litUnloadingList"></asp:Literal>      
                    </div>
                    <div class="col-md-1"></div>
                </div>
            </dx:ContentControl>
        </ContentCollection>
    </dx:BootstrapCallbackPanel>
    
    
    <dx:BootstrapCallbackPanel runat="server" ID="cpUnloadingDetail" ClientInstanceName="cpUnloadingDetail" ClientVisible="false"
        OnCallback="cpUnloadingDetail_Callback">
        <ClientSideEvents EndCallback="function(s,e){cpUnloadingList.SetVisible(false); s.SetVisible(true);}"/>
        <ContentCollection>
            <dx:ContentControl>
                <dx:ASPxHiddenField runat="server" ID="hf"></dx:ASPxHiddenField>

<%--                <div class="row">
                    <div class="col-md-2"></div>
                    <div class="col-md-6">
                        <dx:BootstrapTextBox runat="server" ID="txtNoLO" Caption="Nomor LO" ReadOnly="true"></dx:BootstrapTextBox>
                    </div>
                    <div class="col-md-2">
                        <dx:BootstrapTextBox runat="server" ID="txtLODate" Caption="Tanggal LO" ReadOnly="true"></dx:BootstrapTextBox>
                    </div>
                    <div class="col-md-2"></div>
                </div>--%>

                <br />
                
                <div class="row">
                    <div class="col-md-2"></div>
                    <div class="col-md-8">
                        <div class="panel-group" id="accordionInfoNoSurat">
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <h4 class="panel-title">
                                    <a class="btn-block" data-toggle="collapse" style="color:#337AB7" data-parent="#accordionInfoNoSurat" href="#collapseInfoNoSurat"><span class='glyphicon glyphicon-chevron-down'></span> Info Nomor Surat</a>
                                    </h4>
                                </div>
                                <div id="collapseInfoNoSurat" class="panel-collapse collapse">
                                    <div class="panel-body">
                                        <div class="row">
                                            <div class="col-md-9">
                                                <dx:BootstrapTextBox runat="server" ID="txtNoDO" Caption="Nomor Delivery" ReadOnly="true"></dx:BootstrapTextBox>
                                            </div>
                                            <div class="col-md-3">
                                                <dx:BootstrapTextBox runat="server" ID="txtDODate" Caption="Tanggal Delivery" ReadOnly="true"></dx:BootstrapTextBox>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="col-md-9">
                                                <dx:BootstrapTextBox runat="server" ID="txtNoPO" Caption="Nomor PO" ReadOnly="true"></dx:BootstrapTextBox>
                                            </div>
                                            <div class="col-md-3">
                                                <dx:BootstrapTextBox runat="server" ID="txtPODate" Caption="Tanggal PO" ReadOnly="true"></dx:BootstrapTextBox>
                                            </div>
                                            <div class="col-md-2"></div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="col-md-9">
                                                <dx:BootstrapTextBox runat="server" ID="txtNoOrder" Caption="Nomor Order" ReadOnly="true"></dx:BootstrapTextBox>
                                            </div>
                                            <div class="col-md-3">
                                                <dx:BootstrapTextBox runat="server" ID="txtOrderDate" Caption="Tanggal Order" ReadOnly="true"></dx:BootstrapTextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-2"></div>
                </div>

                <div class="row">
                    <div class="col-md-2"></div>
                    <div class="col-md-8">
                        <div class="panel-group" id="accordionInfoTransport">
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <h4 class="panel-title">
                                    <a class="btn-block" data-toggle="collapse" style="color:#337AB7" data-parent="#accordionInfoTransport" href="#collapseInfoTransport"><span class='glyphicon glyphicon-chevron-down'></span> Info Transport</a>
                                    </h4>
                                </div>
                                <div id="collapseInfoTransport" class="panel-collapse collapse">
                                    <div class="panel-body">
                                        <div class="row">
                                            <div class="col-md-12">
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

                                                <div class="row">
                                                    <div class="col-md-6">
                                                        <dx:BootstrapTextBox runat="server" ID="txtTransporter" Caption="Transportir" ReadOnly="true"></dx:BootstrapTextBox>
                                                        <br />
                                                    </div>
                                                    <div class="col-md-6">
                                                        <dx:BootstrapTextBox runat="server" ID="txtDriver" Caption="Driver" ReadOnly="true"></dx:BootstrapTextBox>
                                                        <br />
                                                    </div>
                                                </div>

                                                <div class="row">
                                                    <div class="col-md-6">
                                                        <dx:BootstrapTextBox runat="server" ID="txtVehicleType" Caption="Tipe Kendaraan" ReadOnly="true"></dx:BootstrapTextBox>
                                                        <br />
                                                    </div>
                                                    <div class="col-md-6">
                                                        <dx:BootstrapTextBox runat="server" ID="txtVehicleNumber" Caption="Nomor Kendaraan" ReadOnly="true"></dx:BootstrapTextBox>
                                                        <br />
                                                    </div>
                                                </div>
                
                                                <div class="row">
                                                    <div class="col-md-12">
                                                        <dx:BootstrapMemo runat="server" ID="txtDONote" Caption="Delivery Note" CssClasses-Control="MemoNoResize" ReadOnly="true"></dx:BootstrapMemo>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-2"></div>
                </div>
                
                <hr />
                
                <div class="row">
                    <div class="col-md-3"></div>
                    <div class="col-md-6">
                        <dx:BootstrapDateEdit runat="server" ID="deUnloading" Caption="Tanggal Unloading" ValidationSettings-RequiredField-IsRequired="true">
                        <ClientSideEvents GotFocus="function(s,e){s.ShowDropDown();}"/></dx:BootstrapDateEdit>
                    </div>
                    <div class="col-md-3"></div>
                </div>
                <br />
                <div class="row">
                    <div class="col-md-3"></div>
                    <div class="col-md-6">
                        <dx:BootstrapTextBox runat="server" ID="txtMetodePengukuran" Caption="Metode Pengukuran"></dx:BootstrapTextBox>
                    </div>
                    <div class="col-md-3"></div>
                </div>
                <br />
                <div class="row">
                    <div class="col-md-3"></div>
                    <div class="col-md-6">
                        <dx:BootstrapSpinEdit runat="server" ID="seTinggiEijkBoot" Caption="Tinggi EijkBoot (Tera)" AllowMouseWheel="false" NullText="mm" DisplayFormatString="{0} mm"></dx:BootstrapSpinEdit>
                    </div>
                    <div class="col-md-3"></div>
                </div>
                <br />
                <div class="row">
                    <div class="col-md-3"></div>
                    <div class="col-md-6">
                        <dx:BootstrapSpinEdit runat="server" ID="seAktualEijkBoot" Caption="Aktual EijkBoot" AllowMouseWheel="false" NullText="mm" DisplayFormatString="{0} mm"></dx:BootstrapSpinEdit>
                    </div>
                    <div class="col-md-3"></div>
                </div>
                <br />
                <div class="row">
                    <div class="col-md-3"></div>
                    <div class="col-md-6">
                        <dx:BootstrapSpinEdit runat="server" ID="seVolumeKepekaan" Caption="Volume Kepekaan (Tera)" AllowMouseWheel="false" NullText="Liter/mm" DisplayFormatString="{0} Liter/mm"></dx:BootstrapSpinEdit>
                    </div>
                    <div class="col-md-3"></div>
                </div>
                <br />
                <div class="row">
                    <div class="col-md-3"></div>
                    <div class="col-md-6">
                        <dx:BootstrapTextBox runat="server" ID="txtVolumePengiriman" ClientInstanceName="txtVolumePengiriman" Caption="Volume Pengiriman" ReadOnly="true" DisplayFormatString="{0} Liter"></dx:BootstrapTextBox>
                    </div>
                    <div class="col-md-3"></div>
                </div>
                <br />
                <div class="row">
                    <div class="col-md-3"></div>
                    <div class="col-md-6">
                        <dx:BootstrapSpinEdit runat="server" ID="seVolumePenerimaan" ClientInstanceName="seVolumePenerimaan" Caption="Volume Penerimaan" NumberType="Integer" AllowNull="false" AllowMouseWheel="false" NullText="Liter" DisplayFormatString="{0} Liter">
                            <ClientSideEvents 
                                KeyUp="OnVolumeChanged"
                                NumberChanged="OnVolumeChanged"
                                 />
                        </dx:BootstrapSpinEdit>
                    </div>
                    <div class="col-md-3"></div>
                </div>
                <br />
                <div class="row">
                    <div class="col-md-3"></div>
                    <div class="col-md-6">
                        <dx:BootstrapTextBox runat="server" ID="txtLosses" ClientInstanceName="txtLosses" Caption="Losses" ReadOnly="true"  DisplayFormatString="{0} Liter"></dx:BootstrapTextBox>
                    </div>
                    <div class="col-md-3"></div>
                </div>
                <br />
                <div class="row">
                    <div class="col-md-3"></div>
                    <div class="col-md-6">
                        <dx:BootstrapMemo runat="server" ID="txtUnloadingNote" Caption="Unloading Note" CssClasses-Control="MemoNoResize"></dx:BootstrapMemo>
                    </div>
                    <div class="col-md-3"></div>
                </div>

                <hr />
                
                <div class="row">
                    <div class="col-md-3"></div>
                    <div class="col-md-6">
                        <dx:BootstrapTextBox runat="server" ID="txtNoBAST" ClientInstanceName="txtNoBAST" Caption="Nomor BAST" ValidationSettings-RequiredField-IsRequired="true"></dx:BootstrapTextBox>
                        <dx:BootstrapUploadControl runat="server" ID="ucBAST" ClientInstanceName="ucBAST" UploadMode="Advanced" ShowProgressPanel="true" AutoStartUpload="true"
                            NullText="Upload BAST (Max Size 1 MB)(.jpg, .jpeg, .png, .pdf, .doc, .docx)" ValidationSettings-AllowedFileExtensions=".jpg,.jpeg,.png,.pdf,.doc,.docx"
                             ValidationSettings-MaxFileSize="1048576" ValidationSettings-MaxFileSizeErrorText="File size exceeds the maximum allowed size, which is 1 MB"
                            OnFileUploadComplete="ucBAST_FileUploadComplete">
                            <ClientSideEvents FileUploadComplete="function(s,e){tokBAST.AddToken(e.callbackData); s.SetVisible(false); tokBAST.SetVisible(true);}"/>
                        </dx:BootstrapUploadControl>
                        <dx:ASPxTokenBox runat="server" ID="tokBAST" ClientInstanceName="tokBAST" ClientVisible="false" Width="100%" AllowCustomTokens="false">
                            <ClientSideEvents TokensChanged="function(s,e){if(s.GetTokenCollection().length==0){s.SetVisible(false); ucBAST.SetVisible(true);}}"/>
                        </dx:ASPxTokenBox>
                    </div>
                    <div class="col-md-3"></div>
                </div>

                <hr />

                <div class="row">
                    <div class="col-md-12" style="text-align:center">
                        <dx:BootstrapButton runat="server" ID="btnSubmit" CssClasses-Control="btn-success" Text="Submit" Width="150px" OnClick="btnSubmit_Click">
                            <ClientSideEvents Click="function(s,e){ 
                                                        if(ASPxClientEdit.ValidateGroup(null)) 
                                                        {
                                                            if(tokBAST.GetTokenCollection().length!=0)
                                                            {
                                                                lpModal.Show();
                                                                e.processOnServer = true;
                                                            }
                                                            else 
                                                            {
                                                                e.processOnServer = false; 
                                                                Alert('warning', 'Warning', 'BAST Upload is required.');
                                                            }
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
                            <ClientSideEvents Click="function(s,e){ ASPxClientEdit.ClearEditorsInContainer(null); cpUnloadingDetail.SetVisible(false); cpUnloadingList.SetVisible(true); }" />
                        </dx:BootstrapButton>
                    </div>
                </div>
            </dx:ContentControl>
        </ContentCollection>
    </dx:BootstrapCallbackPanel>
     
   
</div>
</asp:Content>