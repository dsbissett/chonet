<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SelectCat.aspx.cs" Inherits="Adm_SelectCat" %>
<%@ Register Assembly="Infragistics2.WebUI.UltraWebGrid.v7.1, Version=7.1.20071.1048, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebGrid" TagPrefix="igtbl" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Select Category</title>
    <link href="../Css/admin.css" rel="stylesheet" type="text/css" /> 
    <script id="igClientScript" type="text/javascript">
    <!--
        function onCheck(obj)
        {
            var spanSelect = document.getElementById('spanSelect');
            var n = parseInt(spanSelect.innerHTML,10);
            var spanMax = document.getElementById('spanMax')
            var max = parseInt(spanMax.innerText,10);
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
                    alert('Bạn không thể chọn quá ' + max + ' danh mục!'); 
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
                        //alert(document.form1.chkSelect[i].value);
                        if (document.form1.chkSelect[i].value=='True') 
                        {
                            document.form1.chkSelect[i].checked=true;
                        }
                        else
                        {
                            document.form1.chkSelect[i].checked=false;
                        }
                    }
                }
                else
                {
                    if (document.form1.chkSelect.value=='True') 
                        document.form1.chkSelect.checked=true;
                    else  
                        document.form1.chkSelect.checked=false;                    
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
                    Bạn đã chọn <span id="spanSelect" runat="server" style="color:Red; font-weight:bold;"></span> trong tổng số <span id="spanMax" runat="server" style="color:Red; font-weight:bold;"></span> danh mục được phép chọn</td>
            </tr>
            <tr>
                <td>
                    <igtbl:ultrawebgrid id="grdCat" runat="server" height="330px" width="100%"><Bands>
<igtbl:UltraGridBand>
<AddNewRow Visible="NotSet" View="NotSet"></AddNewRow>
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
        <igtbl:UltraGridColumn BaseColumnName="TenNhomSanPham" Key="TenNhomSanPham" Width="200px">
            <HeaderStyle HorizontalAlign="Center" />
            <Header Caption="Danh mục">
                <RowLayoutColumnInfo OriginX="1" />
            </Header>
            <Footer>
                <RowLayoutColumnInfo OriginX="1" />
            </Footer>
        </igtbl:UltraGridColumn>
        <igtbl:UltraGridColumn BaseColumnName="MoTaNhomSanPham" Key="MoTaNhomSanPham" Width="405px">
            <HeaderStyle HorizontalAlign="Center" />
            <Header Caption="M&#244; tả">
                <RowLayoutColumnInfo OriginX="2" />
            </Header>
            <Footer>
                <RowLayoutColumnInfo OriginX="2" />
            </Footer>
        </igtbl:UltraGridColumn>
        <igtbl:UltraGridColumn BaseColumnName="Show" Case="Lower" Hidden="True" Key="Selected"
            Width="50px">
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
</igtbl:UltraGridBand>
</Bands>

<DisplayLayout Version="4.00" SelectTypeRowDefault="Single" Name="grdCat" AllowSortingDefault="OnClient" AllowColSizingDefault="Free" RowHeightDefault="20px" HeaderClickActionDefault="SortMulti" BorderCollapseDefault="Separate" AllowRowNumberingDefault="Continuous" AutoGenerateColumns="False" CellPaddingDefault="2" ScrollBar="Always" ScrollBarView="Vertical" CellClickActionDefault="RowSelect">
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
                <td style="padding-top: 10px; text-align: center">
                    <asp:Button ID="btnSave" runat="server" CssClass="short-button" Text="Cập nhật" OnClick="btnSave_Click" /></td>
            </tr>
        </table>
    </form>
</body>
</html>
