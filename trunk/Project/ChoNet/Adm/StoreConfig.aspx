<%@ Page Language="C#" MasterPageFile="~/Adm/Admin.master" AutoEventWireup="true"
    CodeFile="StoreConfig.aspx.cs" Inherits="Adm_StoreConfig" Title="Gian hàng" %>

<%@ Register Assembly="Infragistics2.WebUI.Misc.v7.1, Version=7.1.20071.1048, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.Misc" TagPrefix="igmisc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphAdmin" runat="Server">
    <!--[if lt IE 7]>
<script defer type="text/javascript" src="../Scripts/pngfix.js"></script>
<![endif]-->   

    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td align="center" valign="top">
                <table width="780" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td style="width: 200px" valign="top">
                            <table>
                                <tr>
                                    <td>
                                        <div onclick="ChangeAdv(55);" style="cursor: hand; left: 1px; width: 110px;">
                                            <table cellpadding="0" cellspacing="0" border="0">
                                                <tr>
                                                    <td>
                                                        <img src="../Images/edit.gif" alt="Thay đổi" /></td>
                                                    <td class="red-button">
                                                        Thay đổi quảng cáo 55</td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table style="left: 1px; width: 110px;">
                                            <tr>
                                                <td colspan="2">
                                                    <asp:UpdatePanel ID="pnlleftbanner" runat="server" OnLoad="pnlleftbanner_Load">
                                                        <ContentTemplate>
                                                            <span id="divAdvLeft" runat="server"></span>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td width="780">
                            <table class="form" width="94%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td class="bgbanner">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td width="22%" align="left" class="blured">
                                                    <img height="121" src="../GianHang/images/logoE.jpg" width="179" id="imgLogo" runat="server" /><a></a></td>
                                                <td width="47%" align="center">
                                                    <div onclick="ChangeAdv(51);" style="cursor: hand;">
                                                        <table cellpadding="0" cellspacing="0" border="0">
                                                            <tr>
                                                                <td>
                                                                    <img src="../Images/edit.gif" alt="Thay đổi" /></td>
                                                                <td class="red-button">
                                                                    Thay đổi quảng cáo 51</td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                    <div class="blured">
                                                    <igmisc:WebAsyncRefreshPanel ID="pnlQuangCao51" runat="server" Height="" Width="100%"
                                                        OnContentRefresh="pnlQuangCao51_ContentRefresh" RefreshComplete="RefreshComplete">
                                                        <span id="spnQuangCao51" runat="server"></span>
                                                    </igmisc:WebAsyncRefreshPanel></div>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td width="230" align="left" valign="top">
                                                    <table width="100%" border="0" cellspacing="4" cellpadding="0">
                                                        <tr>
                                                            <td class="blured">
                                                                <table class="box1" width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                    <tr>
                                                                        <td class="box1_name">
                                                                            <span class="textxanh">Danh mục chính </span><span class="textcam"></span>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="box1_bor">
                                                                            <table width="100%" class="listcat" border="0" cellspacing="0" cellpadding="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <a>Trang chủ E-Store </a>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="height: 13px">
                                                                                        <a>Sản phẩm khuyến mãi </a>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <a>Thông tin doanh nghiệp </a>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <a>Liên hệ </a>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <igmisc:WebAsyncRefreshPanel ID="pnlDanhMuc" runat="server" Width="100%" Height="100%"
                                                                    RefreshComplete="RefreshComplete" OnContentRefresh="pnlDanhMuc_ContentRefresh">
                                                                    <table class="box2" width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                        <tr>
                                                                            <td class="box2_name" style="height: 26px">
                                                                                Danh mục sản phẩm
                                                                            </td>
                                                                            <td class="box2_name" style="cursor: hand" onclick="Add();">
                                                                                <img src="../Images/Add.gif" alt="Thêm danh mục cha" /></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="box2_bor" colspan="2">
                                                                                <table width="100%" border="0" cellspacing="0" cellpadding="0" id="tblDanhMuc" runat="server">
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </igmisc:WebAsyncRefreshPanel>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <table class="box1" width="100%" border="0" cellspacing="0" cellpadding="0">                                                                
                                                                    <tr>
                                                                        <td class="box1_name">
                                                                        <div onclick="ChangeAdv(57);" style="cursor: hand;">
                                                                    <table cellpadding="0" cellspacing="0" border="0">
                                                                        <tr>
                                                                            <td>
                                                                                <img src="../Images/edit.gif" alt="Thay đổi" /></td>
                                                                            <td class="red-button">
                                                                                Thay đổi quảng cáo 57</td>
                                                                        </tr>
                                                                    </table>
                                                                </div>
                                                                            <span class="textxanh">Quảng cáo</span></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="box1_bor" style="text-align: center;">
                                                                            <igmisc:WebAsyncRefreshPanel ID="pnlQuangCao57" runat="server" Height="" OnContentRefresh="pnlGianHang_ContentRefresh"
                                                                                Width="" RefreshComplete="RefreshComplete">
                                                                                <span id="tblQuangCao57" runat="server" >
                                                                                </span>
                                                                            </igmisc:WebAsyncRefreshPanel>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td align="left" valign="top">
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td align="left" valign="top" style="padding: 4px;">
                                                                <div onclick="ChangeAdv(54);" style="cursor: hand;">
                                                                    <table cellpadding="0" cellspacing="0" border="0">
                                                                        <tr>
                                                                            <td>
                                                                                <img src="../Images/edit.gif" alt="Thay đổi" /></td>
                                                                            <td class="red-button">
                                                                                Thay đổi quảng cáo 54</td>
                                                                        </tr>
                                                                    </table>
                                                                </div>
                                                                <igmisc:WebAsyncRefreshPanel ID="pnlQuangCao54" runat="server" Height="" Width="100%"
                                                                    OnContentRefresh="pnlQuangCao54_ContentRefresh" RefreshComplete="RefreshComplete">
                                                                    <span id="spnQuangCao54" runat="server"></span>
                                                                </igmisc:WebAsyncRefreshPanel>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" valign="top" style="padding: 4px;" class="blured">
                                                                <table width="100%" border="0" class="box4" cellspacing="0" cellpadding="0">
                                                                    <tr>
                                                                        <td class="box4_name">
                                                                            <span class="textxanh">Gian hàng </span><span class="textcam">giới thiệu </span>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="box4_bor">
                                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                <tr>
                                                                                    <td align="left" valign="top">
                                                                                        <table class="product" width="100%" border="0" cellspacing="4" cellpadding="0">
                                                                                            <tr>
                                                                                                <td align="center">
                                                                                                    <a>
                                                                                                        <img src="../images/sp1.jpg" alt="#" width="99" height="89" border="0" style="border: #CCCCCC 1px solid" /></a></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td align="center">
                                                                                                    <a>Logitech Z5400</a><br />
                                                                                                    Giá: <span class="price">1.450.000</span> VNĐ
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                    <td align="left" valign="top">
                                                                                        <table class="product" width="100%" border="0" cellspacing="4" cellpadding="0">
                                                                                            <tr>
                                                                                                <td align="center">
                                                                                                    <a>
                                                                                                        <img src="../images/sp1.jpg" alt="#" width="99" height="89" border="0" style="border: #CCCCCC 1px solid" /></a></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td align="center">
                                                                                                    <a>Logitech Z5400</a><br />
                                                                                                    Giá: <span class="price">1.450.000</span> VNĐ
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                    <td align="left" valign="top">
                                                                                        <table class="product" width="100%" border="0" cellspacing="4" cellpadding="0">
                                                                                            <tr>
                                                                                                <td align="center">
                                                                                                    <a>
                                                                                                        <img src="../images/sp1.jpg" alt="#" width="99" height="89" border="0" style="border: #CCCCCC 1px solid" /></a></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td align="center">
                                                                                                    <a>Logitech Z5400</a><br />
                                                                                                    Giá: <span class="price">1.450.000</span> VNĐ
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="left" valign="top">
                                                                                        <table class="product" width="100%" border="0" cellspacing="4" cellpadding="0">
                                                                                            <tr>
                                                                                                <td align="center">
                                                                                                    <a>
                                                                                                        <img src="../images/sp1.jpg" alt="#" width="99" height="89" border="0" style="border: #CCCCCC 1px solid" /></a></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td align="center">
                                                                                                    <a>Logitech Z5400</a><br />
                                                                                                    Giá: <span class="price">1.450.000</span> VNĐ
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                    <td align="left" valign="top">
                                                                                        <table class="product" width="100%" border="0" cellspacing="4" cellpadding="0">
                                                                                            <tr>
                                                                                                <td align="center">
                                                                                                    <a>
                                                                                                        <img src="../images/sp1.jpg" alt="#" width="99" height="89" border="0" style="border: #CCCCCC 1px solid" /></a></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td align="center">
                                                                                                    <a>Logitech Z5400</a><br />
                                                                                                    Giá: <span class="price">1.450.000</span> VNĐ
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                    <td align="left" valign="top">
                                                                                        <table class="product" width="100%" border="0" cellspacing="4" cellpadding="0">
                                                                                            <tr>
                                                                                                <td align="center">
                                                                                                    <a>
                                                                                                        <img src="../images/sp1.jpg" alt="#" width="99" height="89" border="0" style="border: #CCCCCC 1px solid" /></a></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td align="center">
                                                                                                    <a>Logitech Z5400</a><br />
                                                                                                    Giá: <span class="price">1.450.000</span> VNĐ
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="left" valign="top">
                                                                                        <table class="product" width="100%" border="0" cellspacing="4" cellpadding="0">
                                                                                            <tr>
                                                                                                <td align="center">
                                                                                                    <a>
                                                                                                        <img src="../images/sp1.jpg" alt="#" width="99" height="89" border="0" style="border: #CCCCCC 1px solid" /></a></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td align="center">
                                                                                                    <a>Logitech Z5400</a><br />
                                                                                                    Giá: <span class="price">1.450.000</span> VNĐ
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                    <td align="left" valign="top">
                                                                                        <table class="product" width="100%" border="0" cellspacing="4" cellpadding="0">
                                                                                            <tr>
                                                                                                <td align="center">
                                                                                                    <a>
                                                                                                        <img src="../images/sp1.jpg" alt="#" width="99" height="89" border="0" style="border: #CCCCCC 1px solid" /></a></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td align="center">
                                                                                                    <a>Logitech Z5400</a><br />
                                                                                                    Giá: <span class="price">1.450.000</span> VNĐ
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                    <td align="left" valign="top">
                                                                                        <table class="product" width="100%" border="0" cellspacing="4" cellpadding="0">
                                                                                            <tr>
                                                                                                <td align="center">
                                                                                                    <a>
                                                                                                        <img src="../images/sp1.jpg" alt="#" width="99" height="89" border="0" style="border: #CCCCCC 1px solid" /></a></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td align="center">
                                                                                                    <a>Logitech Z5400</a><br />
                                                                                                    Giá: <span class="price">1.450.000</span> VNĐ
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="left" valign="top">
                                                                                        <table class="product" width="100%" border="0" cellspacing="4" cellpadding="0">
                                                                                            <tr>
                                                                                                <td align="center">
                                                                                                    <a>
                                                                                                        <img src="../images/sp1.jpg" alt="#" width="99" height="89" border="0" style="border: #CCCCCC 1px solid" /></a></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td align="center">
                                                                                                    <a>Logitech Z5400</a><br />
                                                                                                    Giá: <span class="price">1.450.000</span> VNĐ
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                    <td align="left" valign="top">
                                                                                        <table class="product" width="100%" border="0" cellspacing="4" cellpadding="0">
                                                                                            <tr>
                                                                                                <td align="center">
                                                                                                    <a>
                                                                                                        <img src="../images/sp1.jpg" alt="#" width="99" height="89" border="0" style="border: #CCCCCC 1px solid" /></a></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td align="center">
                                                                                                    <a>Logitech Z5400</a><br />
                                                                                                    Giá: <span class="price">1.450.000</span> VNĐ
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                    <td align="left" valign="top">
                                                                                        <table class="product" width="100%" border="0" cellspacing="4" cellpadding="0">
                                                                                            <tr>
                                                                                                <td align="center">
                                                                                                    <a>
                                                                                                        <img src="../images/sp1.jpg" alt="#" width="99" height="89" border="0" style="border: #CCCCCC 1px solid" /></a></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td align="center">
                                                                                                    <a>Logitech Z5400</a><br />
                                                                                                    Giá: <span class="price">1.450.000</span> VNĐ
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="left" valign="top">
                                                                                        <table class="product" width="100%" border="0" cellspacing="4" cellpadding="0">
                                                                                            <tr>
                                                                                                <td align="center">
                                                                                                    <a>
                                                                                                        <img src="../images/sp1.jpg" alt="#" width="99" height="89" border="0" style="border: #CCCCCC 1px solid" /></a></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td align="center">
                                                                                                    <a>Logitech Z5400</a><br />
                                                                                                    Giá: <span class="price">1.450.000</span> VNĐ
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                    <td align="left" valign="top">
                                                                                        <table class="product" width="100%" border="0" cellspacing="4" cellpadding="0">
                                                                                            <tr>
                                                                                                <td align="center">
                                                                                                    <a>
                                                                                                        <img src="../images/sp1.jpg" alt="#" width="99" height="89" border="0" style="border: #CCCCCC 1px solid" /></a></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td align="center">
                                                                                                    <a>Logitech Z5400</a><br />
                                                                                                    Giá: <span class="price">1.450.000</span> VNĐ
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                    <td align="left" valign="top">
                                                                                        <table class="product" width="100%" border="0" cellspacing="4" cellpadding="0">
                                                                                            <tr>
                                                                                                <td align="center">
                                                                                                    <a>
                                                                                                        <img src="../images/sp1.jpg" alt="#" width="99" height="89" border="0" style="border: #CCCCCC 1px solid" /></a></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td align="center">
                                                                                                    <a>Logitech Z5400</a><br />
                                                                                                    Giá: <span class="price">1.450.000</span> VNĐ
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="3">
                                                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                            <tr>
                                                                                                <td width="82%" align="left">
                                                                                                    <b>Trang [1] 2 3 4 5 6 7 ... &gt; &gt;&gt; </b>
                                                                                                </td>
                                                                                                <td width="18%">
                                                                                                    <table width="100%" border="0" cellspacing="4" cellpadding="0">
                                                                                                        <tr>
                                                                                                            <td width="82%" nowrap="nowrap">
                                                                                                                <strong>Đi tới trang </strong>
                                                                                                            </td>
                                                                                                            <td width="18%">
                                                                                                                <select name="select5" style="width: 50px; font-size: 11px;">
                                                                                                                    <option>08</option>
                                                                                                                </select>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td width="230" align="left" valign="top">
                                                    <table width="100%" border="0" cellspacing="4" cellpadding="0">
                                                        <tr>
                                                            <td>
                                                                <div onclick="AddHTTT();" style="cursor: hand;">
                                                                    <table cellpadding="0" cellspacing="0" border="0">
                                                                        <tr>
                                                                            <td>
                                                                                <img src="../Images/Add.gif" alt="Thay đổi" /></td>
                                                                            <td class="red-button">
                                                                                Thêm hỗ trợ trực tuyến</td>
                                                                        </tr>
                                                                    </table>
                                                                </div>
                                                                <igmisc:WebAsyncRefreshPanel ID="pnlHoTro" runat="server" Height="" Width="100%"
                                                                    OnContentRefresh="pnlHoTro_ContentRefresh" RefreshComplete="RefreshComplete">
                                                                    <table class="box1" width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                        <tr>
                                                                            <td class="box1_name">
                                                                                <span class="textxanh">Hỗ trợ khách hàng </span><span class="textcam"></span>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="box1_bor">
                                                                                <span runat="server" id="spnHoTroTrucTuyen"></span>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </igmisc:WebAsyncRefreshPanel>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="blured">
                                                                <table class="box1" width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                    <tr>
                                                                        <td class="box1_name">
                                                                            <span class="textxanh">Sản phẩm xem nhiều nhất </span><span class="textcam"></span>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="box1_bor">
                                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <table class="product" width="100%" border="0" cellspacing="4" cellpadding="0">
                                                                                            <tr>
                                                                                                <td align="center">
                                                                                                    <a>
                                                                                                        <img src="../images/sp1.jpg" alt="#" width="74" height="66" border="0" style="border: #CCCCCC 1px solid" /></a></td>
                                                                                                <td align="left">
                                                                                                    <a>Logitech Z5400</a><br />
                                                                                                    Giá: <span class="price">1.450.000</span> VNĐ
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <table class="product" width="100%" border="0" cellspacing="4" cellpadding="0">
                                                                                            <tr>
                                                                                                <td align="center">
                                                                                                    <a>
                                                                                                        <img src="../images/sp1.jpg" alt="#" width="74" height="66" border="0" style="border: #CCCCCC 1px solid" /></a></td>
                                                                                                <td align="left">
                                                                                                    <a>Logitech Z5400</a><br />
                                                                                                    Giá: <span class="price">1.450.000</span> VNĐ
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <table class="product" width="100%" border="0" cellspacing="4" cellpadding="0">
                                                                                            <tr>
                                                                                                <td align="center">
                                                                                                    <a>
                                                                                                        <img src="../images/sp1.jpg" alt="#" width="74" height="66" border="0" style="border: #CCCCCC 1px solid" /></a></td>
                                                                                                <td align="left">
                                                                                                    <a>Logitech Z5400</a><br />
                                                                                                    Giá: <span class="price">1.450.000</span> VNĐ
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <div onclick="ChangeProduct(23);" style="cursor: hand;">
                                                                    <table cellpadding="0" cellspacing="0" border="0">
                                                                        <tr>
                                                                            <td>
                                                                                <img src="../Images/Add.gif" alt="Thay đổi" /></td>
                                                                            <td class="red-button">
                                                                                Thay đổi sản phẩm Hot</td>
                                                                        </tr>
                                                                    </table>
                                                                </div>
                                                                <asp:UpdatePanel ID="pnlSanPhamHot" runat="server" OnLoad="pnlSanPhamHot_Load">
                                                                <ContentTemplate>
                                                                <table class="box1" width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                        <tr>
                                                                            <td class="box1_name">
                                                                                <span class="textxanh">Sản Phẩm HOT</span><span class="textcam"></span>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="box1_bor">
                                                                                <asp:Table runat="server" ID="tblSanPhamHot"></asp:Table>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </ContentTemplate>                                                                
                                                                </asp:UpdatePanel>                                                                
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="blured">
                                        <table width="100%" border="0" cellspacing="4" cellpadding="0">
                                            <tr>
                                                <td height="25" align="center" bgcolor="#398e33" class="footer">
                                                    Bản quyền thuộc Chonet.vn - Phiên bản đang hoạt động thử nghiệm theo giấy phép của
                                                    BVHTT
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td valign="top">
                            <table>
                                <tr>
                                    <td>
                                        <div onclick="ChangeAdv(56);" style="cursor: hand; left: 895px; width: 110px;">
                                            <table cellpadding="0" cellspacing="0" border="0">
                                                <tr>
                                                    <td>
                                                        <img src="../Images/edit.gif" alt="Thay đổi" /></td>
                                                    <td class="red-button">
                                                        Thay đổi quảng cáo 56</td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table style="left: 895px; width: 110px;">
                                            <tr>
                                                <td colspan="2">
                                                    <asp:UpdatePanel ID="pnlrightbanner" runat="server" OnLoad="pnlrightbanner_Load">
                                                        <ContentTemplate>
                                                            <span id="divAdvRight" runat="server"></span>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    
     <script id="igClientScript" type="text/javascript">
<!--
function loadjscssfile(filename, filetype){
 if (filetype=="js"){ //if filename is a external JavaScript file
  var fileref=document.createElement('script')
  fileref.setAttribute("type","text/javascript")
  fileref.setAttribute("src", filename)
 }
 else if (filetype=="css"){ //if filename is an external CSS file
  var fileref=document.createElement("link")
  fileref.setAttribute("rel", "stylesheet")
  fileref.setAttribute("type", "text/css")
  fileref.setAttribute("href", filename)
 }
 if (typeof fileref!="undefined")
  document.getElementsByTagName("head")[0].appendChild(fileref)
}

loadjscssfile("../css/style.css", "css") ////dynamically load and add this .css file

function RefreshAdv(aid)
{
    var warp;
    switch(aid)
    {
        case 51: warp = ig$('<%=pnlQuangCao51.ClientID %>'); 
        if(!warp) return;
	    warp.refresh();	
        break;
        
        case 54: warp = ig$('<%=pnlQuangCao54.ClientID %>'); 
        if(!warp) return;
	    warp.refresh();	
        break;
        
        case 55: //warp = document.getElementById(); 
        __doPostBack('<%=pnlleftbanner.ClientID %>','');        
        CloseDialogWindow();
        break;
        
        case 56: 
        __doPostBack('<%=pnlrightbanner.ClientID %>',''); 
        CloseDialogWindow();
        break;
    }
    		
}
function RefreshStoreInfo()
{   
	var warp2 = ig$('<%=pnlHoTro.ClientID%>'); 
    if(!warp2) return;
	warp2.refresh();		
}

function RefreshComplete(oPanel){
	CloseDialogWindow();
}
function ChangeAdv(aid)
{
    OpenDialogWindow('Thay đổi quảng cáo',680,420,'page','SelectAdv.aspx?aid=' + aid);
}
function ChangeProduct(pid)
{   
     OpenDialogWindow('Thay đổi sản phẩm',1006,700,'page','SelectProd.aspx?pid=' + pid);    
}
function EditShopInfo()
{
    OpenDialogWindow('Thay đổi thông tin cửa hàng',560,620,'page','UpdateStore.aspx?sid=<%=CuaHangID.ToString()%>');
}
function ChangeStore(sid)
{
    OpenDialogWindow('Thay đổi gian hàng',780,620,'page','SelectStore.aspx?sid=' + sid);
}
function RefreshStore()
{  	var warp = ig$('<%=pnlQuangCao57.ClientID %>');	
	if(!warp)
		return;
	warp.refresh();		
}
function AddHTTT(){                              
        OpenDialogWindow('Thêm hỗ trợ',340,280,'page','AddSupporter.aspx?sid=<%=CuaHangID.ToString()%>');    
}
function EditHTTT(id){                              
        OpenDialogWindow('Sửa thông tin hỗ trợ',340,280,'page','AddSupporter.aspx?sid=<%=CuaHangID.ToString()%>&hid=' + id);    
}
function DeleteHTTT(id){                      
        OpenDialogWindow('Xóa hỗ trợ',350,170,'page','Delete.aspx?id=' + id + '&type=hotrotructuyen');    
}
function Add(){                              
        OpenDialogWindow('Thêm danh mục cha',680,420,'page','SelectStoreCat.aspx?sid=<%=CuaHangID.ToString()%>&did=0');    
}
function AddSub(id){                              
        OpenDialogWindow('Thêm danh mục con',680,420,'page','SelectStoreCat.aspx?sid=<%=CuaHangID.ToString()%>&did=' + id);    
}

function Delete(id){                      
        OpenDialogWindow('Xóa danh mục',350,170,'page','Delete.aspx?id=' + id + '&sid=<%=CuaHangID.ToString() %>&type=cuahangnhomsanpham');    
}
function Refresh()
{  	var warp = ig$('<%=pnlDanhMuc.ClientID%>');
	if(warp)	
	warp.refresh();	
	var warp2 = ig$('<%=pnlHoTro.ClientID%>'); 
    if(!warp2) return;
	warp2.refresh();	
}

function RefreshProduct(pid)
{
    var warp;
    switch(pid)
    {
        case 23: warp = document.getElementById('<%=pnlSanPhamHot.ClientID%>');
        __doPostBack('<%=pnlSanPhamHot.ClientID %>','');        
        CloseDialogWindow();
        break;  
        default:
        break;      
    }    	

	
}
// -->
    </script>
</asp:Content>
