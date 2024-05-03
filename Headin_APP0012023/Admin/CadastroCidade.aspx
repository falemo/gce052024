<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CadastroCidade.aspx.cs" Inherits="Headin_APP0012023.Admin.CadastroCidade" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <h2>Manutenção de Cidades</h2>

        <!-- Formulário para inserção e edição -->
        <div class="card mt-3">
            <div class="card-body">
                <h5 class="card-title">Adicionar/Editar Cidade</h5>
                <div class="form-group">
                    <label for="txtNomeCidade">Nome da Cidade:</label>
                    <asp:TextBox ID="txtNomeCidade" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="ddlPais">Pais:</label>
                    <asp:DropDownList ID="ddlPais" runat="server" CssClass="form-select" AutoPostBack="True" OnSelectedIndexChanged="ddlPais_SelectedIndexChanged">
                        <asp:ListItem Text="Selecione seu Pais" Value="" />
                        </asp:DropDownList>
                </div>
                <div class="form-group">
                    <label for="ddlEstado">Estado:</label>
                    <asp:DropDownList ID="ddlEstado" runat="server" CssClass="form-select" AutoPostBack="False">
                        <asp:ListItem Text="Selecione seu Estado" Value="" />
                        </asp:DropDownList>
                </div>

                <div class="form-control-plaintext">
                    <asp:Button ID="btnInserirCidade" runat="server" Text="Salvar" CssClass="btn btn-primary" OnClick="btnInserirCidade_Click" />
                    <asp:Button ID="btnLimparCidade" runat="server" Text="Limpar" CssClass="btn btn-secondary" OnClick="LimparCidade_Click" />
                </div>
            </div>
        </div>

        <!-- Estrutura de consulta -->
        <div class="mt-3">
            <h5>Filtrar por Nome da Cidade:</h5>
            <asp:TextBox ID="txtFiltroCidade" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtFiltroCidade_TextChanged"></asp:TextBox>
        </div>

        <!-- Tabela para exibir dados -->
        <asp:GridView ID="GridViewCidades" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered" DataKeyNames="Id" OnRowEditing="GridViewCidades_RowEditing"
            OnRowCancelingEdit="GridViewCidades_RowCancelingEdit" OnRowUpdating="GridViewCidades_RowUpdating" OnRowDeleting="GridViewCidades_RowDeleting">
            <Columns>
                <asp:TemplateField>
                    <HeaderTemplate>Id</HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblIdCidade" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:Label ID="lblIdCidade" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>Nome da Cidade</HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblNomeCidade" runat="server" Text='<%# Eval("nmCidade") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtNomeCidade" runat="server" Text='<%# Bind("nmCidade") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>Estado</HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblEstado" runat="server" Text='<%# Eval("nmEstado") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:DropDownList ID="ddlEditEstado" runat="server" CssClass="form-control" OnLoad="ddlEditEstado_Load" SelectedValue='<%# Bind("idEstado") %>'>
                        </asp:DropDownList>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
    </div>
    <div class="d-flex align-items-center justify-content-between mt-4 mb-0">
        <asp:Label ID="lblMessage" runat="server" CssClass="text-center font-weight-light my-4" Text=""></asp:Label>
    </div>

</asp:Content>
