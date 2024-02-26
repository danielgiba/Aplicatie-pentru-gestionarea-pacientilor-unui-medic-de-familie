<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMst.Master" AutoEventWireup="true" CodeBehind="Tratamente.aspx.cs" Inherits="ManagementPacientiMedicFam.Admin.Tratamente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container p-md-4 p-sm-4">
        <h2 class="text-center">Tratamente</h2>

        
        <asp:Button ID="btnAfiseazaTratamente" runat="server" CssClass="btn btn-primary" Text="Tratamentele Pacienti" OnClick="btnAfiseazaTratamente_Click" />

        <div class="row">
            <div class="col-md-12">
                <div>
                   
                    <asp:Label ID="lblTratamente" runat="server"></asp:Label>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
