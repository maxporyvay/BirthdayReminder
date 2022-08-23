<%@ Page Title="Полный список ДР" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FullBirthdaysList.aspx.cs" Inherits="BirthdayReminder.Pages.FullBirthdaysList.FullBirthdaysList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <asp:Button ID="ButtonAdd" runat="server" Text="Добавить новый ДР" PostBackUrl="~/Pages/FullBirthdaysList/AddBirthday.aspx"/>
    <asp:GridView ID="GridViewFullBirthdaysList" runat="server" BackColor="#DEBA84" OnRowDeleting="GridViewFullBirthdaysList_RowDeleting" OnRowDataBound="GridViewFullBirthdaysList_RowDataBound" OnRowEditing="GridViewFullBirthdaysList_RowEditing" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" DataKeyNames="PersonId">
        <Columns>
            <asp:BoundField DataField="RowNumb" HeaderText="№" HeaderStyle-HorizontalAlign="Center" />
            <asp:CommandField ShowDeleteButton="True" />
            <asp:CommandField ShowCancelButton="False" ShowEditButton="True" />
            <asp:BoundField DataField="PersonName" HeaderText="Имя" HeaderStyle-HorizontalAlign="Center" />
            <asp:TemplateField HeaderText="Дата рождения" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:Label ID="PersonBirthdate" runat="server" Text='<%# Bind("PersonBirthdate","{0:d}") %>'></asp:Label>
                </ItemTemplate>
                <FooterStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:ImageField DataImageUrlField="PersonPhotoName" DataImageUrlFormatString="~/image/people/{0}" AlternateText="Фотография" HeaderText="Фотография" ReadOnly="true" ControlStyle-Width="85px" ControlStyle-Height="105px" HeaderStyle-HorizontalAlign="Center" />
        </Columns>
        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
        <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
        <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#FFF1D4" />
        <SortedAscendingHeaderStyle BackColor="#B95C30" />
        <SortedDescendingCellStyle BackColor="#F1E5CE" />
        <SortedDescendingHeaderStyle BackColor="#93451F" />
    </asp:GridView>
</asp:Content>
