<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ugens_program.aspx.cs" Inherits="RoskildeDampradio.ugens_program" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="second_colon">
        <div id="second_colon_content">
            <asp:Repeater ID="Repeater_program" runat="server" DataSourceID="SqlDataSource_poster">
                <HeaderTemplate><div id="program_info"></HeaderTemplate>
                <ItemTemplate>
                    <h1><%# Eval("overskrift")%></h1>
                    <p><%# Eval("tekst") %></p>
                </ItemTemplate>
                <FooterTemplate></div></FooterTemplate>
            </asp:Repeater>
            <asp:SqlDataSource ID="SqlDataSource_poster" runat="server" 
                ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                SelectCommand="SELECT * FROM [poster] WHERE ([overskrift] = @overskrift)">
                <SelectParameters>
                    <asp:Parameter DefaultValue="Program" Name="overskrift" Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
            <div id="program_kalender">
                <asp:Calendar ID="Calendar_program" runat="server" BackColor="White" 
                    BorderColor="#999999" CellPadding="4" DayNameFormat="FirstTwoLetters" 
                    Font-Size="8pt" ForeColor="White" Width="100%" 
                    onselectionchanged="Calendar_program_SelectionChanged">
                    <DayHeaderStyle BackColor="#E39925" Font-Size="18px" Font-Bold="false" />
                    <NextPrevStyle VerticalAlign="Bottom" />
                    <OtherMonthDayStyle ForeColor="#808080"/>
                    <SelectedDayStyle BackColor="#6DADC0" Font-Bold="True" ForeColor="White" />
                    <SelectorStyle BackColor="#CCCCCC" />
                    <TitleStyle BackColor="Silver" BorderColor="Black" ForeColor="White"/>
                    <TodayDayStyle BackColor="#E39925" ForeColor="White" />
                    <DayStyle BackColor="Black" />
                </asp:Calendar>
                <div class="color-box">
                    <span class="orange"></span>
                    <span>Dags dato</span> <span class="blue"></span>
                    <span>Valgte datoer</span>
                </div>
            </div>
            <div id="program_dag">
                <hr />
                <h2>
                    <asp:Label ID="Label_program_dag" runat="server"></asp:Label>
                    <asp:Label ID="Label_program_sidste_dag" runat="server"></asp:Label>
                </h2>
                <asp:Repeater ID="Repeater_program_dag" runat="server">
                    <HeaderTemplate><div class="program_dag"></HeaderTemplate>
                    <ItemTemplate>
                        <h3><%# Eval("titel") %></h3> <%# Eval("start") %><br />
                        <%# Eval("info") %><br />
                        <b>Vært:</b> <%# Eval("vaert") %> <b>Producer:</b> <%# Eval("producer") %>
                    </ItemTemplate>
                    <FooterTemplate></div></FooterTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
</asp:Content>