<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Site_admin.Master" AutoEventWireup="true" CodeBehind="sider.aspx.cs" Inherits="RoskildeDampradio.admin.sider" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="indhold">
        <div id="content">
            Vælg post 
            <asp:DropDownList ID="DropDownList_kategori" runat="server">
            </asp:DropDownList>
            <asp:Repeater ID="Repeater_sider" runat="server" onitemcommand="Repeater_sider_ItemCommand">
                <HeaderTemplate>
                    <table>
                        <tr>
                            <th>Id</th>
                            <th>Titel</th>
                            <td><asp:LinkButton ID="LinkButton_ny" CssClass="opret_ny" runat="server">Opret ny</asp:LinkButton></td>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("id") %></td>
                        <td><%# Eval("overskrift") %></td>
                        <td>
                            <asp:LinkButton ID="LinkButton_ret" runat="server" CommandArgument='<%#Eval("id") %>'><i class="icon-pencil-neg"></i></asp:LinkButton>
                            <asp:LinkButton ID="LinkButton_slet" runat="server" CommandArgument='<%#Eval("id") %>'><i class="icon-trash"></i></asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate></table></FooterTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>