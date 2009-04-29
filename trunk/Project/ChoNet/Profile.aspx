<%@ Page Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true"
    CodeFile="Profile.aspx.cs" Inherits="Admin_Profile" Title="Thông tin cá nhân" %>

<%@ Register Assembly="Infragistics2.WebUI.WebDateChooser.v7.1, Version=7.1.20071.1048, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.WebSchedule" TagPrefix="igsch" %>
<%@ Register Assembly="Infragistics2.WebUI.UltraWebGrid.v7.1, Version=7.1.20071.1048, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebGrid" TagPrefix="igtbl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphMain" runat="Server">

    <script type="text/javascript">
        function DoiMatKhau()
        {
            OpenDialogWindow('Đổi mật khẩu',340,240,'page','ChangePassWord.aspx');    
        }
        function Refresh()
    {
        CloseDialogWindow();
    }
    </script>

    <asp:Panel ID="pnlProfile" runat="server" DefaultButton="btnLuu" Width="100%">
        <table border="0" cellpadding="0" cellspacing="2" width="100%" class="table">
            <tr>
                <td colspan="1" style="height: 20px">
                </td>
                <td align="right" colspan="3" style="height: 20px">
                </td>
                <td colspan="1">
                </td>
                <td colspan="1">
                </td>
            </tr>
            <tr>
                <td colspan="1" style="height: 20px" align="left">
                </td>
                <td colspan="4" align="left">
                    <strong>Thông tin người dùng&nbsp;</strong></td>
                <td colspan="1" align="left">
                </td>
            </tr>
            <tr>
                <td colspan="1" style="height: 20px">
                </td>
                <td align="right" colspan="4">
                </td>
                <td colspan="1">
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 10%">
                </td>
                <td align="right" style="width: 15%">
                    Tên truy cập :
                </td>
                <td align="left" colspan="3">
                    <asp:TextBox ID="txtTaiKhoan" runat="server" Width="30%" Enabled="False"></asp:TextBox></td>
                <td align="left" style="width: 10%">
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 10%">
                </td>
                <td align="right" style="width: 15%;">
                    Họ và tên&nbsp;:</td>
                <td align="left" colspan="3">
                    <asp:TextBox ID="txtHoVaTen" runat="server" Width="30%" ValidationGroup="Profile"></asp:TextBox><asp:RequiredFieldValidator
                        ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtHoVaTen" ErrorMessage="*" ValidationGroup="Profile">*</asp:RequiredFieldValidator></td>
                <td align="left" style="width: 10%">
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 10%">
                </td>
                <td align="right" style="width: 15%">
                    Ngày sinh :</td>
                <td align="left" colspan="3">
                    <igsch:WebDateChooser ID="wdcNgaySinh" runat="server" Width="30%" Value="2008-06-12">
                        <CalendarLayout Culture="Vietnamese (Vietnam)">
                        </CalendarLayout>
                    </igsch:WebDateChooser>
                </td>
                <td align="left" style="width: 10%">
                </td>
            </tr>
            <tr>
                <td align="right">
                </td>
                <td align="right">
                    Giới tính :</td>
                <td align="left" colspan="3">
                    <asp:RadioButton ID="rbtGioiTinhNam" runat="server" GroupName="GioiTinh" Text="Nam" />
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;<asp:RadioButton
                        ID="rbtGioiTinhNu" runat="server" GroupName="GioiTinh" Text="Nữ" />&nbsp;</td>
                <td align="left">
                </td>
            </tr>
            <tr>
                <td align="right">
                </td>
                <td align="right">
                    Điện thoại di động :</td>
                <td align="left" colspan="3">
                    <asp:TextBox ID="txtDienThoaiDiDong" runat="server" Width="30%"></asp:TextBox></td>
                <td align="left">
                </td>
            </tr>
            <tr>
                <td align="right">
                </td>
                <td align="right">
                    Điện thoại cố định :</td>
                <td align="left" colspan="3">
                    <asp:TextBox ID="txtDienThoaiCoDinh" runat="server" Width="30%"></asp:TextBox></td>
                <td align="left">
                </td>
            </tr>
            <tr>
                <td align="right">
                </td>
                <td align="right">
                    Email :</td>
                <td align="left" colspan="3">
                    <asp:TextBox ID="txtEmail" runat="server" Width="30%" ValidationGroup="Profile"></asp:TextBox><asp:RegularExpressionValidator
                        ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail"
                        ErrorMessage="Email không hợp lệ" SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="Profile"></asp:RegularExpressionValidator></td>
                <td align="left">
                </td>
            </tr>
            <tr>
                <td align="right">
                </td>
                <td align="right">
                    YM :</td>
                <td align="left" colspan="3">
                    <asp:TextBox ID="txtYM" runat="server" Width="30%"></asp:TextBox></td>
                <td align="left">
                </td>
            </tr>
            <tr>
                <td align="right">
                </td>
                <td align="right">
                    Số chứng minh thư :</td>
                <td align="left" colspan="3">
                    <asp:TextBox ID="txtSoChungMinhThu" runat="server" Width="30%" MaxLength="9"></asp:TextBox></td>
                <td align="left">
                </td>
            </tr>
            <tr>
                <td align="right">
                </td>
                <td align="right">
                </td>
                <td align="left" colspan="3">
                </td>
                <td align="left">
                </td>
            </tr>
            <tr>
                <td align="right">
                </td>
                <td align="right">
                    Địa chỉ :</td>
                <td align="left" colspan="3" rowspan="">
                    <asp:TextBox ID="txtDiaChi" runat="server" Height="77px" TextMode="MultiLine" Width="50%"></asp:TextBox></td>
                <td align="left" colspan="1" rowspan="1">
                </td>
            </tr>
            <tr>
                <td align="right" style="height: 40px">
                </td>
                <td align="right">
                </td>
                <td align="left" colspan="3">
                    <a href="#" onclick="DoiMatKhau();">Đổi mật khẩu</a></td>
                <td align="left">
                </td>
            </tr>
            <tr>
                <td align="right">
                </td>
                <td align="right">
                    &nbsp;
                    <input id="hidMatKhau" runat="server" type="hidden" /></td>
                <td align="left" colspan="3">
                    <asp:Button ID="btnLuu" runat="server" CssClass="long-button" Text="Lưu thông tin"
                        OnClick="btnLuu_Click" ValidationGroup="Profile" />
                    <strong><asp:Label ID="lblInform" runat="server"></asp:Label></strong></td>
                <td align="left">
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
