<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Adm/Admin.master" CodeFile="OrderAdmin.aspx.cs" Inherits="Adm_OrderAdmin" Title="Quản lí Đơn hàng" %>

<%@ Register Assembly="Infragistics2.WebUI.Misc.v7.1, Version=7.1.20071.1048, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.Misc" TagPrefix="igmisc" %>
<%@ Register Assembly="Infragistics2.WebUI.UltraWebGrid.v7.1, Version=7.1.20071.1048, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebGrid" TagPrefix="igtbl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphAdmin" Runat="Server">
<script type="text/javascript">
//    function Add(){                              
//        OpenDialogWindow('Thêm hãng sản xuất',350,175,'page','AddManu.aspx');    
//    }

    function Edit(obj){   
            var cell=igtbl_getCellById(obj.parentElement.id);
            var id=cell.Row.getCellFromKey('NhanXetID').getValue();                   
            OpenDialogWindow('Sửa nhận xét',550,275,'page','EditComment.aspx?cid=' + id);// + '&rand=' + rand_no);    
    }

    function Delete(obj){                      
            var cell=igtbl_getCellById(obj.parentElement.id);
            var id=cell.Row.getCellFromKey('NhanXetID').getValue();
            OpenDialogWindow('Xóa nhận xét',350,170,'page','Delete.aspx?id=' + id + '&type=nhanxetsanpham');    
    }

    function Refresh()
    {  	
        var warp = ig$('<%=pnlNhanXet.ClientID%>');	   
        //alert(warp);
        if(!warp)
		    return;		
	    warp.refresh();	
    }

    function WebAsyncRefreshPanel1_RefreshComplete(oPanel)
    {
	    CloseDialogWindow();
    }
</script>
<table border="0" cellpadding="0" cellspacing="0" width="100%"><tr><td>
    <igmisc:webasyncrefreshpanel id="pnlNhanXet" runat="server" Height="100%"  width="100%" OnContentRefresh="pnlNhanXet_ContentRefresh" RefreshComplete="WebAsyncRefreshPanel1_RefreshComplete"><igtbl:UltraWebGrid ID="grdNhanXet" runat="server" Width="100%" DataKeyField="NhanXetID">
            <Bands>
                <igtbl:UltraGridBand DataKeyField="NhanXetID">
                    <Columns>
                        <igtbl:TemplatedColumn SortIndicator="Disabled" Width="8%">
                            <CellTemplate>
                                <a href="#Edit" onclick="Edit(this);">Sửa</a> <a href="#delete" onclick="Delete(this);">
                                    Xóa</a>
                            </CellTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle Cursor="Hand" HorizontalAlign="Center">
                            </CellStyle>
                            <Header Caption="">
                            </Header>
                        </igtbl:TemplatedColumn>
                        <igtbl:UltraGridColumn BaseColumnName="DonHangID" DataType="System.Int32" Hidden="True"
                            Key="DonHangID">
                            <Header>
                                <RowLayoutColumnInfo OriginX="1" />
                            </Header>
                            <Footer>
                                <RowLayoutColumnInfo OriginX="1" />
                            </Footer>
                        </igtbl:UltraGridColumn>
                        <igtbl:UltraGridColumn BaseColumnName="NoiDung" Key="NoiDung" Width="40%">
                            <HeaderStyle HorizontalAlign="Center" />
                            <Header Caption="Nội dung">
                                <RowLayoutColumnInfo OriginX="2" />
                            </Header>
                            <Footer>
                                <RowLayoutColumnInfo OriginX="2" />
                            </Footer>
                        </igtbl:UltraGridColumn>
                        <igtbl:UltraGridColumn BaseColumnName="NguoiNhanXet" Key="NguoiNhanXet" Width="15%">
                            <HeaderStyle HorizontalAlign="Center" />
                            <Header Caption="Người nhận x&#233;t">
                                <RowLayoutColumnInfo OriginX="3" />
                            </Header>
                            <Footer>
                                <RowLayoutColumnInfo OriginX="3" />
                            </Footer>
                        </igtbl:UltraGridColumn>
                        <igtbl:UltraGridColumn BaseColumnName="TenSanPham" Key="TenSanPham" Width="15%">
                            <Header Caption="Sản phẩm">
                                <RowLayoutColumnInfo OriginX="4" />
                            </Header>
                            <Footer>
                                <RowLayoutColumnInfo OriginX="4" />
                            </Footer>
                        </igtbl:UltraGridColumn>
                        <igtbl:UltraGridColumn BaseColumnName="TenCuaHang" Key="TenCuaHang" Width="30%">
                            <Header Caption="Gian h&#224;ng">
                                <RowLayoutColumnInfo OriginX="5" />
                            </Header>
                            <Footer>
                                <RowLayoutColumnInfo OriginX="5" />
                            </Footer>
                        </igtbl:UltraGridColumn>
                    </Columns>
                    <AddNewRow View="NotSet" Visible="NotSet">
                    </AddNewRow>
                </igtbl:UltraGridBand>
            </Bands>
            <DisplayLayout AllowAddNewDefault="Yes" AllowColSizingDefault="Free" AllowColumnMovingDefault="OnServer"
                AllowDeleteDefault="Yes" AllowSortingDefault="OnClient" AutoGenerateColumns="False"
                BorderCollapseDefault="Separate" CellClickActionDefault="RowSelect" ColWidthDefault=""
                HeaderClickActionDefault="SortMulti" Name="grdNhanXet" RowHeightDefault="20px"
                RowSelectorsDefault="No" ScrollBarView="Vertical" SelectTypeRowDefault="Extended"
                StationaryMargins="Header" StationaryMarginsOutlookGroupBy="True" TableLayout="Fixed"
                Version="4.00" ViewType="OutlookGroupBy" AllowUpdateDefault="RowTemplateOnly" ScrollBar="Always">
                <FrameStyle BackColor="Window" BorderColor="InactiveCaption" BorderStyle="Solid"
                    BorderWidth="1px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt"
                    Width="100%">
                </FrameStyle>
                <RowAlternateStyleDefault BackColor="#FAFAFA">
                </RowAlternateStyleDefault>
                <Pager MinimumPagesForDisplay="2">
                    <PagerStyle BackColor="LightGray" BorderStyle="Solid" BorderWidth="1px">
                        <BorderDetails ColorLeft="White" ColorTop="White" WidthLeft="1px" WidthTop="1px" />
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
                <SelectedRowStyleDefault BackColor="#FFFFE1">
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
                <ActivationObject BorderColor="Silver" BorderWidth="1px">
                </ActivationObject>
                <FilterOptionsDefault>
                    <FilterDropDownStyle BackColor="White" BorderColor="Silver" BorderStyle="Solid" BorderWidth="1px"
                        CustomRules="overflow:auto;" Font-Names="Verdana,Arial,Helvetica,sans-serif"
                        Font-Size="11px" Height="300px" Width="200px">
                        <Padding Left="2px" />
                    </FilterDropDownStyle>
                    <FilterHighlightRowStyle BackColor="#151C55" ForeColor="White">
                    </FilterHighlightRowStyle>
                    <FilterOperandDropDownStyle BackColor="White" BorderColor="Silver" BorderStyle="Solid"
                        BorderWidth="1px" CustomRules="overflow:auto;" Font-Names="Verdana,Arial,Helvetica,sans-serif"
                        Font-Size="11px">
                        <Padding Left="2px" />
                    </FilterOperandDropDownStyle>
                </FilterOptionsDefault>
                <ClientSideEvents InitializeLayoutHandler="grdSanPham_InitializeLayoutHandler" />
            </DisplayLayout>
        </igtbl:UltraWebGrid></igmisc:webasyncrefreshpanel>
    </td>
    </tr>    
    </table>
</asp:Content>
