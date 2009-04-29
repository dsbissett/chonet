<%@ Page Language="C#" MasterPageFile="~/Adm/Admin.master" AutoEventWireup="true" CodeFile="~/Adm/ExpiredProductAdmin.aspx.cs" Inherits="AdminExpired_Product" Title="Sản phẩm quá hạn"%>

<%@ Register Assembly="Infragistics2.WebUI.Misc.v7.1, Version=7.1.20071.1048, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.Misc" TagPrefix="igmisc" %>
<%@ Register Assembly="Infragistics2.WebUI.UltraWebGrid.v7.1, Version=7.1.20071.1048, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebGrid" TagPrefix="igtbl" %>
<asp:Content runat="server" ID="content1" ContentPlaceHolderID="cphAdmin">

    <script id="igClientScript" type="text/javascript">
<!--

function ddlGianHang_onchange()
{    
     var warp = ig$('<%=pnlSanPham.ClientID%>');	   
    //alert(warp);
    if(!warp)
		return;		
	warp.refresh();	
    
}
//function SetTitle(title)
//{
//    var tdDialogTitle = document.getElementById('tdDialogTitle'); 
//    //alert(tdDialogTitle.innerText);
//    if(tdDialogTitle != null) tdDialogTitle.innerText = title; 
//}

//function AddFromTemplate()
//{
//    OpenDialogWindow('Chọn sản phẩm mẫu',760,725,'page','SelectTemplate.aspx'); 
//}

//function Add(){                              
//        OpenDialogWindow('Thêm sản phẩm',760,725,'page','AddProduct.aspx');    
//}

//function Edit(obj){   
//        var cell=igtbl_getCellById(obj.parentElement.id);
//        var id=cell.Row.getCellFromKey('SanPhamID').getValue();                   
//        OpenDialogWindow('Sửa thông tin sản phẩm',760,725,'page','AddProduct.aspx?id=' + id);// + '&rand=' + rand_no);    
//}

function Delete(obj){               
        var hid = document.getElementById('<%=hidAction.ClientID %>');
        var cell=igtbl_getCellById(obj.parentElement.id);
        var id=cell.Row.getCellFromKey('SanPhamID').getValue();
        hid.value='delete';
        OpenDialogWindow('Xóa sản phẩm',350,170,'page','Delete.aspx?id=' + id + '&type=sanpham');    
}
function Extend(obj)
{
    var hid = document.getElementById('<%=hidAction.ClientID %>');
    var hidid = document.getElementById('<%=hidID.ClientID %>');
    var cell=igtbl_getCellById(obj.parentElement.id);
    hidid.value = cell.Row.getCellFromKey('SanPhamID').getValue();
    //alert(hidid.value);
    hid.value = 'extend';
    Refresh();
}
function ExtendList()
{
    var hid = document.getElementById('<%=hidAction.ClientID %>');
    hid.value = 'extendlist';
    Refresh();
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

function CheckAll(obj)
{
    if(document.aspnetForm.chkSelect!=null)
    {
        if(document.aspnetForm.chkSelect.length > 1)
        {
            for (i=0; i<document.aspnetForm.chkSelect.length; i++)
            {
                document.aspnetForm.chkSelect[i].checked = obj.checked; 
                var cell=igtbl_getCellById(document.aspnetForm.chkSelect[i].parentElement.id);
                if (cell != null)
                {                
                    cell.Row.getCellFromKey('Selected').setValue(obj.checked);                                            
                }
            }
        }        
    }
}

function chkSelect_onclick(obj)
{
    var cell=igtbl_getCellById(obj.parentElement.id);    
    cell.Row.getCellFromKey('Selected').setValue(obj.checked);
}

// -->
    </script>
<table border="0" cellpadding="0" cellspacing="0" width="100%"><tr><td>
    <igmisc:WebAsyncRefreshPanel ID="pnlSanPham" runat="server" Height="100%" Width="100%"
        RefreshComplete="WebAsyncRefreshPanel1_RefreshComplete" OnContentRefresh="pnlSanPham_ContentRefresh">
        <asp:DropDownList ID="ddlGianHang"   runat="server">
        </asp:DropDownList>
        <igtbl:UltraWebGrid ID="grdSanPham" runat="server" Width="100%" DataKeyField="SanPhamID">
            <Bands>
                <igtbl:UltraGridBand DataKeyField="SanPhamID">
                    <Columns>
                        <igtbl:TemplatedColumn Width="5%">
                            <CellTemplate>
                                <input id="chkSelect" type="checkbox" onclick="chkSelect_onclick(this);" />
                            </CellTemplate>
                            <HeaderTemplate>
                                <input id="Checkbox2" type="checkbox" onclick="CheckAll(this);" />
                            </HeaderTemplate>
                            <CellStyle HorizontalAlign="Center">
                            </CellStyle>
                        </igtbl:TemplatedColumn>
                        <igtbl:TemplatedColumn Key="Command" SortIndicator="Disabled" Width="8%">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellTemplate>
                                <a href="#extend" onclick="Extend(this);" >Gia hạn</a> <a href="#delete" onclick="Delete(this);">
                                    Xóa</a>
                            </CellTemplate>
                            <Header Caption="">
                                <RowLayoutColumnInfo OriginX="1" />
                            </Header>
                            <CellStyle Cursor="Hand" HorizontalAlign="Center">
                            </CellStyle>
                            <Footer>
                                <RowLayoutColumnInfo OriginX="1" />
                            </Footer>
                        </igtbl:TemplatedColumn>
                        <igtbl:UltraGridColumn BaseColumnName="TenSanPham" CellMultiline="Yes" Key="TenSanPham"
                            Width="10%">
                            <HeaderStyle HorizontalAlign="Center" />
                            <Header Caption="Sản phẩm">
                                <RowLayoutColumnInfo OriginX="2" />
                            </Header>
                            <Footer>
                                <RowLayoutColumnInfo OriginX="2" />
                            </Footer>
                            <CellStyle Wrap="True">
                            </CellStyle>
                        </igtbl:UltraGridColumn>
                        <igtbl:UltraGridColumn BaseColumnName="GiaSanPham" DataType="System.Decimal" Format="###,###,##0"
                            Key="GiaSanPham" Width="10%">
                            <HeaderStyle HorizontalAlign="Center" />
                            <Header Caption="Gi&#225;">
                                <RowLayoutColumnInfo OriginX="3" />
                            </Header>
                            <Footer>
                                <RowLayoutColumnInfo OriginX="3" />
                            </Footer>
                        </igtbl:UltraGridColumn>
                        <igtbl:UltraGridColumn BaseColumnName="TenNhomSanPham" Key="TenNhomSanPham" Width="13%">
                            <HeaderStyle HorizontalAlign="Center" />
                            <Header Caption="Nh&#243;m ">
                                <RowLayoutColumnInfo OriginX="4" />
                            </Header>
                            <Footer>
                                <RowLayoutColumnInfo OriginX="4" />
                            </Footer>
                        </igtbl:UltraGridColumn>
                        <igtbl:UltraGridColumn BaseColumnName="TenCuaHang" CellMultiline="Yes" Key="TenCuaHang"
                            Width="14%">
                            <Header Caption="Cửa h&#224;ng">
                                <RowLayoutColumnInfo OriginX="5" />
                            </Header>
                            <Footer>
                                <RowLayoutColumnInfo OriginX="5" />
                            </Footer>
                            <CellStyle TextOverflow="Ellipsis" Wrap="True">
                            </CellStyle>
                        </igtbl:UltraGridColumn>
                        <igtbl:UltraGridColumn BaseColumnName="TenHangSanXuat" Key="TenHangSanXuat" Width="10%">
                            <HeaderStyle HorizontalAlign="Center" />
                            <Header Caption="H&#227;ng sản xuất">
                                <RowLayoutColumnInfo OriginX="6" />
                            </Header>
                            <Footer>
                                <RowLayoutColumnInfo OriginX="6" />
                            </Footer>
                        </igtbl:UltraGridColumn>
                        <igtbl:UltraGridColumn BaseColumnName="TenKhuVuc" Key="TenKhuVuc" Width="10%">
                            <HeaderStyle HorizontalAlign="Center" />
                            <Header Caption="KhuVuc">
                                <RowLayoutColumnInfo OriginX="7" />
                            </Header>
                            <Footer>
                                <RowLayoutColumnInfo OriginX="7" />
                            </Footer>
                        </igtbl:UltraGridColumn>
                        <igtbl:UltraGridColumn BaseColumnName="dates" Key="dates" Width="10%">
                            <HeaderStyle HorizontalAlign="Center" />
                            <Header Caption="Số ng&#224;y">
                                <RowLayoutColumnInfo OriginX="8" />
                            </Header>
                            <Footer>
                                <RowLayoutColumnInfo OriginX="8" />
                            </Footer>
                        </igtbl:UltraGridColumn>
                        <igtbl:TemplatedColumn Width="10%">
                            <CellTemplate>
                                <img alt="" id="imgCell" height="40" 
                                src=".<%#Container.Cell.Row.Cells.FromKey("AnhSanPham").Value %>" width="80" />
                            </CellTemplate>
                            <Header Caption="Ảnh">
                                <RowLayoutColumnInfo OriginX="9" />
                            </Header>
                            <Footer>
                                <RowLayoutColumnInfo OriginX="9" />
                            </Footer>
                        </igtbl:TemplatedColumn>
                        <igtbl:UltraGridColumn BaseColumnName="SanPhamID" DataType="System.Int32" Hidden="True"
                            Key="SanPhamID">
                            <Header>
                                <RowLayoutColumnInfo OriginX="10" />
                            </Header>
                            <Footer>
                                <RowLayoutColumnInfo OriginX="10" />
                            </Footer>
                        </igtbl:UltraGridColumn>
                        <igtbl:UltraGridColumn BaseColumnName="GiamGia" DataType="System.Boolean" Hidden="True"
                            Key="GiamGia">
                            <Header Caption="Giảm gi&#225;">
                                <RowLayoutColumnInfo OriginX="11" />
                            </Header>
                            <Footer>
                                <RowLayoutColumnInfo OriginX="11" />
                            </Footer>
                            <CellStyle HorizontalAlign="Center">
                            </CellStyle>
                        </igtbl:UltraGridColumn>
                        <igtbl:UltraGridColumn BaseColumnName="KhuyenMai" Hidden="True" Key="KhuyenMai">
                            <Header Caption="Khuyến m&#227;i">
                                <RowLayoutColumnInfo OriginX="12" />
                            </Header>
                            <Footer>
                                <RowLayoutColumnInfo OriginX="12" />
                            </Footer>
                            <CellStyle HorizontalAlign="Center">
                            </CellStyle>
                        </igtbl:UltraGridColumn>
                        <igtbl:UltraGridColumn BaseColumnName="NhomSanPhamID" Hidden="True" Key="NhomSanPhamID">
                            <Header>
                                <RowLayoutColumnInfo OriginX="13" />
                            </Header>
                            <Footer>
                                <RowLayoutColumnInfo OriginX="13" />
                            </Footer>
                        </igtbl:UltraGridColumn>
                        <igtbl:UltraGridColumn BaseColumnName="AnhSanPham" Hidden="True" Key="AnhSanPham">
                            <Header>
                                <RowLayoutColumnInfo OriginX="14" />
                            </Header>
                            <Footer>
                                <RowLayoutColumnInfo OriginX="14" />
                            </Footer>
                        </igtbl:UltraGridColumn>
                        <igtbl:UltraGridColumn Hidden="True" Key="Selected">
                            <Header>
                                <RowLayoutColumnInfo OriginX="15" />
                            </Header>
                            <Footer>
                                <RowLayoutColumnInfo OriginX="15" />
                            </Footer>
                        </igtbl:UltraGridColumn>
                    </Columns>
                    <AddNewRow View="NotSet" Visible="NotSet">
                    </AddNewRow>
                    <RowEditTemplate>
                        <br />
                        <p align="center">
                            <input id="igtbl_reOkBtn" onclick="igtbl_gRowEditButtonClick(event);" style="width: 50px"
                                type="button" value="OK" />&nbsp;
                            <input id="igtbl_reCancelBtn" onclick="igtbl_gRowEditButtonClick(event);" style="width: 50px"
                                type="button" value="Cancel" /></p>
                    </RowEditTemplate>
                    <RowTemplateStyle BackColor="Window" BorderColor="Window" BorderStyle="Ridge">
                        <BorderDetails WidthBottom="3px" WidthLeft="3px" WidthRight="3px" WidthTop="3px" />
                    </RowTemplateStyle>
                </igtbl:UltraGridBand>
            </Bands>
            <DisplayLayout AllowColSizingDefault="Free" AllowColumnMovingDefault="OnServer" AutoGenerateColumns="False"
                BorderCollapseDefault="Separate" CellClickActionDefault="RowSelect" ColWidthDefault=""
                HeaderClickActionDefault="SortMulti" Name="grdSanPham" RowHeightDefault="20px" ScrollBarView="Vertical"
                Version="4.00" AllowRowNumberingDefault="Continuous" CellPaddingDefault="2">
                <FrameStyle BackColor="Window" BorderColor="InactiveCaption" BorderStyle="Solid"
                    BorderWidth="1px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt"
                    Width="100%">
                </FrameStyle>
                <RowAlternateStyleDefault BackColor="#FAFAFA">
                </RowAlternateStyleDefault>
                <Pager MinimumPagesForDisplay="2" AllowPaging="True" PageSize="100" Pattern="Trang [default]" QuickPages="10" StyleMode="QuickPages">
                <PagerStyle BackColor="LightGray" BorderWidth="1px" BorderStyle="Solid">
                <BorderDetails ColorLeft="White" ColorTop="White" WidthLeft="1px" WidthTop="1px"></BorderDetails>
                </PagerStyle>
                </Pager>
                <EditCellStyleDefault BorderStyle="None" BorderWidth="0px">
                </EditCellStyleDefault>
                <FooterStyleDefault BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                    <BorderDetails ColorLeft="White" ColorTop="White" WidthLeft="1px" WidthTop="1px" />
                </FooterStyleDefault>
                <HeaderStyleDefault BackColor="LightGray" BorderStyle="Solid" HorizontalAlign="Center">
                    <BorderDetails ColorLeft="White" ColorTop="White" WidthLeft="1px" WidthTop="1px" />
                </HeaderStyleDefault>
                <RowStyleDefault BackColor="Window" BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px"
                    Font-Names="Microsoft Sans Serif" Font-Size="8.25pt">
                    <Padding Left="3px" />
                    <BorderDetails ColorLeft="Window" ColorTop="Window" />
                </RowStyleDefault>
                <GroupByRowStyleDefault BackColor="Control" BorderColor="Window">
                </GroupByRowStyleDefault>
                <SelectedRowStyleDefault ForeColor="Blue">
                </SelectedRowStyleDefault>
                <GroupByBox Hidden="True">
                    <BoxStyle BackColor="ActiveBorder" BorderColor="Window">
                    </BoxStyle>
                </GroupByBox>
                <AddNewBox>
                    <BoxStyle BackColor="Window" BorderColor="InactiveCaption" BorderStyle="Solid" BorderWidth="1px">
                        <BorderDetails ColorLeft="White" ColorTop="White" WidthLeft="1px" WidthTop="1px" />
                    </BoxStyle>
                </AddNewBox>
                <ActivationObject BorderColor="White" BorderWidth="1px">
                    <BorderDetails ColorBottom="Silver" ColorRight="Silver" />
                </ActivationObject>
                <FilterOptionsDefault AllString="Tất cả" ContainsString="Chứa" DoesNotContainString="Kh&#244;ng chứa" DoesNotEndWithString="Kh&#244;ng kết th&#250;c bằng" DoesNotStartWithString="Kh&#244;ngbắt đầu bằng" EmptyString="(Trống)" EndsWithString="Kết th&#250;c bằng" EqualsString="Bằng" FilterUIType="FilterRow" GreaterThanOrEqualsString="Lớn hơn hoặc bằng" GreaterThanString="Lớn hơn" LessThanOrEqualsString="Nhỏ hơn hoặc bằng" LessThanString="Nhỏ hơn" LikeString="Giống" NonEmptyString="(Kh&#244;ng trống)" NotEqualsString="Kh&#244;ng bằng" NotLikeString="Kh&#244;ng giống" ShowAllCondition="Yes" ShowEmptyCondition="No" StartsWithString="Bắt đầu bởi" FilterComparisonType="CaseInsensitive" AllowRowFiltering="OnClient">
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
            </DisplayLayout>
        </igtbl:UltraWebGrid>
        </igmisc:WebAsyncRefreshPanel>
    </td>
    </tr>
    <tr><td style="padding-top: 10px">
        <table width="100%">
                <tr>
                    <td>
                        <input id="btnExtend" runat="server" class="button" style="width: 73px" type="button"
                            value="Gia hạn" onclick="ExtendList();" />
                        &nbsp; &nbsp; &nbsp; &nbsp;
                        <input id="btnDelete" runat="server" class="button" style="width: 73px" type="button"
                            value="Xóa" onserverclick="btnDelete_ServerClick" />
                    </td>
                    <td style="text-align: right">
                        <input id="hidID" runat="server" type="hidden" />
                        <input id="hidAction" runat="server" type="hidden" />
                        &nbsp;&nbsp;
                    </td>
                </tr>
            </table>
        </td></tr>
    </table>
</asp:Content>
