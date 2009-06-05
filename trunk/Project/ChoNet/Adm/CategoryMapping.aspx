<%@ Page Language="C#" MasterPageFile="~/Adm/Admin.master" AutoEventWireup="true"
    CodeFile="CategoryMapping.aspx.cs" Inherits="Adm_CategoryMapping" Title="Gán tên nhóm sản phẩm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphAdmin" runat="Server">
    <table width="100%">
        <tr>
            <td style="width: 10%">
                &nbsp;</td>
            <td style="width: 238px">
                <div>
                    &nbsp;<asp:GridView ID="grvNhomSanPham" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                ForeColor="#333333" GridLines="None" Width="700px" CssClass="Grid" DataKeyNames="CuaHangNhomSanPhamID">
                                <RowStyle BackColor="#EFF3FB" />
                                <Columns>
                                    <asp:BoundField DataField="NhomSanPhamID" Visible="False" >
                                        <ItemStyle Width="300px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="TenNhomSanPham" HeaderText="Nh&#243;m sản phẩm">
                                        <HeaderStyle Width="300px" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="T&#234;n hiển thị">
                                        <ItemTemplate> 
                                            <asp:TextBox ID="txtDisplayName" runat="server" Text='<%# bind("TenNhomSanPhamHienThi") %>' Width="227px"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <EditRowStyle BackColor="#2461BF" />
                                <AlternatingRowStyle BackColor="White" />
                        <EmptyDataTemplate>
                            Không có dữ liệu
                        </EmptyDataTemplate>
                            </asp:GridView>
                </div>
            </td>
        </tr>
        <tr>
            <td style="width: 10%">
            </td>
            <td style="width: 238px">
                <asp:Button ID="Button1" runat="server" CssClass="long-button" OnClick="btnSave_Click"
                    Text="Lưu" /></td>
        </tr>
    </table>
</asp:Content>
