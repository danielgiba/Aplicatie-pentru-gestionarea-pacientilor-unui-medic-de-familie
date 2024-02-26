<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMst.Master" AutoEventWireup="true" CodeBehind="Pacienti.aspx.cs" Inherits="ManagementPacientiMedicFam.Admin.Pacienti" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div class="container p-md-4 p-sm-4">
            <div>
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
            </div>
            <h2 class="text-center">Pacienti</h2>

            <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-5">
                <div class="col md-6 ">
                    <label for="txtNumePacient">Nume</label>
                    <asp:TextBox ID="txtNumePacient" runat="server" CssClass="form-control" placeholder="Introdu Numele" required></asp:TextBox>
                </div>
            

           
                <div class="col md-6 ">
                    <label for="txtPrenumePacient">Prenume</label>
                    <asp:TextBox ID="txtPrenumePacient" runat="server" CssClass="form-control" placeholder="Introdu Prenumele" required></asp:TextBox>
                </div>
            </div>
           

             <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-5">
                <div class="col md-6 col-md-offset-2 mb-3">
                    <label for="txtCNPPacient">CNP</label>
                    <asp:TextBox ID="txtCNPPacient" runat="server" CssClass="form-control" placeholder="Introdu CNP" TextMode="Number" required></asp:TextBox>
                </div>
            </div>

              <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-5">
                <div class="col md-6 col-md-offset-2 mb-3">
                    <label for="txtStradaPacient">Strada</label>
                    <asp:TextBox ID="txtStradaPacient" runat="server" CssClass="form-control" placeholder="Introdu Strada" required></asp:TextBox>
                </div>
           
                <div class="col md-6 col-md-offset-2 mb-3">
                    <label for="txtNrAdresaPacient">Numar</label>
                    <asp:TextBox ID="txtNrAdresaPacient" runat="server" CssClass="form-control" placeholder="Introdu Numarul Strazii" TextMode="Number" required></asp:TextBox>
                </div>
            </div>

              <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-5">
                <div class="col md-6 col-md-offset-2 mb-3">
                    <label for="ddlSexPacient">Sex</label>
                    <asp:DropDownList ID="ddlSexPacient" runat="server">
                        <asp:ListItem Value="0">Selectati Sexul</asp:ListItem>
                        <asp:ListItem>M</asp:ListItem>
                        <asp:ListItem>F</asp:ListItem>
                    </asp:DropDownList>
                </div>
           
                <div class="col md-6 col-md-offset-2 mb-3">
                    <label for="txtDataNasterePacient">Data Nasterii</label>
                   <asp:TextBox ID="txtDataNasterePacient" runat="server" CssClass="form-control" placeholder="Introdu Data Nasterii" textMode="Date" required></asp:TextBox>
                </div>
            </div>

              <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-5">
                <div class="col md-6 col-md-offset-2 mb-3">
                    <label for="txtNrTelPacient">Numar de Telefon</label>
                    <asp:TextBox ID="txtNrTelPacient" runat="server" CssClass="form-control" placeholder="Introdu Numarul de Telefon" textMode="Number" required></asp:TextBox>
                </div>
           
                <div class="col md-6 col-md-offset-2 mb-3">
                    <label for="txtEmailPacient">Email</label>
                    <asp:TextBox ID="txtEmailPacient" runat="server" CssClass="form-control" placeholder="Introdu Email-ul" textMode="Email"></asp:TextBox>
                </div>
            </div>


            <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-5">
                <div class="col-md-3 col-md-offset-2 mb-3">
                    <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-primary btn-block" BackColor="#5558C9" Text="Adaugati Pacient" OnClick="btnAdd_Click" />
                </div>
            </div>

             <div class="row mb-6 mr-lg-8 ml-lg-6">
                <div class="col-md-7">
                    <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-bordered" DataKeyNames="PacientID" AutoGenerateColumns="False" 
                        EmptyDataText="Nicio inregistrare de afisat!" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCancelingEdit="GridView1_RowCancelingEdit"
                        OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" AllowPaging="True" PageSize="5" OnRowDeleting="GridView1_RowDeleting">
                        <Columns>
                            <asp:BoundField DataField="Nr Pacienti" HeaderText="Nr Pacienti" ReadOnly="True">
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>

                            <asp:TemplateField HeaderText="Nume">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtNumeEdit" runat="server" Text='<%# Eval("Nume") %>' CssClass="form-control"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblNume" runat="server" Text='<%# Eval("Nume") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                                 
                            </asp:TemplateField>

                             <asp:TemplateField HeaderText="Prenume">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtPrenumeEdit" runat="server" Text='<%# Eval("Prenume") %>' CssClass="form-control"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblPrenume" runat="server" Text='<%# Eval("Prenume") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>

                             <asp:TemplateField HeaderText="CNP">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtCNPEdit" runat="server" Text='<%# Eval("CNP") %>' CssClass="form-control"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblCNP" runat="server" Text='<%# Eval("CNP") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>

                            <asp:CommandField CausesValidation="False" HeaderText="Modificari" ShowEditButton="True" ShowDeleteButton="True" />
                        </Columns>
                        
                        <HeaderStyle BackColor="#5558C9" ForeColor="White"/>
                    </asp:GridView>

                </div>
            </div>

        </div>
    </div>

     

</asp:Content>
