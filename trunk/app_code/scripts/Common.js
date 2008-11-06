//============================================================================
//WebGrid Functions Begin
//============================================================================
//----------------------------------------------------
//Global Variables Begin
//----------------------------------------------------
//Description:  Used to determine which button was clicked to open RowTemplate pop-up window
//              =['add'] if pop-up is opened by click on Add New button
//              =['edit'] if if pop-up is opened by click on Edit button
//              =[null] if if pop-up is opened by click on a cell at grid
var EditorMode = null;
var EditorLoaded = false;
var AllowCloseRowTemplate = false;

//----------------------------------------------------
//Description:  Store the IDs of Edit, Remove, Print, Submit Changes and Reject Changes buttons
var btnEdit = '';
var btnRemove = '';
var btnPrint = '';
var btnSubmit = '';
var btnReject = '';
//----------------------------------------------------
//Global Variables End
//----------------------------------------------------
//----------------------------------------------------
//Event Handlers Begin
//----------------------------------------------------

function grd_MouseDownHandler(gridName, id, button){
	if (EditorMode != null) return true;
}

//Fired when a row is selected
function grd_AfterRowActivateHandler(gridName, rowId){
	setEditRemoveButtons(gridName);
}

//Fired when delete a row
function grd_AfterRowDeletedHandler(gridName, rowId){
	setEditRemoveButtons(gridName);	
}

//Fired when data on a cell is updated
function grd_AfterCellUpdateHandler(gridName, cellId){  
    
    if (EditorMode == 'add' && EditorLoaded == false) return true;
	enableSubmitRejectButtons();
}

function grd_BeforeRowTemplateOpenHandler(gridName, rowId){    
    //Prevent Editor from opening when user clicks 2 times on grid row       
    if (EditorMode == null) return true;    
}

//Fired when row template is opened
function grd_AfterRowTemplateOpenHandler(gridName, rowId){
    
    //Set value for AllowCloseRowTemplate to keep template open
    //when user clicks outside the editor        
    AllowCloseRowTemplate=false; 
    EditorLoaded = true;   
    if (typeof(Page_ClientValidate)=='function' && EditorMode!='add')
    {
        Page_ClientValidate();
    }
}
//Fired before row templated is closed, when click outside the template
//this function return will cancel the event processing by return true
//so, we can keep the editor open.
function grd_BeforeRowTemplateCloseHandler(gridName, rowId, bSaveChanges){
	return !AllowCloseRowTemplate;
}
//Set ADD/EDIT template Position
function ultraWebGrid_AfterRowTemplateOpenHandler(gridName, rowId){

var oAfterRowTemplate = document.getElementById(gridName + "_rowtempl_0"); //replace template name here
var oAfterRowTemplateChild  = document.getElementById(gridName + "_rowtempl_1"); //replace template name here
var oWebGrid = document.getElementById(gridName + "_main");
    var x=0;
    var y=0;    
    if( typeof( oWebGrid.offsetParent ) != 'undefined' ) {
        for(var posX = 0, posY = 0; oWebGrid; oWebGrid = oWebGrid.offsetParent ) {
            posX += oWebGrid.offsetTop;
            posY += oWebGrid.offsetLeft;
        }
        x=posX;
        y=posY;
    } 
    else {
        x=oWebGrid.x;
        y=oWebGrid.y;
    }    
    
    oAfterRowTemplate.style.top= x; 
    oAfterRowTemplate.style.left=y; 

    // set position DataGrid_Child 
    if (oAfterRowTemplateChild != null)
    {    
    oAfterRowTemplateChild.style.top= x; 
    oAfterRowTemplateChild.style.left=y;
    }
}



//Fired when row templated is closed
function grd_AfterRowTemplateCloseHandler(gridName, rowId, bSaveChanges){
    
    //If user click on add button then cancel editor, 
    //the new row will be remove from datagrid   
    var grid = igtbl_getGridById(gridName);
    var activeRow = grid.getActiveRow();
	if (EditorMode=='add' && bSaveChanges==false)
	{	    
	    if (activeRow != null) 
	    {
	        activeRow.deleteRow();
	        activeRow.endEditRow();
	        for(var rowId in grid.SelectedRows)
            {
	            var row=igtbl_getRowById(rowId);
	            row.setSelected(false);	            
            }
            igtbl_cancelPostBack(gridName);
        }
	}
	else
	{
	    if (activeRow != null) 
	    {
	        activeRow.setSelected(true);	        
        }
        if(bSaveChanges==true)
	    {
	        EditorMode=null;
	        EditorLoaded=false;
	        if (activeRow != null) activeRow.processUpdateRow();
	    }
	}
	EditorMode=null;
	EditorLoaded=false;
}

//Fired when click on OK button at row template pop-up window
function RowTemplateOK_OnClick()
{
    //Validate data first    
    if (typeof(Page_ClientValidate)=='function')
    {
        var result = Page_ClientValidate();
        if (result == true)
        {
            //Then fill back the data to grid
            AllowCloseRowTemplate=true;
            igtbl_gRowEditButtonClick(event);
        }
    }
    else
    {    
        AllowCloseRowTemplate=true;
        igtbl_gRowEditButtonClick(event);
    }
}

//Fired when click on Cancel button at row template pop-up window
function RowTemplateCancel_OnClick()
{
    AllowCloseRowTemplate=true;
    igtbl_gRowEditButtonClick(event);
}
//----------------------------------------------------
//Event Handlers End
//----------------------------------------------------
//----------------------------------------------------
//Common Functions Begin
//----------------------------------------------------
function removeRow(gridName) {
    //If Editor is already opened, exit function
    if (EditorMode != null) return false;
    var result = confirm('Bạn có muốn xoá bản ghi này không?');
    if (result == true) 
    {
        var activeRow = igtbl_getGridById(gridName).getActiveRow();
	    if (activeRow != null) 
	    {
	        activeRow.deleteRow();
	        activeRow.endEditRow();
	        enableSubmitRejectButtons();
        }
    }
    return false;
}

function openTemplate(gridName) {
    //If Editor is already opened, exit function
    if (EditorMode != null) return false;
    EditorMode='edit';
    var header = document.getElementById('divRowTemplateHeader');
    if (header != null) header.innerHTML ='Sửa';    
	var activeRow = igtbl_getGridById(gridName).getActiveRow();	
	if (activeRow != null) activeRow.editRow();		
	return false;
}

//Called when user clicks on Add New button
function addNewRow(gridName) {    
    //If Editor is already opened, exit function
    if (EditorMode != null) return false;
    //Set Mode = add
    EditorMode='add';
    //Change editor title
    var header = document.getElementById('divRowTemplateHeader');
    if (header != null) header.innerHTML = 'Thêm Mới';
    //Clear previous validate text
    var ValidateText =  document.getElementById("ValidateText");
    if (ValidateText != null) 
    {
        var ValidatorSummary = ValidateText.all[0];
        ValidatorSummary.innerHTML='';
    }
    //Add new row
    igtbl_addNew(gridName,0).editRow();     
    return false;
}

//Open report viewr when user clicks on Print button
function viewReport(reportName)
{
    window.open("ViewReport.aspx?report=" + reportName);
    return false;
}

//Prevent server buttons submit when editor is opening
function ServerButtonOnclick()
{   
    if (EditorMode != null) return false;
    return true;
}

function setEditRemoveButtons(gridName)
{
    var activeRow = igtbl_getGridById(gridName).getActiveRow();	
	if (activeRow != null)
	{
        enableButton(btnEdit);
        enableButton(btnRemove);
    }
    else
    {
        disableButton(btnEdit);
        disableButton(btnRemove);
    }
}

function enableSubmitRejectButtons()
{
    enableButton(btnSubmit);
    enableButton(btnReject);
}

function enableButton(btnName)
{
    document.getElementById(btnName).disabled='';
}

function disableButton(btnName)
{
    document.getElementById(btnName).disabled='disabled';
}

//----------------------------------------------------
//Common Functions End
//----------------------------------------------------
//============================================================================
//WebGrid Functions End
//============================================================================
//============================================================================
//Validate control
//============================================================================
function DoubleOnly(id,e)
{
	var key = window.event ? e.keyCode : e.which;  
	//Number 
	if (key <48 || key >57) 
	{	
			if (key==46)
			{
				//Decimal dot
				var ctrl=document.getElementById(id);
				var current_text=ctrl.value;
				if (current_text.indexOf('.') > -1)
					e.preventDefault? e.preventDefault() : e.returnValue = false;				
			}
			else
			{
				if (key != 8 && key != 0)				
					e.preventDefault? e.preventDefault() : e.returnValue = false;	
			}				
	}
}

function NumbersOnly(e)
{
	var key = window.event ? e.keyCode : e.which;  
	if (key>=48 && key<=57)
		{
		return true;
		}
	else
	    {
	    return false;
	    }
}
function ValidateLetter(e)
{
    var key = window.event ? e.keyCode : e.which;
    // Chi cho phep nhap cac ky tu vao la so va chu( chu hoa va chu thuong) ngoai ra se cho la cac ky tu ko hop le
    // 33(!); 13(Enter); 64(@); 35(#); 36($); 42(*) 94(^);126(~); xem trong bang ma asscii
    if( key == 13 ||(key >= 33 && key <= 47)||(key >= 60 && key <= 64)||(key >= 91 && key <= 94)||(key >= 123 && key <= 126)) 
    {
        return false
    }
    else
    {
        return true;
    }
}
// Removes leading whitespaces
function LTrim( value ) {	
	var re = /\s*((\S+\s*)*)/;
	return value.replace(re, "$1");	
}

// Removes ending whitespaces
function RTrim( value ) {	
	var re = /((\s*\S+)*)\s*/;
	return value.replace(re, "$1");	
}

// Removes leading and ending whitespaces
function Trim( value ) {	
	return LTrim(RTrim(value));	
}


//============================================================================
//Validate control end
//============================================================================


function ShowModalDialog(sURL, sTitle, sWidth, sHeight) {
	var sFeatures = "status:no;dialogWidth:" + sWidth + "px;dialogHeight:" + sHeight + "px;dialogHide:true;help:no;scroll:no";
	var objArgs = new Object();;
	objArgs.URL = sURL;
	objArgs.title = sTitle;
	objArgs.opener = window;
	return window.showModalDialog("DialogPage.htm", objArgs, sFeatures);
}

function lib_bwcheck(){ //Browsercheck (needed)

    this.ver=navigator.appVersion

    this.agent=navigator.userAgent

    this.dom=document.getElementById?1:0

    this.opera5=this.agent.indexOf("Opera 5")>-1

    this.ie5=(this.ver.indexOf("MSIE 5")>-1 && this.dom && !this.opera5)?1:0; 

    this.ie6=(this.ver.indexOf("MSIE 6")>-1 && this.dom && !this.opera5)?1:0;

    this.ie7=(this.ver.indexOf("MSIE 7")>-1 && this.dom && !this.opera5)?1:0;

    this.ie4=(document.all && !this.dom && !this.opera5)?1:0;

    this.ie=this.ie4||this.ie5||this.ie6||this.ie7

    this.mac=this.agent.indexOf("Mac")>-1

    this.ns6=(this.dom && parseInt(this.ver) >= 5) ?1:0; 

    this.ns4=(document.layers && !this.dom)?1:0;

    this.bw=(this.ie7 ||this.ie6 || this.ie5 || this.ie4 || this.ns4 || this.ns6 || this.opera5)

    return this
}

                                    