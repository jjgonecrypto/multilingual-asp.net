jsi.kic = new jsi.Package("kic");

jsi.kic.toLoad = null;

jsi.kic.content = new Array();

jsi.kic.contentElement = null;

//ButtonImage
jsi.kic.nextImage = null;

//ButtonImage
jsi.kic.prevImage = null;



jsi.kic.ButtonImage = function(container, src_normal, src_none)
{
    this.container = container;
    this.srcNormal = src_normal;
    this.srcNone = src_none;
}

jsi.kic.ButtonImage.prototype.toggle = function(status)
{
    img = this.container.getElementsByTagName("img")[0];
    img.loadObject();
    
    if (status)
    {
        img.object.src = this.srcNormal;
    }
    else
    {
        img.object.src = this.srcNone;
    }
}

jsi.kic.setPrev = function(container, src_normal, src_none)
{
    this.prevImage = new jsi.kic.ButtonImage(container, src_normal, src_none);
}

jsi.kic.setNext = function(container, src_normal, src_none)
{
    this.nextImage = new jsi.kic.ButtonImage(container, src_normal, src_none);
}


jsi.kic.addContentSection = function(section)
{
    this.content[section.id] = section;
    this.content.length++;
}

jsi.kic.setContentElement = function(element)
{
    this.contentElement = element;
} 
    
jsi.kic.showContent = function(id)
{
    
    this.toLoad = this.content[id];

    //var fadeOut = new jsi.animation.Fade(this.contentElement,100,50,0,5,true);
    var fadeIn = new jsi.animation.Fade(this.contentElement,0,50,0,8,false);
    
      //fadeOut.start();
     //setTimeout(jsi.kic.doSwitch,350);
    
    this.contentElement.setOpacity(0);
   
    this.doSwitch();
   
     fadeIn.start();
     
     //find out which buttons to modify
     var isFirst = true;
     var counter = 0;
     var isLast = false;
     
     for (var i in this.content)
     {
        counter++;
        isLast = (counter == this.content.length);
        
        if (i == id)
        {
            if (isFirst)
            {
                this.prevImage.toggle(false);
            }
            else
            {
                this.prevImage.toggle(true);
            }
            
            if (isLast)
            {
               this.nextImage.toggle(false);
            }
            else
            {
               this.nextImage.toggle(true);
            }
        }
        
        isFirst = false;
        
     
     }
}

jsi.kic.setImageContainers = function(prev, next)
{
    this.prevImageContainer = prev;
    this.nextImageContainer = next;
}



jsi.kic.doSwitch = function()
{
     this.contentElement.setValue(this.toLoad.getValue());
}

jsi.kic.onLoad = function()
{
    var flag = false;
    
    for (var i in jsi.kic.content)
    {
        if (!flag)
        {
            jsi.kic.showContent.call(jsi.kic,i);
            
            flag = true;
        } 
        
        jsi.kic.content[i].setDisplay(false);
   
    }  
}

jsi.kic.goNext = function()
{
    var flag = false;
    
    for (var i in jsi.kic.content)
    {
        if (i == this.toLoad.id)
        {
            flag = true;        
        }
        else if (flag)
        {
            this.showContent(i);
            return;
        }
       
    }
    
    
}

jsi.kic.goPrev = function()
{
    var prev = null;
    
    
    for (var i in this.content)
    {
        if (i == this.toLoad.id)
        {
            if (prev)
            {
                this.showContent(prev);
            }      
        }
        else 
        {
            prev = i;
        }
    }
}

jsi.onload.addStartupFunction(jsi.kic.onLoad);