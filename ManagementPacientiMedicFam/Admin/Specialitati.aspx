<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMst.Master" AutoEventWireup="true" CodeBehind="Specialitati.aspx.cs" Inherits="ManagementPacientiMedicFam.Admin.Specialitati" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div class="container p-md-4 p-sm-4">
            <div>
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
            </div>
            <h2 class="text-center">Specialitati</h2>

            <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-5">
                <div class="col md-6 ">
                    <label for="txtNumeSpec">Nume</label>
                    <asp:TextBox ID="txtNumeSpec" runat="server" CssClass="form-control" placeholder="Introdu Numele" required></asp:TextBox>
                </div>
            </div>

              <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-5">
                <div class="col md-6 col-md-offset-2 mb-3">
                    <label for="txtStradaSpec">Strada</label>
                    <asp:TextBox ID="txtStradaSpec" runat="server" CssClass="form-control" placeholder="Introdu Strada" required></asp:TextBox>
                </div>
            </div>

              <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-5">
                <div class="col md-6 col-md-offset-2 mb-3">
                    <label for="txtNumarSpec">Numar</label>
                    <asp:TextBox ID="txtNumarSpec" runat="server" CssClass="form-control" placeholder="Introdu Numarul Strazii" TextMode="Number" required></asp:TextBox>
                </div>
            </div>


              <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-5">
                <div class="col md-6 col-md-offset-2 mb-3">
                    <label for="txtNrTelSpec">Numar de Telefon</label>
                    <asp:TextBox ID="txtNrTelSpec" runat="server" CssClass="form-control" placeholder="Introdu Numarul de Telefon" textMode="Number" required></asp:TextBox>
                </div>
            </div>


            <div class="row mb-3 mr-lg-5 ml-lg-5 mt-md-5">
                <div class="col-md-3 col-md-offset-2 mb-3">
                    <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-primary btn-block" BackColor="#5558C9" Text="Adaugati Specializarea" OnClick="btnAdd_Click" />
                </div>
            </div>

             <div class="row mb-3 mr-lg-5 ml-lg-5">
                <div class="col-md-6">
                    <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-bordered" DataKeyNames="SpecialitateID" AutoGenerateColumns="False" 
                        EmptyDataText="Nicio inregistrare de afisat!" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCancelingEdit="GridView1_RowCancelingEdit"
                        OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" AllowPaging="True" PageSize="4" OnRowDeleting="GridView1_RowDeleting">
                        <Columns>
                            <asp:BoundField DataField="Nr Specialitati" HeaderText="Nr Specialitati" ReadOnly="True">
                            <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>

                            <asp:TemplateField HeaderText="Nume">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtNumeSpecEdit" runat="server" Text='<%# Eval("Nume") %>' CssClass="form-control"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblNumeSpec" runat="server" Text='<%# Eval("Nume") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>

                             <asp:TemplateField HeaderText="Strada">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtStradaSpecEdit" runat="server" Text='<%# Eval("Strada") %>' CssClass="form-control"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblStradaSpec" runat="server" Text='<%# Eval("Strada") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>

                             <asp:TemplateField HeaderText="Numar">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtNumarSpecEdit" runat="server" Text='<%# Eval("Numar") %>' CssClass="form-control" TextMode="Number"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblNumarSpec" runat="server" Text='<%# Eval("Numar") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Contact">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtNrTelSpecEdit" runat="server" Text='<%# Eval("NumarTelefon") %>' CssClass="form-control" TextMode="Number"></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblNrTelSpec" runat="server" Text='<%# Eval("NumarTelefon") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>

                            <asp:CommandField CausesValidation="False" HeaderText="Operation" ShowEditButton="True" ShowDeleteButton="True" />
                        </Columns>
                        <HeaderStyle BackColor="#5558C9" ForeColor="White"/>
                    </asp:GridView>

                </div>
            </div>

        </div>
    </div>
</asp:Content>
