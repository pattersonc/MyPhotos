<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MyPhotos.WebUI.ViewModel.PhotoDetailViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<%= Html.Encode(Model.CurrentPhoto.Description) %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div id="currentPhoto">
    <div>
        <img alt="<%=Model.CurrentPhoto.Description%>" src="<%=Html.ImgageUrl(Model.CurrentPhoto.Filename)%>" />
    </div>
    <span><%=Html.Label(Model.CurrentPhoto.Description)%></span>
    </div>
    
    <div id="prevNextContainer">
        
        <div class="photoNav">
        <span>Previous</span>
        <% if (Model.PrevPhoto != null) {%> 
        <div>
            <a href="<%=Url.Action("index", new {id = Model.PrevPhoto.ID})%>">
            <img alt="<%=Model.PrevPhoto.Description%>" src="<%=Html.ImgageUrl(Model.PrevPhoto.ThumbFilename)%>" />
            </a>
        </div>
        <% } else { %> 
        <div class="startOfAlbumText">
            <span>Start<br />of<br />Album</span>
        </div>
        <% } %>
        </div>
        
        <div class="photoNav">
        <span>Next</span>
        <% if (Model.NextPhoto != null) { %>  
        <div>
            <a href="<%= Url.Action("index", new { id = Model.NextPhoto.ID }) %>">
            <img alt="<%= Model.NextPhoto.Description %>" src="<%= Html.ImgageUrl(Model.NextPhoto.ThumbFilename) %>" />
            </a>
        </div>
        <% } else { %>
        
        <div class="endOfAlbumText">
            <span>End<br />of<br />Album</span>
        </div>
        
        <% } %>
        </div>
        
    </div>

    <div class="clear"></div>
    <p>
        <%=Html.ActionLink("Edit", "Edit", new { /* id=Model.PrimaryKey */ }) %> |
        <%=Html.ActionLink("Back to List", "Index") %>
    </p>

</asp:Content>

