<%@ Page Title="VidasFit" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CadastroTipoMensalidade.aspx.cs" Inherits="Headin_APP0012023.CadastroTipoMensalidade" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <h2>Manutenção Tipo de Mensalidade</h2>

        <!-- Formulário para inserção e edição -->
        <div class="card mt-3">
            <div class="card-body">
                <h5 class="card-title">Adiciona/Editar Tipo de Mensalidade</h5>
                <div class="form-group">
                    <label for="txtdsTipo">Descrição do Tipo:</label>
                    <asp:TextBox ID="txtdsTipo" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="txtdiasFaturacao">Dias Faturação:</label>
                    <asp:TextBox ID="txtdiasFaturacao" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="txtflHabilitado">Habilitado:</label>
                    <asp:CheckBox ID="chkflHabilitado" runat="server" CssClass="form-control"></asp:CheckBox>
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
        <asp:GridView ID="GridViewTipoMensalidade" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered" DataKeyNames="Id" OnRowEditing="GridViewTipoMensalidade_RowEditing" 
             OnRowCancelingEdit="GridViewTipoMensalidade_RowCancelingEdit" OnRowUpdating="GridViewTipoMensalidade_RowUpdating" OnRowDeleting="GridViewTipoMensalidade_RowDeleting">
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
            <HeaderTemplate>Dias Faturação</HeaderTemplate>
            <ItemTemplate>
                <asp:Label ID="lbldiasFaturacao" runat="server" Text='<%# Eval("diasFaturacao") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtdiasFaturacao" runat="server" Text='<%# Bind("diasFaturacao") %>'></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField>
            <HeaderTemplate>Habilitado</HeaderTemplate>
            <ItemTemplate>
                <asp:Label ID="lblflHabilitado" runat="server" Text='<%# Eval("flHabilitado") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:CheckBox ID="chkflHabilitado" runat="server" Checked='<%# Bind("flHabilitado") %>'></asp:CheckBox>
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
