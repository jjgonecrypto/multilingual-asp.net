<%@ Page Language="C#" MasterPageFile="~/Master/Master.master" AutoEventWireup="true" CodeFile="FileNotFound.aspx.cs" Inherits="TaiyoBussan.Trading.FileNotFoundPage" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="Content">
    
        <div class="ErrorText" style="margin-left: 1em;">
            <Localized:LocalizedLiteral runat="server" key="msgFileNotFound" />
        </div>
        
    </div>
</asp:Content>