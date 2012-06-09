<%@ Page Theme="Main" MasterPageFile="~/Master/Master.master" Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="TaiyoBussan.Trading.HomePage" %>

<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    
    <div class="Page HomePage">
        
        <div class="PageHeader"><Localized:LocalizedLiteral runat="server" Key="headingHome" /></div>
        
        <div class="Section">
            <jjx:de runat="server" key="homeText" />
        </div>
        
    </div>

</asp:Content>
