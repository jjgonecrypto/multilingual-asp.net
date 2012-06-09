<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="TaiyoBussan.KIC.Admin_Login" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>KIC Admin</title>
</head>
<body>
    <div class="AdminLogin">
     <form id="form1" runat="server">
     
        <div class="Top">
        
        </div>
        
        <div class="GreenLine"> 
        </div>
        <div class="RedLine">
        </div>
        <div class="YellowLine">
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
                    <asp:Button runat="Server" Text="Submit" ID="btnSubmit" />
                </div>
            </div>
        </div>
        
        <div class="YellowLine">
        </div>
        <div class="RedLine">
        </div>
        <div class="GreenLine"> 
        </div>
        
        <div class="Bottom">
            <asp:Label runat="server" CssClass="ErrorText" ID="lblError" />
            Restricted access. 
        </div>
      
    </form>  
    </div>
</body>
</html>