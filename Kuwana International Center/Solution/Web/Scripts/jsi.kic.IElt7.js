jsi.kic.ButtonImage.prototype.toggle = function(status)
{
    if (status)
    {
        this.container.setValue("<img src='" + this.srcNormal + "' border='0' />");
    }
    else
    {
        this.container.setValue("<img src='" + this.srcNone + "' border='0' />");
    }
}
