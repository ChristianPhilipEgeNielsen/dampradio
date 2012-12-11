<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Site_admin.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="RoskildeDampradio.admin._default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="indhold">
        <div id="content">
            <asp:Repeater ID="Repeater_dash" runat="server">
                <ItemTemplate><h1><%# Eval("brugernavn") %></h1></ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
