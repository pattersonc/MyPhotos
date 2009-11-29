<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<MyPhotos.Core.Model.Album>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
<<<<<<< HEAD
	ViewPage1
=======
	Index
>>>>>>> 9ba4c3fe087f13567002771f2e073635cfcbf8ba
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<<<<<<< HEAD
    <h2>ViewPage1</h2>
=======
    <h2>Index</h2>
>>>>>>> 9ba4c3fe087f13567002771f2e073635cfcbf8ba

    <table>
        <tr>
            <th></th>
            <th>
                ID
            </th>
            <th>
                Name
            </th>
            <th>
                CreatedDate
            </th>
            <th>
                ModifiedDate
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
<<<<<<< HEAD
                <%= Html.ActionLink("Edit", "Edit", new {  id=item.ID  }) %> |
=======
                <%= Html.ActionLink("Edit", "Edit", new { /* id=item.PrimaryKey */ }) %> |
>>>>>>> 9ba4c3fe087f13567002771f2e073635cfcbf8ba
                <%= Html.ActionLink("Details", "Details", new { /* id=item.PrimaryKey */ })%>
            </td>
            <td>
                <%= Html.Encode(item.ID) %>
            </td>
            <td>
                <%= Html.Encode(item.Name) %>
            </td>
            <td>
                <%= Html.Encode(String.Format("{0:g}", item.CreatedDate)) %>
            </td>
            <td>
                <%= Html.Encode(String.Format("{0:g}", item.ModifiedDate)) %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%= Html.ActionLink("Create New", "Create") %>
    </p>

</asp:Content>

