<%@ Page Language="C#" MasterPageFile="~/Master/Master.master" AutoEventWireup="true" CodeFile="Resources.aspx.cs" Inherits="TaiyoBussan.KIC.ResourcesPage" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="Content ResourcesPage">
    
        <div class="Section Resources">
        
           <div class="ContentHeading">
                <Localized:LocalizedLiteral runat="server" key="headingResources" />
           </div>
          
           
           <div class="Paragraph">
           
                <jjx:de runat="server" key="resourcesText" />
           
           </div>
            
                
	       
	            
           
                
              
	        
        </div>
        
    </div>
</asp:Content>
