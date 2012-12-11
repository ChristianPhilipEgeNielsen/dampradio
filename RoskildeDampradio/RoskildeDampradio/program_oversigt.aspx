<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="program_oversigt.aspx.cs" Inherits="RoskildeDampradio.program_oversigt" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="second_colon">
        <div id="second_colon_content">
            <asp:Repeater ID="Repeater_titel" runat="server">
                <ItemTemplate><h1><%# Eval("overskrift") %></h1></ItemTemplate>
            </asp:Repeater>
            <div id="genre_second_colon_content_left">
                <asp:Repeater ID="Repeater_genre_kategori" runat="server" onitemdatabound="Repeater_genre_Item_Data_Bound">
                    <ItemTemplate>
                        <div class="genre_bg">
                            <div class="genre_kategori">
                                <h3><%# Eval("navn") %></h3>
                                <asp:Repeater ID="Repeater_genre" runat="server" OnItemDataBound="Repeater_genre_program_Item_Data_Bound">
                                    <HeaderTemplate><div class="genre"><ul></HeaderTemplate>
                                    <ItemTemplate>
                                        <li>
                                            <a href='program_oversigt.aspx?id=<%# Eval("id") %>'><%# Eval("navn") %></a>
                                            <asp:Repeater ID="Repeater_genre_program" runat="server">
                                                <HeaderTemplate><div class="genre_program"><ul></HeaderTemplate>
                                                <ItemTemplate>          
                                                    <li>
                                                        <a href='program_oversigt.aspx?id=<%# Eval("id") %>'><%# Eval("navn") %></a>
                                                    </li>
                                                </ItemTemplate>
                                                <FooterTemplate></ul></div></FooterTemplate>
                                            </asp:Repeater>
                                        </li>
                                    </ItemTemplate>
                                    <FooterTemplate></ul></div></FooterTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <asp:Repeater ID="Repeater_info" runat="server">
                <ItemTemplate>
                    <div class="genre_kategori_info">
                        <h3><%# Eval("navn") %></h3>
                        <div class="genre_kategori_info_p"><p><%# Eval("beskrivelse") %></p></div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
