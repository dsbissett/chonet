<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddNews.aspx.cs" Inherits="Adm_AddNews" %>

<%@ Register Assembly="Infragistics2.WebUI.WebHtmlEditor.v7.1, Version=7.1.20071.1048, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.WebHtmlEditor" TagPrefix="ighedit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Thêm tin tức</title>
    <link href="../Css/admin.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="../Scripts/multifile_compressed.js"></script>

    <script type="text/javascript" src="../Scripts/dialog.js"></script>

    <script type="text/javascript" src="../Scripts/WebForm.js"></script>

    <script type="text/javascript" src="../Scripts/WebUIValidation.js"></script>

    <script type="text/javascript" id="igClientScript">
    function btnThoat_OnClose()
    {     
        window.parent.CloseDialogWindow();        
    }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table width="800px">
    <tr>
    <td style="width: 20%" align="right" valign="top">
        Tiêu đề: &nbsp;</td>
        <td>
            <asp:TextBox ID="txtTieuDe" runat="server" Width="596px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTieuDe"
                ErrorMessage="*"></asp:RequiredFieldValidator></td>
    </tr>
        <tr>
            <td align="right" style="width: 20%" valign="top">
                Loại tin tức: &nbsp;
            </td>
            <td>
                <asp:RadioButton ID="rbtTinTuc" runat="server" Checked="True" GroupName="loaitintuc"
                    Text="Tin tức" />
                <asp:RadioButton ID="rbtTroGiup" runat="server" GroupName="loaitintuc" Text="Trợ giúp" /></td>
        </tr>
        <tr>
            <td align="right" valign="top">
                Tóm tắt: &nbsp;</td>
            <td>
                <asp:TextBox ID="txtTomTat" runat="server" Height="60px" TextMode="MultiLine" Width="598px"></asp:TextBox></td>
        </tr>
        <tr height="60px">
            <td align="right" valign="top">
                Ảnh đại diện:&nbsp;
            </td>
            <td>
            <table width="100%">
            <tr>
                                <td colspan="2" valign="top" style="height: 82px">
                                    <asp:FileUpload ID="fileAnhChinh" runat="server" Width="96%" accept="image/*" />
                                    <asp:Label ID="lblAnhChinhErr" runat="server" ForeColor="Red"></asp:Label>
                                    <br />
                                    <input id="hidAnhChinh" type="hidden" runat="server" /></td>
                                <td align="left" style="height: 82px">
                                    <asp:Image ID="imgAnhChinh" runat="server" Height="80px" Width="100px" /></td>
                            </tr>
            </table>
            </td>
        </tr>
        <tr>
            <td align="right" valign="top">
                Nội dung:&nbsp;
            </td>
            <td>
                <ighedit:webhtmleditor id="wheNoiDung" runat="server" fontformattinglist="Heading 1=<h1>&Heading 2=<h2>&Heading 3=<h3>&Heading 4=<h4>&Heading 5=<h5>&Normal=<p>"
                    fontnamelist="Arial,Verdana,Tahoma,Courier New,Georgia" fontsizelist="1,2,3,4,5,6,7"
                    fontstylelist="Blue Underline=color:blue;text-decoration:underline;&Red Bold=color:red;font-weight:bold;&ALL CAPS=text-transform:uppercase;&all lowercase=text-transform:lowercase;&Reset="
                    height="270px" specialcharacterlist="Ω,Σ,Δ,Φ,Γ,Ψ,Π,Θ,Ξ,Λ,ξ,μ,η,φ,ω,ε,θ,δ,ζ,ψ,β,π,σ,ß,þ,Þ,ƒ,Ж,Ш,Ю,Я,ж,ф,ш,ю,я,お,あ,絵,Æ,Å,Ç,Ð,Ñ,Ö,æ,å,ã,ç,ð,ë,ñ,¢,£,¤,¥,№,™,©,®,—,@,•,¡,&#14;,←,↑,→,↓,↔,↕,↖,↗,↘,↙,&#18;,¦,§,¨,ª,¬,¯,¶,°,±,«,»,·,¸,º,¹,²,³,¼,½,¾,¿,×,÷"
                    width="96%">
<Toolbar Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"><ighedit:ToolbarButton runat="server" Type="Bold" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></ighedit:ToolbarButton>
<ighedit:ToolbarButton runat="server" Type="Italic" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></ighedit:ToolbarButton>
<ighedit:ToolbarButton runat="server" Type="Underline" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></ighedit:ToolbarButton>
<ighedit:ToolbarButton runat="server" Type="Strikethrough" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></ighedit:ToolbarButton>
<ighedit:ToolbarButton runat="server" Type="Undo" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></ighedit:ToolbarButton>
<ighedit:ToolbarButton runat="server" Type="Redo" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></ighedit:ToolbarButton>
<ighedit:ToolbarButton runat="server" Type="JustifyLeft" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></ighedit:ToolbarButton>
<ighedit:ToolbarButton runat="server" Type="JustifyCenter" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></ighedit:ToolbarButton>
<ighedit:ToolbarButton runat="server" Type="JustifyRight" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></ighedit:ToolbarButton>
<ighedit:ToolbarButton runat="server" Type="JustifyFull" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></ighedit:ToolbarButton>
<ighedit:ToolbarButton runat="server" Type="Indent" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></ighedit:ToolbarButton>
<ighedit:ToolbarButton runat="server" Type="Outdent" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></ighedit:ToolbarButton>
<ighedit:ToolbarDialogButton runat="server" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False" Type="FontColor">
<Dialog Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></Dialog>
</ighedit:ToolbarDialogButton>
<ighedit:ToolbarMenuButton runat="server" Type="InsertTable" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False">
<Menu Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"><ighedit:HtmlBoxMenuItem runat="server" Act="TableProperties" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False">
<Dialog InternalDialogType="InsertTable" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></Dialog>
</ighedit:HtmlBoxMenuItem>
<ighedit:HtmlBoxMenuItem runat="server" Act="InsertColumnRight" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False">
<Dialog Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></Dialog>
</ighedit:HtmlBoxMenuItem>
<ighedit:HtmlBoxMenuItem runat="server" Act="InsertColumnLeft" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False">
<Dialog Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></Dialog>
</ighedit:HtmlBoxMenuItem>
<ighedit:HtmlBoxMenuItem runat="server" Act="InsertRowAbove" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False">
<Dialog Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></Dialog>
</ighedit:HtmlBoxMenuItem>
<ighedit:HtmlBoxMenuItem runat="server" Act="InsertRowBelow" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False">
<Dialog Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></Dialog>
</ighedit:HtmlBoxMenuItem>
<ighedit:HtmlBoxMenuItem runat="server" Act="DeleteRow" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False">
<Dialog Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></Dialog>
</ighedit:HtmlBoxMenuItem>
<ighedit:HtmlBoxMenuItem runat="server" Act="DeleteColumn" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False">
<Dialog Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></Dialog>
</ighedit:HtmlBoxMenuItem>
<ighedit:HtmlBoxMenuItem runat="server" Act="IncreaseColspan" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False">
<Dialog Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></Dialog>
</ighedit:HtmlBoxMenuItem>
<ighedit:HtmlBoxMenuItem runat="server" Act="DecreaseColspan" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False">
<Dialog Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></Dialog>
</ighedit:HtmlBoxMenuItem>
<ighedit:HtmlBoxMenuItem runat="server" Act="IncreaseRowspan" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False">
<Dialog Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></Dialog>
</ighedit:HtmlBoxMenuItem>
<ighedit:HtmlBoxMenuItem runat="server" Act="DecreaseRowspan" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False">
<Dialog Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></Dialog>
</ighedit:HtmlBoxMenuItem>
<ighedit:HtmlBoxMenuItem runat="server" Act="CellProperties" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False">
<Dialog InternalDialogType="CellProperties" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></Dialog>
</ighedit:HtmlBoxMenuItem>
<ighedit:HtmlBoxMenuItem runat="server" Act="TableProperties" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False">
<Dialog InternalDialogType="ModifyTable" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></Dialog>
</ighedit:HtmlBoxMenuItem>
</Menu>
</ighedit:ToolbarMenuButton>
<ighedit:ToolbarButton runat="server" Type="InsertLink" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></ighedit:ToolbarButton>
<ighedit:ToolbarDropDown runat="server" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False" Type="FontName" Width="80px"></ighedit:ToolbarDropDown>
<ighedit:ToolbarDropDown runat="server" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False" Type="FontSize" Width="50px"></ighedit:ToolbarDropDown>
</Toolbar>

<DropDownStyle Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></DropDownStyle>

<ProgressBar Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></ProgressBar>

<DownlevelTextArea Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></DownlevelTextArea>

<RightClickMenu Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"><ighedit:HtmlBoxMenuItem runat="server" Act="Cut" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False">
<Dialog Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></Dialog>
</ighedit:HtmlBoxMenuItem>
<ighedit:HtmlBoxMenuItem runat="server" Act="Copy" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False">
<Dialog Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></Dialog>
</ighedit:HtmlBoxMenuItem>
<ighedit:HtmlBoxMenuItem runat="server" Act="Paste" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False">
<Dialog Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></Dialog>
</ighedit:HtmlBoxMenuItem>
<ighedit:HtmlBoxMenuItem runat="server" Act="PasteHtml" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False">
<Dialog Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></Dialog>
</ighedit:HtmlBoxMenuItem>
<ighedit:HtmlBoxMenuItem runat="server" Act="CellProperties" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False">
<Dialog InternalDialogType="CellProperties" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></Dialog>
</ighedit:HtmlBoxMenuItem>
<ighedit:HtmlBoxMenuItem runat="server" Act="TableProperties" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False">
<Dialog InternalDialogType="ModifyTable" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></Dialog>
</ighedit:HtmlBoxMenuItem>
<ighedit:HtmlBoxMenuItem runat="server" Act="InsertImage" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False">
<Dialog Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></Dialog>
</ighedit:HtmlBoxMenuItem>
</RightClickMenu>

<TextWindow Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></TextWindow>

<DownlevelLabel Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></DownlevelLabel>

<TabStrip Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></TabStrip>
</ighedit:webhtmleditor>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="right" valign="top">
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td align="right" valign="top">
            </td>
            <td>
                <asp:Button ID="btnLuu" runat="server" CssClass="short-button" OnClick="btnLuu_Click"
                    Text="Lưu" Width="77px" />&nbsp; &nbsp;&nbsp;
                        <input id="btnThoat" runat="server" class="button" onclick="return btnThoat_OnClose();"
                            type="button" value="Đóng" style="width: 72px" /></td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
