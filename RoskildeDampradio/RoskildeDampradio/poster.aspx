<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="poster.aspx.cs" Inherits="RoskildeDampradio.poster" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="second_colon">
        <div id="second_colon_content">
            <asp:Repeater ID="Repeater_poster" runat="server">
                <ItemTemplate>
                    <h2><%# Eval("overskrift") %></h2>
                    <p><%# Eval("tekst") %></p>
                    <p><%# Eval("udgivelses_dato") %></p>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
