<%@ Page Language="C#" MasterPageFile="~/EstoreMaster.master" AutoEventWireup="true"
    CodeFile="eStoreInfo.aspx.cs" Inherits="eStoreInfo" Title="Thong tin doanh nghiep" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphEstore" runat="Server">
    <table width="100%" cellspacing="2" cellpadding="0" class="box1">
        <tr>
            <td>
                <table width="100%" cellspacing="2" cellpadding="0" style="text-align: left;" class="box1_bor">
                    <tr>
                        <td colspan="2" style="text-align: center; font-weight: bold;" valign="top">
                            THÔNG TIN DOANH NGHIỆP</td>
                    </tr>
                    <tr>
                        <td style="width: 30%" valign="top">
                            &nbsp;</td>
                        <td style="width: 80%">
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            Tên doanh nghiệp:
                        </td>
                        <td style="font-weight: bold;">
                            <asp:Label ID="lblTenCuaHang" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td valign="top">
                            Giới thiệu:</td>
                        <td>
                            <asp:Label ID="lblGioiThieu" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td valign="top">
                            Địa chỉ liên hệ:</td>
                        <td>
                            <asp:Label ID="lblDiaChi" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td valign="top">
                            Email:</td>
                        <td>
                            <asp:Label ID="lblEmail" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td valign="top">
                            Điện thoại</td>
                        <td>
                            <asp:Label ID="lblCoDinh" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td valign="top">
                            Di động:</td>
                        <td>
                            <asp:Label ID="lblDiDong" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td valign="top">
                            Fax:</td>
                        <td>
                            <asp:Label ID="lblFax" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: center; font-weight: bold; padding-top: 10px;"
                            valign="top">
                            <asp:Label ID="lblBack" runat="server" ForeColor="Blue"></asp:Label></td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
