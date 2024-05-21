<%@ Page Title="Demolay Sergipe" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CadastroSubMenu.aspx.cs" Inherits="Headin_APP0012023.CadastroSubMenu" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <h2>Manutenção de SubMenu</h2>

        <!-- Formulário para inserção e edição -->
        <div class="card mt-3">
            <div class="card-body">
                <h5 class="card-title">Adiciona/Editar Sub Menu</h5>
                <div class="form-group">
                    <label for="ddlMenu">Menu:</label>
                    <asp:DropDownList ID="ddlMenu" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
                 <div class="form-group">
                     <label for="txtNomeSubMenu">Descrição SubMenu:</label>
                     <asp:TextBox ID="txtNomeSubMenu" runat="server" CssClass="form-control"></asp:TextBox>
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
                     <label for="txtLinkSubMenu">Link SubMenu:</label>
                     <asp:TextBox ID="txtLinkSubMenu" runat="server" CssClass="form-control"></asp:TextBox>
                 </div>
                <div class="form-group">
                    <label for="txtnrOrdem">Ordem Apresentação:</label>
                    <asp:TextBox ID="txtnrOrdem" runat="server" CssClass="form-control"></asp:TextBox>
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
            <h5>Filtrar por descrição do SubMenu:</h5>
            <asp:TextBox ID="txtFiltro" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtFiltro_TextChanged"></asp:TextBox>
        </div>

        <!-- Tabela para exibir dados -->
        <asp:GridView ID="GridViewMenu" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered" DataKeyNames="idSubMenu" OnRowEditing="GridViewMenu_RowEditing" 
             OnRowCancelingEdit="GridViewMenu_RowCancelingEdit" OnRowUpdating="GridViewMenu_RowUpdating" OnRowDeleting="GridViewMenu_RowDeleting">
            <Columns>
        <asp:TemplateField>
            <HeaderTemplate>Id</HeaderTemplate>
            <ItemTemplate>
                <asp:Label ID="lblId" runat="server" Text='<%# Eval("idSubMenu") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:Label ID="lblId" runat="server" Text='<%# Eval("idSubMenu") %>'></asp:Label>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField>
            <HeaderTemplate>Id Menu</HeaderTemplate>
            <ItemTemplate>
                <asp:Label ID="lblMenu" runat="server" Text='<%# Eval("dsMenu") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:DropDownList ID="ddlEditMenu" runat="server" CssClass="form-control" OnLoad="ddlEditMenu_Load" SelectedValue='<%# Bind("idMenu") %>'>
                </asp:DropDownList>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField>
            <HeaderTemplate>Descrição do SubMenu</HeaderTemplate>
            <ItemTemplate>
                <asp:Label ID="lblSubmenu" runat="server" Text='<%# Eval("dsSubMenu") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtSubmenu" runat="server" Text='<%# Bind("dsSubMenu") %>'></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField>
            <HeaderTemplate>Professional</HeaderTemplate>
            <ItemTemplate>
                <asp:CheckBox ID="chkProfessional" runat="server" Checked='<%# Convert.ToBoolean(Eval("flProfissional")) %>'></asp:CheckBox>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:CheckBox ID="chkProfessional" runat="server" Checked='<%# Bind("flProfissional") %>'></asp:CheckBox>
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
            <HeaderTemplate>Link SubMenu</HeaderTemplate>
            <ItemTemplate>
                <asp:Label ID="lbllinkSubmenu" runat="server" Text='<%# Eval("dsLink") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtlinkSubmenu" runat="server" Text='<%# Bind("dsLink") %>'></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField>
            <HeaderTemplate>Ordem SubMenu</HeaderTemplate>
            <ItemTemplate>
                <asp:Label ID="lblnrOrdem" runat="server" Text='<%# Eval("nrOrdem") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtnrOrdem" runat="server" Text='<%# Bind("nrOrdem") %>'></asp:TextBox>
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
