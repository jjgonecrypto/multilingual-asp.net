<%@ Page Language="C#" MasterPageFile="~/Master/Master.master" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="TaiyoBussan.KIC.Home" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="Content HomePage">
        
        <div class="Section Welcome">
            <div class="ContentHeading"><Localized:LocalizedLiteral runat="server" Key="headingWelcome" /> </div>
            <jjx:de runat="server" Key="welcomeText" /> 
        </div>
    
        <div class="Section News">
            <div class="ContentHeading"><Localized:LocalizedLiteral  runat="server" Key="headingNews" /> </div>
            <jjx:de runat="server" Key="newsText" /> 
        </div>
        
        <div class="Section Events">
            
            <div class="ContentHeading"><Localized:LocalizedLiteral runat="server" Key="headingEvents" /> </div>
            <jjx:de runat="server" Key="eventsText" /> 
        </div>
        
    </div>



</asp:Content>
