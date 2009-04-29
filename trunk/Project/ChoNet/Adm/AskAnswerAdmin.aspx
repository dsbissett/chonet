<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Adm/Admin.master" CodeFile="AskAnswerAdmin.aspx.cs" Inherits="Adm_AskAnswerAdmin" Title="Quản trị hỏi đáp" %>

<%@ Register Assembly="Infragistics2.WebUI.Misc.v7.1, Version=7.1.20071.1048, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.Misc" TagPrefix="igmisc" %>
<%@ Register Assembly="Infragistics2.WebUI.UltraWebGrid.v7.1, Version=7.1.20071.1048, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebGrid" TagPrefix="igtbl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphAdmin" Runat="Server">
<script type="text/javascript">
//    function Add(){                              
//        OpenDialogWindow('Thêm h?ng s?n xu?t',350,175,'page','AddManu.aspx');    
//    }

    function Edit(obj){   
            var cell=igtbl_getCellById(obj.parentElement.id);
            var id=cell.Row.getCellFromKey('HoiDapID').getValue();                   
            OpenDialogWindow('Sửa hỏi đáp',450,235,'page','EditAskAnswer.aspx?aid=' + id);// + '&rand=' + rand_no);    
    }

    function Delete(obj){                      
            var cell=igtbl_getCellById(obj.parentElement.id);
            var id=cell.Row.getCellFromKey('HoiDapID').getValue();
            OpenDialogWindow('Xóa hỏi đáp',350,170,'page','Delete.aspx?id=' + id + '&type=hoidapsanpham');    
    }

    function Refresh()
    {  	
        var warp = ig$('<%=pnlHoiDap.ClientID%>');	   
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
    <igmisc:webasyncrefreshpanel id="pnlHoiDap" runat="server" Height="100%"  width="100%" OnContentRefresh="pnlHoiDap_ContentRefresh" RefreshComplete="WebAsyncRefreshPanel1_RefreshComplete"><igtbl:UltraWebGrid ID="grdHoiDap" runat="server" Width="100%" DataKeyField="HoiDapID">
            <Bands>
                <igtbl:UltraGridBand DataKeyField="HoiDapID">
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
                        <igtbl:UltraGridColumn BaseColumnName="HoiDapID" DataType="System.Int32" Hidden="True"
                            Key="HoiDapID">
                            <Header>
                                <RowLayoutColumnInfo OriginX="1" />
                            </Header>
                            <Footer>
                                <RowLayoutColumnInfo OriginX="1" />
                            </Footer>
                        </igtbl:UltraGridColumn>
                        <igtbl:UltraGridColumn BaseColumnName="CauHoi" Key="CauHoi" Width="23%">
                            <HeaderStyle HorizontalAlign="Center" />
                            <Header Caption="C&#226;u hỏi">
                                <RowLayoutColumnInfo OriginX="2" />
                            </Header>
                            <Footer>
                                <RowLayoutColumnInfo OriginX="2" />
                            </Footer>
                        </igtbl:UltraGridColumn>
                        <igtbl:UltraGridColumn BaseColumnName="TraLoi" Key="TraLoi" Width="32%">
                            <HeaderStyle HorizontalAlign="Center" />
                            <Header Caption="Trả lời">
                                <RowLayoutColumnInfo OriginX="3" />
                            </Header>
                            <Footer>
                                <RowLayoutColumnInfo OriginX="3" />
                            </Footer>
                        </igtbl:UltraGridColumn>
                        <igtbl:UltraGridColumn BaseColumnName="NguoiHoi" Key="NguoiHoi" Width="10%">
                            <Header Caption="Người hỏi">
                                <RowLayoutColumnInfo OriginX="4" />
                            </Header>
                            <Footer>
                                <RowLayoutColumnInfo OriginX="4" />
                            </Footer>
                        </igtbl:UltraGridColumn>
                        <igtbl:UltraGridColumn BaseColumnName="TenSanPham" Key="TenSanPham" Width="10%">
                            <Header Caption="Sản phẩm">
                                <RowLayoutColumnInfo OriginX="5" />
                            </Header>
                            <Footer>
                                <RowLayoutColumnInfo OriginX="5" />
                            </Footer>
                        </igtbl:UltraGridColumn>
                        <igtbl:UltraGridColumn BaseColumnName="TenCuaHang" Key="TenCuaHang" Width="20%">
                            <Header Caption="Gian h&#224;ng">
                                <RowLayoutColumnInfo OriginX="6" />
                            </Header>
                            <Footer>
                                <RowLayoutColumnInfo OriginX="6" />
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
                HeaderClickActionDefault="SortMulti" Name="grdHoiDap" RowHeightDefault="20px"
                RowSelectorsDefault="No" ScrollBarView="Vertical" SelectTypeRowDefault="Extended"
                StationaryMargins="Header" StationaryMarginsOutlookGroupBy="True" TableLayout="Fixed"
                Version="4.00" ViewType="OutlookGroupBy" AllowUpdateDefault="RowTemplateOnly" ScrollBar="Always">
                <FrameStyle BackColor="Window" BorderColor="InactiveCaption" BorderStyle="Solid"
                    BorderWidth="1px" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt"
                    Width="100%">
                </FrameStyle>
                <RowAlternateStyleDefault BackColor="#FAFAFA">
                </RowAlternateStyleDefault>
                <Pager MinimumPagesForDisplay="2" AllowPaging="True" PageSize="10" Pattern="Trang [default]">
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
