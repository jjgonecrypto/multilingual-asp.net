<%@ Page Language="C#" MasterPageFile="~/Master/Master.master" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="TaiyoBussan.Trading.ContactPage" %>

<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    
    <script language="javascript" type="text/javascript">
        jsi.validation.load();
        
        jsi.validation.initialiseASPDOTNETValidation(new Array());
    </script>
    
    <div class="Page ContactPage">
        
        <div class="PageHeader">
            <Localized:LocalizedLiteral runat="server" Key="headingContact" />
        </div>
        
        <asp:Panel runat="server" ID="pnlSuccess" Visible="false">
            <div id="__successText" style="display: none;"><Localized:LocalizedLiteral runat="server" Key="mailSent" /></div>
            <script language="javascript" type="text/javascript" >
                jsi.onload.addCompleteFunction(
                function() 
                {
                    var txt = new jsi.dhtml.Element("__successText");
                    alert(txt.getValue());
                }
                );
            </script>  
        </asp:Panel>
            
        <div class="Section">
            <jjx:de runat="server" key="contactText" />
        </div>
        
        <div class="Form">
            <div class="FormRow">
                <div class="InputLabel">
                    <Localized:LocalizedLiteral runat="server" key="contactFormName" />
                </div>
                <div class="InputItem">
                    <asp:TextBox runat="server" ID="txtName" CssClass="Text" jsi_validate="true" jsi_label="Your Name" jsi_validationtype="text"  />
                </div>
            </div>
            
            <div class="FormRow">
                <div class="InputLabel">
                    <Localized:LocalizedLiteral runat="server" key="contactFormEmail" />
                </div>
                <div class="InputItem">
                    <asp:TextBox runat="server" ID="txtNEmail" CssClass="Text" jsi_validate="true" jsi_label="Email Address" jsi_validationtype="email" />
                </div>
            </div>
            
            <div class="FormRow Textarea">
                <div class="InputLabel">
                    <Localized:LocalizedLiteral runat="server" key="contactFormMessage" />
                </div>
                <div class="InputItem">
                    <asp:TextBox runat="server" TextMode="MultiLine" ID="txtMessage"  jsi_validate="true" jsi_label="Message" jsi_validationtype="text"  />
                </div>
            </div>
            
            <div class="FormRow">
                <div class="InputLabel">
                </div>
                <div class="InputItem">
                    <Localized:LocalizedButton runat="server" ID="btnSubmit" Key="btnSubmit" CssClass="Button" />&nbsp;
                    <button class="Button" onclick="new function() {document.forms[0].reset(); }; return false;"><Localized:LocalizedLiteral runat="server" Key="btnReset" /></button>
                </div>
            </div>
          
        </div>
        
    </div>

</asp:Content>

