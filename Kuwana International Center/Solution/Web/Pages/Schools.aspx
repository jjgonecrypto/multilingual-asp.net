<%@ Page Language="C#" MasterPageFile="~/Master/Master.master" AutoEventWireup="true" CodeFile="Schools.aspx.cs" Inherits="TaiyoBussan.KIC.SchoolsPage" %>


<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="Content SchoolsPage">
    
        <div class="Section Schools">
        
            <div class="ContentHeading">
                <Localized:LocalizedLiteral runat="server" key="headingSchools" />
            </div>
          
          
            <div class="Paragraph">
                <jjx:dep runat="server" Key="schoolsPage" />
            </div>
            
        </div>
        
    </div>
</asp:Content>
