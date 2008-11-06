<%@ Page Language="C#" MasterPageFile="~/Adm/Admin.master" AutoEventWireup="true" CodeFile="AdvAdmin.aspx.cs" Inherits="Admin_AdvAdmin" Title="Quảng cáo" %>

<%@ Register Assembly="Infragistics2.WebUI.Misc.v7.1, Version=7.1.20071.1048, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.Misc" TagPrefix="igmisc" %>
<%@ Register Assembly="Infragistics2.WebUI.UltraWebGrid.v7.1, Version=7.1.20071.1048, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebGrid" TagPrefix="igtbl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphAdmin" Runat="Server">
    <script id="igClientScript" type="text/javascript">
<!--

function Add(){
    if ('<%=CHONET.Common.Common.LoaiNguoiDungID() %>' != '3')
    {
        var grid = igtbl_getGridById('<%=grdAdv.ClientID %>'); 
        var count = 0;                             
        if (grid != null) 
        {
            count = grid.Rows.length;                      
        }
        if (count < 10)
        {
            OpenDialogWindow('Thêm quảng cáo',480,460,'page','AddAdv.aspx');    
        }
        else
        {
            alert('Bạn chỉ được tải lên không quá 10 quảng cáo');
        }
    }
    else
    {
       OpenDialogWindow('Thêm quảng cáo',480,460,'page','AddAdv.aspx'); 
    }    
}
function Edit(obj){ 
    var cell=igtbl_getCellById(obj.parentElement.id);
    var id=cell.Row.getCellFromKey('QuangCaoID').getValue();                  
    OpenDialogWindow('Sửa quảng cáo',480,460,'page','AddAdv.aspx?id=' + id);  
}
function Delete(obj){                              
    var cell=igtbl_getCellById(obj.parentElement.id);
    var id=cell.Row.getCellFromKey('QuangCaoID').getValue();        
    OpenDialogWindow('Xóa quảng cáo',310,120,'page','Delete.aspx?type=quangcao&id=' + id);    
}
function Refresh(){    
  	var warp = ig$('<%=pnlAdv.ClientID%>');	
	if(!warp) return;
	warp.refresh();		
}
function pnlAdv_RefreshComplete(oPanel){
	CloseDialogWindow();
}
// -->
</script>

<table width="100%" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <td></td>
    </tr>
     <tr>
        <td>
            <igmisc:webasyncrefreshpanel id="pnlAdv" runat="server" height="100%" width="100%" RefreshComplete="pnlAdv_RefreshComplete">            
            <igtbl:UltraWebGrid id="grdAdv" runat="server" Width="100%" OnInitializeLayout="grdAdv_InitializeLayout"><Bands>
<igtbl:UltraGridBand><Columns>
    <igtbl:TemplatedColumn Key="Command" Width="60px">
        <CellTemplate>
            <a href="#edit" onclick="Edit(this);">Sửa</a>&nbsp;<a href="#delete" onclick="Delete(this);">Xóa</a>
        </CellTemplate>
        <CellStyle HorizontalAlign="Center">
        </CellStyle>
        <Header Caption="">
        </Header>
    </igtbl:TemplatedColumn>
    <igtbl:UltraGridColumn BaseColumnName="QuangCaoID" DataType="System.UInt32" Hidden="True"
        Key="QuangCaoID">
        <Header>
            <RowLayoutColumnInfo OriginX="1" />
        </Header>
        <Footer>
            <RowLayoutColumnInfo OriginX="1" />
        </Footer>
    </igtbl:UltraGridColumn>
    <igtbl:UltraGridColumn BaseColumnName="DuongDan" Key="DuongDan" Width="250px">
        <HeaderStyle HorizontalAlign="Center" />
        <Header Caption="URL">
            <RowLayoutColumnInfo OriginX="2" />
        </Header>
        <Footer>
            <RowLayoutColumnInfo OriginX="2" />
        </Footer>
    </igtbl:UltraGridColumn>
    <igtbl:UltraGridColumn BaseColumnName="NoiDungQuangCao" Key="NoiDungQuangCao" Width="270px">
        <HeaderStyle HorizontalAlign="Center" />
        <Header Caption="Nội dung quảng c&#225;o">
            <RowLayoutColumnInfo OriginX="3" />
        </Header>
        <Footer>
            <RowLayoutColumnInfo OriginX="3" />
        </Footer>
    </igtbl:UltraGridColumn>
    <igtbl:UltraGridColumn BaseColumnName="DuongDanAnh" Hidden="True" Key="DuongDanAnh">
        <Header Caption="">
            <RowLayoutColumnInfo OriginX="4" />
        </Header>
        <Footer>
            <RowLayoutColumnInfo OriginX="4" />
        </Footer>
    </igtbl:UltraGridColumn>
    <igtbl:UltraGridColumn BaseColumnName="LoaiAnh" Key="LoaiAnh" Width="80px">
        <HeaderStyle HorizontalAlign="Center" />
        <Header Caption="Loại quảng c&#225;o">
            <RowLayoutColumnInfo OriginX="5" />
        </Header>
        <Footer>
            <RowLayoutColumnInfo OriginX="5" />
        </Footer>
    </igtbl:UltraGridColumn>
    <igtbl:UltraGridColumn Hidden="True" Key="Anh" Width="110px">
        <HeaderStyle HorizontalAlign="Center" />
        <CellStyle HorizontalAlign="Center">
        </CellStyle>
        <Header Caption="Ảnh">
            <RowLayoutColumnInfo OriginX="6" />
        </Header>
        <Footer>
            <RowLayoutColumnInfo OriginX="6" />
        </Footer>
    </igtbl:UltraGridColumn>
    <igtbl:UltraGridColumn BaseColumnName="GhiChu" Key="GhiChu" Width="30%">
        <HeaderStyle HorizontalAlign="Center" />
        <Header Caption="Ghi ch&#250;">
            <RowLayoutColumnInfo OriginX="7" />
        </Header>
        <Footer>
            <RowLayoutColumnInfo OriginX="7" />
        </Footer>
    </igtbl:UltraGridColumn>
</Columns>

<AddNewRow Visible="NotSet" View="NotSet"></AddNewRow>
</igtbl:UltraGridBand>
</Bands>

<DisplayLayout Version="4.00" SelectTypeRowDefault="Single" Name="grdAdv" CellPaddingDefault="2" AllowColSizingDefault="Free" RowHeightDefault="20px" CellClickActionDefault="RowSelect" HeaderClickActionDefault="SortMulti" BorderCollapseDefault="Separate" AutoGenerateColumns="False" AllowRowNumberingDefault="Continuous">
<FrameStyle BackColor="Window" BorderColor="InactiveCaption" BorderWidth="1px" BorderStyle="Solid" Font-Names="Microsoft Sans Serif" Font-Size="8.25pt" Width="100%"></FrameStyle>

<Pager MinimumPagesForDisplay="2" AllowPaging="True" PageSize="15" Pattern="Trang [default]">
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
    <RowAlternateStyleDefault BackColor="#FAFAFA">
    </RowAlternateStyleDefault>
    <SelectedRowStyleDefault ForeColor="Blue">
    </SelectedRowStyleDefault>
</DisplayLayout>
</igtbl:UltraWebGrid></igmisc:webasyncrefreshpanel>
        </td>
    </tr>
    <tr>
        <td style="padding-top: 10px">
            <table width="100%">
                <tr>
                    <td><input id="btnAdd" class="short-button" type="button" value="Thêm mới" onclick="Add();" /></td>
                    <td style="text-align: right">
                        <asp:RadioButton ID="rbtPhanTrang" runat="server" AutoPostBack="True" Checked="True"
                            GroupName="pager" Text="Hiện theo trang" />
                        <asp:RadioButton ID="rbtTatCa" runat="server" AutoPostBack="True" GroupName="pager"
                            Text="Hiện tất cả" /></td>
                </tr>
            </table>
            </td>
    </tr>
</table>

</asp:Content>

