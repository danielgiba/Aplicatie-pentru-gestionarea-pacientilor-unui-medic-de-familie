<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMst.Master" AutoEventWireup="true" CodeBehind="Trimiteri.aspx.cs" Inherits="ManagementPacientiMedicFam.Admin.Trimiteri" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container p-md-4 p-sm-4">
        <h2 class="text-center">Trimiteri</h2>

        <div class="row mb-3 mr-lg-5 ml-lg-5">
            <div class="col-md-6">
                <asp:Button ID="btnSpecialitatiCuValabilitateMaxima" runat="server" CssClass="btn btn-primary btn-block" BackColor="#5558C9" Text="Val Maxima la Spec" OnClick="btnSpecialitatiCuValabilitateMaxima_Click" />
            </div>
        </div>

         <div class="row mb-3 mr-lg-5 ml-lg-5">
            <div class="col-md-6">
                <asp:TextBox ID="txtCautareSpecialitate" runat="server" CssClass="form-control" placeholder="Cauta specialitate..." />
                
            </div>
      
            <div class="col-md-6">
                <asp:Button ID="btnCautarePacientiSpecialitate" runat="server" CssClass="btn btn-primary btn-block" BackColor="#5558C9" Text="Cauta Pacienti la Cabinete" OnClick="btnCautarePacientiSpecialitate_Click" />
                
            </div>
        </div>

        <div id="divRezultate" runat="server" class="mt-4">
           
        </div>
    </div>
</asp:Content>
