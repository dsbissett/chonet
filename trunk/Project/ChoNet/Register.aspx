<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" Title="Đăng ký" %>

<%@ Register Assembly="Infragistics2.WebUI.WebDateChooser.v7.1, Version=7.1.20071.1048, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.WebSchedule" TagPrefix="igsch" %>

<%@ Register Assembly="Infragistics2.WebUI.Misc.v7.1, Version=7.1.20071.1048, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.Misc" TagPrefix="igmisc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" Runat="Server">
<script type="text/javascript">   
    
    function btn_onclick()
    {
        
    }
</script>
<table width="980px" cellspacing="0" cellpadding="0">
        <tr>
            <td align="center">
<asp:Panel ID="pnlRegister" runat="server" DefaultButton="btnDangKy" Width="100%">
<table border="0" cellpadding="0" cellspacing="2" width="100%" style="text-align:justify; border-top-width: 1px; border-right: gray 1px solid; border-left: gray 1px solid; border-top-color: gray; border-bottom: gray 1px solid;">
<tr>
<td style="height: 30px;" colspan="4">
    <strong>Đăng ký làm User hay E-Store        
    </strong><hr /></td>
</tr>
<tr>    
<td style="width:5%"></td>
<td style="width:20%" align="right">
    Đăng ký làm :</td>
<td>
    <asp:RadioButton ID="rbtUser" runat="server" GroupName="LoaiNguoiDung" Text="User" Checked="True" />
    <asp:RadioButton ID="rbtEStore" runat="server" GroupName="LoaiNguoiDung" Text="E-Store" /></td>
<td style="width:5%"></td>
</tr>
<tr>
<td style="height: 30px;" colspan="4">
<hr style="height:1px" />
    <strong>        
        Thông tin tài khoản        
    </strong></td>
</tr>
<tr>
<td style="width:5%"></td>
<td style="width:15%" align="right">
    Tên đăng nhập :</td>
<td><asp:TextBox ID="txtTaiKhoan" runat="server" Width="25%" MaxLength="60" ></asp:TextBox><asp:RequiredFieldValidator
        ID="rfvTaiKhoan" runat="server" ErrorMessage="*" ControlToValidate="txtTaiKhoan" SetFocusOnError="True" ValidationGroup="Register"></asp:RequiredFieldValidator><asp:Label
            ID="lblErr" runat="server" ForeColor="Red"></asp:Label></td>
</tr>
<tr>
<td style="width:5%"></td>
<td style="width:15%" align="right">
    Địa chỉ Email :</td>
<td>
    <asp:TextBox ID="txtEmail" runat="server" Width="25%" MaxLength="60"></asp:TextBox><asp:RequiredFieldValidator ID="rfvEmail" runat="server" ErrorMessage="*" ControlToValidate="txtEmail" SetFocusOnError="True" ValidationGroup="Register"></asp:RequiredFieldValidator><asp:Label
        ID="lblEmailError" runat="server" ForeColor="Red"></asp:Label></td>
<td style="width:5%"></td>
</tr>
<tr>
<td style="width:5%"></td>
<td style="width:15%" align="right">
    Xác nhận lại địa chỉ Email :</td>
<td>
    <asp:TextBox ID="txtXacNhanEmail" runat="server" Width="25%" MaxLength="60"></asp:TextBox><asp:RequiredFieldValidator ID="rfvXacNhanEmail" runat="server" ErrorMessage="*" ControlToValidate="txtXacNhanEmail" SetFocusOnError="True" ValidationGroup="Register"></asp:RequiredFieldValidator><asp:CompareValidator
        ID="cvEmail" runat="server" ControlToCompare="txtEmail" ControlToValidate="txtXacNhanEmail"
        ErrorMessage="Email không khớp" SetFocusOnError="True"></asp:CompareValidator></td>
<td style="width:5%"></td>
</tr>
<tr>
<td style="width:5%"></td>
<td style="width:15%" align="right">
    Mật khẩu :</td>
<td>
    <asp:TextBox ID="txtMatKhau" runat="server" TextMode="Password" Width="25%" MaxLength="60"></asp:TextBox><asp:RequiredFieldValidator ID="rfvMatKhau" runat="server" ErrorMessage="*" ControlToValidate="txtMatKhau" SetFocusOnError="True" ValidationGroup="Register"></asp:RequiredFieldValidator></td>
<td style="width:5%"></td>
</tr>
<tr>
<td style="width:5%"></td>
<td style="width:15%" align="right">
    Xác nhận lại mật khẩu :</td>
<td>
    <asp:TextBox ID="txtXacNhanMatKhau" runat="server" TextMode="Password" Width="25%" MaxLength="60"></asp:TextBox><asp:RequiredFieldValidator ID="rfvXacNhanMatKhau" runat="server" ErrorMessage="*" ControlToValidate="txtXacNhanMatKhau" SetFocusOnError="True" ValidationGroup="Register"></asp:RequiredFieldValidator><asp:CompareValidator
        ID="CompareValidator1" runat="server" ControlToCompare="txtMatKhau" ControlToValidate="txtXacNhanMatKhau"
        ErrorMessage="Mật khẩu không khớp" SetFocusOnError="True"></asp:CompareValidator></td>
<td style="width:5%"></td>
</tr>
<tr>
<td style="height: 47px;" colspan="4">
    <hr /><strong>
        
        Thông tin cá nhân
        
    </strong><hr /></td>
</tr>
<tr>
<td style="width:5%"></td>
<td style="width:15%" align="right">
    Tên đầy đủ :</td>
<td>
    <asp:TextBox ID="txtHoVaTen" runat="server" Width="25%" MaxLength="100"></asp:TextBox><asp:RequiredFieldValidator ID="rfvHoVaTen" runat="server" ErrorMessage="*" ControlToValidate="txtHoVaTen" SetFocusOnError="True" ValidationGroup="Register"></asp:RequiredFieldValidator></td>
<td style="width:5%"></td>
</tr>
    <tr>
        <td style="width: 5%">
        </td>
        <td align="right" style="width: 15%">
            Giới tính :</td>
        <td>
            <asp:RadioButton ID="rbtGioiTinhNam" runat="server" GroupName="GioiTinh" Text="Nam" Checked="True" /><asp:RadioButton ID="rbtGioiTinhNu" runat="server" GroupName="GioiTinh" Text="Nữ" /></td>
        <td style="width: 5%">
        </td>
    </tr>
    <tr>
        <td style="width: 5%">
        </td>
        <td align="right" style="width: 15%">
            Ngày sinh :</td>
        <td>
            <igsch:WebDateChooser ID="wdcNgaySinh" runat="server">
                <CalendarLayout Culture="Vietnamese (Vietnam)" DropDownYearsNumber="150">
                </CalendarLayout>
            </igsch:WebDateChooser>
            
        </td>
        <td style="width: 5%">
        </td>
    </tr>
<tr>
<td style="width:5%"></td>
<td style="width:15%" align="right">
    Địa chỉ:</td>
<td>
    <asp:TextBox ID="txtDiaChi" runat="server" Height="100px" TextMode="MultiLine" Width="50%"></asp:TextBox></td>
<td style="width:5%"></td>
</tr>
<tr>
<td style="width:5%"></td>
<td style="width:15%" align="right">
    Điện thoại di động :</td>
<td>
    <asp:TextBox ID="txtDienThoaiDiDong" runat="server" Width="25%" MaxLength="20"></asp:TextBox></td>
<td style="width:5%"></td>
</tr>
<tr>
<td style="width:5%"></td>
<td style="width:15%" align="right">
    Số chứng mình thư :</td>
<td>
    <asp:TextBox ID="txtSoChungMinhThu" runat="server" Width="25%" MaxLength="9"></asp:TextBox></td>
<td style="width:5%"></td>
</tr>
    <tr>
        <td style="width: 5%">
        </td>
        <td align="right" style="width: 15%">
            YM :</td>
        <td>
            <asp:TextBox ID="txtYM" runat="server" Width="25%" MaxLength="60"></asp:TextBox></td>
        <td style="width: 5%">
        </td>
    </tr>
<tr>
<td style="width:5%"></td>
<td style="width:15%" align="right"></td>
<td></td>
<td style="width:5%"></td>
</tr>
<tr>
<td style="width:5%"></td>
<td style="width:15%" align="right"></td>
<td></td>
<td style="width:5%"></td>
</tr>
<tr>
<td style="width:5%"></td>
<td style="width:15%" align="right"></td>
<td>
    <br />
    <br />
    <asp:Button ID="btnDangKy" runat="server" CssClass="button" Text="Đăng ký" OnClick="btnDangKy_Click" ValidationGroup="Register" /><br />
    <br />
    <br />
    <br />
    <br />
</td>
<td style="width:5%"></td>
</tr>
</table></asp:Panel>
</td>
        </tr>
    </table>
</asp:Content>

