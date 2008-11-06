<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SelectTemplate.aspx.cs" Inherits="Adm_SelectTemplate" %>

<%@ Register Assembly="Infragistics2.WebUI.Misc.v7.1, Version=7.1.20071.1048, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.Misc" TagPrefix="igmisc" %>
<%@ Register Assembly="Infragistics2.WebUI.UltraWebGrid.v7.1, Version=7.1.20071.1048, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebGrid" TagPrefix="igtbl" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Chọn sản phẩm mẫu</title>
    <link href="../Css/admin.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="../Scripts/multifile_compressed.js"></script>

    <script type="text/javascript" src="../Scripts/dialog.js"></script>

    <script type="text/javascript" src="../Scripts/WebForm.js"></script>

    <script type="text/javascript" src="../Scripts/WebUIValidation.js"></script>

    <script type="text/javascript">
    function ddl_onchange()
{    
     var warp = ig$('<%=pnlSanPham.ClientID%>');	   
    //alert(warp);
    if(!warp)
		return;		
	warp.refresh();	
    
}
    function onCheck(obj)
        {         
            if (obj.checked == false)            
            {
                SetRadio(false);
                obj.checked =  true;
            }
            var cell=igtbl_getCellById(obj.parentElement.id);
            cell.Row.getCellFromKey('Selected').setValue(obj.checked);                                                                
        }
        
        function SetRadio(bl)
        {
            if(document.form1.rbtSelect!=null)
            {
                if(document.form1.rbtSelect.length >= 1)
                {
                    for (i=0; i<document.form1.rbtSelect.length; i++)
                    {
                        document.form1.rbtSelect[i].checked=bl;
                    }
                }                
            }
        }
        
        function CheckSelected()
        {
            if(document.form1.rbtSelect!=null)
            {
                if(document.form1.rbtSelect.length >= 1)
                {
                    for (i=0; i<document.form1.rbtSelect.length; i++)
                    {
                        var rbt = document.form1.rbtSelect[i];
                        if (rbt.checked==true)
                        {
                            var cell=igtbl_getCellById(rbt.parentElement.id);
                            var id=cell.Row.getCellFromKey('SanPhamID').getValue();
                            
                            self.resizeTo(960,1210);
                            window.location = "addproduct.aspx?spmid=" + id;                              
                            
                            return true;                            
                        }
                    }
                }                
            }
            alert("Bạn phải chọn một sản phẩm mẫu");
            return false;
        }
        
        function Refresh()
{  	
    var warp = ig$('<%=pnlSanPham.ClientID%>');	   
    //alert(warp);
    if(!warp)
		return;		
	warp.refresh();	
}
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
        <igmisc:WebAsyncRefreshPanel ID="pnlSanPham" runat="server" Height="100%" Width="100%"
                    RefreshComplete="WebAsyncRefreshPanel1_RefreshComplete" OnContentRefresh="pnlSanPham_ContentRefresh">
            <table border="0" cellpadding="0" cellspacing="0" style="height: 690px; width: 950px"
                class="row-template-table">
                <tr><td><table border="0" cellpadding="0" cellspacing="0" width="100%">
                    
                    <tr>
                        <td>
                            Danh mục cấp 1</td>
                        <td>
                            <asp:DropDownList ID="ddlDanhMuc1" runat="server" Width="200px">
                            </asp:DropDownList></td>
                        <td>
                            Danh mục cấp 2</td>
                        <td>
                            <asp:DropDownList ID="ddlDanhMuc2" runat="server" Width="200px">
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td>
                            Hãng sản xuất</td>
                        <td>
                            <asp:DropDownList ID="ddlHangSanXuat" runat="server" Width="200px">
                            </asp:DropDownList></td>
                        <td>
                            Khu vực</td>
                        <td>
                            <asp:DropDownList ID="ddlKhuVuc" runat="server" Width="200px">
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td>
                            Tên sản phẩm</td>
                        <td>
                            <asp:TextBox ID="txtTenSanPham" runat="server" Width="194px"></asp:TextBox></td>
                        <td>
                            </td>
                        <td>
                            </td>
                    </tr>
                    <tr>
                        <td colspan="4" style="height: 40px" valign="bottom">
                            <asp:Button ID="btnSearch" runat="server" CssClass="button" Text="Tìm kiếm" Width="84px" UseSubmitBehavior="false" /></td>
                    </tr>
                </table></td></tr>
                <tr>
                    <td style="height: 500px" valign="top">
                    
                        <igtbl:UltraWebGrid ID="grdSanPhamMau" runat="server" Width="100%" DataKeyField="SanPhamID"
                            OnInitializeLayout="grdSanPham_InitializeLayout">
                            <Bands>
                                <igtbl:UltraGridBand DataKeyField="SanPhamID">
                                    <Columns>
                                        <igtbl:TemplatedColumn Key="Command" SortIndicator="Disabled" Width="10%">
                                            <CellTemplate>
                                                <input id="rbtSelect" type="radio" onclick="onCheck(this);" value="<%#Container.Cell.Row.Cells.FromKey("Selected").Value %>" />
                                            </CellTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <CellStyle Cursor="Hand" HorizontalAlign="Center">
                                            </CellStyle>
                                            <Header Caption="">
                                            </Header>
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
                                        <igtbl:UltraGridColumn BaseColumnName="TenSanPham" Key="TenSanPham" Width="20%">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <Header Caption="Sản phẩm">
                                                <RowLayoutColumnInfo OriginX="2" />
                                            </Header>
                                            <Footer>
                                                <RowLayoutColumnInfo OriginX="2" />
                                            </Footer>
                                        </igtbl:UltraGridColumn>
                                        <igtbl:UltraGridColumn BaseColumnName="TenNhomSanPham" Key="TenNhomSanPham" Width="18%">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <Header Caption="Nh&#243;m ">
                                                <RowLayoutColumnInfo OriginX="3" />
                                            </Header>
                                            <Footer>
                                                <RowLayoutColumnInfo OriginX="3" />
                                            </Footer>
                                        </igtbl:UltraGridColumn>
                                        <igtbl:UltraGridColumn BaseColumnName="TenHangSanXuat" Key="TenHangSanXuat" Width="18%">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <Header Caption="H&#227;ng sản xuất">
                                                <RowLayoutColumnInfo OriginX="4" />
                                            </Header>
                                            <Footer>
                                                <RowLayoutColumnInfo OriginX="4" />
                                            </Footer>
                                        </igtbl:UltraGridColumn>
                                        <igtbl:UltraGridColumn BaseColumnName="NhomSanPhamID" Hidden="True" Key="NhomSanPhamID">
                                            <Header>
                                                <RowLayoutColumnInfo OriginX="5" />
                                            </Header>
                                            <Footer>
                                                <RowLayoutColumnInfo OriginX="5" />
                                            </Footer>
                                        </igtbl:UltraGridColumn>
                                        <igtbl:UltraGridColumn BaseColumnName="AnhSanPham" Hidden="True" Key="AnhSanPham">
                                            <Header>
                                                <RowLayoutColumnInfo OriginX="6" />
                                            </Header>
                                            <Footer>
                                                <RowLayoutColumnInfo OriginX="6" />
                                            </Footer>
                                        </igtbl:UltraGridColumn>
                                        <igtbl:UltraGridColumn BaseColumnName="TenKhuVuc" Key="TenKhuVuc" Width="15%">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <Header Caption="KhuVuc">
                                                <RowLayoutColumnInfo OriginX="7" />
                                            </Header>
                                            <Footer>
                                                <RowLayoutColumnInfo OriginX="7" />
                                            </Footer>
                                        </igtbl:UltraGridColumn>
                                        <igtbl:TemplatedColumn Width="15%">
                                            <CellTemplate>
                                                <img alt="" id="imgCell" height="40" src=".<%#Container.Cell.Row.Cells.FromKey("AnhSanPham").Value %>"
                                                    width="80" />
                                            </CellTemplate>
                                            <Header Caption="Ảnh">
                                                <RowLayoutColumnInfo OriginX="8" />
                                            </Header>
                                            <Footer>
                                                <RowLayoutColumnInfo OriginX="8" />
                                            </Footer>
                                        </igtbl:TemplatedColumn>
                                        <igtbl:UltraGridColumn Hidden="True" Key="Selected">
                                            <Header>
                                                <RowLayoutColumnInfo OriginX="9" />
                                            </Header>
                                            <Footer>
                                                <RowLayoutColumnInfo OriginX="9" />
                                            </Footer>
                                        </igtbl:UltraGridColumn>
                                    </Columns>
                                    <AddNewRow View="NotSet" Visible="NotSet">
                                    </AddNewRow>
                                </igtbl:UltraGridBand>
                            </Bands>
                            <DisplayLayout AllowColSizingDefault="Free" AllowColumnMovingDefault="OnServer" AutoGenerateColumns="False"
                                BorderCollapseDefault="Separate" CellClickActionDefault="RowSelect" ColWidthDefault=""
                                HeaderClickActionDefault="SortMulti" Name="grdSanPhamMau" RowHeightDefault="20px"
                                ScrollBarView="Vertical" Version="4.00" AllowRowNumberingDefault="Continuous"
                                CellPaddingDefault="2">
                                <FrameStyle BackColor="Window" BorderColor="InactiveCaption" BorderStyle="Solid"
                                    BorderWidth="1px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Width="100%">
                                </FrameStyle>
                                <RowAlternateStyleDefault BackColor="#FAFAFA">
                                </RowAlternateStyleDefault>
                                <Pager PageSize="12" Pattern="Trang [default]"  AllowPaging="true" AllowCustomPaging="True" StyleMode="CustomLabels">
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
                            </DisplayLayout>
                        </igtbl:UltraWebGrid>                        
                        </td>
                </tr>
                <tr>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Panel runat="server" ID="pnlPhanTrang" Width="100%">
                            <table width="100%">
                                <tr>
                                    <td style="width: 65%">
                                        <input type="button" id="btnSelect" class="long-button" onclick="return CheckSelected();"
                                            value="Chọn" width="76px" style="width: 76px" /></td>
                                    <td>
                                        <input type="button" id="btnClose" class="button" onclick="window.parent.CloseDialogWindow();"
                                            value="Đóng" width="76px" style="width: 76px" />                                        </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
            </igmisc:WebAsyncRefreshPanel>
        </div>
    </form>
</body>
</html>
