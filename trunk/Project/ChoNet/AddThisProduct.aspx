<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddThisProduct.aspx.cs" Inherits="AddThisProduct" Title="Thêm sản phẩm" %>

<%@ Register Assembly="Infragistics2.WebUI.WebDateChooser.v7.1, Version=7.1.20071.1048, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.WebSchedule" TagPrefix="igsch" %>
<%@ Register Assembly="Infragistics2.WebUI.WebHtmlEditor.v7.1, Version=7.1.20071.1048, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.WebHtmlEditor" TagPrefix="ighedit" %>
<%@ Register Assembly="Infragistics2.WebUI.WebDataInput.v7.1, Version=7.1.20071.1048, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.WebDataInput" TagPrefix="igtxt" %>
    
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Thêm sản phẩm</title>
    <link type="text/css" href="Css/style.css" rel="Stylesheet" />
    <link type="text/css" href="Css/admin.css" rel="Stylesheet" />

    <script type="text/javascript" src="Scripts/WebForm.js"></script>

    <script type="text/javascript" src="Scripts/WebUIValidation.js"></script>

    <script type="text/javascript" src="Scripts/common.js"></script>

    <script type="text/javascript" id="igClientScript">
    function resetFields()
    {
        var wdcFrom = igdrp_getComboById('wdcBatDauKM');
        var wdcTo = igdrp_getComboById('wdcKetThucKM');
        var txtNoiDung = document.getElementById('txtMoTaKhuyenMai');
        var chk = document.getElementById('chkKhuyenMai');
	    var whe = iged_getById('wheThongTinSanPham');         
        var txtGiaMoi = igedit_getById('txtGiaMoi'); 
        var txtGia = igedit_getById('txtGiaSanPham');
       // var rfv = document.getElementById('rfvGiaMoi');   
        //var cvGiaMoi = document.getElementById('cvGiaMoi');
        //var cv = document.getElementById('cvKhuyenMai');
	    //var wdcFrom = igdrp_getComboById('wdcBatDauKM');
	    //var wdcTo = igdrp_getComboById('wdcKetThucKM');

	    whe.setText('');
	    var currentdate = new Date();
	    wdcFrom.setValue(currentdate);
	    wdcTo.setValue(currentdate);
	    txtNoiDung.value='';
	    txtGiaMoi.setValue('');
	    txtGia.setValue('');
	    chk.checked=false;
        
    }
     function chkKhuyenMai_onclick(obj)
    {
        if (('<%=blKhuyenMai %>' == 'True') && (obj.checked == true))
        {
            obj.checked = false;
            alert('Bạn đã có đủ số sản phẩm khuyến mãi');
            return;
        }  
            var cv = document.getElementById('cvKhuyenMai');
            var wdcFrom = igdrp_getComboById('wdcBatDauKM');
            var wdcTo = igdrp_getComboById('wdcKetThucKM');
            var txtNoiDung = document.getElementById('txtMoTaKhuyenMai');
            
            ValidatorEnable(cv, obj.checked);                   
            wdcFrom.setEnabled(obj.checked);
            wdcTo.setEnabled(obj.checked);
            txtNoiDung.disabled = !obj.checked;      
    }
    
    function chkGiamGia_onclick(obj)
    {        
        if (('<%=blGiamGia %>' == 'True') && (obj.checked == true))
        {
            obj.checked = false;
            alert('Bạn đã có đủ số sản phẩm giảm giá');
            return;
        }
        
        var txtGiaMoi = igedit_getById('txtGiaMoi'); 
        var rfv = document.getElementById('rfvGiaMoi');   
        var cvGiaMoi = document.getElementById('cvGiaMoi');  
                                                          
        txtGiaMoi.setEnabled(obj.checked);                    
        ValidatorEnable(rfv, obj.checked);
        ValidatorEnable(cvGiaMoi, obj.checked);
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
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div style="width: 600px; height: 400px">
            <table cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td colspan="3" style="color: red; height: 50px; padding-left: 10px; width: 25%;"
                        valign="middle">
                        <span style="font-size: 12pt"><strong>
                        Thêm sản phẩm vào gian hàng</strong></span></td>
                </tr>
                <tr>
                    <td style="padding-left: 10px; width: 25%; height: 24px">
                        Tên
                    </td>
                    <td style="width: 37%; height: 24px">
                        <asp:TextBox ID="txtTenSanPham" runat="server" ReadOnly="True" Width="228px"></asp:TextBox></td>
                    <td style="width: 38%; height: 24px">
                        Tên phụ &nbsp; &nbsp; &nbsp;
                        <asp:TextBox ID="txtTenPhu" runat="server" Width="173px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="width: 25%; padding-left: 10px;">
                        Giá</td>
                    <td style="width: 37%">
                        <igtxt:WebNumericEdit ID="txtGiaSanPham" runat="server" HorizontalAlign="Left" Width="228px">
                        </igtxt:WebNumericEdit>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtGiaSanPham"
                            ErrorMessage="*" Width="4%"></asp:RequiredFieldValidator></td>
                    <td style="width: 38%">
                        Khu vực &nbsp;&nbsp; &nbsp;&nbsp;
                        <asp:DropDownList ID="ddlKhuVuc" runat="server" Width="182px">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td style="padding-left: 10px; width: 25%">
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td rowspan="3" style="padding-left: 10px; padding-top: 10px;" valign="top">
                        Tùy chọn</td>
                    <td>
                        <asp:CheckBox ID="chkGiamGia" runat="server" Font-Bold="False" Text="Giảm giá" TextAlign="Left" /><igtxt:WebNumericEdit
                            ID="txtGiaMoi" runat="server" Enabled="False" HorizontalAlign="Left" Width="145px">
                        </igtxt:WebNumericEdit>
                        <asp:RequiredFieldValidator ID="rfvGiaMoi" runat="server" ControlToValidate="txtGiaMoi"
                            Enabled="False" ErrorMessage="*" Width="4%"></asp:RequiredFieldValidator>
                        &nbsp;&nbsp;
                    </td>
                    <td align="left">
                        <asp:CheckBox ID="chkKhuyenMai" runat="server" Text="Khuyến mãi      " TextAlign="Left" /></td>
                </tr>
                <tr>
                    <td style="height: 15px" colspan="2">
                        <asp:CompareValidator ID="cvGiaMoi" runat="server" ControlToCompare="txtGiaSanPham"
                            ControlToValidate="txtGiaMoi" Enabled="False" ErrorMessage="Giá mới phải nhỏ hơn giá sản phẩm"
                            Operator="LessThan" SetFocusOnError="True" Type="Double"></asp:CompareValidator><asp:CustomValidator
                                ID="cvKhuyenMai" runat="server" ClientValidationFunction="validateKhuyenMai"
                                ControlToValidate="wdcKetThucKM" ErrorMessage="Thời gian khuyến mại không hợp lệ"
                                SetFocusOnError="True"></asp:CustomValidator></td>
                </tr>
                <tr>
                    <td style="height: 13px">
                        <table cellspacing="0" style="padding-left: 5px; vertical-align: top; text-align: left"
                            width="100%">
                            <tr>
                                <td align="left" style="width: 13%">
                                    Bắt đầu KM</td>
                                <td style="width: 30%">
                                    <igsch:WebDateChooser ID="wdcBatDauKM" runat="server" Enabled="False" Format="Long"
                                        Width="150px">
                                        <CalendarLayout Culture="Vietnamese (Vietnam)">
                                        </CalendarLayout>
                                    </igsch:WebDateChooser>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td>
                        <table cellspacing="0" style="padding-left: 5px; vertical-align: top; text-align: left"
                            width="100%">
                            <tr>
                                <td align="left" style="width: 11%">
                                    Kết thúc KM</td>
                                <td style="width: 27%" align="left">
                                    <igsch:WebDateChooser ID="wdcKetThucKM" runat="server" Enabled="False" Format="Long"
                                        Width="178px">
                                        <CalendarLayout Culture="Vietnamese (Vietnam)">
                                        </CalendarLayout>
                                    </igsch:WebDateChooser>
                                </td>
                            </tr>
            </table>
            </td> </tr>
            <tr>
                <td style="padding-left: 10px; width: 25%;" valign="top">
                    Nội dung khuyến mại</td>
                <td style="height: 13px" colspan="2">
                    <asp:TextBox ID="txtMoTaKhuyenMai" runat="server" Enabled="False" Height="70px" TextMode="MultiLine"
                        Width="99%"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="padding-left: 10px; width: 25%" valign="top">
                    Thông tin thêm</td>
                <td colspan="2">
                    <ighedit:WebHtmlEditor ID="wheThongTinSanPham" runat="server" FontFormattingList="Heading 1=<h1>&Heading 2=<h2>&Heading 3=<h3>&Heading 4=<h4>&Heading 5=<h5>&Normal=<p>"
                        FontNameList="Arial,Verdana,Tahoma,Courier New,Georgia" FontSizeList="1,2,3,4,5,6,7"
                        FontStyleList="Blue Underline=color:blue;text-decoration:underline;&Red Bold=color:red;font-weight:bold;&ALL CAPS=text-transform:uppercase;&all lowercase=text-transform:lowercase;&Reset="
                        Height="80px" SpecialCharacterList="Ω,Σ,Δ,Φ,Γ,Ψ,Π,Θ,Ξ,Λ,ξ,μ,η,φ,ω,ε,θ,δ,ζ,ψ,β,π,σ,ß,þ,Þ,ƒ,Ж,Ш,Ю,Я,ж,ф,ш,ю,я,お,あ,絵,Æ,Å,Ç,Ð,Ñ,Ö,æ,å,ã,ç,ð,ë,ñ,¢,£,¤,¥,№,™,©,®,—,@,•,¡,&#14;,←,↑,→,↓,↔,↕,↖,↗,↘,↙,&#18;,¦,§,¨,ª,¬,¯,¶,°,±,«,»,·,¸,º,¹,²,³,¼,½,¾,¿,×,÷"
                        Width="91%">
                        <Toolbar Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False"
                            Font-Bold="False">
                            <ighedit:ToolbarButton runat="server" Type="Bold" Font-Italic="False" Font-Strikeout="False"
                                Font-Underline="False" Font-Overline="False" Font-Bold="False"></ighedit:ToolbarButton>
                            <ighedit:ToolbarButton runat="server" Type="Italic" Font-Italic="False" Font-Strikeout="False"
                                Font-Underline="False" Font-Overline="False" Font-Bold="False"></ighedit:ToolbarButton>
                            <ighedit:ToolbarButton runat="server" Type="Underline" Font-Italic="False" Font-Strikeout="False"
                                Font-Underline="False" Font-Overline="False" Font-Bold="False"></ighedit:ToolbarButton>
                            <ighedit:ToolbarButton runat="server" Type="Strikethrough" Font-Italic="False" Font-Strikeout="False"
                                Font-Underline="False" Font-Overline="False" Font-Bold="False"></ighedit:ToolbarButton>
                            <ighedit:ToolbarButton runat="server" Type="Undo" Font-Italic="False" Font-Strikeout="False"
                                Font-Underline="False" Font-Overline="False" Font-Bold="False"></ighedit:ToolbarButton>
                            <ighedit:ToolbarButton runat="server" Type="Redo" Font-Italic="False" Font-Strikeout="False"
                                Font-Underline="False" Font-Overline="False" Font-Bold="False"></ighedit:ToolbarButton>
                            <ighedit:ToolbarButton runat="server" Type="JustifyLeft" Font-Italic="False" Font-Strikeout="False"
                                Font-Underline="False" Font-Overline="False" Font-Bold="False"></ighedit:ToolbarButton>
                            <ighedit:ToolbarButton runat="server" Type="JustifyCenter" Font-Italic="False" Font-Strikeout="False"
                                Font-Underline="False" Font-Overline="False" Font-Bold="False"></ighedit:ToolbarButton>
                            <ighedit:ToolbarButton runat="server" Type="JustifyRight" Font-Italic="False" Font-Strikeout="False"
                                Font-Underline="False" Font-Overline="False" Font-Bold="False"></ighedit:ToolbarButton>
                            <ighedit:ToolbarButton runat="server" Type="JustifyFull" Font-Italic="False" Font-Strikeout="False"
                                Font-Underline="False" Font-Overline="False" Font-Bold="False"></ighedit:ToolbarButton>
                            <ighedit:ToolbarButton runat="server" Type="Indent" Font-Italic="False" Font-Strikeout="False"
                                Font-Underline="False" Font-Overline="False" Font-Bold="False"></ighedit:ToolbarButton>
                            <ighedit:ToolbarButton runat="server" Type="Outdent" Font-Italic="False" Font-Strikeout="False"
                                Font-Underline="False" Font-Overline="False" Font-Bold="False"></ighedit:ToolbarButton>
                            <ighedit:ToolbarDialogButton runat="server" Font-Italic="False" Font-Strikeout="False"
                                Font-Underline="False" Font-Overline="False" Font-Bold="False" Type="FontColor">
                                <Dialog Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False"
                                    Font-Bold="False"></Dialog>
                            </ighedit:ToolbarDialogButton>
                            <ighedit:ToolbarMenuButton runat="server" Type="InsertTable" Font-Italic="False"
                                Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False">
                                <Menu Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False"
                                    Font-Bold="False">
                                    <ighedit:HtmlBoxMenuItem runat="server" Act="TableProperties" Font-Italic="False"
                                        Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False">
                                        <Dialog InternalDialogType="InsertTable" Font-Italic="False" Font-Strikeout="False"
                                            Font-Underline="False" Font-Overline="False" Font-Bold="False"></Dialog>
                                    </ighedit:HtmlBoxMenuItem>
                                    <ighedit:HtmlBoxMenuItem runat="server" Act="InsertColumnRight" Font-Italic="False"
                                        Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False">
                                        <Dialog Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False"
                                            Font-Bold="False"></Dialog>
                                    </ighedit:HtmlBoxMenuItem>
                                    <ighedit:HtmlBoxMenuItem runat="server" Act="InsertColumnLeft" Font-Italic="False"
                                        Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False">
                                        <Dialog Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False"
                                            Font-Bold="False"></Dialog>
                                    </ighedit:HtmlBoxMenuItem>
                                    <ighedit:HtmlBoxMenuItem runat="server" Act="InsertRowAbove" Font-Italic="False"
                                        Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False">
                                        <Dialog Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False"
                                            Font-Bold="False"></Dialog>
                                    </ighedit:HtmlBoxMenuItem>
                                    <ighedit:HtmlBoxMenuItem runat="server" Act="InsertRowBelow" Font-Italic="False"
                                        Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False">
                                        <Dialog Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False"
                                            Font-Bold="False"></Dialog>
                                    </ighedit:HtmlBoxMenuItem>
                                    <ighedit:HtmlBoxMenuItem runat="server" Act="DeleteRow" Font-Italic="False" Font-Strikeout="False"
                                        Font-Underline="False" Font-Overline="False" Font-Bold="False">
                                        <Dialog Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False"
                                            Font-Bold="False"></Dialog>
                                    </ighedit:HtmlBoxMenuItem>
                                    <ighedit:HtmlBoxMenuItem runat="server" Act="DeleteColumn" Font-Italic="False" Font-Strikeout="False"
                                        Font-Underline="False" Font-Overline="False" Font-Bold="False">
                                        <Dialog Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False"
                                            Font-Bold="False"></Dialog>
                                    </ighedit:HtmlBoxMenuItem>
                                    <ighedit:HtmlBoxMenuItem runat="server" Act="IncreaseColspan" Font-Italic="False"
                                        Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False">
                                        <Dialog Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False"
                                            Font-Bold="False"></Dialog>
                                    </ighedit:HtmlBoxMenuItem>
                                    <ighedit:HtmlBoxMenuItem runat="server" Act="DecreaseColspan" Font-Italic="False"
                                        Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False">
                                        <Dialog Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False"
                                            Font-Bold="False"></Dialog>
                                    </ighedit:HtmlBoxMenuItem>
                                    <ighedit:HtmlBoxMenuItem runat="server" Act="IncreaseRowspan" Font-Italic="False"
                                        Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False">
                                        <Dialog Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False"
                                            Font-Bold="False"></Dialog>
                                    </ighedit:HtmlBoxMenuItem>
                                    <ighedit:HtmlBoxMenuItem runat="server" Act="DecreaseRowspan" Font-Italic="False"
                                        Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False">
                                        <Dialog Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False"
                                            Font-Bold="False"></Dialog>
                                    </ighedit:HtmlBoxMenuItem>
                                    <ighedit:HtmlBoxMenuItem runat="server" Act="CellProperties" Font-Italic="False"
                                        Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False">
                                        <Dialog InternalDialogType="CellProperties" Font-Italic="False" Font-Strikeout="False"
                                            Font-Underline="False" Font-Overline="False" Font-Bold="False"></Dialog>
                                    </ighedit:HtmlBoxMenuItem>
                                    <ighedit:HtmlBoxMenuItem runat="server" Act="TableProperties" Font-Italic="False"
                                        Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False">
                                        <Dialog InternalDialogType="ModifyTable" Font-Italic="False" Font-Strikeout="False"
                                            Font-Underline="False" Font-Overline="False" Font-Bold="False"></Dialog>
                                    </ighedit:HtmlBoxMenuItem>
                                </Menu>
                            </ighedit:ToolbarMenuButton>
                            <ighedit:ToolbarButton runat="server" Type="InsertLink" Font-Italic="False" Font-Strikeout="False"
                                Font-Underline="False" Font-Overline="False" Font-Bold="False"></ighedit:ToolbarButton>
                            <ighedit:ToolbarDropDown runat="server" Font-Italic="False" Font-Strikeout="False"
                                Font-Underline="False" Font-Overline="False" Font-Bold="False" Type="FontName"
                                Width="80px">
                            </ighedit:ToolbarDropDown>
                            <ighedit:ToolbarDropDown runat="server" Font-Italic="False" Font-Strikeout="False"
                                Font-Underline="False" Font-Overline="False" Font-Bold="False" Type="FontSize"
                                Width="50px">
                            </ighedit:ToolbarDropDown>
                        </Toolbar>
                        <DropDownStyle Font-Italic="False" Font-Strikeout="False" Font-Underline="False"
                            Font-Overline="False" Font-Bold="False"></DropDownStyle>
                        <ProgressBar Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False"
                            Font-Bold="False"></ProgressBar>
                        <DownlevelTextArea Font-Italic="False" Font-Strikeout="False" Font-Underline="False"
                            Font-Overline="False" Font-Bold="False"></DownlevelTextArea>
                        <RightClickMenu Font-Italic="False" Font-Strikeout="False" Font-Underline="False"
                            Font-Overline="False" Font-Bold="False">
                            <ighedit:HtmlBoxMenuItem runat="server" Act="Cut" Font-Italic="False" Font-Strikeout="False"
                                Font-Underline="False" Font-Overline="False" Font-Bold="False">
                                <Dialog Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False"
                                    Font-Bold="False"></Dialog>
                            </ighedit:HtmlBoxMenuItem>
                            <ighedit:HtmlBoxMenuItem runat="server" Act="Copy" Font-Italic="False" Font-Strikeout="False"
                                Font-Underline="False" Font-Overline="False" Font-Bold="False">
                                <Dialog Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False"
                                    Font-Bold="False"></Dialog>
                            </ighedit:HtmlBoxMenuItem>
                            <ighedit:HtmlBoxMenuItem runat="server" Act="Paste" Font-Italic="False" Font-Strikeout="False"
                                Font-Underline="False" Font-Overline="False" Font-Bold="False">
                                <Dialog Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False"
                                    Font-Bold="False"></Dialog>
                            </ighedit:HtmlBoxMenuItem>
                            <ighedit:HtmlBoxMenuItem runat="server" Act="PasteHtml" Font-Italic="False" Font-Strikeout="False"
                                Font-Underline="False" Font-Overline="False" Font-Bold="False">
                                <Dialog Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False"
                                    Font-Bold="False"></Dialog>
                            </ighedit:HtmlBoxMenuItem>
                            <ighedit:HtmlBoxMenuItem runat="server" Act="CellProperties" Font-Italic="False"
                                Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False">
                                <Dialog InternalDialogType="CellProperties" Font-Italic="False" Font-Strikeout="False"
                                    Font-Underline="False" Font-Overline="False" Font-Bold="False"></Dialog>
                            </ighedit:HtmlBoxMenuItem>
                            <ighedit:HtmlBoxMenuItem runat="server" Act="TableProperties" Font-Italic="False"
                                Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False">
                                <Dialog InternalDialogType="ModifyTable" Font-Italic="False" Font-Strikeout="False"
                                    Font-Underline="False" Font-Overline="False" Font-Bold="False"></Dialog>
                            </ighedit:HtmlBoxMenuItem>
                            <ighedit:HtmlBoxMenuItem runat="server" Act="InsertImage" Font-Italic="False" Font-Strikeout="False"
                                Font-Underline="False" Font-Overline="False" Font-Bold="False">
                                <Dialog Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False"
                                    Font-Bold="False"></Dialog>
                            </ighedit:HtmlBoxMenuItem>
                        </RightClickMenu>
                        <TextWindow Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False"
                            Font-Bold="False"></TextWindow>
                        <DownlevelLabel Font-Italic="False" Font-Strikeout="False" Font-Underline="False"
                            Font-Overline="False" Font-Bold="False"></DownlevelLabel>
                        <TabStrip Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False"
                            Font-Bold="False"></TabStrip>
                    </ighedit:WebHtmlEditor>
                </td>
            </tr>
            <tr>
                <td style="height: 20px">
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:Button ID="btnAddNew" runat="server" CssClass="long-button" Text="Thêm mới" OnClick="btnAddNew_Click" />
                    <asp:Button ID="btnReset" runat="server" CssClass="long-button" Text="Làm lại" OnClick="btnReset_Click" CausesValidation="False" />
                </td>
                <td>
                </td>
            </tr>
            </table>
        </div>
    </form>
</body>
</html>
