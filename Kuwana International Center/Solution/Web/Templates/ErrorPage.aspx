<%@ Page Language="C#" MasterPageFile="~/Master/Master.master" AutoEventWireup="true" CodeFile="ErrorPage.aspx.cs" Inherits="TaiyoBussan.KIC.ErrorPage" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="Content">
    
        <div class="ErrorText" style="margin-left: 1em;">
            <Localized:LocalizedLiteral runat="server" key="msgError" />
        </div>
        
        <div style="margin-left: 1em; margin-top: 1em; color: blue">
            <a href="javascript: history.back();"><Localized:LocalizedLiteral runat="server" key="msgClickBack" /></a>
        </div>
    </div>
</asp:Content>