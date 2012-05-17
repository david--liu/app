<%@ MasterType VirtualPath="App.master" %>
<%@ page language="c#" autoeventwireup="true" inherits="app.web.ui.views.ProductBrowser, App_Web_3uk4ochh" masterpagefile="App.master" %>
<%@ Import Namespace="app.web.application.catalogbrowsing" %>

<asp:Content ID="content" runat="server" ContentPlaceHolderID="childContentPlaceHolder">
    <form></form>
    <p id="noResultsParagraph" runat="server" visible="true">No Results Found</p>
            <table>
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Description</th>
                        <th>Quantity</th>                   
                        <th>Price</th>                                                
                        <th></th>
                        <th></th>
                    </tr>
                </thead>
                <% foreach (var product in this.model)
                   { %>   
        <tr class="nonShadedRow">                    
            <td class="ListItem">                    
                <a href='#'><%= product.name %></a>
            </td>
            <td>Product Description</td>
            <td><input type="text" class="normalTextBox" value="1" /></td>
            <td>10.00</td>               
            <td><input type="checkbox" class="normalCheckBox" /></td>
            <td><input type="button" value="Add To cart"/></td>

        </tr>
        <% } %>
    	</table>	
								<table>
									<tr>
										<td>
                      <input type="button" value="Add Selected Items To Cart" />
										<td>
                      <input type="button" value="Go To Shopping Cart" />
										<td>
                      <input type="button" value="Continue to checkout" />
										</td>
									</tr>

								</table>							
								    
								
							
		</asp:Content>
