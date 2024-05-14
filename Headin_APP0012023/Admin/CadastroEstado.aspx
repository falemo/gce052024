<%@ Page Title="Demolay Sergipe" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CadastroEstado.aspx.cs" Inherits="Headin_APP0012023.CadastroEstado" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <h2>Manutenção de Estados</h2>

        <!-- Formulário para inserção e edição -->
        <div class="card mt-3">
            <div class="card-body">
                <h5 class="card-title">Adiciona/Editar Estado</h5>
                <div class="form-group">
                    <label for="txtNomeEstado">Nome do Estado:</label>
                    <asp:TextBox ID="txtNomeEstado" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="txtSiglaEstado">Sigla do Estado:</label>
                    <asp:TextBox ID="txtSiglaEstado" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="ddlPais">País:</label>
                    <asp:DropDownList ID="ddlPais" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
                <div class="form-control-plaintext">
                    <asp:Button ID="btnInserir" runat="server" Text="Salvar" CssClass="btn btn-primary" OnClick="btnInserir_Click" />
                    <asp:Button ID="btnLimpar" runat="server" Text="Limpar" CssClass="btn btn-secondary" OnClick="Limpar_Click" />
                </div>
            </div>
        </div>

        <!-- Estrutura de consulta -->
        <div class="mt-3">
            <h5>Filtrar por Nome do Estado:</h5>
            <asp:TextBox ID="txtFiltro" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtFiltro_TextChanged"></asp:TextBox>
        </div>

        <!-- Tabela para exibir dados -->
        <asp:GridView ID="GridViewEstados" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered" DataKeyNames="Id" OnRowEditing="GridViewEstados_RowEditing" 
             OnRowCancelingEdit="GridViewEstados_RowCancelingEdit" OnRowUpdating="GridViewEstados_RowUpdating" OnRowDeleting="GridViewEstados_RowDeleting">
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
                    <HeaderTemplate>Nome do Estado</HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblNomeEstado" runat="server" Text='<%# Eval("nmEstado") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtNomeEstado" runat="server" Text='<%# Bind("nmEstado") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>Sigla do Estado</HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblSiglaEstado" runat="server" Text='<%# Eval("sigla") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtSiglaEstado" runat="server" Text='<%# Bind("sigla") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>Id País</HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblPais" runat="server" Text='<%# Eval("nmPais") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:DropDownList ID="ddlEditPais" runat="server" CssClass="form-control" OnLoad="ddlEditPais_Load" SelectedValue='<%# Bind("idPais") %>'>
                        </asp:DropDownList>
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
