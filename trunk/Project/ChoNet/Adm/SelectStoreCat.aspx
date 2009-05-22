<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SelectStoreCat.aspx.cs" Inherits="Adm_SelectStoreCat" %>
<%@ Register Assembly="Infragistics2.WebUI.UltraWebGrid.v7.1, Version=7.1.20071.1048, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebGrid" TagPrefix="igtbl" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Chọn danh mục</title>
    <link href="../Css/admin.css" rel="stylesheet" type="text/css" /> 
    <script id="igClientScript" type="text/javascript">
    <!--
        function onCheck(obj)
        {
            var cell=igtbl_getCellById(obj.parentElement.id);
            cell.Row.getCellFromKey('Selected').setValue(obj.checked);                                   
        }   
                 
    // -->
    
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">            
            <tr>
                <td style="width: 977px">
                    <igtbl:ultrawebgrid id="grdCat" runat="server" height="330px" width="100%" DataKeyField="NhomSanPhamID"><Bands>
                        <igtbl:UltraGridBand DataKeyField="NhomSanPhamID">
                            <Columns>
                                <igtbl:TemplatedColumn AllowUpdate="Yes" DataType="System.Boolean" Key="CheckBox"
                                    Width="30px">
                                    <CellTemplate>
                <input id="chkSelect" type="checkbox" name="chkSelect" onclick="onCheck(this);" />
                                    </CellTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <CellStyle HorizontalAlign="Center">
                                    </CellStyle>
                                    <Header Caption="Chọn">
                                    </Header>
                                </igtbl:TemplatedColumn>
                                <igtbl:UltraGridColumn BaseColumnName="TenNhomSanPham" Key="TenNhomSanPham" Width="200px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="Danh mục">
                                        <RowLayoutColumnInfo OriginX="1" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="1" />
                                    </Footer>
                                </igtbl:UltraGridColumn>
                                <igtbl:UltraGridColumn BaseColumnName="TenNhomSanPhamHienThi" Key="TenNhomSanPhamHienThi"
                                    Width="405px">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <Header Caption="T&#234;n hiển thị ở gian h&#224;ng">
                                        <RowLayoutColumnInfo OriginX="2" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="2" />
                                    </Footer>
                                </igtbl:UltraGridColumn>
                                <igtbl:UltraGridColumn Case="Lower" DataType="System.Boolean" Key="Selected" Width="50px">
                                    <Header Caption="Selected">
                                        <RowLayoutColumnInfo OriginX="3" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="3" />
                                    </Footer>
                                </igtbl:UltraGridColumn>
                                <igtbl:UltraGridColumn BaseColumnName="NhomSanPhamID" Hidden="True" Key="NhomSanPhamID">
                                    <Header>
                                        <RowLayoutColumnInfo OriginX="4" />
                                    </Header>
                                    <Footer>
                                        <RowLayoutColumnInfo OriginX="4" />
                                    </Footer>
                                </igtbl:UltraGridColumn>
                            </Columns>
                            <RowEditTemplate>
                                <br />
                                <p align="center">
                                    <input id="igtbl_reOkBtn" onclick="igtbl_gRowEditButtonClick(event);" style="width: 50px"
                                        type="button" value="OK" />&nbsp;
                                    <input id="igtbl_reCancelBtn" onclick="igtbl_gRowEditButtonClick(event);" style="width: 50px"
                                        type="button" value="Cancel" /></p>
                            </RowEditTemplate>
                            <AddNewRow View="NotSet" Visible="NotSet">
                            </AddNewRow>
                        </igtbl:UltraGridBand>
</Bands>

<DisplayLayout Version="4.00" SelectTypeRowDefault="Single" Name="grdCat" AllowSortingDefault="OnClient" AllowColSizingDefault="Free" RowHeightDefault="20px" HeaderClickActionDefault="SortMulti" BorderCollapseDefault="Separate" AllowRowNumberingDefault="Continuous" AutoGenerateColumns="False" CellPaddingDefault="2" ScrollBar="Always" ScrollBarView="Vertical" CellClickActionDefault="RowSelect" TableLayout="Fixed">
<FrameStyle BackColor="Window" BorderColor="InactiveCaption" BorderWidth="1px" BorderStyle="Solid" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="330px" Width="100%"></FrameStyle>

<Pager MinimumPagesForDisplay="2">
<PagerStyle BackColor="LightGray" BorderWidth="1px" BorderStyle="Solid">
<BorderDetails ColorLeft="White" ColorTop="White" WidthLeft="1px" WidthTop="1px"></BorderDetails>
</PagerStyle>
</Pager>

<EditCellStyleDefault BorderWidth="0px" BorderStyle="None"></EditCellStyleDefault>

<FooterStyleDefault BackColor="LightGray" BorderWidth="1px" BorderStyle="Solid">
<BorderDetails ColorLeft="White" ColorTop="White" WidthLeft="1px" WidthTop="1px"></BorderDetails>
</FooterStyleDefault>

<HeaderStyleDefault HorizontalAlign="Left" BackColor="LightGray" BorderStyle="Solid">
<BorderDetails ColorLeft="White" ColorTop="White" WidthLeft="1px" WidthTop="1px"></BorderDetails>
</HeaderStyleDefault>

<RowStyleDefault BackColor="Window" BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt">
<Padding Left="3px"></Padding>

<BorderDetails ColorLeft="Window" ColorTop="Window"></BorderDetails>
</RowStyleDefault>

<GroupByRowStyleDefault BackColor="Control" BorderColor="Window"></GroupByRowStyleDefault>

<GroupByBox>
<BoxStyle BackColor="ActiveBorder" BorderColor="Window"></BoxStyle>
</GroupByBox>

<AddNewBox Hidden="False">
<BoxStyle BackColor="Window" BorderColor="InactiveCaption" BorderWidth="1px" BorderStyle="Solid">
<BorderDetails ColorLeft="White" ColorTop="White" WidthLeft="1px" WidthTop="1px"></BorderDetails>
</BoxStyle>
</AddNewBox>

<ActivationObject BorderColor="" BorderWidth=""></ActivationObject>

<FilterOptionsDefault>
<FilterDropDownStyle CustomRules="overflow:auto;" BackColor="White" BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid" Font-Names="Verdana,Arial,Helvetica,sans-serif" Font-Size="11px" Height="300px" Width="200px">
<Padding Left="2px"></Padding>
</FilterDropDownStyle>

<FilterHighlightRowStyle BackColor="#151C55" ForeColor="White"></FilterHighlightRowStyle>

<FilterOperandDropDownStyle CustomRules="overflow:auto;" BackColor="White" BorderColor="Silver" BorderWidth="1px" BorderStyle="Solid" Font-Names="Verdana,Arial,Helvetica,sans-serif" Font-Size="11px">
<Padding Left="2px"></Padding>
</FilterOperandDropDownStyle>
</FilterOptionsDefault>
    <RowSelectorStyleDefault HorizontalAlign="Center">
    </RowSelectorStyleDefault>
</DisplayLayout>
</igtbl:ultrawebgrid>
                    </td>
            </tr>
            <tr>
                <td style="padding-top: 10px; text-align: center; width: 977px;">
                    <asp:Button ID="btnSave" runat="server" CssClass="short-button" Text="Cập nhật" OnClick="btnSave_Click" /></td>
            </tr>
        </table>
    </form>
</body>
</html>
