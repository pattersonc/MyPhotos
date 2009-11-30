<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<MyPhotos.Core.Model.Album>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	ViewPage1
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>My Albums</h2>

    <ul class="album">
    <% foreach (var item in Model) { %>
    <li>
        <a href="<%= Url.Action("Edit", "Album", new { id = item.ID }) %>">
        <img alt="<%= item.Name %>" src="<%= Html.ImgageUrl(item.CoverPhoto.ThumbFilename) %>" />
        </a>
        <%= Html.ActionLink("Edit", "Edit", new {  id=item.ID  }) %> |
        <%= Html.ActionLink("View", "Index", "Photo", new { id=item.Photos.First().ID }, new object())%>
    </li>
    <% } %>
    </ul>

    <p>
        <%= Html.ActionLink("Create New", "Create") %>
    </p>

</asp:Content>

