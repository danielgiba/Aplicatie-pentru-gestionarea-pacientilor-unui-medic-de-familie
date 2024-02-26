<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMst.Master" AutoEventWireup="true" CodeBehind="Medicamente.aspx.cs" Inherits="ManagementPacientiMedicFam.Admin.Medicamente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container p-md-4 p-sm-4">
        <h2 class="text-center">Medicamente</h2>

        <div class="row mb-3 mr-lg-5 ml-lg-5">
            <div class="col-md-6">
                <asp:Button ID="btnMedicamente1" runat="server" CssClass="btn btn-primary btn-block" BackColor="#5558C9" Text="Medicam cu Tratament Lung" OnClick="btnMedicamente1_Click" />
            </div>
        </div>

        <div class="row mb-3 mr-lg-5 ml-lg-5">
            <div class="col-md-6">
                <asp:Button ID="btnSearchMedicament" runat="server" CssClass="btn btn-primary btn-block" BackColor="#5558C9" Text="Cauta Medicament" OnClick="btnSearchMedicament_Click" />
            </div>
        </div>

        <div class="row mb-3 mr-lg-5 ml-lg-5">
            <div class="col-md-6">
                <asp:TextBox ID="txtSearchMedicament" runat="server" CssClass="form-control" placeholder="Cauta medicament..." />
                
            </div>
        </div>

        <div class="row">
            <div class="col-md-12">
                <div>
                   
                    <asp:Label ID="lblMedicamente" runat="server"></asp:Label>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
