<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddProductTemplate.aspx.cs"
    Inherits="Admin_AddProductTemplate" EnableEventValidation="false" %>
<%@ Register Assembly="Infragistics2.WebUI.WebHtmlEditor.v7.1, Version=7.1.20071.1048, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.WebHtmlEditor" TagPrefix="ighedit" %>
<%@ Register Assembly="Infragistics2.WebUI.Misc.v7.1, Version=7.1.20071.1048, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.Misc" TagPrefix="igmisc" %>
<%@ Register Assembly="Infragistics2.WebUI.WebDateChooser.v7.1, Version=7.1.20071.1048, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.WebSchedule" TagPrefix="igsch" %>
<%@ Register Assembly="Infragistics2.WebUI.WebDataInput.v7.1, Version=7.1.20071.1048, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.WebDataInput" TagPrefix="igtxt" %>
    
    <%@ OutputCache Duration="30" VaryByParam="id" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Thêm sản phẩm</title>
    <link href="../Css/admin.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="../Scripts/multifile_compressed.js"></script>

    <script type="text/javascript" src="../Scripts/dialog.js"></script>
    
    <script type="text/javascript" src="../Scripts/common.js"></script>

    <script type="text/javascript" src="../Scripts/WebForm.js"></script>

    <script type="text/javascript" src="../Scripts/WebUIValidation.js"></script>

    <script type="text/javascript" id="igClientScript">
    
      
    var selectedImage = null;        
    

//    function CheckNhomSanPham()
//    {           
//        var cv = document.       
//        return Page_IsValid;      
//    }
    function XoaAnhPhu(id, src, imgid, obj)
    {                              
        selectedImage = obj;
        OpenDialogWindow('Xóa ảnh', 350, 170,'page','Delete.aspx?id=' + id + '&src=' + src 
        + '&imgid=' + imgid + '&type=anhsanpham');
    }

    function btnThoat_OnClose()
    {
        if ('<%=ViewState["Save"].ToString() %>' == 'TRUE')
        {
            window.parent.Refresh();
        }
        else
        {
            window.parent.CloseDialogWindow();
        }
    }
   
    function CheckSaved()
    {                   
        if ('<%=ViewState["Action"].ToString() %>' != 'EDIT') 
        {            
            alert('Bạn phải lưu sản phẩm trước khi tải ảnh phụ!');
            return false;
        }        
        else
        {
            var file = document.getElementById('<%=fileAnhPhu.ClientID%>');        
            
            if (file.value == '')
            {            
                alert('Hãy chọn ảnh để tải lên!');
                return false;
            }
            else
            {
                return true;
            }
        }                          
    }
           
        
    function fileAnh_onselect(obj)
    {    
        var list = document.getElementById('lstAnh');
        var lsOption=document.createElement("option"); 
                
        list.options.add(lsOption);       
        lsOption.innerText = obj.value;
    }
    
    function Refresh()
    {           
        selectedImage.width=0;
        selectedImage.height=0;
		selectedImage.style.visibility='hidden';		
		CloseDialogWindow();
    } 

    function pnlAnhPhu_RefreshComplete(oPanel){      
	    CloseDialogWindow();
    }

    function validateKhuyenMai(source, arguments)
    {    
        var cv = document.getElementById('cvKhuyenMai');
	    var wdcFrom = igdrp_getComboById('wdcBatDauKM');
	    var wdcTo = igdrp_getComboById('wdcKetThucKM');
	    var chk = document.getElementById('chkKhuyenMai');
	    
	    if (chk.checked == true)
	    {
	        var myDate = wdcFrom.getValue();
	        var newDate = wdcTo.getValue(); 	    
            var month = myDate.getMonth();        
            var modifiedMonth = month+1;        
            var modifiedDate = new Date(myDate.getYear(), modifiedMonth, myDate.getDate());
	        if ((newDate < modifiedDate) && (newDate > myDate)) 
	        {
	            arguments.IsValid = true;	       
	            return;
	        }
	        else
	        {	        
	           arguments.IsValid = false;
	           return;	       
	        }
	    }            
    }
    
     function chkKhuyenMai_onclick(obj)
    {                
            var wdcFrom = igdrp_getComboById('wdcBatDauKM');
            var wdcTo = igdrp_getComboById('wdcKetThucKM');
            var txtNoiDung = document.getElementById('txtMoTaKhuyenMai');
                                      
            wdcFrom.setEnabled(obj.checked);
            wdcTo.setEnabled(obj.checked);
            txtNoiDung.disabled = !obj.checked;      
    }
    
    function chkGiamGia_onclick(obj)
    {                
        var txtGiaMoi = igedit_getById('txtGiaMoi'); 
            var rfv = document.getElementById('rfvGiaMoi');   
            var cvGiaMoi = document.getElementById('cvGiaMoi');  
                                                              
            txtGiaMoi.setEnabled(obj.checked);                    
            ValidatorEnable(rfv, obj.checked);
            ValidatorEnable(cvGiaMoi, obj.checked);
    }
// -->
    </script>

</head>
<body>
    <form id="form1" runat="server" defaultbutton="btnLuu" defaultfocus="txtTenSanPham">
        <div id="divDialog" class="divDialog">
            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                <tr class="dialogTitleBar" id="trDialogTitleBar">
                    <td id="tdDialogTitle" class="dialogTitle">
                    </td>
                    <td style="width: 20%; text-align: right; padding-right: 2px;">
                        <img id="imgClose" alt="Close" src="../Images/close.jpg" style="border: none; cursor: hand"
                            onclick="CloseDialogWindow();" onmouseover="CloseButtonOnMouseOver(this);" onmouseout="CloseButtonOnMouseOut(this);" /></td>
                </tr>
                <tr>
                    <td colspan="2" id="tdDialogContent" class="dialogContent">
                        &nbsp;</td>
                </tr>
            </table>
        </div>
         <asp:ScriptManager ID="ScriptManager1" runat="server">
                                    </asp:ScriptManager>
        <div>
            <table border="0" cellpadding="0" cellspacing="0" width="950px" class="row-template-table"
                style="margin-top: 5px; margin-left: 5px">
                <tr>
                    <td align="left" colspan="4" style="height: 30px">
                        <table width="100%" cellspacing="3px" style="text-align: left; vertical-align: top;
                            vertical-align: top">
                            <tr>
                                <td style="width: 16%; padding-right: 5px;" align="right">
                                    Tên sản phẩm</td>
                                <td style="width: 30%" valign="top">
                                    <asp:TextBox ID="txtTenSanPham" runat="server" Width="266px"></asp:TextBox><asp:RequiredFieldValidator
                                        ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTenSanPham"
                                        ErrorMessage="*" Width="4%"></asp:RequiredFieldValidator></td>
                                <td style="width: 10%" align="right" valign="top">
                                    Danh mục</td>
                                <td style="width: 27%" valign="top">
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                    <asp:DropDownList ID="ddlNhomSanPham" runat="server" Width="272px" AutoPostBack="True" OnSelectedIndexChanged="ddlNhomSanPham_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:CustomValidator ID="cvNhomSanPham" runat="server" 
                                    ControlToValidate="ddlNhomSanPham" ErrorMessage="Chọn nhóm sản phẩm không đúng"
                                        SetFocusOnError="True" OnServerValidate="cvNhomSanPham_ServerValidate" EnableClientScript="False"></asp:CustomValidator>
                                    </ContentTemplate>
                                    </asp:UpdatePanel>
                                    
                                    </td>
                            </tr>
                            <tr>
                                <td align="right" style="padding-right: 5px; height: 22px;">
                                    Hãng sản xuất</td>
                                <td valign="top" style="height: 22px">
                                    <asp:DropDownList ID="ddlHangSanXuat" runat="server" Width="272px">
                                    </asp:DropDownList></td>
                                <td align="right" valign="top" style="height: 22px">
                                    Khu vực</td>
                                <td valign="top" style="height: 22px">
                                    <asp:DropDownList ID="ddlKhuVuc" runat="server" Width="272px">
                                    </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td align="right" style="padding-right: 5px">
                                    Giá</td>
                                <td style="height: 24px" valign="top">
                                    <igtxt:WebNumericEdit ID="txtGiaSanPham" runat="server" Width="266px" HorizontalAlign="Left" Nullable="False">
                                    </igtxt:WebNumericEdit>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtGiaSanPham"
                                        ErrorMessage="*" Width="4%"></asp:RequiredFieldValidator></td>
                                <td align="right" valign="top">
                                    <asp:CheckBox ID="chkGiamGia" runat="server" Font-Bold="False" Text="Giảm giá" TextAlign="Left" /></td>
                                <td valign="top">
                                    <igtxt:WebNumericEdit ID="txtGiaMoi" runat="server" Width="266px" HorizontalAlign="Left"
                                        Enabled="False">
                                    </igtxt:WebNumericEdit>
                                    <asp:RequiredFieldValidator ID="rfvGiaMoi" runat="server" ControlToValidate="txtGiaMoi"
                                        ErrorMessage="*" Width="4%" Enabled="False"></asp:RequiredFieldValidator></td>
                            </tr>
                             <tr>
                    <td align="left" colspan="4" style="height: 30px">
                        <table width="100%" cellspacing="0px" style="padding-left: 5px; text-align: left;
                            vertical-align: top; vertical-align: top">
                            <tr>
                                <td align="right" style="width: 16%; padding-right: 5px;">
                                    <asp:CheckBox ID="chkKhuyenMai" runat="server" Text="Khuyến mãi" /></td>
                                <td style="width: 30%" align="right">
                                    <asp:CustomValidator ID="cvKhuyenMai" ClientValidationFunction="validateKhuyenMai"
                                        runat="server" ControlToValidate="wdcKetThucKM" ErrorMessage="Thời gian khuyến mại không hợp lệ"
                                        SetFocusOnError="True"></asp:CustomValidator>&nbsp;</td>
                                <td align="right" style="width: 10%">
                                </td>
                                <td style="width: 27%">
                                    <asp:CompareValidator ID="cvGiaMoi" runat="server" ControlToCompare="txtGiaSanPham"
                                        ControlToValidate="txtGiaMoi" ErrorMessage="Giá mới phải nhỏ hơn giá sản phẩm"
                                        Operator="LessThan" Type="Double" Enabled="False" SetFocusOnError="True"></asp:CompareValidator></td>
                            </tr>
                            <tr>
                                <td align="right" style="padding-right: 5px">
                                    Bắt đầu KM</td>
                                <td style="width: 30%">
                                    <igsch:WebDateChooser ID="wdcBatDauKM" runat="server" Width="89%" Enabled="False"
                                        Format="Long">
                                        <CalendarLayout Culture="Vietnamese (Vietnam)">
                                        </CalendarLayout>
                                    </igsch:WebDateChooser>
                                </td>
                                <td align="right" style="width: 10%">
                                    Kết thúc KM</td>
                                <td style="width: 27%">
                                    <igsch:WebDateChooser ID="wdcKetThucKM" runat="server" Width="89%" Enabled="False"
                                        Format="Long">
                                        <CalendarLayout Culture="Vietnamese (Vietnam)">
                                        </CalendarLayout>
                                    </igsch:WebDateChooser>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="padding-right: 5px">
                                    Nội dung khuyến mãi</td>
                                <td colspan="3">
                                    <asp:TextBox ID="txtMoTaKhuyenMai" runat="server" Height="50px" TextMode="MultiLine"
                                        Width="95%" Enabled="False"></asp:TextBox></td>
                            </tr>
                        </table>
                    </td>
                </tr>                           
                            <tr>
                                <td rowspan="1" align="right" valign="top" style="padding-right: 5px;">
                                    Ảnh chính
                                </td>
                                <td colspan="2" valign="top" style="height: 82px">
                                    <asp:FileUpload ID="fileAnhChinh" runat="server" Width="96%" />
                                    <asp:Image ID="imgAnhChinh" runat="server" Height="80px" Width="100px" />
                                    <asp:Label ID="lblAnhChinhErr" runat="server" ForeColor="Red"></asp:Label></td>
                                <td align="left" style="height: 82px" valign="top">
                                    Thuộc tính sản phẩm:<br />                                   
                                    <asp:UpdatePanel ID="pnlThuocTinh" runat="server" ChildrenAsTriggers="False" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="ddlThuocChinhCha" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlThuocChinhCha_SelectedIndexChanged"
                                                Width="90%">
                                            </asp:DropDownList>
                                            <asp:ListBox ID="lbiThuocTinh" runat="server" SelectionMode="Multiple" Width="90%"></asp:ListBox>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="ddlNhomSanPham" EventName="SelectedIndexChanged" />
                                            <asp:AsyncPostBackTrigger ControlID="ddlThuocChinhCha" EventName="SelectedIndexChanged" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                    </td>
                            </tr>
                            <tr>
                                <td align="right" valign="top" style="padding-right: 5px">
                                    Các ảnh phụ
                                </td>
                                <td colspan="2" valign="top">
                                    <asp:FileUpload ID="fileAnhPhu" runat="server" Width="96%" /><asp:Button ID="btnUpLoad"
                                        runat="server" CssClass="button" Text="Tải lên" OnClick="btnUpLoad_Click" />
                                    <asp:Label ID="lblAnhPhuErr" runat="server" ForeColor="Red"></asp:Label></td>
                                <td style="height: 50px">
                                    <igmisc:WebAsyncRefreshPanel ID="pnlAnhPhu" runat="server" Height="100%" Width="90%"
                                        Overflow="Auto" RefreshComplete="pnlAnhPhu_RefreshComplete" OnContentRefresh="pnlAnhPhu_ContentRefresh">
                                    </igmisc:WebAsyncRefreshPanel>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                                <td align="right" valign="top" style="padding-right: 5px; width: 19%">
                                    Mô tả sản phẩm</td>
                                <td colspan="3" valign="top">
                                    <ighedit:WebHtmlEditor ID="wheMoTaSanPham" runat="server" FontFormattingList="Heading 1=<h1>&Heading 2=<h2>&Heading 3=<h3>&Heading 4=<h4>&Heading 5=<h5>&Normal=<p>"
                                        FontNameList="Arial,Verdana,Tahoma,Courier New,Georgia" FontSizeList="1,2,3,4,5,6,7"
                                        FontStyleList="Blue Underline=color:blue;text-decoration:underline;&Red Bold=color:red;font-weight:bold;&ALL CAPS=text-transform:uppercase;&all lowercase=text-transform:lowercase;&Reset="
                                        Height="200px" SpecialCharacterList="Ω,Σ,Δ,Φ,Γ,Ψ,Π,Θ,Ξ,Λ,ξ,μ,η,φ,ω,ε,θ,δ,ζ,ψ,β,π,σ,ß,þ,Þ,ƒ,Ж,Ш,Ю,Я,ж,ф,ш,ю,я,お,あ,絵,Æ,Å,Ç,Ð,Ñ,Ö,æ,å,ã,ç,ð,ë,ñ,¢,£,¤,¥,№,™,©,®,—,@,•,¡,&#14;,←,↑,→,↓,↔,↕,↖,↗,↘,↙,&#18;,¦,§,¨,ª,¬,¯,¶,°,±,«,»,·,¸,º,¹,²,³,¼,½,¾,¿,×,÷"
                                        Width="96%" Focus="False" UseLineBreak="True">
                                        <DownlevelLabel Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                            Font-Underline="False"></DownlevelLabel>
                                        <DropDownStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                            Font-Underline="False"></DropDownStyle>
                                        <ProgressBar Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                            Font-Underline="False"></ProgressBar>
                                        <DownlevelTextArea Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                            Font-Underline="False"></DownlevelTextArea>
                                        <RightClickMenu Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                            Font-Underline="False">
                                            <ighedit:HtmlBoxMenuItem runat="server" Act="Cut" Font-Bold="False" Font-Italic="False"
                                                Font-Overline="False" Font-Strikeout="False" Font-Underline="False">
                                                <Dialog Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                    Font-Underline="False"></Dialog>
                                            </ighedit:HtmlBoxMenuItem>
                                            <ighedit:HtmlBoxMenuItem runat="server" Act="Copy" Font-Bold="False" Font-Italic="False"
                                                Font-Overline="False" Font-Strikeout="False" Font-Underline="False">
                                                <Dialog Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                    Font-Underline="False"></Dialog>
                                            </ighedit:HtmlBoxMenuItem>
                                            <ighedit:HtmlBoxMenuItem runat="server" Act="Paste" Font-Bold="False" Font-Italic="False"
                                                Font-Overline="False" Font-Strikeout="False" Font-Underline="False">
                                                <Dialog Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                    Font-Underline="False"></Dialog>
                                            </ighedit:HtmlBoxMenuItem>
                                            <ighedit:HtmlBoxMenuItem runat="server" Act="PasteHtml" Font-Bold="False" Font-Italic="False"
                                                Font-Overline="False" Font-Strikeout="False" Font-Underline="False">
                                                <Dialog Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                    Font-Underline="False"></Dialog>
                                            </ighedit:HtmlBoxMenuItem>
                                            <ighedit:HtmlBoxMenuItem runat="server" Act="CellProperties" Font-Bold="False" Font-Italic="False"
                                                Font-Overline="False" Font-Strikeout="False" Font-Underline="False">
                                                <Dialog InternalDialogType="CellProperties" Font-Bold="False" Font-Italic="False"
                                                    Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></Dialog>
                                            </ighedit:HtmlBoxMenuItem>
                                            <ighedit:HtmlBoxMenuItem runat="server" Act="TableProperties" Font-Bold="False" Font-Italic="False"
                                                Font-Overline="False" Font-Strikeout="False" Font-Underline="False">
                                                <Dialog InternalDialogType="ModifyTable" Font-Bold="False" Font-Italic="False" Font-Overline="False"
                                                    Font-Strikeout="False" Font-Underline="False"></Dialog>
                                            </ighedit:HtmlBoxMenuItem>
                                            <ighedit:HtmlBoxMenuItem runat="server" Act="InsertImage" Font-Bold="False" Font-Italic="False"
                                                Font-Overline="False" Font-Strikeout="False" Font-Underline="False">
                                                <Dialog Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                    Font-Underline="False"></Dialog>
                                            </ighedit:HtmlBoxMenuItem>
                                        </RightClickMenu>
                                        <TextWindow Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                            Font-Underline="False"></TextWindow>
                                        <Toolbar Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                            Font-Underline="False">
                                            <ighedit:ToolbarButton runat="server" Type="Bold" Font-Bold="False" Font-Italic="False"
                                                Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ighedit:ToolbarButton>
                                            <ighedit:ToolbarButton runat="server" Type="Italic" Font-Bold="False" Font-Italic="False"
                                                Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ighedit:ToolbarButton>
                                            <ighedit:ToolbarButton runat="server" Type="Underline" Font-Bold="False" Font-Italic="False"
                                                Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ighedit:ToolbarButton>
                                            <ighedit:ToolbarButton runat="server" Type="Strikethrough" Font-Bold="False" Font-Italic="False"
                                                Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ighedit:ToolbarButton>
                                            <ighedit:ToolbarButton runat="server" Type="Undo" Font-Bold="False" Font-Italic="False"
                                                Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ighedit:ToolbarButton>
                                            <ighedit:ToolbarButton runat="server" Type="Redo" Font-Bold="False" Font-Italic="False"
                                                Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ighedit:ToolbarButton>
                                            <ighedit:ToolbarButton runat="server" Type="JustifyLeft" Font-Bold="False" Font-Italic="False"
                                                Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ighedit:ToolbarButton>
                                            <ighedit:ToolbarButton runat="server" Type="JustifyCenter" Font-Bold="False" Font-Italic="False"
                                                Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ighedit:ToolbarButton>
                                            <ighedit:ToolbarButton runat="server" Type="JustifyRight" Font-Bold="False" Font-Italic="False"
                                                Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ighedit:ToolbarButton>
                                            <ighedit:ToolbarButton runat="server" Type="JustifyFull" Font-Bold="False" Font-Italic="False"
                                                Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ighedit:ToolbarButton>
                                            <ighedit:ToolbarButton runat="server" Type="Indent" Font-Bold="False" Font-Italic="False"
                                                Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ighedit:ToolbarButton>
                                            <ighedit:ToolbarButton runat="server" Type="Outdent" Font-Bold="False" Font-Italic="False"
                                                Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ighedit:ToolbarButton>
                                            <ighedit:ToolbarDialogButton runat="server" Type="FontColor" Font-Bold="False" Font-Italic="False"
                                                Font-Overline="False" Font-Strikeout="False" Font-Underline="False">
                                                <Dialog Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                    Font-Underline="False"></Dialog>
                                            </ighedit:ToolbarDialogButton>
                                            <ighedit:ToolbarMenuButton runat="server" Type="InsertTable" Font-Bold="False" Font-Italic="False"
                                                Font-Overline="False" Font-Strikeout="False" Font-Underline="False">
                                                <Menu Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                    Font-Underline="False">
                                                    <ighedit:HtmlBoxMenuItem runat="server" Act="TableProperties" Font-Bold="False" Font-Italic="False"
                                                        Font-Overline="False" Font-Strikeout="False" Font-Underline="False">
                                                        <Dialog InternalDialogType="InsertTable" Font-Bold="False" Font-Italic="False" Font-Overline="False"
                                                            Font-Strikeout="False" Font-Underline="False"></Dialog>
                                                    </ighedit:HtmlBoxMenuItem>
                                                    <ighedit:HtmlBoxMenuItem runat="server" Act="InsertColumnRight" Font-Bold="False"
                                                        Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False">
                                                        <Dialog Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                            Font-Underline="False"></Dialog>
                                                    </ighedit:HtmlBoxMenuItem>
                                                    <ighedit:HtmlBoxMenuItem runat="server" Act="InsertColumnLeft" Font-Bold="False"
                                                        Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False">
                                                        <Dialog Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                            Font-Underline="False"></Dialog>
                                                    </ighedit:HtmlBoxMenuItem>
                                                    <ighedit:HtmlBoxMenuItem runat="server" Act="InsertRowAbove" Font-Bold="False" Font-Italic="False"
                                                        Font-Overline="False" Font-Strikeout="False" Font-Underline="False">
                                                        <Dialog Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                            Font-Underline="False"></Dialog>
                                                    </ighedit:HtmlBoxMenuItem>
                                                    <ighedit:HtmlBoxMenuItem runat="server" Act="InsertRowBelow" Font-Bold="False" Font-Italic="False"
                                                        Font-Overline="False" Font-Strikeout="False" Font-Underline="False">
                                                        <Dialog Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                            Font-Underline="False"></Dialog>
                                                    </ighedit:HtmlBoxMenuItem>
                                                    <ighedit:HtmlBoxMenuItem runat="server" Act="DeleteRow" Font-Bold="False" Font-Italic="False"
                                                        Font-Overline="False" Font-Strikeout="False" Font-Underline="False">
                                                        <Dialog Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                            Font-Underline="False"></Dialog>
                                                    </ighedit:HtmlBoxMenuItem>
                                                    <ighedit:HtmlBoxMenuItem runat="server" Act="DeleteColumn" Font-Bold="False" Font-Italic="False"
                                                        Font-Overline="False" Font-Strikeout="False" Font-Underline="False">
                                                        <Dialog Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                            Font-Underline="False"></Dialog>
                                                    </ighedit:HtmlBoxMenuItem>
                                                    <ighedit:HtmlBoxMenuItem runat="server" Act="IncreaseColspan" Font-Bold="False" Font-Italic="False"
                                                        Font-Overline="False" Font-Strikeout="False" Font-Underline="False">
                                                        <Dialog Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                            Font-Underline="False"></Dialog>
                                                    </ighedit:HtmlBoxMenuItem>
                                                    <ighedit:HtmlBoxMenuItem runat="server" Act="DecreaseColspan" Font-Bold="False" Font-Italic="False"
                                                        Font-Overline="False" Font-Strikeout="False" Font-Underline="False">
                                                        <Dialog Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                            Font-Underline="False"></Dialog>
                                                    </ighedit:HtmlBoxMenuItem>
                                                    <ighedit:HtmlBoxMenuItem runat="server" Act="IncreaseRowspan" Font-Bold="False" Font-Italic="False"
                                                        Font-Overline="False" Font-Strikeout="False" Font-Underline="False">
                                                        <Dialog Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                            Font-Underline="False"></Dialog>
                                                    </ighedit:HtmlBoxMenuItem>
                                                    <ighedit:HtmlBoxMenuItem runat="server" Act="DecreaseRowspan" Font-Bold="False" Font-Italic="False"
                                                        Font-Overline="False" Font-Strikeout="False" Font-Underline="False">
                                                        <Dialog Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                            Font-Underline="False"></Dialog>
                                                    </ighedit:HtmlBoxMenuItem>
                                                    <ighedit:HtmlBoxMenuItem runat="server" Act="CellProperties" Font-Bold="False" Font-Italic="False"
                                                        Font-Overline="False" Font-Strikeout="False" Font-Underline="False">
                                                        <Dialog InternalDialogType="CellProperties" Font-Bold="False" Font-Italic="False"
                                                            Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></Dialog>
                                                    </ighedit:HtmlBoxMenuItem>
                                                    <ighedit:HtmlBoxMenuItem runat="server" Act="TableProperties" Font-Bold="False" Font-Italic="False"
                                                        Font-Overline="False" Font-Strikeout="False" Font-Underline="False">
                                                        <Dialog InternalDialogType="ModifyTable" Font-Bold="False" Font-Italic="False" Font-Overline="False"
                                                            Font-Strikeout="False" Font-Underline="False"></Dialog>
                                                    </ighedit:HtmlBoxMenuItem>
                                                </Menu>
                                            </ighedit:ToolbarMenuButton>
                                            <ighedit:ToolbarButton runat="server" Type="InsertLink" Font-Bold="False" Font-Italic="False"
                                                Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ighedit:ToolbarButton>
                                            <ighedit:ToolbarDropDown runat="server" Type="FontName" Font-Bold="False" Font-Italic="False"
                                                Font-Overline="False" Font-Strikeout="False" Font-Underline="False" Width="80px">
                                            </ighedit:ToolbarDropDown>
                                            <ighedit:ToolbarDropDown runat="server" Type="FontSize" Font-Bold="False" Font-Italic="False"
                                                Font-Overline="False" Font-Strikeout="False" Font-Underline="False" Width="50px">
                                            </ighedit:ToolbarDropDown>
                                        </Toolbar>
                                        <TabStrip Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                            Font-Underline="False"></TabStrip>
                                    </ighedit:WebHtmlEditor>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" valign="top" style="padding-right: 5px">
                                    Thông tin sản phẩm</td>
                                <td colspan="3" valign="top">
                                    <ighedit:WebHtmlEditor ID="wheThongTinSanPham" runat="server" FontFormattingList="Heading 1=<h1>&Heading 2=<h2>&Heading 3=<h3>&Heading 4=<h4>&Heading 5=<h5>&Normal=<p>"
                                        FontNameList="Arial,Verdana,Tahoma,Courier New,Georgia" FontSizeList="1,2,3,4,5,6,7"
                                        FontStyleList="Blue Underline=color:blue;text-decoration:underline;&Red Bold=color:red;font-weight:bold;&ALL CAPS=text-transform:uppercase;&all lowercase=text-transform:lowercase;&Reset="
                                        Height="450px" SpecialCharacterList="Ω,Σ,Δ,Φ,Γ,Ψ,Π,Θ,Ξ,Λ,ξ,μ,η,φ,ω,ε,θ,δ,ζ,ψ,β,π,σ,ß,þ,Þ,ƒ,Ж,Ш,Ю,Я,ж,ф,ш,ю,я,お,あ,絵,Æ,Å,Ç,Ð,Ñ,Ö,æ,å,ã,ç,ð,ë,ñ,¢,£,¤,¥,№,™,©,®,—,@,•,¡,&#14;,←,↑,→,↓,↔,↕,↖,↗,↘,↙,&#18;,¦,§,¨,ª,¬,¯,¶,°,±,«,»,·,¸,º,¹,²,³,¼,½,¾,¿,×,÷"
                                        Width="96%" Focus="False" UseLineBreak="True">
                                        <DownlevelLabel Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                            Font-Underline="False"></DownlevelLabel>
                                        <DropDownStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                            Font-Underline="False"></DropDownStyle>
                                        <ProgressBar Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                            Font-Underline="False"></ProgressBar>
                                        <DownlevelTextArea Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                            Font-Underline="False"></DownlevelTextArea>
                                        <RightClickMenu Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                            Font-Underline="False">
                                            <ighedit:HtmlBoxMenuItem runat="server" Act="Cut" Font-Bold="False" Font-Italic="False"
                                                Font-Overline="False" Font-Strikeout="False" Font-Underline="False">
                                                <Dialog Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                    Font-Underline="False"></Dialog>
                                            </ighedit:HtmlBoxMenuItem>
                                            <ighedit:HtmlBoxMenuItem runat="server" Act="Copy" Font-Bold="False" Font-Italic="False"
                                                Font-Overline="False" Font-Strikeout="False" Font-Underline="False">
                                                <Dialog Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                    Font-Underline="False"></Dialog>
                                            </ighedit:HtmlBoxMenuItem>
                                            <ighedit:HtmlBoxMenuItem runat="server" Act="Paste" Font-Bold="False" Font-Italic="False"
                                                Font-Overline="False" Font-Strikeout="False" Font-Underline="False">
                                                <Dialog Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                    Font-Underline="False"></Dialog>
                                            </ighedit:HtmlBoxMenuItem>
                                            <ighedit:HtmlBoxMenuItem runat="server" Act="PasteHtml" Font-Bold="False" Font-Italic="False"
                                                Font-Overline="False" Font-Strikeout="False" Font-Underline="False">
                                                <Dialog Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                    Font-Underline="False"></Dialog>
                                            </ighedit:HtmlBoxMenuItem>
                                            <ighedit:HtmlBoxMenuItem runat="server" Act="CellProperties" Font-Bold="False" Font-Italic="False"
                                                Font-Overline="False" Font-Strikeout="False" Font-Underline="False">
                                                <Dialog InternalDialogType="CellProperties" Font-Bold="False" Font-Italic="False"
                                                    Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></Dialog>
                                            </ighedit:HtmlBoxMenuItem>
                                            <ighedit:HtmlBoxMenuItem runat="server" Act="TableProperties" Font-Bold="False" Font-Italic="False"
                                                Font-Overline="False" Font-Strikeout="False" Font-Underline="False">
                                                <Dialog InternalDialogType="ModifyTable" Font-Bold="False" Font-Italic="False" Font-Overline="False"
                                                    Font-Strikeout="False" Font-Underline="False"></Dialog>
                                            </ighedit:HtmlBoxMenuItem>
                                            <ighedit:HtmlBoxMenuItem runat="server" Act="InsertImage" Font-Bold="False" Font-Italic="False"
                                                Font-Overline="False" Font-Strikeout="False" Font-Underline="False">
                                                <Dialog Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                    Font-Underline="False"></Dialog>
                                            </ighedit:HtmlBoxMenuItem>
                                        </RightClickMenu>
                                        <TextWindow Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                            Font-Underline="False"></TextWindow>
                                        <Toolbar Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                            Font-Underline="False">
                                            <ighedit:ToolbarButton runat="server" Type="Bold" Font-Bold="False" Font-Italic="False"
                                                Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ighedit:ToolbarButton>
                                            <ighedit:ToolbarButton runat="server" Type="Italic" Font-Bold="False" Font-Italic="False"
                                                Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ighedit:ToolbarButton>
                                            <ighedit:ToolbarButton runat="server" Type="Underline" Font-Bold="False" Font-Italic="False"
                                                Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ighedit:ToolbarButton>
                                            <ighedit:ToolbarButton runat="server" Type="Strikethrough" Font-Bold="False" Font-Italic="False"
                                                Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ighedit:ToolbarButton>
                                            <ighedit:ToolbarButton runat="server" Type="Undo" Font-Bold="False" Font-Italic="False"
                                                Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ighedit:ToolbarButton>
                                            <ighedit:ToolbarButton runat="server" Type="Redo" Font-Bold="False" Font-Italic="False"
                                                Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ighedit:ToolbarButton>
                                            <ighedit:ToolbarButton runat="server" Type="JustifyLeft" Font-Bold="False" Font-Italic="False"
                                                Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ighedit:ToolbarButton>
                                            <ighedit:ToolbarButton runat="server" Type="JustifyCenter" Font-Bold="False" Font-Italic="False"
                                                Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ighedit:ToolbarButton>
                                            <ighedit:ToolbarButton runat="server" Type="JustifyRight" Font-Bold="False" Font-Italic="False"
                                                Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ighedit:ToolbarButton>
                                            <ighedit:ToolbarButton runat="server" Type="JustifyFull" Font-Bold="False" Font-Italic="False"
                                                Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ighedit:ToolbarButton>
                                            <ighedit:ToolbarButton runat="server" Type="Indent" Font-Bold="False" Font-Italic="False"
                                                Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ighedit:ToolbarButton>
                                            <ighedit:ToolbarButton runat="server" Type="Outdent" Font-Bold="False" Font-Italic="False"
                                                Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ighedit:ToolbarButton>
                                            <ighedit:ToolbarDialogButton runat="server" Type="FontColor" Font-Bold="False" Font-Italic="False"
                                                Font-Overline="False" Font-Strikeout="False" Font-Underline="False">
                                                <Dialog Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                    Font-Underline="False"></Dialog>
                                            </ighedit:ToolbarDialogButton>
                                            <ighedit:ToolbarMenuButton runat="server" Type="InsertTable" Font-Bold="False" Font-Italic="False"
                                                Font-Overline="False" Font-Strikeout="False" Font-Underline="False">
                                                <Menu Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                    Font-Underline="False">
                                                    <ighedit:HtmlBoxMenuItem runat="server" Act="TableProperties" Font-Bold="False" Font-Italic="False"
                                                        Font-Overline="False" Font-Strikeout="False" Font-Underline="False">
                                                        <Dialog InternalDialogType="InsertTable" Font-Bold="False" Font-Italic="False" Font-Overline="False"
                                                            Font-Strikeout="False" Font-Underline="False"></Dialog>
                                                    </ighedit:HtmlBoxMenuItem>
                                                    <ighedit:HtmlBoxMenuItem runat="server" Act="InsertColumnRight" Font-Bold="False"
                                                        Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False">
                                                        <Dialog Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                            Font-Underline="False"></Dialog>
                                                    </ighedit:HtmlBoxMenuItem>
                                                    <ighedit:HtmlBoxMenuItem runat="server" Act="InsertColumnLeft" Font-Bold="False"
                                                        Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False">
                                                        <Dialog Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                            Font-Underline="False"></Dialog>
                                                    </ighedit:HtmlBoxMenuItem>
                                                    <ighedit:HtmlBoxMenuItem runat="server" Act="InsertRowAbove" Font-Bold="False" Font-Italic="False"
                                                        Font-Overline="False" Font-Strikeout="False" Font-Underline="False">
                                                        <Dialog Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                            Font-Underline="False"></Dialog>
                                                    </ighedit:HtmlBoxMenuItem>
                                                    <ighedit:HtmlBoxMenuItem runat="server" Act="InsertRowBelow" Font-Bold="False" Font-Italic="False"
                                                        Font-Overline="False" Font-Strikeout="False" Font-Underline="False">
                                                        <Dialog Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                            Font-Underline="False"></Dialog>
                                                    </ighedit:HtmlBoxMenuItem>
                                                    <ighedit:HtmlBoxMenuItem runat="server" Act="DeleteRow" Font-Bold="False" Font-Italic="False"
                                                        Font-Overline="False" Font-Strikeout="False" Font-Underline="False">
                                                        <Dialog Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                            Font-Underline="False"></Dialog>
                                                    </ighedit:HtmlBoxMenuItem>
                                                    <ighedit:HtmlBoxMenuItem runat="server" Act="DeleteColumn" Font-Bold="False" Font-Italic="False"
                                                        Font-Overline="False" Font-Strikeout="False" Font-Underline="False">
                                                        <Dialog Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                            Font-Underline="False"></Dialog>
                                                    </ighedit:HtmlBoxMenuItem>
                                                    <ighedit:HtmlBoxMenuItem runat="server" Act="IncreaseColspan" Font-Bold="False" Font-Italic="False"
                                                        Font-Overline="False" Font-Strikeout="False" Font-Underline="False">
                                                        <Dialog Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                            Font-Underline="False"></Dialog>
                                                    </ighedit:HtmlBoxMenuItem>
                                                    <ighedit:HtmlBoxMenuItem runat="server" Act="DecreaseColspan" Font-Bold="False" Font-Italic="False"
                                                        Font-Overline="False" Font-Strikeout="False" Font-Underline="False">
                                                        <Dialog Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                            Font-Underline="False"></Dialog>
                                                    </ighedit:HtmlBoxMenuItem>
                                                    <ighedit:HtmlBoxMenuItem runat="server" Act="IncreaseRowspan" Font-Bold="False" Font-Italic="False"
                                                        Font-Overline="False" Font-Strikeout="False" Font-Underline="False">
                                                        <Dialog Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                            Font-Underline="False"></Dialog>
                                                    </ighedit:HtmlBoxMenuItem>
                                                    <ighedit:HtmlBoxMenuItem runat="server" Act="DecreaseRowspan" Font-Bold="False" Font-Italic="False"
                                                        Font-Overline="False" Font-Strikeout="False" Font-Underline="False">
                                                        <Dialog Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                                            Font-Underline="False"></Dialog>
                                                    </ighedit:HtmlBoxMenuItem>
                                                    <ighedit:HtmlBoxMenuItem runat="server" Act="CellProperties" Font-Bold="False" Font-Italic="False"
                                                        Font-Overline="False" Font-Strikeout="False" Font-Underline="False">
                                                        <Dialog InternalDialogType="CellProperties" Font-Bold="False" Font-Italic="False"
                                                            Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></Dialog>
                                                    </ighedit:HtmlBoxMenuItem>
                                                    <ighedit:HtmlBoxMenuItem runat="server" Act="TableProperties" Font-Bold="False" Font-Italic="False"
                                                        Font-Overline="False" Font-Strikeout="False" Font-Underline="False">
                                                        <Dialog InternalDialogType="ModifyTable" Font-Bold="False" Font-Italic="False" Font-Overline="False"
                                                            Font-Strikeout="False" Font-Underline="False"></Dialog>
                                                    </ighedit:HtmlBoxMenuItem>
                                                </Menu>
                                            </ighedit:ToolbarMenuButton>
                                            <ighedit:ToolbarButton runat="server" Type="InsertLink" Font-Bold="False" Font-Italic="False"
                                                Font-Overline="False" Font-Strikeout="False" Font-Underline="False"></ighedit:ToolbarButton>
                                            <ighedit:ToolbarDropDown runat="server" Type="FontName" Font-Bold="False" Font-Italic="False"
                                                Font-Overline="False" Font-Strikeout="False" Font-Underline="False" Width="80px">
                                            </ighedit:ToolbarDropDown>
                                            <ighedit:ToolbarDropDown runat="server" Type="FontSize" Font-Bold="False" Font-Italic="False"
                                                Font-Overline="False" Font-Strikeout="False" Font-Underline="False" Width="50px">
                                            </ighedit:ToolbarDropDown>
                                        </Toolbar>
                                        <TabStrip Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                            Font-Underline="False"></TabStrip>
                                    </ighedit:WebHtmlEditor>
                                </td>
                            </tr>
               
                <tr>
                    <td align="center" colspan="4" style="height: 20px">
                    </td>
                </tr>
                <tr>
                    <td align="right" colspan="4" style="height: 40px" valign="bottom">
                        <asp:Button ID="btnLuu" runat="server" CssClass="long-button" Text="Lưu " CausesValidation="true"
                            OnClick="btnLuu_ServerClick" />
                        &nbsp; &nbsp;&nbsp;
                        <asp:Button ID="btnLuuAndDong" runat="server" CssClass="button" Text="Lưu và đóng"
                            OnClick="btnLuuAndDong_ServerClick" />
                        &nbsp; &nbsp;&nbsp;
                        <asp:Button ID="btnThemMoi" runat="server" CssClass="button" Text="Lưu và thêm mới"
                            OnClick="btnLuuAndThem_ServerClick" />
                        &nbsp; &nbsp;&nbsp;
                        <input id="btnThoat" runat="server" class="button" onclick="return btnThoat_OnClose();"
                            type="button" value="Đóng" style="width: 72px" />
                        &nbsp; &nbsp; &nbsp;&nbsp;
                    </td>
                </tr>
                <tr>
                    <td rowspan="1" valign="top" align="right" style="height: 20px;" colspan="5">
                        &nbsp;&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
