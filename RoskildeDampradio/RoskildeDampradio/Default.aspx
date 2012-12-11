<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RoskildeDampradio.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="second_colon">
        <div id="forside_stiki">
        <asp:Repeater ID="Repeater_forside_stiki" runat="server" 
            DataSourceID="SqlDataSource_forside_stiki">
            <ItemTemplate>
                <%# Eval("tekst") %>
            </ItemTemplate>
        </asp:Repeater>
        <asp:SqlDataSource ID="SqlDataSource_forside_stiki" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            SelectCommand="SELECT poster.*, kategori.* FROM kategori INNER JOIN poster ON kategori.id = poster.kategori_id WHERE (kategori.type = @type) AND (poster.stiki = @stiki) ORDER BY poster.position">
            <SelectParameters>
                <asp:Parameter DefaultValue="nyhed" Name="type" Type="String" />
                <asp:Parameter DefaultValue="1" Name="stiki" Type="Byte" />
            </SelectParameters>
        </asp:SqlDataSource>
        <hr />
        </div>
        <div id="forside_nyhed">
            <asp:Repeater ID="Repeater_forside_nyhed" runat="server" 
                DataSourceID="SqlDataSource_nyhed">
                <ItemTemplate>
                    <div class="forside_nyhed">
                        <%# Eval("tekst") %>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <asp:SqlDataSource ID="SqlDataSource_nyhed" runat="server" 
                ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
            
                SelectCommand="SELECT poster.*, kategori.* FROM kategori INNER JOIN poster ON kategori.id = poster.kategori_id WHERE (kategori.type = @type) AND (poster.stiki = @stiki) ORDER BY poster.position">
                <SelectParameters>
                    <asp:Parameter DefaultValue="nyhed" Name="type" />
                    <asp:Parameter DefaultValue="0" Name="stiki" />
                </SelectParameters>
            </asp:SqlDataSource>
        </div>
    </div>
</asp:Content>