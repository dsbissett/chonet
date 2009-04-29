<%@ Page Language="C#" AutoEventWireup="true" CodeFile="~/Adm/SelectProd.aspx.cs"
    Inherits="Admin_SelectProd" Title="Chọn Sản phẩm" %>

<%@ Register Assembly="Infragistics2.WebUI.WebDateChooser.v7.1, Version=7.1.20071.1048, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.WebSchedule" TagPrefix="igsch" %>
<%@ Register Assembly="Infragistics2.WebUI.Misc.v7.1, Version=7.1.20071.1048, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.Misc" TagPrefix="igmisc" %>
<%@ Register Assembly="Infragistics2.WebUI.UltraWebGrid.v7.1, Version=7.1.20071.1048, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebGrid" TagPrefix="igtbl" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Select Product</title>
    <link href="../Css/admin.css" rel="stylesheet" type="text/css" />    
    <script src="../Scripts/dialog.js" type="text/javascript"></script> 
    <script src="../Scripts/Common.js" type="text/javascript"></script> 
    <script src="../Scripts/WebForm.js" type="text/javascript"></script> 
    <script src="../Scripts/WebUIValidation.js" type="text/javascript"></script> 
    <script src="../Scripts/Common.js" type="text/javascript"></script> 
    <script id="igClientScript" type="text/javascript">
<!--

 function CloseSelect(id)
{
    hidAdd = document.getElementById('<%=hidAdd.ClientID %>');                             
    hidAdd.value = 'false';
    window.parent.RefreshProduct(id);
}
        
function CloseSelect(id, cid)
{
    hidAdd = document.getElementById('<%=hidAdd.ClientID %>');                             
    hidAdd.value = 'false';
    window.parent.RefreshProduct04(cid);
}
function ddl_onchange(i)
{    
     var warp = ig$('<%=pnlSanPham.ClientID%>');
     var hid = document.getElementById('<%=hiddropdown.ClientID %>');
     hid.value=i;	   
    //alert(warp);
    if(!warp)
		return;		
	warp.refresh();	
    
}

function Add(){ 
        hidAdd = document.getElementById('<%=hidAdd.ClientID %>');                             
        hidAdd.value = 'true';
        Refresh();
}


function Delete(obj){  
        hidAdd = document.getElementById('<%=hidAdd.ClientID %>');                             
        hidAdd.value = 'false';                            
        var cell=igtbl_getCellById(obj.parentElement.id);
        var id=cell.Row.getCellFromKey('ViTriSanPhamID').getValue();
        OpenDialogWindow('Xóa vị trí sản phẩm',350,170,'page','Delete.aspx?id=' + id + '&type=vitrisanpham');    
}

function Refresh()
{  	
    var warp = ig$('<%=pnlSanPham.ClientID%>');	   
    //alert(warp);
    if(!warp)
		return;		
	warp.refresh();	
}

function WebAsyncRefreshPanel1_RefreshComplete(oPanel)
{
	CloseDialogWindow();
}

function onCheck(obj)
        {
            var spanSelect = document.getElementById('<%=spanSelect.ClientID %>');
            var n = parseInt(spanSelect.innerHTML,10);
            var spanMax = document.getElementById('<%=spanMax.ClientID%>');
            var max = parseInt(spanMax.innerHTML,10);
            //alert('a');
            if(obj.checked ==  true)
            {
                if(n < max)
                {
                    n=n+1;
                    spanSelect.innerHTML = n.toString();
                    var cell=igtbl_getCellById(obj.parentElement.id);
                    cell.Row.getCellFromKey('Selected').setValue(obj.checked);
                    //alert(cell.Row.getCellFromKey('SanPhamID').Text)
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
// -->
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td>
                <div id="divDialog" class="divDialog">
            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                <tr class="dialogTitleBar" id="trDialogTitleBar">
                    <td id="tdDialogTitle" class="dialogTitle"></td>
                    <td style="width:20%; text-align:right; padding-right:2px;">
                        <img id="imgClose" alt="Close" src="../Images/close.jpg" style="border:none; cursor:hand" 
                        onclick="CloseDialogWindow();" onmouseover="CloseButtonOnMouseOver(this);"
                        onmouseout="CloseButtonOnMouseOut(this);" /></td>
                </tr>
                 <tr>
                    <td colspan="2" id="tdDialogContent" class="dialogContent">&nbsp;</td>
                </tr>
            </table>        
        </div>
                    <div>
                        <igmisc:WebAsyncRefreshPanel ID="pnlSanPham" runat="server" Height="100%" Width="100%"
                            RefreshComplete="WebAsyncRefreshPanel1_RefreshComplete" OnContentRefresh="pnlSanPham_ContentRefresh">
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td style="width: 60%">
                                        <igmisc:WebAsyncRefreshPanel ID="pnlAllSanPham" runat="server" Height="100%" Width="100%"
                                            OnContentRefresh="pnlAllSanPham_ContentRefresh">
                                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                <tr>
                                                    <td>
                                                        Danh mục cấp 1</td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlDanhMuc1" runat="server" Width="177px">
                                                        </asp:DropDownList></td>
                                                    <td>
                                                        Danh mục cấp 2</td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlDanhMuc2" runat="server" Width="177px">
                                                        </asp:DropDownList></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Hãng sản xuất</td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlHangSanXuat" runat="server" Width="177px">
                                                        </asp:DropDownList></td>
                                                    <td>
                                                        Khu vực</td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlKhuVuc" runat="server" Width="177px">
                                                        </asp:DropDownList></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Danh mục cấp 3</td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlDanhMucCap3" runat="server" Width="200px">
                                                        </asp:DropDownList></td>
                                                    
                                                    <td>Tên sản phẩm
                                                    </td>
                                                    <td><asp:TextBox ID="txtTenSanPham" runat="server" Width="194px"></asp:TextBox></td>
                                                
                                                    
                                                </tr>
                                                <tr>
                                                    <td><input id="hiddropdown" runat="server" type="hidden" value="0" />
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="btnSearch" runat="server" CssClass="button" Text="Tìm kiếm" Width="84px"
                                                            UseSubmitBehavior="false" /></td>
                                                    <td>
                                                        </td>
                                                    <td>
                                                        </tr>
                                            </table>
                                            <igtbl:UltraWebGrid ID="grdProduct" runat="server" Height="450px" OnPageIndexChanged="grdProduct_PageIndexChanged"
                                                Width="100%">
                                                <Bands>
                                                    <igtbl:UltraGridBand>
                                                        <AddNewRow View="NotSet" Visible="NotSet">
                                                        </AddNewRow>
                                                        <Columns>
                                                            <igtbl:TemplatedColumn AllowUpdate="Yes" DataType="System.Boolean" Key="CheckBox"
                                                                Width="30px">
                                                                <CellTemplate>
                                                                    <input id="chkSelect" name="chkSelect" onclick="onCheck(this);" type="checkbox" value='<%#Container.Cell.Row.Cells.FromKey("Selected").Value %>' />
                                                                </CellTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <CellStyle HorizontalAlign="Center">
                                                                </CellStyle>
                                                                <Header Caption="Chọn">
                                                                </Header>
                                                            </igtbl:TemplatedColumn>
                                                            <igtbl:UltraGridColumn BaseColumnName="TenSanPham" Key="TenSanPham" Width="30%">
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
                                                            <igtbl:TemplatedColumn BaseColumnName="Anh" Key="Anh" Width="15%">
                                                                <CellTemplate>
                                                                    <img id="imgCell" alt="" height="30" src='.<%#Container.Cell.Row.Cells.FromKey("AnhSanPham").Value %>'
                                                                        width="100" />
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
                                                                Width="10%">
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
                                                            <igtbl:UltraGridColumn BaseColumnName="DonViTienTe" Key="DonViTienTe" Width="20px">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <Header Caption="$">
                                                                    <RowLayoutColumnInfo OriginX="5" />
                                                                </Header>
                                                                <Footer>
                                                                    <RowLayoutColumnInfo OriginX="5" />
                                                                </Footer>
                                                            </igtbl:UltraGridColumn>
                                                            <igtbl:UltraGridColumn BaseColumnName="TenCuaHang" Key="TenCuaHang" Width="240px"
                                                                Hidden="True">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <Header Caption="Cửa h&#224;ng">
                                                                    <RowLayoutColumnInfo OriginX="6" />
                                                                </Header>
                                                                <Footer>
                                                                    <RowLayoutColumnInfo OriginX="6" />
                                                                </Footer>
                                                            </igtbl:UltraGridColumn>
                                                            <igtbl:UltraGridColumn BaseColumnName="TenNhomSanPham" Key="TenNhomSanPham" Width="20%">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <Header Caption="Danh mục">
                                                                    <RowLayoutColumnInfo OriginX="7" />
                                                                </Header>
                                                                <Footer>
                                                                    <RowLayoutColumnInfo OriginX="7" />
                                                                </Footer>
                                                            </igtbl:UltraGridColumn>
                                                            <igtbl:UltraGridColumn BaseColumnName="MoTaSanPham" Hidden="True" Key="MoTaSanPham">
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
                                                <DisplayLayout AllowColSizingDefault="Free" AllowRowNumberingDefault="Continuous"
                                                    AllowSortingDefault="OnClient" AutoGenerateColumns="False" BorderCollapseDefault="Separate"
                                                    CellClickActionDefault="RowSelect" CellPaddingDefault="1" HeaderClickActionDefault="SortMulti"
                                                    Name="grdProduct" RowHeightDefault="20px" ScrollBar="Always" ScrollBarView="Vertical"
                                                    SelectTypeRowDefault="Single" Version="4.00">
                                                    <FrameStyle BackColor="Window" BorderColor="InactiveCaption" BorderStyle="Solid"
                                                        BorderWidth="1px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Height="450px"
                                                        Width="100%">
                                                    </FrameStyle>
                                                    <Pager AllowCustomPaging="True" AllowPaging="True" PageSize="10" Pattern="Trang [default]"
                                                        StyleMode="QuickPages" QuickPages="10">
                                                        <PagerStyle BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                                            <BorderDetails ColorLeft="White" ColorTop="White" WidthLeft="1px" WidthTop="1px" />
                                                        </PagerStyle>
                                                    </Pager>
                                                    <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                                                    </EditCellStyleDefault>
                                                    <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                                        <BorderDetails ColorLeft="White" ColorTop="White" WidthLeft="1px" WidthTop="1px" />
                                                    </FooterStyleDefault>
                                                    <HeaderStyleDefault BackColor="LightGray" BorderStyle="Solid" HorizontalAlign="Left">
                                                        <BorderDetails ColorLeft="White" ColorTop="White" WidthLeft="1px" WidthTop="1px" />
                                                    </HeaderStyleDefault>
                                                    <RowStyleDefault BackColor="Window" BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px"
                                                        Font-Names="Microsoft Sans Serif" Font-Size="8.25pt">
                                                        <Padding Left="3px" />
                                                        <BorderDetails ColorLeft="Window" ColorTop="Window" />
                                                    </RowStyleDefault>
                                                    <GroupByRowStyleDefault BackColor="Control" BorderColor="Window">
                                                    </GroupByRowStyleDefault>
                                                    <GroupByBox>
                                                        <BoxStyle BackColor="ActiveBorder" BorderColor="Window">
                                                        </BoxStyle>
                                                    </GroupByBox>
                                                    <AddNewBox Hidden="False">
                                                        <BoxStyle BackColor="Window" BorderColor="InactiveCaption" BorderStyle="Solid" BorderWidth="1px">
                                                            <BorderDetails ColorLeft="White" ColorTop="White" WidthLeft="1px" WidthTop="1px" />
                                                        </BoxStyle>
                                                    </AddNewBox>
                                                    <ActivationObject BorderColor="" BorderWidth="">
                                                    </ActivationObject>
                                                    <FilterOptionsDefault AllowRowFiltering="OnServer" AllString="Tất cả" ContainsString="Chứa"
                                                        DoesNotContainString="Kh&#244;ng chứa" DoesNotEndWithString="Kh&#244;ng kết th&#250;c bằng"
                                                        DoesNotStartWithString="Kh&#244;ngbắt đầu bằng" EmptyString="(Trống)" EndsWithString="Kết th&#250;c bằng"
                                                        EqualsString="Bằng" FilterComparisonType="CaseInsensitive" FilterUIType="FilterRow"
                                                        GreaterThanOrEqualsString="Lớn hơn hoặc bằng" GreaterThanString="Lớn hơn" LessThanOrEqualsString="Nhỏ hơn hoặc bằng"
                                                        LessThanString="Nhỏ hơn" LikeString="Giống" NonEmptyString="(Kh&#244;ng trống)"
                                                        NotEqualsString="Kh&#244;ng bằng" NotLikeString="Kh&#244;ng giống" ShowAllCondition="Yes"
                                                        ShowEmptyCondition="No" StartsWithString="Bắt đầu bởi">
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
                                        </igmisc:WebAsyncRefreshPanel>
                                    </td>
                                    <td>
                                        <input runat="server" id="hidAdd" value="false" type="hidden" style="width: 49px" /><br />
                                        <input id="btnAdd" class="short-button" type="button" value="Thêm" onclick="Add();"
                                            runat="server" style="width: 67px" /></td>
                                    <td style="width: 35%" valign="top">
                                        Bạn đã chọn <span id="spanSelect" runat="server" style="color: Red; font-weight: bold;">
                                        </span>trong tổng số <span id="spanMax" runat="server" style="color: Red; font-weight: bold;">
                                        </span>sản phẩm được phép chọn
                                        <br />
                                        <br />
                                        <br />
                                        <br />
                                        <br />
                                        <igtbl:UltraWebGrid ID="grdSanPham" runat="server" Width="100%" DataKeyField="SanPhamID"
                                            Height="450px">
                                            <Bands>
                                                <igtbl:UltraGridBand DataKeyField="SanPhamID">
                                                    <AddNewRow View="NotSet" Visible="NotSet">
                                                    </AddNewRow>
                                                    <Columns>
                                                        <igtbl:TemplatedColumn Key="Command" SortIndicator="Disabled" Width="8%">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <CellTemplate>
                                                                <a href="#delete" onclick="Delete(this);">Xóa</a>
                                                            </CellTemplate>
                                                            <Header Caption="">
                                                            </Header>
                                                            <CellStyle Cursor="Hand" HorizontalAlign="Center">
                                                            </CellStyle>
                                                        </igtbl:TemplatedColumn>
                                                        <igtbl:UltraGridColumn BaseColumnName="SanPhamID" DataType="System.Int32" Hidden="True"
                                                            Key="SanPhamID">
                                                            <Header>
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Header>
                                                            <Footer>
                                                                <RowLayoutColumnInfo OriginX="1" />
                                                            </Footer>
                                                        </igtbl:UltraGridColumn>
                                                        <igtbl:UltraGridColumn BaseColumnName="TenSanPham" Key="TenSanPham" Width="40%">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <Header Caption="Sản phẩm">
                                                                <RowLayoutColumnInfo OriginX="2" />
                                                            </Header>
                                                            <Footer>
                                                                <RowLayoutColumnInfo OriginX="2" />
                                                            </Footer>
                                                        </igtbl:UltraGridColumn>
                                                        <igtbl:UltraGridColumn BaseColumnName="NhomSanPhamID" Hidden="True" Key="NhomSanPhamID">
                                                            <Header>
                                                                <RowLayoutColumnInfo OriginX="3" />
                                                            </Header>
                                                            <Footer>
                                                                <RowLayoutColumnInfo OriginX="3" />
                                                            </Footer>
                                                        </igtbl:UltraGridColumn>
                                                        <igtbl:UltraGridColumn BaseColumnName="AnhSanPham" Hidden="True" Key="AnhSanPham">
                                                            <Header>
                                                                <RowLayoutColumnInfo OriginX="4" />
                                                            </Header>
                                                            <Footer>
                                                                <RowLayoutColumnInfo OriginX="4" />
                                                            </Footer>
                                                        </igtbl:UltraGridColumn>
                                                        <igtbl:TemplatedColumn Width="25%">
                                                            <CellTemplate>
                                                                <img alt="" id="imgCell" height="40" src=".<%#Container.Cell.Row.Cells.FromKey("AnhSanPham").Value %>"
                                                                    width="80" />
                                                            </CellTemplate>
                                                            <Header Caption="Ảnh">
                                                                <RowLayoutColumnInfo OriginX="5" />
                                                            </Header>
                                                            <Footer>
                                                                <RowLayoutColumnInfo OriginX="5" />
                                                            </Footer>
                                                        </igtbl:TemplatedColumn>
                                                        <igtbl:UltraGridColumn BaseColumnName="ViTriSanPhamID" DataType="System.UInt32" Hidden="false" Width='20%'
                                                            Key="ViTriSanPhamID">
                                                            <Header>
                                                                <RowLayoutColumnInfo OriginX="6" />
                                                            </Header>
                                                            <Footer>
                                                                <RowLayoutColumnInfo OriginX="6" />
                                                            </Footer>
                                                        </igtbl:UltraGridColumn>
                                                    </Columns>
                                                </igtbl:UltraGridBand>
                                            </Bands>
                                            <DisplayLayout AllowColSizingDefault="Free" AllowColumnMovingDefault="OnServer" AutoGenerateColumns="False"
                                                BorderCollapseDefault="Separate" CellClickActionDefault="RowSelect" ColWidthDefault=""
                                                HeaderClickActionDefault="SortMulti" Name="grdSanPham" RowHeightDefault="20px"
                                                ScrollBarView="Vertical" Version="4.00" AllowRowNumberingDefault="Continuous"
                                                CellPaddingDefault="2">
                                                <GroupByBox Hidden="True">
                                                    <BoxStyle BackColor="ActiveBorder" BorderColor="Window">
                                                    </BoxStyle>
                                                </GroupByBox>
                                                <GroupByRowStyleDefault BackColor="Control" BorderColor="Window">
                                                </GroupByRowStyleDefault>
                                                <ActivationObject BorderColor="White" BorderWidth="1px">
                                                    <BorderDetails ColorBottom="Silver" ColorRight="Silver" />
                                                </ActivationObject>
                                                <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                                                    <BorderDetails ColorLeft="White" ColorTop="White" WidthLeft="1px" WidthTop="1px" />
                                                </FooterStyleDefault>
                                                <RowStyleDefault BackColor="Window" BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px"
                                                    Font-Names="Microsoft Sans Serif" Font-Size="8.25pt">
                                                    <BorderDetails ColorLeft="Window" ColorTop="Window" />
                                                    <Padding Left="3px" />
                                                </RowStyleDefault>
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
                                                    <FilterRowStyle BackColor="#E0E0E0" ForeColor="Black" HorizontalAlign="Left">
                                                    </FilterRowStyle>
                                                    <FilterDropDownStyle BackColor="White" BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px"
                                                        CustomRules="overflow:auto;" Font-Names="Verdana,Arial,Helvetica,sans-serif"
                                                        Font-Size="11px" Height="300px" Width="200px">
                                                        <Padding Left="2px" />
                                                    </FilterDropDownStyle>
                                                </FilterOptionsDefault>
                                                <SelectedRowStyleDefault ForeColor="Blue">
                                                </SelectedRowStyleDefault>
                                                <HeaderStyleDefault BackColor="LightGray" BorderStyle="Solid" HorizontalAlign="Center">
                                                    <BorderDetails ColorLeft="White" ColorTop="White" WidthLeft="1px" WidthTop="1px" />
                                                </HeaderStyleDefault>
                                                <RowAlternateStyleDefault BackColor="#FAFAFA">
                                                </RowAlternateStyleDefault>
                                                <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                                                </EditCellStyleDefault>
                                                <FrameStyle BackColor="Window" BorderColor="InactiveCaption" BorderStyle="Solid"
                                                    BorderWidth="1px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Width="100%"
                                                    Height="450px">
                                                </FrameStyle>
                                                <Pager PageSize="10" Pattern="Trang [default]" AllowCustomPaging="True" StyleMode="CustomLabels">
                                                    <PagerStyle BackColor="LightGray" BorderWidth="1px" BorderStyle="Solid">
                                                        <BorderDetails ColorLeft="White" ColorTop="White" WidthLeft="1px" WidthTop="1px" />
                                                    </PagerStyle>
                                                </Pager>
                                                <AddNewBox>
                                                    <BoxStyle BackColor="Window" BorderColor="InactiveCaption" BorderStyle="Solid" BorderWidth="1px">
                                                        <BorderDetails ColorLeft="White" ColorTop="White" WidthLeft="1px" WidthTop="1px" />
                                                    </BoxStyle>
                                                </AddNewBox>
                                            </DisplayLayout>
                                        </igtbl:UltraWebGrid>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3" style="padding-top: 10px">
                                        <table width="100%">
                                            <tr>
                                                <td>
                                                    <asp:Button ID="btnDong" UseSubmitBehavior="false" runat="server" CssClass="button" Text="Đóng" Width="87px" />
                                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                                                </td>
                                                <td style="text-align: right">
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </igmisc:WebAsyncRefreshPanel>
                    </div>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
