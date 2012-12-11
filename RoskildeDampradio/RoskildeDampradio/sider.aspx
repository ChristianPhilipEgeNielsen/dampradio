<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="sider.aspx.cs" Inherits="RoskildeDampradio.sider" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="second_colon">
        <div id="second_colon_content">
            <asp:Repeater ID="Repeater_sider" runat="server">
                <ItemTemplate>
                    <h2><%# Eval("titel") %></h2>
                    <p><%# Eval("tekst") %></p>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
