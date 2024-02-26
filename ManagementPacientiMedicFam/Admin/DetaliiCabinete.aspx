<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMst.Master" AutoEventWireup="true" CodeBehind="DetaliiCabinete.aspx.cs" Inherits="ManagementPacientiMedicFam.Admin.DetaliiCabinete" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <div class="container p-md-4 p-sm-4">
        <h2 class="text-center">Detalii Cabinete</h2>

        <div class="row mb-3 mr-lg-5 ml-lg-5">
            <div class="col-md-6">
                <asp:Button ID="btnSpecialitatiFaraTrimiteri" runat="server" CssClass="btn btn-primary btn-block" BackColor="#5558C9" Text="Cabinete fara Trimiteri" OnClick="btnSpecialitatiFaraTrimiteri_Click" />
            </div>
            <div class="col-md-6">
                <asp:Button ID="btnStatisticiPacienti" runat="server" CssClass="btn btn-primary btn-block" BackColor="#5558C9" Text="Total Ocup Cab" OnClick="btnStatisticiPacienti_Click" />
            </div>
        </div>

        <div class="row mb-3 mr-lg-5 ml-lg-5">
            <div class="col-md-6">
                <asp:Button ID="btnProgramariSpecialitate" runat="server" CssClass="btn btn-primary btn-block" BackColor="#5558C9" Text="Prog Cabinete" OnClick="btnProgramariSpecialitate_Click" />
            </div>
            <div class="col-md-6">
                <asp:Button ID="btnAfiseazaDetalii" runat="server" CssClass="btn btn-primary btn-block" BackColor="#5558C9" Text="Pacienti Cab" OnClick="btnAfiseazaDetalii_Click" />
            </div>
        </div>

        <div class="row mb-3 mr-lg-5 ml-lg-5">
            <div class="col-md-6">
                <asp:Button ID="btnCautareSpecialitate" runat="server" CssClass="btn btn-primary btn-block" BackColor="#5558C9" Text="Cauta Pacienti cu Trimiteri" OnClick="btnCautareSpecialitate_Click" />
            </div>
       

            <div class="col-md-6">
                <asp:TextBox ID="txtCautareSpecialitate" runat="server" CssClass="form-control" placeholder="Cauta specialitate..." />
                
            </div>
        </div>

        <div id="divRezultate" runat="server" class="mt-4">
           
        </div>
    </div>
</asp:Content>
