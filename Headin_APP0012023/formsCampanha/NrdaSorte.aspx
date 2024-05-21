<%@ Page Title="Demolay Sergipe" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NrdaSorte.aspx.cs" Inherits="Headin_APP0012023.CadastroCampanha" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <h2>Manutenção de Campanhas</h2>

        <!-- Formulário para inserção e edição -->
        <div class="card mt-3">
            <div class="card-body">
                <h5 class="card-title">Adicionar/Editar Campanha</h5>
                <div class="form-group">
                    <label for="txtVlrCampanha">Valor da Campanha:</label>
                    <asp:TextBox ID="txtVlrCampanha" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="txtDtInicio">Data de Início:</label>
                    <asp:TextBox ID="txtDtInicio" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="txtDtFim">Data de Fim:</label>
                    <asp:TextBox ID="txtDtFim" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="chkFlAtiva">Campanha Ativa?</label>
                    <asp:CheckBox ID="chkFlAtiva" runat="server" CssClass="form-control"></asp:CheckBox>
                </div>
                <div class="form-group">
                    <label for="txtDsPix">Descrição do Pix:</label>
                    <asp:TextBox ID="txtDsPix" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="txtDsPixInfo">Informações do Pix:</label>
                    <asp:TextBox ID="txtDsPixInfo" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="txtIdPessoa">ID da Pessoa:</label>
                    <asp:TextBox ID="txtIdPessoa" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="txtFilePath">Caminho do Arquivo:</label>
                    <asp:TextBox ID="txtFilePath" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="txtVlrMinimoSorte">Valor Mínimo para Sorteio:</label>
                    <asp:TextBox ID="txtVlrMinimoSorte" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-control-plaintext">
                    <asp:Button ID="btnInserir" runat="server" Text="Salvar" CssClass="btn btn-primary" OnClick="btnInserir_Click" />
                    <asp:Button ID="btnLimpar" runat="server" Text="Limpar" CssClass="btn btn-secondary" OnClick="btnLimpar_Click" />
                </div>
            </div>
        </div>

        <!-- Estrutura de consulta -->
        <div class="mt-3">
            <h5>Filtrar por descrição do Pix:</h5>
            <asp:TextBox ID="txtFiltro" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtFiltro_TextChanged"></asp:TextBox>
        </div>

        <!-- Tabela para exibir dados -->
        <asp:GridView ID="GridViewCampanha" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered" DataKeyNames="id" OnRowEditing="GridViewCampanha_RowEditing" 
             OnRowCancelingEdit="GridViewCampanha_RowCancelingEdit" OnRowUpdating="GridViewCampanha_RowUpdating" OnRowDeleting="GridViewCampanha_RowDeleting">
            <Columns>
                <asp:TemplateField>
                    <HeaderTemplate>Id</HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblId" runat="server" Text='<%# Eval("id") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:Label ID="lblId" runat="server" Text='<%# Eval("id") %>'></asp:Label>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>Valor Campanha</HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblVlrCampanha" runat="server" Text='<%# Eval("vlrCampanha") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtEditVlrCampanha" runat="server" Text='<%# Bind("vlrCampanha") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>Data Início</HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblDtInicio" runat="server" Text='<%# Eval("dtInicio") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtEditDtInicio" runat="server" Text='<%# Bind("dtInicio") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>Data Fim</HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblDtFim" runat="server" Text='<%# Eval("dtFim") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtEditDtFim" runat="server" Text='<%# Bind("dtFim") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>Ativa</HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="chkFlAtiva" runat="server" Checked='<%# Convert.ToBoolean(Eval("flAtiva")) %>'></asp:CheckBox>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:CheckBox ID="chkEditFlAtiva" runat="server" Checked='<%# Bind("flAtiva") %>'></asp:CheckBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>Descrição Pix</HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblDsPix" runat="server" Text='<%# Eval("dsPix") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtEditDsPix" runat="server" Text='<%# Bind("dsPix") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>Informações Pix</HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblDsPixInfo" runat="server" Text='<%# Eval("dsPixInfo") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtEditDsPixInfo" runat="server" Text='<%# Bind("dsPixInfo") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>ID Pessoa</HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblIdPessoa" runat="server" Text='<%# Eval("idPessoa") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtEditIdPessoa" runat="server" Text='<%# Bind("idPessoa") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>Caminho do Arquivo</HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblFilePath" runat="server" Text='<%# Eval("file_path") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtEditFilePath" runat="server" Text='<%# Bind("file_path") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>Valor Mínimo para Sorteio</HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblVlrMinimoSorte" runat="server" Text='<%# Eval("vlrMinimoSorte") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtEditVlrMinimoSorte" runat="server" Text='<%# Bind("vlrMinimoSorte") %>'></asp:TextBox>
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
