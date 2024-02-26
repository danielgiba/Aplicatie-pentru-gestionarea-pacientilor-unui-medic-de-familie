<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMst.Master" AutoEventWireup="true" CodeBehind="Programari.aspx.cs" Inherits="ManagementPacientiMedicFam.Admin.Programari" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="styles.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <asp:Label ID="lblMsg" runat="server" CssClass="alert" EnableViewState="False"></asp:Label>

        <h2 class="text-center">Adaugare Programare</h2>

        <div class="row">
            <div class="col-md-6">
                <label for="ddlNumePacient">Nume Pacient</label>
                <asp:DropDownList ID="ddlNumePacient" runat="server" CssClass="form-control" AutoPostBack="true"
                    OnSelectedIndexChanged="ddlNumePacient_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Nume Pacient este obligatoriu"
                    ControlToValidate="ddlNumePacient" Display="Dynamic" ForeColor="Red" InitialValue="Selecteaza Pacientul"
                    SetFocusOnError="True">
                </asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="row mt-3">
            <div class="col-md-6">
                <label for="txtDataProg">Data Programarii</label>
                <asp:TextBox ID="txtDataProg" runat="server" CssClass="form-control" placeholder="Introdu Data Programarii"
                    TextMode="DateTimeLocal" required></asp:TextBox>
            </div>
        </div>

        <div class="row mt-3">
            <div class="col-md-3">
                <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-primary btn-block" Text="Adauga Programare"
                    OnClick="btnAdd_Click" />
            </div>
        </div>

        <div class="row mt-4">
            <div class="col-md-12">
                <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-bordered" DataKeyNames="ProgramareID"
                    AutoGenerateColumns="False" EmptyDataText="Nicio inregistrare de afisat!" OnPageIndexChanging="GridView1_PageIndexChanging"
                    OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating"
                    OnRowDeleting="GridView1_RowDeleting" AllowPaging="True" PageSize="4">
                    <Columns>
                        <asp:BoundField DataField="Nr Programari" HeaderText="Nr Programari" ReadOnly="True">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>

                        <asp:TemplateField HeaderText="Nume">
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddlNumePacientEdit" runat="server" DataSourceID="SqlDataSource1" DataTextField="Nume"
                                    DataValueField="PacientID" SelectedValue='<%# Bind("PacientID") %>' CssClass="form-control">
                                    <asp:ListItem>Selecteaza Pacientul</asp:ListItem>
                                </asp:DropDownList>
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString='<%$ ConnectionStrings:MedicDeFamilieConnectionString %>'
                                    SelectCommand="SELECT [PacientID], [Nume], [Prenume] FROM [Pacienti]"></asp:SqlDataSource>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblNume" runat="server" Text='<%# Eval("Nume") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="DataProg">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtDataProgEdit" runat="server" CssClass="form-control" Text='<%# Bind("DataProg", "{0:yyyy-MM-ddTHH:mm}") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblDataProg" runat="server" Text='<%# Eval("DataProg", "{0:yyyy-MM-dd HH:mm}") %>'></asp:Label>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>

                        <asp:CommandField CausesValidation="False" HeaderText="Actiuni" ShowEditButton="True" ShowDeleteButton="True" />
                    </Columns>
                    <HeaderStyle BackColor="#5558C9" ForeColor="White" />
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
