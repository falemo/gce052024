<%@ Page Title="Demolay Sergipe" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CadastroMenu.aspx.cs" Inherits="Headin_APP0012023.CadastroMenu" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <h2>Manutenção de Países</h2>

        <!-- Formulário para inserção e edição -->
        <div class="card mt-3">
            <div class="card-body">
                <h5 class="card-title">Adiciona/Editar Menu</h5>
                <div class="form-group">
                    <label for="txtNomePais">Descrição Menu:</label>
                    <asp:TextBox ID="txtdsMenu" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="flProfessional">Professional?</label>
                    <asp:CheckBox ID="flProfessional" runat="server" CssClass="form-control" Checked="false"></asp:CheckBox>
                </div>
                <div class="form-group">
                    <label for="flHabilitado">Habilitado?</label>
                    <asp:CheckBox ID="flHabilitado" runat="server" CssClass="form-control" Checked="false"></asp:CheckBox>
                </div>
                <div class="form-group">
                    <label for="txtnrOrdem">Ordem Apresentação:</label>
                    <asp:TextBox ID="txtnrOrdem" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="txtgrupo">Grupo Menu:</label>
                    <asp:TextBox ID="txtgrupo" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="fladministrador">Administrador?</label>
                    <asp:CheckBox ID="fladministrador" runat="server" CssClass="form-control" Checked="false"></asp:CheckBox>
                </div>
                <div class="form-control-plaintext">
                <asp:Button ID="btnInserir" runat="server" Text="Salvar" CssClass="btn btn-primary" OnClick="btnInserir_Click" />
                <asp:Button ID="btnLimpar" runat="server" Text="Limpar" CssClass="btn btn-secondary" OnClick="Limpar_Click" />
                </div>
            </div>
        </div>
        <!-- Estrutura de consulta -->
        <div class="mt-3">
            <h5>Filtrar por descrição do Menu:</h5>
            <asp:TextBox ID="txtFiltro" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtFiltro_TextChanged"></asp:TextBox>
        </div>

        <!-- Tabela para exibir dados -->
        <asp:GridView ID="GridViewMenu" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered" DataKeyNames="Id" OnRowEditing="GridViewMenu_RowEditing" 
             OnRowCancelingEdit="GridViewMenu_RowCancelingEdit" OnRowUpdating="GridViewMenu_RowUpdating" OnRowDeleting="GridViewMenu_RowDeleting">
            <Columns>
        <asp:TemplateField>
            <HeaderTemplate>Id</HeaderTemplate>
            <ItemTemplate>
                <asp:Label ID="lblId" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:Label ID="lblId" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField>
            <HeaderTemplate>Descrição do Menu</HeaderTemplate>
            <ItemTemplate>
                <asp:Label ID="lblmenu" runat="server" Text='<%# Eval("dsMenu") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtmenu" runat="server" Text='<%# Bind("dsMenu") %>'></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField>
            <HeaderTemplate>Professional</HeaderTemplate>
            <ItemTemplate>
                <asp:CheckBox ID="chkProfessional" runat="server" Checked='<%# Convert.ToBoolean(Eval("flProfessional")) %>'></asp:CheckBox>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:CheckBox ID="chkProfessional" runat="server" Checked='<%# Bind("flProfessional") %>'></asp:CheckBox>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField>
            <HeaderTemplate>Habilitado</HeaderTemplate>
            <ItemTemplate>
                <asp:CheckBox ID="chkflHabilitado" runat="server" Checked='<%# Convert.ToBoolean(Eval("flHabilitado")) %>'></asp:CheckBox>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:CheckBox ID="chkflHabilitado" runat="server" Checked='<%# Bind("flHabilitado") %>'></asp:CheckBox>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField>
            <HeaderTemplate>Ordem Menu</HeaderTemplate>
            <ItemTemplate>
                <asp:Label ID="lblnrOrdem" runat="server" Text='<%# Eval("nrOrdem") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtnrOrdem" runat="server" Text='<%# Bind("nrOrdem") %>'></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField>
            <HeaderTemplate>Grupo Menu</HeaderTemplate>
            <ItemTemplate>
                <asp:Label ID="lblgrupo" runat="server" Text='<%# Eval("grupo") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtgrupo" runat="server" Text='<%# Bind("grupo") %>'></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField>
            <HeaderTemplate>Administrador</HeaderTemplate>
            <ItemTemplate>
                <asp:CheckBox ID="chkfladministrador" runat="server" Checked='<%# Convert.ToBoolean(Eval("fladministrador")) %>'></asp:CheckBox>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:CheckBox ID="chkfladministrador" runat="server" Checked='<%# Bind("fladministrador") %>'></asp:CheckBox>
            </EditItemTemplate>
        </asp:TemplateField>
                <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
    </div>
    <div class="d-flex align-items-center justify-content-between mt-4 mb-0">
        <asp:Label ID="lblMessage" runat="server" CssClass="text-center font-weight-light my-4" Text="" />
    </div>
</asp:Content>
