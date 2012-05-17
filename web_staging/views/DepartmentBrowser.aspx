<%@ MasterType VirtualPath="App.master" %>
<%@ page language="C#" autoeventwireup="true" inherits="app.web.ui.views.DepartmentBrowser, App_Web_3uk4ochh" masterpagefile="App.master" %>
<%@ Import Namespace="app.web.application.catalogbrowsing" %>
<asp:Content ID="content" runat="server" ContentPlaceHolderID="childContentPlaceHolder">
    <p class="ListHead">Select An Department</p>
            <table>
                <% foreach (var department in this.model)
                   { %>            
              <tr class="ListItem">
               <td><a href="#"><%= department.name %></a></td>
           	  </tr>        
              <% } %>
      	    </table>            
</asp:Content>
