<%@ Page Language="C#" MasterPageFile="~/Master/Master.master" AutoEventWireup="true" CodeFile="Fun.aspx.cs" Inherits="TaiyoBussan.KIC.FunPage" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="Content FunPage">
    
        <div class="Section Fun">
        
            <div class="ContentHeading">
                <Localized:LocalizedLiteral runat="server" key="headingFun" />
            </div>
          
	       
	        
	        <div class="Paragraph">
                <jjx:dep runat="server" Key="funPage" />
            </div>
            
            
        </div>
        
    </div>
</asp:Content>
