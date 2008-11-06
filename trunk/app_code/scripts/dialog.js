// JScript File
var win = new winObject();
var dialogIsOpen=false;

function winObject()
{
    this.w=1024;
    this.h=600;
    this.y=0;
}

function GetWindowSize(obj)
{
    // the more standards compliant browsers (mozilla/netscape/opera/IE7) 
    //use window.innerWidth and window.innerHeight
 
    //For IE only
    //obj.y = document.body.scrollTop;
    obj.y = typeof window.pageYOffset != 'undefined' ? window.pageYOffset : document.documentElement.scrollTop;
    
    //For other browsers
    //obj.y = window.pageYOffset; 
    //alert(obj.y);
    
    if (typeof window.innerWidth != 'undefined')
    {
        obj.w = window.innerWidth;
        obj.h = window.innerHeight;
    }
 
    // IE6 in standards compliant mode
    //(i.e. with a valid doctype as the first line in the document)
    
    else if (typeof document.documentElement != 'undefined'
    && typeof document.documentElement.clientWidth != 'undefined' 
    && document.documentElement.clientWidth != 0)
    {
        obj.w = document.documentElement.clientWidth,
        obj.h = document.documentElement.clientHeight
    }
 
    // older versions of IE
 
    else
    {
        obj.w = document.getElementsByTagName('window')[0].clientWidth,
        obj.h = document.getElementsByTagName('body')[0].clientHeight
    }
}

function ShowCoverLayer()
{    
    var divBackGround = document.getElementById('divBackGround');
    if(divBackGround != null)
    {
        var h = getScrollHeight();
        divBackGround.style.width=win.w + 'px';
        divBackGround.style.height=h + 'px'; 
        divBackGround.style.visibility = 'visible'
    }
}

function ShowDialogLayer(windowTitle,dialogWidth,dialogHeight,sourceType,sourceName)
{    
    var divDialog = document.getElementById('divDialog');
    if(divDialog != null)
    {
        dialogIsOpen=true;
        var tdDialogTitle = document.getElementById('tdDialogTitle');        
        if(tdDialogTitle != null) tdDialogTitle.innerText = windowTitle;         
        var tdDialogContent = document.getElementById('tdDialogContent');        
        if(tdDialogContent != null) 
        {
            tdDialogContent.style.height=dialogHeight-22;
            switch(sourceType)
            {
                case 'div':
                    var divContent = document.getElementById(sourceName);
                    if(divContent != null)tdDialogContent.innerHTML = divContent.innerHTML;
                    break;
                case 'page':
                    tdDialogContent.innerHTML = '<iframe style=' +
                    '"width:100%; height:'+ (dialogHeight-24).toString() +'px;margin:2px 0px 0px 0px;" src="' 
                    + sourceName + '"></iframe>'
                    break;
            }        
        }
        else
        {
            alert('tdDialogContent is missing');
        }
        
        divDialog.style.width=dialogWidth + 'px';
        divDialog.style.height=dialogHeight + 'px';
        var top = (win.h-dialogHeight)/2 + win.y;
        if (top <= 0) top = 10;
        divDialog.style.top=top + 'px';
        divDialog.style.left=(win.w-dialogWidth)/2 + 'px';
        divDialog.style.visibility='visible';
    }
    else
    {
        alert('divDiaglog is missing');
    }
}

function OpenDialogWindow(windowTitle,dialogWidth,dialogHeight,sourceType,sourceName)
{   
    GetWindowSize(win); 
    ShowCoverLayer(); 
    ShowDialogLayer(windowTitle,dialogWidth,dialogHeight,sourceType,sourceName);    
}

function WindowOnResize()
{
    if(dialogIsOpen==true)
    {
        GetWindowSize(win);        
        ShowCoverLayer();
        var divDialog = document.getElementById('divDialog');
        if(divDialog != null)
        {
            divDialog.style.top=(win.h-parseInt(divDialog.style.height))/2 + win.y;
            divDialog.style.left=(win.w-parseInt(divDialog.style.width))/2;
            var trDialogTitleBar = document.getElementById('trDialogTitleBar');
            if(trDialogTitleBar != null)RestoreDialogTitleBar(trDialogTitleBar);
        }
        else
        {
            alert('divDialog is missing');
        }
    }
}

function CloseDialogWindow()
{    
    var divBackGround = document.getElementById('divBackGround');
    var divDialog = document.getElementById('divDialog');
    var tdDialogContent = document.getElementById('tdDialogContent'); 
    if(tdDialogContent != null) tdDialogContent.innerHTML='';
    if(divBackGround != null) divBackGround.style.visibility='hidden';
    if(divDialog !=null) divDialog.style.visibility='hidden';
    dialogIsOpen=false;
}

function CloseButtonOnMouseOver(img)
{    
    img.src='./Images/close_hover.jpg';   
}
function CloseButtonOnMouseOut(img)
{
    img.src='./Images/close.jpg';   
}

function BackGroundOnClick()
{  
     var trDialogTitleBar = document.getElementById('trDialogTitleBar');        
     var imgClose = document.getElementById('imgClose');
     var divDialog = document.getElementById('divDialog');
     if(trDialogTitleBar != null && imgClose != null && divDialog != null)
     { 
        trDialogTitleBar.className='dialogTitleBarGreyOut';     
        imgClose.src = './Images/close_grey.jpg';
        //divDialog.className='divDialogGrey';
        setTimeout('RestoreDialogTitleBar(trDialogTitleBar)',250);  
     }  
}

function RestoreDialogTitleBar(trDialogTitleBar)
{    
    trDialogTitleBar.className='dialogTitleBar';
    var imgClose = document.getElementById('imgClose');
    if(imgClose != null) imgClose.src = './Images/close.jpg';
    var divDialog = document.getElementById('divDialog');
    //if(divDialog != null) divDialog.className='divDialog';
}

function getScrollHeight(){		
		return document.all ? Math.max(Math.max(document.documentElement.offsetHeight, 
		document.documentElement.scrollHeight), 
		Math.max(document.body.offsetHeight, document.body.scrollHeight)) : 
		(document.body ? document.body.scrollHeight : 
		((document.documentElement.scrollHeight != 0) ? 
		document.documentElement.scrollHeight : 0));
}