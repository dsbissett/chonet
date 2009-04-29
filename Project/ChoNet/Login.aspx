<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" Title="Đăng nhập" Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" Runat="Server">
<script src="Scripts/Common.js" type="text/javascript"></script>
<script type="text/javascript" >

function LostPassword()
    {        
        //OpenDialogWindow('Quên mật khẩu', 320, 150, 'page', 'LostPassword.aspx');        
        ShowModalDialog('LostPassword.aspx','Quên mật khẩu', 320, 150);        
    }
function btnDangNhap_Click()
{

//    if (lbl1 != null)
//        lbl1.style.visibility = 'hidden';
//    if (lbl2 != null)
//        lbl2.style.visibility = 'hidden';
//    if ((rfv != null) && (rfv.IsValid == true))
//        rfv.style.visibility = 'hidden';
//        
//    return Page_ClientValidate();
}
function clickButton(e, buttonid){ 
      var evt = e ? e : window.event;
      var bt = document.getElementById(buttonid);
      if (bt){ 
          if (evt.keyCode == 13){
                bt.click(); 
                return false; 
          } 
      } 
}

</script>
	<table border="0" cellpadding="0" cellspacing="0" width="70%" style="width: 100%">
        <tr>
          <td align="center" colspan="1" height="30" style="height: 40px"></td>
          <td colspan="2" align="center" height="30" valign="top"></td>
        </tr>
      <tr>
          <td align="left" height="30" style="width: 25%" width="110">
          </td>
            <td align="right" height="30" width="110" style="width: 25%">Tên đăng nhập : &nbsp;</td>
            <td align="left" height="30">
            <asp:TextBox ID="txtTaiKhoan" runat="server" Width="150px"></asp:TextBox><asp:RequiredFieldValidator
                ID="rfvTaiKhoan" runat="server" ControlToValidate="txtTaiKhoan" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="Login"></asp:RequiredFieldValidator></td>
      </tr>
      <tr>
          <td align="left" height="30">
          </td>
        <td align="right" height="30">Mật khẩu : &nbsp;
        </td>
        <td align="left" height="30">
            <asp:TextBox ID="txtMatKhau" runat="server" TextMode="Password" Width="150px"></asp:TextBox><asp:RequiredFieldValidator
                ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtMatKhau" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="Login"></asp:RequiredFieldValidator></td>
      </tr>
      <tr>
          <td align="left" height="30">
          </td>
        <td align="left" height="30"> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
        <td align="left" height="30">
            <asp:Button ID="btnDangNhap" runat="server" CssClass="button" Text="Đăng nhập" OnClick="btnDangNhap_Click"/></td>
      </tr>
      <tr>
          <td align="left" colspan="1" height="30" nowrap="nowrap">
          </td>
        <td colspan="2" align="left" height="30" nowrap="nowrap" style="text-align: left; padding-left:200px">
            Đăng ký <u><a href="Register.aspx">tại đây</a></u>. <u><a href="javascript:LostPassword();">Quên mật khẩu</a></u></td>
        </tr>
      <tr>
          <td align="left" height="20">
          </td>
        <td align="left" height="30" colspan="2"> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblErr" runat="server" ForeColor="Red" Visible="False"></asp:Label></td>
      </tr>
    </table>
<script type="text/javascript" >
var txtTaiKhoan = document.getElementById('<%=txtTaiKhoan.ClientID %>');
if(txtTaiKhoan!=null) txtTaiKhoan.focus();
</script>
</asp:Content>

