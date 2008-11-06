<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SelectProduct.aspx.cs" Inherits="Adm_SelectProduct" %>

<%@ Register Assembly="Infragistics2.WebUI.UltraWebGrid.v7.1, Version=7.1.20071.1048, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebGrid" TagPrefix="igtbl" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Select Product</title>
    <link href="../Css/admin.css" rel="stylesheet" type="text/css" />

    <script id="igClientScript" type="text/javascript">
    <!--
    
       
        function onCheck(obj)
        {
            var spanSelect = document.getElementById('spanSelect');
            var n = parseInt(spanSelect.innerHTML,10);
            var spanMax = document.getElementById('spanMax');
            var max = parseInt(spanMax.innerHTML,10);
            if(obj.checked ==  true)
            {
                if(n < max)
                {
                    n=n+1;
                    spanSelect.innerHTML = n.toString();
                    var cell=igtbl_getCellById(obj.parentElement.id);
                    cell.Row.getCellFromKey('Selected').setValue(obj.checked);
                }
                else
                {
                    obj.checked=false;
                    alert('Bạn không thể chọn quá ' + max + ' sản phẩm!'); 
                }
            }
            else
            {
                n=n-1;
                spanSelect.innerHTML = n.toString();
                var cell=igtbl_getCellById(obj.parentElement.id);
                cell.Row.getCellFromKey('Selected').setValue(obj.checked);
            }                                     
        }
        function formOnLoad()
        {
            if(document.form1.chkSelect!=null)
            {
                if(document.form1.chkSelect.length > 1)
                {
                    for (i=0; i<document.form1.chkSelect.length; i++)
                    {
                        if (document.form1.chkSelect[i].value=='true') document.form1.chkSelect[i].checked=true;
                    }
                }
                else
                {
                    if (document.form1.chkSelect.value=='true') document.form1.chkSelect.checked=true;
                }
            }
        }
    // -->
    </script>

</head>
<body onload="formOnLoad();">
    <form id="form1" runat="server">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td style="padding-right: 5px; padding-left: 5px; padding-bottom: 5px; padding-top: 5px">
                    Bạn đã chọn <span id="spanSelect" runat="server" style="color: Red; font-weight: bold;">
                    </span>trong tổng số <span id="spanMax" runat="server" style="color: Red; font-weight: bold;">
                    </span>sản phẩm được phép chọn</td>
            </tr>
            <tr>
                <td>
                    
                </td>
            </tr>
            <tr>
                <td>
                    <igtbl:UltraWebGrid ID="grdProduct" runat="server" Height="490px" Width="100%" OnPageIndexChanged="grdProduct_PageIndexChanged"
                        OnInitializeLayout="grdProduct_InitializeLayout">
                        <Bands>
                            <igtbl:UltraGridBand>
                                <AddNewRow Visible="NotSet" View="NotSet">
                                </AddNewRow>
                                <Columns>
                                    <igtbl:TemplatedColumn AllowUpdate="Yes" DataType="System.Boolean" Key="CheckBox"
                                        Width="30px">
                                        <CellTemplate>
                                            <input id="chkSelect" type="checkbox" name="chkSelect" onclick="onCheck(this);" value="<%#Container.Cell.Row.Cells.FromKey("Selected").Value %>" />
                                        </CellTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <CellStyle HorizontalAlign="Center">
                                        </CellStyle>
                                        <Header Caption="Chọn">
                                        </Header>
                                    </igtbl:TemplatedColumn>
                                    <igtbl:UltraGridColumn BaseColumnName="TenSanPham" Key="TenSanPham" Width="180px">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <Header Caption="T&#234;n sản phẩm">
                                            <RowLayoutColumnInfo OriginX="1" />
                                        </Header>
                                        <Footer>
                                            <RowLayoutColumnInfo OriginX="1" />
                                        </Footer>
                                    </igtbl:UltraGridColumn>
                                    <igtbl:UltraGridColumn BaseColumnName="AnhSanPham" Hidden="True" Key="AnhSanPham">
                                        <Header>
                                            <RowLayoutColumnInfo OriginX="2" />
                                        </Header>
                                        <Footer>
                                            <RowLayoutColumnInfo OriginX="2" />
                                        </Footer>
                                    </igtbl:UltraGridColumn>
                                    <igtbl:TemplatedColumn BaseColumnName="Anh" Key="Anh" Width="110px">
                                        <CellTemplate>
                                            <img alt="" id="imgCell" src=".<%#Container.Cell.Row.Cells.FromKey("AnhSanPham").Value %>"
                                                height="30" width="100" />
                                        </CellTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <CellStyle HorizontalAlign="Center">
                                        </CellStyle>
                                        <Header Caption="Ảnh">
                                            <RowLayoutColumnInfo OriginX="3" />
                                        </Header>
                                        <Footer>
                                            <RowLayoutColumnInfo OriginX="3" />
                                        </Footer>
                                    </igtbl:TemplatedColumn>
                                    <igtbl:UltraGridColumn BaseColumnName="GiaSanPham" Format="#,###" Key="GiaSanPham"
                                        Width="110px">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <CellStyle HorizontalAlign="Right">
                                        </CellStyle>
                                        <Header Caption="Gi&#225;">
                                            <RowLayoutColumnInfo OriginX="4" />
                                        </Header>
                                        <Footer>
                                            <RowLayoutColumnInfo OriginX="4" />
                                        </Footer>
                                    </igtbl:UltraGridColumn>
                                    <igtbl:UltraGridColumn BaseColumnName="DonViTienTe" Key="DonViTienTe" Width="30px">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <Header Caption="$">
                                            <RowLayoutColumnInfo OriginX="5" />
                                        </Header>
                                        <Footer>
                                            <RowLayoutColumnInfo OriginX="5" />
                                        </Footer>
                                    </igtbl:UltraGridColumn>
                                    <igtbl:UltraGridColumn BaseColumnName="TenCuaHang" Key="TenCuaHang" Width="240px">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <Header Caption="Cửa h&#224;ng">
                                            <RowLayoutColumnInfo OriginX="6" />
                                        </Header>
                                        <Footer>
                                            <RowLayoutColumnInfo OriginX="6" />
                                        </Footer>
                                    </igtbl:UltraGridColumn>
                                    <igtbl:UltraGridColumn BaseColumnName="TenNhomSanPham" Key="TenNhomSanPham" Width="160px">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <Header Caption="Danh mục">
                                            <RowLayoutColumnInfo OriginX="7" />
                                        </Header>
                                        <Footer>
                                            <RowLayoutColumnInfo OriginX="7" />
                                        </Footer>
                                    </igtbl:UltraGridColumn>
                                    <igtbl:UltraGridColumn BaseColumnName="MoTaSanPham" Hidden="True" Key="MoTaSanPham"
                                        Width="250px">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <Header Caption="M&#244; tả">
                                            <RowLayoutColumnInfo OriginX="8" />
                                        </Header>
                                        <Footer>
                                            <RowLayoutColumnInfo OriginX="8" />
                                        </Footer>
                                    </igtbl:UltraGridColumn>
                                    <igtbl:UltraGridColumn BaseColumnName="Selected" Case="Lower" Hidden="True" Key="Selected">
                                        <Header Caption="Selected">
                                            <RowLayoutColumnInfo OriginX="9" />
                                        </Header>
                                        <Footer>
                                            <RowLayoutColumnInfo OriginX="9" />
                                        </Footer>
                                    </igtbl:UltraGridColumn>
                                    <igtbl:UltraGridColumn BaseColumnName="SanPhamID" Hidden="True" Key="SanPhamID">
                                        <Header>
                                            <RowLayoutColumnInfo OriginX="10" />
                                        </Header>
                                        <Footer>
                                            <RowLayoutColumnInfo OriginX="10" />
                                        </Footer>
                                    </igtbl:UltraGridColumn>
                                    <igtbl:UltraGridColumn BaseColumnName="ViTriSanPhamID" Hidden="True" Key="ViTriSanPhamID">
                                        <Header Caption="ViTriQuangCaoID">
                                            <RowLayoutColumnInfo OriginX="11" />
                                        </Header>
                                        <Footer>
                                            <RowLayoutColumnInfo OriginX="11" />
                                        </Footer>
                                    </igtbl:UltraGridColumn>
                                    <igtbl:UltraGridColumn BaseColumnName="ViTriSanPham" Hidden="True" Key="ViTriSanPham">
                                        <Header Caption="ViTriQuangCao">
                                            <RowLayoutColumnInfo OriginX="12" />
                                        </Header>
                                        <Footer>
                                            <RowLayoutColumnInfo OriginX="12" />
                                        </Footer>
                                    </igtbl:UltraGridColumn>
                                </Columns>
                            </igtbl:UltraGridBand>
                        </Bands>
                        <DisplayLayout Version="4.00" SelectTypeRowDefault="Single" Name="grdProduct" AllowSortingDefault="OnClient"
                            AllowColSizingDefault="Free" RowHeightDefault="20px" HeaderClickActionDefault="SortMulti"
                            BorderCollapseDefault="Separate" AllowRowNumberingDefault="Continuous" AutoGenerateColumns="False"
                            CellPaddingDefault="1" ScrollBar="Always" ScrollBarView="Vertical" CellClickActionDefault="RowSelect">
                            <FrameStyle BackColor="Window" BorderColor="InactiveCaption" BorderWidth="1px" BorderStyle="Solid"
                                Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="490px" Width="100%">
                            </FrameStyle>
                            <Pager PageSize="12" Pattern="Trang [default]"
                                AllowCustomPaging="True" StyleMode="CustomLabels">
                                <PagerStyle BackColor="LightGray" BorderWidth="1px" BorderStyle="Solid">
                                    <BorderDetails ColorLeft="White" ColorTop="White" WidthLeft="1px" WidthTop="1px"></BorderDetails>
                                </PagerStyle>
                            </Pager>
                            <EditCellStyleDefault BorderWidth="0px" BorderStyle="None">
                            </EditCellStyleDefault>
                            <FooterStyleDefault BackColor="LightGray" BorderWidth="1px" BorderStyle="Solid">
                                <BorderDetails ColorLeft="White" ColorTop="White" WidthLeft="1px" WidthTop="1px"></BorderDetails>
                            </FooterStyleDefault>
                            <HeaderStyleDefault HorizontalAlign="Left" BackColor="LightGray" BorderStyle="Solid">
                                <BorderDetails ColorLeft="White" ColorTop="White" WidthLeft="1px" WidthTop="1px"></BorderDetails>
                            </HeaderStyleDefault>
                            <RowStyleDefault BackColor="Window" BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid"
                                Font-Names="Microsoft Sans Serif" Font-Size="8.25pt">
                                <Padding Left="3px"></Padding>
                                <BorderDetails ColorLeft="Window" ColorTop="Window"></BorderDetails>
                            </RowStyleDefault>
                            <GroupByRowStyleDefault BackColor="Control" BorderColor="Window">
                            </GroupByRowStyleDefault>
                            <GroupByBox>
                                <BoxStyle BackColor="ActiveBorder" BorderColor="Window">
                                </BoxStyle>
                            </GroupByBox>
                            <AddNewBox Hidden="False">
                                <BoxStyle BackColor="Window" BorderColor="InactiveCaption" BorderWidth="1px" BorderStyle="Solid">
                                    <BorderDetails ColorLeft="White" ColorTop="White" WidthLeft="1px" WidthTop="1px"></BorderDetails>
                                </BoxStyle>
                            </AddNewBox>
                            <ActivationObject BorderColor="" BorderWidth="">
                            </ActivationObject>
                            <FilterOptionsDefault AllowRowFiltering="OnServer" AllString="Tất cả" ContainsString="Chứa"
                                DoesNotContainString="Kh&#244;ng chứa" DoesNotEndWithString="Kh&#244;ng kết th&#250;c bằng"
                                DoesNotStartWithString="Kh&#244;ngbắt đầu bằng" EmptyString="(Trống)" EndsWithString="Kết th&#250;c bằng"
                                EqualsString="Bằng" FilterUIType="FilterRow" GreaterThanOrEqualsString="Lớn hơn hoặc bằng"
                                GreaterThanString="Lớn hơn" LessThanOrEqualsString="Nhỏ hơn hoặc bằng" LessThanString="Nhỏ hơn"
                                LikeString="Giống" NonEmptyString="(Kh&#244;ng trống)" NotEqualsString="Kh&#244;ng bằng"
                                NotLikeString="Kh&#244;ng giống" ShowAllCondition="Yes" ShowEmptyCondition="No"
                                StartsWithString="Bắt đầu bởi" FilterComparisonType="CaseInsensitive">
                                <FilterOperandDropDownStyle BackColor="White" BorderColor="Silver" BorderStyle="Solid"
                                    BorderWidth="1px" CustomRules="overflow:auto;" Font-Names="Verdana,Arial,Helvetica,sans-serif"
                                    Font-Size="11px">
                                    <Padding Left="2px" />
                                </FilterOperandDropDownStyle>
                                <FilterHighlightRowStyle BackColor="#151C55" ForeColor="White">
                                </FilterHighlightRowStyle>
                                <FilterDropDownStyle BackColor="White" BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px"
                                    CustomRules="overflow:auto;" Font-Names="Verdana,Arial,Helvetica,sans-serif"
                                    Font-Size="11px" Height="300px" Width="200px">
                                    <Padding Left="2px" />
                                </FilterDropDownStyle>
                                <FilterRowStyle BackColor="#E0E0E0" ForeColor="Black" HorizontalAlign="Left">
                                </FilterRowStyle>
                            </FilterOptionsDefault>
                            <RowSelectorStyleDefault HorizontalAlign="Center">
                            </RowSelectorStyleDefault>
                        </DisplayLayout>
                    </igtbl:UltraWebGrid>
                </td>
            </tr>
            <tr>
                <td style="padding-top: 10px; text-align: center">
                    <table width="100%">
                        <tr>
                            <td style="text-align: right">
                                <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Cập nhật" OnClick="btnSave_Click" />
                                <asp:Button ID="btnSaveAndClose" runat="server" CssClass="button" Text="Cập nhật và đóng"
                                    OnClick="btnSaveAndClose_Click" /></td>
                            <td style="text-align: right">
                                <asp:RadioButton ID="rbtPhanTrang" runat="server" AutoPostBack="True" Checked="True"
                                    GroupName="pager" Text="Hiện theo trang" OnCheckedChanged="rbtPhanTrang_CheckedChanged" />
                                <asp:RadioButton ID="rbtTatCa" runat="server" AutoPostBack="True" GroupName="pager"
                                    Text="Hiện tất cả" OnCheckedChanged="rbtTatCa_CheckedChanged" /></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
