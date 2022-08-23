<%@ Page Title="Редактирование записи" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditFullBirthdaysList.aspx.cs" Inherits="BirthdayReminder.Pages.FullBirthdaysList.EditFullBirthdaysList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1><%: Title %></h1>
    <asp:Label ID="LabelMessage" runat="server"></asp:Label>
    <table>
        <tr>
            <td>Имя</td>
            <td><asp:TextBox ID="TextBoxPersonName" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Дата рождения</td>
            <td><asp:TextBox ID="TextBoxPersonBirthdate" TextMode="Date" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Фотография</td>
            <td><asp:FileUpload ID="FileUploadPersonPhoto" runat="server"></asp:FileUpload></td>
        </tr>
    </table>
    <table>
        <tr>
            <td><asp:RadioButton id="Radio0" OnCheckedChanged="RadioChanged" AutoPostBack="true" Text="Новое фото" GroupName="Radio" runat="server" /></td>
            <td><asp:RadioButton id="Radio1" OnCheckedChanged="RadioChanged" AutoPostBack="true" Text="Старое фото" Checked="True" GroupName="Radio" runat="server" /></td>
            <td><asp:RadioButton id="Radio2" OnCheckedChanged="RadioChanged" AutoPostBack="true" Text="Удалить фото" GroupName="Radio" runat="server" /></td>
        </tr>
        <tr>
            <td><asp:HyperLink ID="HyperLinkCancel" runat="server" NavigateURL="~/Pages/FullBirthdaysList/FullBirthdaysList.aspx">Cancel</asp:HyperLink>&nbsp;<asp:Button ID="ButtonSave" runat="server" Text="Save" OnClick="ButtonSave_Click" /></td>
        </tr>
    </table>
</asp:Content>
