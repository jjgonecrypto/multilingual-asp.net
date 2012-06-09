<%@ Page Language="C#"  MasterPageFile="~/Master/Master.master" AutoEventWireup="true" CodeFile="Living.aspx.cs" Inherits="TaiyoBussan.KIC.LivingPage" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="Content LivingPage">
    
        <div class="Section Living">
        
            <div class="ContentHeading">
                <Localized:LocalizedLiteral runat="server" Key="headingLiving" />
            </div>
            
           
            <div class="Paragraph">
                <jjx:dep runat="server" Key="livingPage" />
            </div>
	        
	
        </div>
        
    </div>
</asp:Content>
