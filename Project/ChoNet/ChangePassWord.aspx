<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="ChangePassWord.aspx.cs" Inherits="Adm_ChangePassWord" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Đổi mật khẩu</title>    
    <link href="Css/admin.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
function btnLuu_Click()
{
    var lbl = document.getElementById('<%=lblMatKhauCuErr.ClientID%>');    
    var txt = document.getElementById('<%=txtMatKhauCu.ClientID%>');
    var txtMKmoi = document.getElementById('<%=txtMatKhauMoi.ClientID%>');
    var hid = document.getElementById('<%=hidMatKhau.ClientID%>');
    var cv = document.getElementById('<%=cvMatKhau.ClientID%>');
     
    if (txt.value != hid.value) 
    {
        if (Page_ClientValidate())
        {       
            lbl.innerText = 'Mật khẩu cũ không đúng!';        
            return false;
        }            
    }
    else if(txtMKmoi.value == hid.value)
    {
        if (Page_ClientValidate())
        {       
            lbl.innerText = 'Mật khẩu mới không được trùng mật khẩu cũ!';        
            return false;
        }  
    }
    else
    {
        lbl.innerText = '';
        return Page_ClientValidate();
    }

    
    return Page_ClientValidate();
}
</script>
</head>
<body>
    <form id="form1" runat="server" defaultfocus="txtMatKhauCu" defaultbutton="btnLuu">

    <table style="width: 320px"><tr><td style="height: 10px;" align="left" colspan="2" valign="top">
        </td></tr>
<tr><td style="width: 120px" align="right">
    Mật khẩu cũ :</td><td>
    <asp:TextBox ID="txtMatKhauCu" runat="server" TextMode="Password"></asp:TextBox><asp:RequiredFieldValidator
        ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtMatKhauCu"
        ErrorMessage="*" ValidationGroup="DoiMatKhau"></asp:RequiredFieldValidator></td></tr>
<tr><td style="width: 120px" align="right">
    Mật khẩu mới :</td><td>
    <asp:TextBox ID="txtMatKhauMoi" runat="server" TextMode="Password"></asp:TextBox><asp:RequiredFieldValidator
        ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtMatKhauMoi"
        ErrorMessage="*" ValidationGroup="DoiMatKhau"></asp:RequiredFieldValidator></td></tr>
        <tr>
            <td align="right" style="width: 120px">
                Nhập lại mật khẩu :</td>
            <td>
                <asp:TextBox ID="txtXacNhanMatKhau" runat="server" TextMode="Password"></asp:TextBox><asp:RequiredFieldValidator
                    ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtXacNhanMatKhau"
                    ErrorMessage="*" ValidationGroup="DoiMatKhau"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td align="right" style="width: 120px; height: 50px;">
                <asp:HiddenField ID="hidMatKhau" runat="server" />
            </td>
            <td>
                <asp:Label
            ID="lblMatKhauCuErr" runat="server" ForeColor="Red"></asp:Label><br />
                <asp:CompareValidator ID="cvMatKhau"
                        runat="server" ControlToCompare="txtMatKhauMoi" ControlToValidate="txtXacNhanMatKhau"
                        ErrorMessage="Mật khẩu không khớp" SetFocusOnError="True" ValidationGroup="DoiMatKhau"></asp:CompareValidator></td>
        </tr>
<tr><td style="width: 120px" align="right"></td><td>
    <asp:Button ID="btnLuu" runat="server" CssClass="button" Text="Lưu mật khẩu" OnClick="btnLuu_Click" ValidationGroup="DoiMatKhau" /></td></tr>
</table>
</form>
</body>
</html>
