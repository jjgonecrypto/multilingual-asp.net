<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="TaiyoBussan.Trading.AdminLogin" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Trading Admin</title>
    
    
    <!--[if lt IE 7.]>
        <link rel="Stylesheet" runat="server" href="~/App_Themes/IE_lt7.css" />
    <![endif]-->
    
</head> 
<body>
    <div class="Master">
    
    <div class="ALogin">
     <form id="form1" runat="server">
     
        <div class="Top">
        
        </div>
        
        
        <div class="Panel">
            <div class="Form">
                <div class="FormRow">
                    <span class="InputLabel">
                        Username: 
                    </span>
                    <span class="InputItem">
                        <asp:TextBox runat="server" ID="txtUsername"   />
                    </span>
                </div>
                <div class="FormRow">
                    <span class="InputLabel">
                        Password: 
                    </span>
                    <span class="InputItem">
                        <asp:TextBox runat="server" ID="txtPassword" TextMode="Password"  />
                    </span>
                </div>
                <div class="FormRow">
                    <asp:Button runat="Server" Text="Submit" ID="btnSubmit" CssClass="Button" />
                </div>
            </div>
            
            <div class="Bottom">
            <asp:Label runat="server" CssClass="ErrorText" ID="lblError" />
            Restricted access. 
            </div>
        </div>
        
      
        
        
      
    </form>  
    </div>
    </div>
</body>
</html>