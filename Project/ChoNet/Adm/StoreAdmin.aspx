<%@ Page Language="C#" MasterPageFile="~/Adm/Admin.master" AutoEventWireup="true" CodeFile="StoreAdmin.aspx.cs" Inherits="Adm_StoreAdmin" Title="Gian hàng" %>
<%@ Register Assembly="Infragistics2.WebUI.Misc.v7.1, Version=7.1.20071.1048, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.Misc" TagPrefix="igmisc" %>
<%@ Register Assembly="Infragistics2.WebUI.UltraWebGrid.v7.1, Version=7.1.20071.1048, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebGrid" TagPrefix="igtbl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphAdmin" Runat="Server">
<script type="text/javascript">
    
    var blvote= false;
    function Upgrade(obj){   
            var cell=igtbl_getCellById(obj.parentElement.id);
            var id=cell.Row.getCellFromKey('CuaHangID').getValue();   
            
            var hid = document.getElementById('<%=hidID.ClientID %>');                
            hid.value = id;
            OpenDialogWindow('Nâng cấp gian hàng',350,175,'page','UpgradeStore.aspx?sid=' + id);// + '&rand=' + rand_no);    
    }

       
    function Refresh()
    {  	
        var warp = ig$('<%=pnlGianHang.ClientID%>');	   
        //alert(warp);
        if(!warp)
		    return;		
	    warp.refresh();	
    }

    function WebAsyncRefreshPanel1_RefreshComplete(oPanel)
    {
        if (blvote!=true)
        {
	        CloseDialogWindow();
	    }
	    else
	    {
	        blvote=false;
	    }
    }
</script>
<table border="0" cellpadding="0" cellspacing="0" width="100%"><tr><td><input type="hidden" id="hidVote" runat="server" value="0" /><input type="hidden" id="hidIDforVote" runat="server" value="0" />
    <igmisc:webasyncrefreshpanel id="pnlGianHang" runat="server" Height="100%"  width="100%" OnContentRefresh="pnlGianHang_ContentRefresh" RefreshComplete="WebAsyncRefreshPanel1_RefreshComplete"><igtbl:UltraWebGrid ID="grdGianHang" runat="server" Width="100%" DataKeyField="GianHangID" OnInitializeLayout="grdGianHang_InitializeLayout">
            <Bands>
                <igtbl:UltraGridBand DataKeyField="GianHangID">
                    <Columns>
                        <igtbl:TemplatedColumn Key="Command" SortIndicator="Disabled" Width="8%">
                            <CellTemplate>
                                <a href="#Upgrade" onclick="Upgrade(this);">Nâng cấp</a> 
                            </CellTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle Cursor="Hand" HorizontalAlign="Center">
                            </CellStyle>
                            <Header Caption="">
                            </Header>
                        </igtbl:TemplatedColumn>                        
                        <igtbl:UltraGridColumn BaseColumnName="CuaHangID" DataType="System.Int32" Hidden="True"
                            Key="CuaHangID">
                            <Header>
                                <RowLayoutColumnInfo OriginX="1" />
                            </Header>
                            <Footer>
                                <RowLayoutColumnInfo OriginX="1" />
                            </Footer>
                        </igtbl:UltraGridColumn>
                        <igtbl:UltraGridColumn BaseColumnName="TenCuaHang" Key="TenCuaHang" Width="40%">
                            <HeaderStyle HorizontalAlign="Center" />
                            <Header Caption="Gian H&#224;ng">
                                <RowLayoutColumnInfo OriginX="2" />
                            </Header>
                            <Footer>
                                <RowLayoutColumnInfo OriginX="2" />
                            </Footer>
                        </igtbl:UltraGridColumn>
                        <igtbl:UltraGridColumn BaseColumnName="TenLoaiCuaHang" Key="TenLoaiCuaHang" Width="20%">
                            <HeaderStyle HorizontalAlign="Center" />
                            <Header Caption="Loại Cửa H&#224;ng">
                                <RowLayoutColumnInfo OriginX="3" />
                            </Header>
                            <Footer>
                                <RowLayoutColumnInfo OriginX="3" />
                            </Footer>
                        </igtbl:UltraGridColumn>
                        <igtbl:UltraGridColumn BaseColumnName="BaoDam" Key="BaoDam" Width="5%">
                            <HeaderStyle HorizontalAlign="Center" />
                            <Header Caption="Mức độ bảo đảm">
                                <RowLayoutColumnInfo OriginX="4" />
                            </Header>
                            <Footer>
                                <RowLayoutColumnInfo OriginX="4" />
                            </Footer>
                        </igtbl:UltraGridColumn>
                        <igtbl:UltraGridColumn BaseColumnName="HoVaTen" Key="HoVaTen" Width="27%">
                            <Header Caption="Người d&#249;ng">
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
            <DisplayLayout AllowColSizingDefault="Free" AutoGenerateColumns="False"
                BorderCollapseDefault="Separate" CellClickActionDefault="RowSelect" ColWidthDefault=""
                HeaderClickActionDefault="SortMulti" Name="grdGianHang" RowHeightDefault="20px" ScrollBarView="Vertical" SelectTypeRowDefault="Single"
                Version="4.00" ScrollBar="Always" CellPaddingDefault="2" AllowRowNumberingDefault="Continuous">
                <FrameStyle BackColor="Window" BorderColor="InactiveCaption" BorderStyle="Solid"
                    BorderWidth="1px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt"
                    Width="100%">
                </FrameStyle>
                <RowAlternateStyleDefault BackColor="#FAFAFA">
                </RowAlternateStyleDefault>
                <Pager MinimumPagesForDisplay="2" AllowPaging="True" PageSize="15" Pattern="Trang [default]">
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
                <SelectedRowStyleDefault Font-Bold="False" ForeColor="Blue">
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
                <FilterOptionsDefault AllowRowFiltering="OnServer" AllString="Tất cả" ContainsString="Chứa" DoesNotContainString="Kh&#244;ng chứa" DoesNotEndWithString="Kh&#244;ng kết th&#250;c bằng" DoesNotStartWithString="Kh&#244;ngbắt đầu bằng" EmptyString="(Trống)" EndsWithString="Kết th&#250;c bằng" EqualsString="Bằng" FilterUIType="FilterRow" GreaterThanOrEqualsString="Lớn hơn hoặc bằng" GreaterThanString="Lớn hơn" LessThanOrEqualsString="Nhỏ hơn hoặc bằng" LessThanString="Nhỏ hơn" LikeString="Giống" NonEmptyString="(Kh&#244;ng trống)" NotEqualsString="Kh&#244;ng bằng" NotLikeString="Kh&#244;ng giống" ShowAllCondition="Yes" ShowEmptyCondition="No" StartsWithString="Bắt đầu bởi" FilterComparisonType="CaseInsensitive">
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
                <ClientSideEvents InitializeLayoutHandler="grdSanPham_InitializeLayoutHandler" />
            </DisplayLayout>
        </igtbl:UltraWebGrid></igmisc:webasyncrefreshpanel><input type="hidden" runat="server" id="hidID" />
    </td>
    </tr>
    <tr><td style="padding-top: 10px">
            <table width="100%">
                <tr>
                    <td></td>
                    <td style="text-align: right">
                        <asp:RadioButton ID="rbtPhanTrang" runat="server" AutoPostBack="True" Checked="True"
                            GroupName="pager" Text="Hiện theo trang" />
                        <asp:RadioButton ID="rbtTatCa" runat="server" AutoPostBack="True" GroupName="pager"
                            Text="Hiện tất cả" /></td>
                </tr>
            </table>
        </td></tr>
    </table>
</asp:Content>

