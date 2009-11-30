<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MyPhotos.Core.Model.Album>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2><%= Model.Name %></h2>


    <% using (Html.BeginForm()) {%>

        <fieldset>
            <legend>Edit album</legend>
            <p>
                <%= Html.LabelFor(model => model.Name) %>
                <%= Html.TextBoxFor(model => model.Name) %>
                <%= Html.ValidationMessageFor(model => model.Name) %>
            </p>
            
            <ul class="album">
            <% foreach (var photo in Model.Photos) { %>
    
            <li>
                <a href="<%= Url.Action("Index", "Photo", new { id = photo.ID }) %>">
                <img alt="<%= photo.Description %>" src="<%= Html.ImgageUrl(photo.ThumbFilename) %>" />
                </a>
                <%= Html.Label(photo.Description) %>
                <%= Html.RadioButton("CoverPhotoID", photo.ID, Model.CoverPhoto.ID == photo.ID, new { name="CoverPhoto"}) %>
                <span>Is album cover</span>
            </li>
    
            <% } %>
            </ul>
            <div class="clear"></div>
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>

    <% } %>
    
    <fieldset>
    <legend>Add photo to album</legend>
        <% using (Html.BeginForm("AddPhoto", "Album", new {id = Model.ID }, FormMethod.Post, new { enctype = "multipart/form-data" })) { %>
        <p>
            <input type="file" id="fileUpload" name="fileUpload" size="23"/>
            <input type="submit" value="Upload file" />
        </p>        
        <% } %> 
    </fieldset>

    <div>
        <%=Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

