<%@ Page Language="C#" MasterPageFile="~/Master/Master.master" AutoEventWireup="true" CodeFile="About.aspx.cs" Inherits="TaiyoBussan.KIC.AboutPage" %>
<asp:Content ContentPlaceHolderID="cphHeader" runat="server">
     <%-- Google Map --- 
     LIVE:
     
    <script src="http://maps.google.com/maps?file=api&amp;v=2&amp;key=ABQIAAAA1ssKrlY5reBUcr_ZsSlV1BTWsVie7a-Hsh3f74hdMjP7XMGPdhSqFFjJqvGGXhu1JbtvtEIU0Jm7ew"
      type="text/javascript"></script>
     
     LOCAL : port 2036 
     
    <script src="http://maps.google.com/maps?file=api&amp;v=2&amp;key=ABQIAAAA1ssKrlY5reBUcr_ZsSlV1BTbEFVDL7kCJ5SAe5t01INURu3ZwhR3V9FlkC_yMICCFDEVqH32_PT-Ig"
      type="text/javascript"></script>
     
     
     
    <script type="text/javascript">

    //<![CDATA[

    jsi.onload.addCompleteFunction(function() {
      if (GBrowserIsCompatible()) {
        var map = new GMap2(document.getElementById("kicMap"));
        map.addControl(new GSmallMapControl());
        map.addControl(new GMapTypeControl());
        var point = new GLatLng(35.062952,136.690993);
        map.setCenter(point, 13);
         var marker = new GMarker(point);
         //marker.openInfoWindowHtml("<b>KIC</b>");
         map.addOverlay(marker);
            
      }
    });

    //]]>
    </script>
     --%> 
</asp:Content>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="Content AboutPage">
    
        <div class="Section About">
        
           <div class="ContentHeading">
                <Localized:LocalizedLiteral runat="server" key="headingAbout" />
           </div>
          
           
           <div class="Paragraph">
           
                <jjx:de runat="server" key="aboutText" />
           
           </div>
               
              
	        
        </div>
        
    </div>
</asp:Content>
