<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Index</h2>

    <% using (Html.BeginForm("Index", "Test", FormMethod.Post, new { enctype = "multipart/form-data" })) { %>
        <br />
        <p><input type="file" id="fileUpload" name="fileUpload" size="23"/></p><br />
        <p><input type="submit" value="Upload file" /></p>        
    <% } %> 

</asp:Content>
