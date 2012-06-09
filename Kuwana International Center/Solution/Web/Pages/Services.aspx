<%@ Page Language="C#" MasterPageFile="~/Master/Master.master" AutoEventWireup="true" CodeFile="Services.aspx.cs" Inherits="TaiyoBussan.KIC.ServicesPage" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    
    <div class="Content ServicesPage">
    
        <div class="Section Services">
        
            <div class="ContentHeading">
                <Localized:LocalizedLiteral runat="server" key="headingServices" />
            </div>
          
            <div class="Paragraph">
                <jjx:dep runat="server" Key="servicesPage" />
            </div>
          
          
        </div>
        
    </div>
</asp:Content>
