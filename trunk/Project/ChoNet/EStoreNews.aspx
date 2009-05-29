<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/EstoreMaster.master"
    CodeFile="EStoreNews.aspx.cs" Inherits="eStoreNew" %>

<%@ Register Assembly="Infragistics2.WebUI.UltraWebGrid.v7.1, Version=7.1.20071.1048, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebGrid" TagPrefix="igtbl" %>
<%@ Register Assembly="Infragistics2.WebUI.Misc.v7.1, Version=7.1.20071.1048, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.Misc" TagPrefix="igmisc" %>
<asp:Content runat="server" ID="content1" ContentPlaceHolderID="cphEstore">
   <div class="content">
				<div class="path-link">
						<ul>
							<li><a href="Estore.aspx?sid=<%=CuaHangID %>">Trang chu</a>&nbsp;&raquo;</li>							
							<li><a href="#"><b>Product-detail</b></a></li>
						</ul>
						<p class="fs-14 fl mr-t pad-b10 pad-t5"><b><asp:Label runat="server" ID="lblTieuDe" Text=""></asp:Label></b></p>
						<div class="fl w598">
							<p class="pad-01 fl"><span runat="server" id="spnImage"></span>
								<span class="tintuc" runat="server" id="spnTinTuc"></span>
							</p>
						</div>
						<div class="news-hot">
							<h3><b class="fs-14">Tin mới</b></h3>
							<span id="spnTinTucMoi" runat="server"></span>
							<div style="clear:both;"></div>
							<h3 class="fl mr-t8"><b class="fs-14">Tin cũ</b></h3>
							<span id="spnTinTucCu" runat="server"></span>
						</div>
				</div>
				
			</div>        
</asp:Content>
