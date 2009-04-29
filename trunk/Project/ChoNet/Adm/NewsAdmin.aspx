
<%@ Page Language="C#" MasterPageFile="~/Adm/Admin.master" AutoEventWireup="true" CodeFile="NewsAdmin.aspx.cs" Inherits="Adm_NewsAdmin" Title="tin tức" %>
<%@ Register Assembly="Infragistics2.WebUI.Misc.v7.1, Version=7.1.20071.1048, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.Misc" TagPrefix="igmisc" %>
<%@ Register Assembly="Infragistics2.WebUI.UltraWebGrid.v7.1, Version=7.1.20071.1048, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebGrid" TagPrefix="igtbl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphAdmin" Runat="Server">
<script type="text/javascript">
    function Add(){                              
        OpenDialogWindow('Thêm tin tức',820,600,'page','AddNews.aspx');    
    }

    function Edit(obj){   
            var cell=igtbl_getCellById(obj.parentElement.id);
            var id=cell.Row.getCellFromKey('TinTucID').getValue();                   
            OpenDialogWindow('Sửa thông tin tin tức',820,600,'page','AddNews.aspx?nid=' + id);// + '&rand=' + rand_no);    
    }

    function Delete(obj){                      
            var cell=igtbl_getCellById(obj.parentElement.id);
            var id=cell.Row.getCellFromKey('TinTucID').getValue();
            OpenDialogWindow('Xóa tin tức',350,170,'page','Delete.aspx?id=' + id + '&type=tintuc');    
    }

    function RefreshNews()
    {  	
        var warp = ig$('<%=pnlTinTuc.ClientID%>');	   
        //alert(warp);
        if(!warp)
		    return;		
	    warp.refresh();	
    }

    function Refresh()
    {  	
        RefreshNews();	
    }
    function WebAsyncRefreshPanel1_RefreshComplete(oPanel)
    {
	    CloseDialogWindow();
    }
</script>
<table border="0" cellpadding="0" cellspacing="0" width="100%"><tr><td>
    <igmisc:webasyncrefreshpanel id="pnlTinTuc" runat="server" Height="100%"  width="100%" OnContentRefresh="pnlTinTuc_ContentRefresh" RefreshComplete="WebAsyncRefreshPanel1_RefreshComplete"><igtbl:UltraWebGrid ID="grdTinTuc" runat="server" Width="100%" DataKeyField="TinTucID">
            <Bands>
                <igtbl:UltraGridBand DataKeyField="TinTucID">
                    <Columns>
                        <igtbl:TemplatedColumn Key="Command" SortIndicator="Disabled" Width="15%">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellTemplate>
                                <a href="#Edit" onclick="Edit(this);">Sửa</a> <a href="#delete" onclick="Delete(this);">
                                    Xóa</a>
                            </CellTemplate>
                            <Header Caption="">
                            </Header>
                            <CellStyle Cursor="Hand" HorizontalAlign="Center">
                            </CellStyle>
                        </igtbl:TemplatedColumn>
                        <igtbl:UltraGridColumn BaseColumnName="TinTucID" DataType="System.Int32" Hidden="True"
                            Key="TinTucID">
                            <Header>
                                <RowLayoutColumnInfo OriginX="1" />
                            </Header>
                            <Footer>
                                <RowLayoutColumnInfo OriginX="1" />
                            </Footer>
                        </igtbl:UltraGridColumn>
                        <igtbl:UltraGridColumn BaseColumnName="TieuDe" CellMultiline="Yes" Key="TieuDe" Width="35%">
                            <HeaderStyle HorizontalAlign="Center" />
                            <Header Caption="Tin tức">
                                <RowLayoutColumnInfo OriginX="2" />
                            </Header>
                            <Footer>
                                <RowLayoutColumnInfo OriginX="2" />
                            </Footer>
                            <CellStyle Wrap="True">
                            </CellStyle>
                        </igtbl:UltraGridColumn>
                        <igtbl:UltraGridColumn AllowResize="Fixed" BaseColumnName="TomTat" CellMultiline="Yes"
                            Key="TomTat" Width="35%">
                            <HeaderStyle HorizontalAlign="Center" />
                            <Header Caption="T&#243;m tắt">
                                <RowLayoutColumnInfo OriginX="3" />
                            </Header>
                            <Footer>
                                <RowLayoutColumnInfo OriginX="3" />
                            </Footer>
                            <CellStyle Wrap="True">
                            </CellStyle>
                        </igtbl:UltraGridColumn>
                        <igtbl:UltraGridColumn BaseColumnName="LoaiTin" Key="LoaiTin" Width="10%">
                            <Header Caption="Loại tin tức">
                                <RowLayoutColumnInfo OriginX="4" />
                            </Header>
                            <Footer>
                                <RowLayoutColumnInfo OriginX="4" />
                            </Footer>
                        </igtbl:UltraGridColumn>
                    </Columns>
                    <AddNewRow View="NotSet" Visible="NotSet">
                    </AddNewRow>
                </igtbl:UltraGridBand>
            </Bands>
            <DisplayLayout AllowColSizingDefault="Free" AutoGenerateColumns="False"
                BorderCollapseDefault="Separate" CellClickActionDefault="RowSelect" ColWidthDefault=""
                HeaderClickActionDefault="SortMulti" Name="grdTinTuc" RowHeightDefault="20px" ScrollBarView="Vertical" SelectTypeRowDefault="Single"
                Version="4.00" ScrollBar="Always" CellPaddingDefault="2" AllowRowNumberingDefault="Continuous">
                <FrameStyle BackColor="Window" BorderColor="InactiveCaption" BorderStyle="Solid"
                    BorderWidth="1px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt"
                    Width="100%">
                </FrameStyle>
                <RowAlternateStyleDefault BackColor="#FAFAFA">
                </RowAlternateStyleDefault>
                <Pager MinimumPagesForDisplay="2" AllowPaging="True" PageSize="10" Pattern="Trang [default]" QuickPages="10" StyleMode="QuickPages">
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
                <FilterOptionsDefault AllowRowFiltering="OnClient" AllString="Tất cả" ContainsString="Chứa" DoesNotContainString="Kh&#244;ng chứa" DoesNotEndWithString="Kh&#244;ng kết th&#250;c bằng" DoesNotStartWithString="Kh&#244;ngbắt đầu bằng" EmptyString="(Trống)" EndsWithString="Kết th&#250;c bằng" EqualsString="Bằng" FilterUIType="FilterRow" GreaterThanOrEqualsString="Lớn hơn hoặc bằng" GreaterThanString="Lớn hơn" LessThanOrEqualsString="Nhỏ hơn hoặc bằng" LessThanString="Nhỏ hơn" LikeString="Giống" NonEmptyString="(Kh&#244;ng trống)" NotEqualsString="Kh&#244;ng bằng" NotLikeString="Kh&#244;ng giống" ShowAllCondition="Yes" ShowEmptyCondition="No" StartsWithString="Bắt đầu bởi" FilterComparisonType="CaseInsensitive">
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
        </igtbl:UltraWebGrid></igmisc:webasyncrefreshpanel>
    </td>
    </tr>
    <tr><td style="padding-top: 10px">
            <table width="100%">
                <tr>
                    <td><input id="btnAdd" class="short-button" type="button" value="Thêm mới" onclick="Add();" /></td>
                    <td style="text-align: right">
                        &nbsp;</td>
                </tr>
            </table>
        </td></tr>
    </table>
</asp:Content>

