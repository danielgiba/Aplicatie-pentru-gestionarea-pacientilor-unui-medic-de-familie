<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMst.Master" AutoEventWireup="true" CodeBehind="Retete.aspx.cs" Inherits="ManagementPacientiMedicFam.Admin.Retete" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container p-md-4 p-sm-4">
        <h2 class="text-center">Rețete</h2>

        <div class="row mb-3 mr-lg-5 ml-lg-5">
            <div class="col-md-6">
                <asp:TextBox ID="txtCautareSpecialitate" runat="server" CssClass="form-control" placeholder="Cauta specialitate..." />
            </div>
            <div class="col-md-6">
                <asp:Button ID="btnCautarePacientiSpecialitate" runat="server" CssClass="btn btn-primary btn-block" BackColor="#5558C9" Text="Pacienti cu Reteta&Prog la Cab" OnClick="btnCautarePacientiSpecialitate_Click" />
            </div>
        </div>

        <div class="row mb-3 mr-lg-5 ml-lg-5">
            <div class="col-md-6">
                <asp:DropDownList ID="ddlCompensareRetete" runat="server" CssClass="form-control">
                    <asp:ListItem Text="Gratuit" Value="Gratuit" />
                    <asp:ListItem Text="Redus" Value="Redus" />
                    <asp:ListItem Text="Intreg" Value="Intreg" />
                </asp:DropDownList>
            </div>
            <div class="col-md-6">
                <asp:Button ID="btnCautareReteteCompensate" runat="server" CssClass="btn btn-primary btn-block" BackColor="#5558C9" Text="Cauta Retete Pacienti" OnClick="btnCautareReteteCompensate_Click" />
            </div>
        </div>

        <div id="divRezultate" runat="server" class="mt-4">

        </div>
    </div>
</asp:Content>
