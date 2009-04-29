<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Default.master" CodeFile="ShoppingCart.aspx.cs"
    Inherits="ShoppingCart" EnableEventValidation="false" Title="Giỏ hàng của bạn" %>

<%@ Register Assembly="Infragistics2.WebUI.Misc.v7.1, Version=7.1.20071.1048, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.Misc" TagPrefix="igmisc" %>
<asp:Content ID="contentShoppingCart" runat="server" ContentPlaceHolderID="cphMain">

    <script type="text/javascript">
    function setdelete(obj, id)
    {
        var hid = document.getElementById('<%=hidXoa.ClientID%>');
        if (obj.checked ==true)
        {        
            hid.value += id + '_'
        }
        else
        {
            if (hid.value.indexOf(id) != -1)        
            {
                //alert(hid.value.indexOf(id+'_'));
                //alert(hid.value.lastIndexOf(id+'_'));
                hid.value = hid.value.substring(0, hid.value.indexOf(id+'_')) + hid.value.substring(hid.value.indexOf(id+'_') + (id+'_').length, hid.value.length);
            }
        }
        //alert(hid.value);
    }
    function changenumber(obj, id)
    {
        var strValue = "";
    //    if (obj.value == "") obj.value = '0';
    //    
    //    if ((obj.value < '0') && (obj.value > '99')) obj.value ='0';
        if (!/^[0-9]+$/.test(obj.value)) 
        { 
            //alert("Please enter onyl number.");
            obj.value = '0';
        }


        if (obj.value.length == 2)
        {
           strValue = obj.value; 
        }
        else
        {
            strValue = '0' + obj.value;
        }
        //alert(strValue);
        //alert(obj.value);
        var hid = document.getElementById('<%=hidNumber.ClientID%>');

            if (hid.value.indexOf(id) != -1)        
            {
                //alert(hid.value.indexOf(id+'_'));
                //alert(hid.value.lastIndexOf(id+'_'));
                hid.value = hid.value.substring(0, hid.value.indexOf(id)) + id + '_' + strValue + '|' + hid.value.substring(hid.value.indexOf(id) + (id + '_' + strValue + '|').length, hid.value.length);
            }
            else
            {
                hid.value += id + '_' + strValue + '|';
            }

    //    alert(hid.value);
    }

   
    </script>

    <div style="width: 100%">
        <table cellpadding="0" cellspacing="5" width="100%">
            <tr>
                <td valign="top" align="left" style="width: 230px" rowspan="3">
                    <table class="box2" width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td class="box2_name">
                                Danh mục sản phẩm
                            </td>
                        </tr>
                        <tr>
                            <td class="box2_bor">
                                <asp:Table ID="tblDanhMuc" runat="server" CssClass="listcat" Width="100%" CellPadding="0"
                                    CellSpacing="0">
                                </asp:Table>
                            </td>
                        </tr>
                    </table>
                </td>
                <td align="left" rowspan="3" style="width: 2%" valign="top">
                </td>
                <td valign="top" align="right">
                    <div runat="server" id="divDonHang">
                        <table width="100%" cellpadding="0" cellspacing="0">
                            <tbody>
                                <tr height="24">
                                    <td style="width: 1px">
                                        <img src="./Images/ShoppingCartLeft.jpg"></td>
                                    <td background="./Images/ShoppingCartBkg.jpg">
                                        <div style="padding-top: 4px; color: White; font-size: 12px; font-family: Arial, Helvetica, sans-serif;
                                            font-weight: bold">
                                            GIỎ HÀNG</div>
                                    </td>
                                    <td width="1">
                                        <img src="./Images/ShoppingCartright.jpg"></td>
                                </tr>
                            </tbody>
                        </table>
                        <table width="100%" cellpadding="0" cellspacing="0">
                            <tbody>
                                <tr>
                                    <td width="1" background="./Images/4.jpg">
                                        <img src="./Images/4.jpg"></td>
                                    <td>
                                        <div style="padding: 15px; text-align: left" runat="server" id="divShoppingCart">
                                        </div>
                                        <br />
                                        <asp:Button ID="btnGuiDonHang" runat="server" Text="Gửi đơn hàng" CssClass="button"
                                            Width="122px" OnClick="btnGuiDonHang_Click" />
                                        &nbsp; &nbsp;<asp:Button ID="btnXoa" runat="server" Text="Xóa" CssClass="button"
                                            OnClick="btnXoa_Click" Width="122px" />
                                        &nbsp; &nbsp;<asp:Button ID="btnTinhLai" runat="server" Text="Tính lại" CssClass="button"
                                            Width="122px" OnClick="btnTinhLai_Click" />
                                        &nbsp; &nbsp;<asp:Button ID="btnTiepTuc" runat="server" Text="Tiếp tục mua hàng"
                                            CssClass="button" Width="122px" OnClick="btnTiepTuc_Click" />&nbsp;
                                        <br />
                                        <br />
                                        <br />
                                    </td>
                                    <td width="1" background="./Images/6.jpg">
                                        <img src="./Images/6.jpg"></td>
                                </tr>
                            </tbody>
                        </table>
                        <table width="100%" cellpadding="0" cellspacing="0">
                            <tbody>
                                <tr height="2">
                                    <td width="3">
                                        <img src="./Images/1.jpg"></td>
                                    <td background="./Images/2.jpg">
                                        <img src="./Images/2.jpg"></td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </td>
            </tr>
            <tr>
                <td align="right" valign="top">
                    <input id="hidNumber" runat="server" type="hidden" />
                    <input id="hidXoa" runat="server" type="hidden" />
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
