<%@ Page Title="VidasFit" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CadastroTipoFormacao.aspx.cs" Inherits="Headin_APP0012023.CadastroTipoFormacao" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <h2>Manutenção de Tipo Formação</h2>

        <!-- Formulário para inserção e edição -->
        <div class="card mt-3">
            <div class="card-body">
                <h5 class="card-title">Adiciona/Editar Tipo de Formação</h5>
                <div class="form-group">
                    <label for="txtdsTipo">Descrição do Tipo:</label>
                    <asp:TextBox ID="txtdsTipo" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="txtnrNivel">Nivel:</label>
                    <asp:TextBox ID="txtnrNivel" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-control-plaintext">
                <asp:Button ID="btnInserir" runat="server" Text="Salvar" CssClass="btn btn-primary" OnClick="btnInserir_Click" />
                <asp:Button ID="btnLimpar" runat="server" Text="Limpar" CssClass="btn btn-secondary" OnClick="Limpar_Click" />
                </div>
            </div>
        </div>
        <!-- Estrutura de consulta -->
        <div class="mt-3">
            <h5>Filtrar por Descrição:</h5>
            <asp:TextBox ID="txtFiltro" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtFiltro_TextChanged"></asp:TextBox>
        </div>

        <!-- Tabela para exibir dados -->
        <asp:GridView ID="GridViewTipoFormacao" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered" DataKeyNames="Id" OnRowEditing="GridViewTipoFormacao_RowEditing" 
             OnRowCancelingEdit="GridViewTipoFormacao_RowCancelingEdit" OnRowUpdating="GridViewTipoFormacao_RowUpdating" OnRowDeleting="GridViewTipoFormacao_RowDeleting">
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
            <HeaderTemplate>Descrição do Tipo</HeaderTemplate>
            <ItemTemplate>
                <asp:Label ID="lbldsTipo" runat="server" Text='<%# Eval("dsTipo") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtdsTipo" runat="server" Text='<%# Bind("dsTipo") %>'></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField>
            <HeaderTemplate>Nível</HeaderTemplate>
            <ItemTemplate>
                <asp:Label ID="lblnrNivel" runat="server" Text='<%# Eval("nrNivel") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtnrNivel" runat="server" Text='<%# Bind("nrNivel") %>'></asp:TextBox>
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
