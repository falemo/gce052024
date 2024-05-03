<%@ Page Title="VidasFit" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CadastroPais.aspx.cs" Inherits="Headin_APP0012023.CadastroPais" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <h2>Manutenção de Países</h2>

        <!-- Formulário para inserção e edição -->
        <div class="card mt-3">
            <div class="card-body">
                <h5 class="card-title">Adiciona/Editar País</h5>
                <div class="form-group">
                    <label for="txtNomePais">Nome do País:</label>
                    <asp:TextBox ID="txtNomePais" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="txtCodPais">Código do País:</label>
                    <asp:TextBox ID="txtCodPais" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-control-plaintext">
                <asp:Button ID="btnInserir" runat="server" Text="Salvar" CssClass="btn btn-primary" OnClick="btnInserir_Click" />
                <asp:Button ID="btnLimpar" runat="server" Text="Limpar" CssClass="btn btn-secondary" OnClick="Limpar_Click" />
                </div>
            </div>
        </div>
        <!-- Estrutura de consulta -->
        <div class="mt-3">
            <h5>Filtrar por Nome do País:</h5>
            <asp:TextBox ID="txtFiltro" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtFiltro_TextChanged"></asp:TextBox>
        </div>

        <!-- Tabela para exibir dados -->
        <asp:GridView ID="GridViewPaises" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered" DataKeyNames="Id" OnRowEditing="GridViewPaises_RowEditing" 
             OnRowCancelingEdit="GridViewPaises_RowCancelingEdit" OnRowUpdating="GridViewPaises_RowUpdating" OnRowDeleting="GridViewPaises_RowDeleting">
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
            <HeaderTemplate>Nome do País</HeaderTemplate>
            <ItemTemplate>
                <asp:Label ID="lblNome" runat="server" Text='<%# Eval("nmPais") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtNome" runat="server" Text='<%# Bind("nmPais") %>'></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField>
            <HeaderTemplate>Código do País</HeaderTemplate>
            <ItemTemplate>
                <asp:Label ID="lblCodPais" runat="server" Text='<%# Eval("codPais") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtCodPais" runat="server" Text='<%# Bind("codPais") %>'></asp:TextBox>
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
