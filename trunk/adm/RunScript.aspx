<%@ Page Language="C#" MasterPageFile="~/Adm/Admin.master" AutoEventWireup="true" CodeFile="RunScript.aspx.cs" Inherits="Adm_RunScript" %>

<asp:Content ContentPlaceHolderID="cphAdmin" ID="contentRunScript" runat="server">
    <asp:TextBox ID="txtScript" runat="server" Height="251px" TextMode="MultiLine" Width="800px"></asp:TextBox>
    <div style="height:150px; overflow: auto; width: 800px;"><asp:GridView ID="GridView1" runat="server" Height="103px" PageSize="5"
        Width="586px">
    </asp:GridView></div>
    <br />
    <asp:Label ID="lblMessage" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label><br />
    Confirmation Code:
    <asp:TextBox ID="txtCode" runat="server"></asp:TextBox>
    <asp:Button ID="btnRun" runat="server" CssClass="button" OnClick="btnRun_Click" Text="Run"
        Width="83px" />
    <asp:Button ID="Button1" runat="server" CssClass="button" OnClick="btnRunSelect_Click" Text="Run Select"
        Width="83px" />
</asp:Content>