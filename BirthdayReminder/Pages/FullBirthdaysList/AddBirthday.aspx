<%@ Page Title="Добавление записи" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddBirthday.aspx.cs" Inherits="BirthdayReminder.Pages.FullBirthdaysList.AddBirthday" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1><%: Title %></h1>
    <table>
        <tr>
            <td>Имя</td>
            <td><asp:TextBox ID="TextBoxPersonName" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Дата рождения</td>
            <td><asp:TextBox ID="TextBoxPersonBirthdate" TextMode="Date"  runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Фотография</td>
            <td><asp:FileUpload ID="FileUploadPersonPhoto" runat="server"></asp:FileUpload></td>
        </tr>
    </table>
    <table>
        <tr>
            <td><asp:HyperLink ID="HyperLinkCancel" runat="server" NavigateURL="~/Pages/FullBirthdaysList/FullBirthdaysList.aspx">Cancel</asp:HyperLink>&nbsp;<asp:Button ID="ButtonSave" runat="server" Text="Save" OnClick="ButtonSave_Click" /></td>
        </tr>
    </table>
    <asp:Label runat="server" ID="ErrorMessage"></asp:Label>
</asp:Content>
