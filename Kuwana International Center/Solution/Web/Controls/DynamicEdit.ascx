<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DynamicEdit.ascx.cs" Inherits="TaiyoBussan.KIC.DynamicEdit_imp" %>


<asp:PlaceHolder runat="server" ID="plhScriptOnce" Visible="false">

    <!-- should be called once for the control -->
 
    <script language="javascript" type="text/javascript">
        if (jsi == null)
        {
            alert("Fatal Error: jsi project not running.");
        }
        else if (!jsi.aspdotnet.isLoaded)
        {
            alert("Fatal Error: jsi.aspdotnet project not loaded.");
        }
        else if (jsi.aspdotnet.DynamicEdit == null)
        {
            jsi.aspdotnet.DynamicEdit = function(id, textElement, textboxContainer, textbox, emptyText)
            {
                jsi.aspdotnet.CustomControl.call(this,id,"DynamicEdit");
                
                this.textElement = textElement;
                
                this.textboxContainer = textboxContainer;
                
                this.textbox = textbox;
                
                this.isEmpty = false;
                
                this.emptyText = emptyText;
            }
            
            jsi.aspdotnet.DynamicEdit.prototype.onLoad = function()
            {
                
                this.textbox.loadObject();
                
                if (this.textElement.getValue() == this.emptyText)
                {
                    this.textElement.setColour("#aaaaaa");
                
                    this.isEmpty = true;
                }
                else
                {
                    //set the text once here on Load event
                    
                    this.textbox.setValue(this.textElement.getValue());
                
                    tinyMCE.execInstanceCommand(this.textbox.getAttribute("name"), 'mceSetContent',false, this.textElement.getValue(), true);
                    
                }
            }
            
            jsi.aspdotnet.DynamicEdit.prototype.edit = function(event)
            {
            
                
                //hide the textContainer
                this.textElement.setDisplay(false);
                
                //show the textboxContainer
                this.textboxContainer.setDisplay(true);
               
               
                if (!this.isEmpty) 
                {
                   
                    
                }
                
             
            
            }
            
            jsi.aspdotnet.DynamicEdit.prototype.lock = function()
            {
                
                
                //hide the textContainer
                this.textElement.setDisplay(true);
                
                this.textboxContainer.setDisplay(false);
                
               
                
                /*
                don't change the text otherwise the user will think it is changed.
                
                if (this.textbox.getValue() != "")
                {
                    this.textElement.setValue(this.textbox.getValue());
                }*/
                
                
                
                return false;
                
            }
        }
        
    </script>
</asp:PlaceHolder>

<!--  ===================================   -->

<asp:PlaceHolder runat="server" ID="plhScriptAlways">
   
 <script language="javascript" type="text/javascript">
   
    __temp_ctrl = new jsi.aspdotnet.DynamicEdit
                        (
                        "<%= this.UniqueID %>",
                        new jsi.dhtml.Element("<%= containingData.ClientID %>"),
                        new jsi.dhtml.Element("<%= editingData.ClientID %>"),
                        new jsi.dhtml.Formitem("<%= txtForEdit.ClientID %>"),
                        "<%= this.EmptyText %>"
                        );
    
    jsi.aspdotnet.addControlInstance(__temp_ctrl);
</script>

</asp:PlaceHolder>

<asp:Label runat="server" ID="containingData"><asp:PlaceHolder ID="plhText" runat="server" /></asp:Label>

<asp:Panel runat="server" ID="editingData" style="display: none; width: 97%;">
    <asp:TextBox runat="server" ID="txtForEdit" TextMode="MultiLine" style=" width: 100%; " />
    <div style="text-align: center;">
        <asp:Button runat="server" Text="Submit" id="btnSubmit" onmouseover="this.style.cursor='pointer';" OnClick="Submit_Clicked" />
        &nbsp;
        <asp:Button runat="server" Text="Cancel" id="btnCancel"  onmouseover="this.style.cursor='pointer';"  UseSubmitBehavior="false" /> 
    </div>
</asp:Panel>

     
        