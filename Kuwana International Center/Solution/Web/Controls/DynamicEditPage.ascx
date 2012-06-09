<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DynamicEditPage.ascx.cs" Inherits="TaiyoBussan.KIC.DynamicEditPage_imp" %>

   
<%-- This is what every web user will see --%>
<asp:Placeholder runat="server" ID="plhPlain">
    
    <asp:Panel runat="server" ID="pnlEditInfo" Visible="false" style="margin: 1em; padding: 0.5em; background-color: #aaa; font-family: Tahoma;">
        <Localized:LocalizedLinkButton style="color: Yellow;" runat="server" ID="lnkGoEdit" Key="txtClickToEdit" />
    </asp:Panel>
    

    <script language="javascript" type="text/javascript">
        jsi.kic.setContentElement(new jsi.dhtml.Element("<%= pnlContent.ClientID %>"));
        
        //set the image buttons
        jsi.kic.setPrev(new jsi.dhtml.Element("<%= lnkGoPrev.ClientID %>"),"../App_Themes/Main/Images/button_prev.png","../App_Themes/Main/Images/button_prev_o.png");
        
        jsi.kic.setNext(new jsi.dhtml.Element("<%= lnkGoNext.ClientID %>"),"../App_Themes/Main/Images/button_next.png","../App_Themes/Main/Images/button_next_o.png");
    </script>
    
     <div class="Bookmarks Paragraph">
	        
	            
        <asp:Repeater runat="server" ID="rptBookmarks">
            <HeaderTemplate><ul></HeaderTemplate>
            <ItemTemplate>
                <li>
                <div class="ListItemHeading">
                    <a href="javascript: void jsi.kic.showContent('Section<%# ((System.Xml.XmlNode)(Container.DataItem)).Attributes["index"].Value %>');">
                    <%# ((System.Xml.XmlNode)(Container.DataItem)).SelectSingleNode("title").InnerText%>
                    </a></div>
                <div class="ListItemText">
                <%# ((System.Xml.XmlNode)(Container.DataItem)).SelectSingleNode("teaser").InnerText%>
               </div>
                </li>
                <script language="javascript" type="text/javascript">
                    jsi.kic.addContentSection(new jsi.dhtml.Element("Section<%# ((System.Xml.XmlNode)(Container.DataItem)).Attributes["index"].Value %>"));
                </script>
            </ItemTemplate>
            <FooterTemplate></ul></FooterTemplate>
        </asp:Repeater>
                
    </div>

    
    
    <asp:Panel runat="server" CssClass="PageContent Paragraph" id="pnlContent"></asp:Panel>
    <div style="text-align: center; margin-left: 160px;">
        <asp:HyperLink runat="server" NavigateUrl="javascript: void jsi.kic.goPrev();" id="lnkGoPrev"><img  border="0" /></asp:HyperLink> &nbsp;&nbsp; <asp:HyperLink runat="server" ID="lnkGoNext" NavigateUrl="javascript: void jsi.kic.goNext();" ><img  border="0" /></asp:HyperLink>
    </div>
     
    <asp:Repeater runat="server" ID="rptPages">
        <ItemTemplate>
            <div class="Paragraph" id="Section<%# ((System.Xml.XmlNode)(Container.DataItem)).Attributes["index"].Value %>">
                <div class="SectionHeading"><%# ((System.Xml.XmlNode)(Container.DataItem)).SelectSingleNode("title").InnerXml %></div>
                <%# ((System.Xml.XmlNode)(Container.DataItem)).SelectSingleNode("text").InnerXml %>
            </div>
        </ItemTemplate>
    </asp:Repeater>
         
   
</asp:Placeholder>



<%-- This is what a logged-in Administrator will see  --%>
<asp:Panel runat="server" ID="pnlEditor" Visible="false" CssClass="AdminPage">
 
    <asp:Panel runat="server" ID="pnlPreview" style="margin: 1em 1em 1em 0em; padding: 0.5em; background-color: #aaa; font-family: Tahoma;">
        <Localized:LocalizedLinkButton style="color: Yellow;" runat="server" ID="lnkBackToNormal" Key="txtBackToNormal" />
    </asp:Panel>
    
    <script language="javascript" type="text/javascript">
            //turn on textboxes automatically
            /*
            if (!tinyMCE)
            {
                throw("Error: TinyMCE not found.");
            }
            
            tinyMCE.init({
                mode : "textareas",
                theme : "simple",
                editor_selector : "tinymceSimple",
                remove_trailing_nbsp : true,
                entity_encoding : "numeric",
                language : "<%= ((TaiyoBussan.KIC.WebMaster)this.Page.Master).JS_WYSIWYG_Language %>"
                
            });
            
             tinyMCE.init({
                mode : "textareas",
                theme : "advanced",
                editor_selector : "tinymceAdvanced",
                plugins : "advimage",
                remove_trailing_nbsp : true,
                entity_encoding : "numeric",
                language : "<%= ((TaiyoBussan.KIC.WebMaster)this.Page.Master).JS_WYSIWYG_Language %>"
                
            });
            */
    </script>
    
    <asp:Repeater runat="server" ID="rptPagesForEdit">
        <HeaderTemplate>
            <table class="ATable" cellpadding="0" cellspacing="0">
                <tr class="ATableHeader">
                    <th><Localized:LocalizedLiteral runat="server" key="txtPagesPageTitle" /></th>
                    <th colspan="2"><Localized:LocalizedLiteral runat="server" key="txtPagesActions" /></th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td style="font-weight: bold;">
                    <%# ((System.Xml.XmlNode)Container.DataItem).SelectSingleNode("title").InnerText%>
                </td>
                <td style="font-size: 80%">
                    <a href="?<%= PageIndexQueryVariable %>=<%# ((System.Xml.XmlNode)Container.DataItem).Attributes["index"].Value %>" ><Localized:LocalizedLiteral runat="server" Key="txtActionEdit" /></a>
                </td>
                <td style="font-size: 80%">
                    <a onclick="new function() { if (confirm('Delete this page?')) window.location.href='?<%= PageIndexQueryVariable %>=<%# ((System.Xml.XmlNode)Container.DataItem).Attributes["index"].Value %>&amp;d=1'; }; return false; " href="javascript: void(0);" ><Localized:LocalizedLiteral runat="server" Key="txtActionDelete" /></a>
                </td>
            </tr>  
        </ItemTemplate>
        <FooterTemplate>
            </table>
            <a href="?"><Localized:LocalizedLiteral runat="server" key="pagesAddingTitle" /></a>
        </FooterTemplate>
    </asp:Repeater>
    
    
    <div class="APageHeading">
        <Localized:LocalizedLiteral runat="server" ID="litTitle" />
    </div>
    
    <asp:HiddenField runat="server" ID="hdnEditPage"  />
    
    <div class="AForm" style="">
        <div class="Paragraph">
            <div class="AFormRow">
                <div class="InputLabel"><Localized:LocalizedLiteral runat="server" Key="textTitle" /></div>
                <div class="InputItem"><asp:TextBox runat="server" ID="txtTitle" /></div>
            </div>
            <div class="AFormRow">
                <div class="InputLabel"><Localized:LocalizedLiteral runat="server" Key="textTeaser" /></div>
                <div class="InputItem SmallTextarea"><asp:TextBox runat="server" ID="txtTeaser" TextMode="MultiLine" CssClass="tinymceSimple" /></div>
            </div>
            <div class="AFormRow">
                <div class="InputLabel"><Localized:LocalizedLiteral runat="server" Key="textText" /></div>
                <div class="InputItem BigTextarea"><asp:TextBox runat="server" ID="txtText" TextMode="MultiLine" CssClass="tinymceAdvanced" /></div>
            </div>
        </div>
    </div>
            
            
    <div class="AForm" >
        <div class="AFormRow">
            <div class="InputLabel"></div>
            <div class="InputItem">
                <Localized:LocalizedButton runat="server" id="btnSubmit" key="btnSubmit" CssClass="Button" OnClick="Submit_Clicked" />&nbsp;
                <Localized:LocalizedButton runat="server" id="btnCancel" key="btnCancel" CssClass="Button"  OnClick="Cancel_Clicked" />
            </div>
        </div>
    </div>
    
    
</asp:Panel>