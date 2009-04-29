<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="Inform.aspx.cs" Inherits="Inform" %>

<asp:Content ContentPlaceHolderID="cphMain" runat="server" ID="InformContent" >
<div style="vertical-align:middle">
<p><br /><br />
<asp:Label ID="lblInform" runat="server" Font-Size="Small"></asp:Label></p>    
</div>
    <div runat="server" id="divInformUser" style="padding-left: 50px; text-align: left">
    <span style="font-size: 14px"><span style="color: black">
    Cảm ơn </span><span style="color: green">
        <strong>
            <asp:Label ID="lblName" runat="server"></asp:Label></strong></span> <span style="color: #000000">
                đã đăng ký thành viên tại Chợnét 
                <br />
                Để hoàn tất quá trình đăng ký,
    bạn hãy kiểm tra Email kích hoạt chúng tôi gửi đến địa chỉ</span> <span style="color: #ff6600"><strong>
                    <asp:Label ID="lblEmail" runat="server"></asp:Label></strong> </span>
        <br />
        <span style="color: #000000">Hãy Click vào
    đường link trong đó để Activate tài khoản trước khi có thể đăng nhập.</span></span><span style="color: #000000"> </span>
    <p>
        <em><span style="color: #000000">Chú ý: <br />
    - Nếu vẫn chưa nhận được Email kick hoạt, hãy click <a href="http://chonet.vn/SendActiveMail.aspx" target="_blank">
                <span style="color: blue">vào đây</span></a> để chúng tôi gửi lại; <br />
    - Trong trường hợp khác bạn vui lòng vào đây <a href="http://chonet.vn/giupdo" target="_blank"><span
                style="color: blue">http://chonet.vn/giupdo</span></a> để xem hướng dẫn. </span>
        </em>
    </p></div>
    <div runat="server" id="divInformEstore" style="padding-left: 50px; text-align: left">
    <span style="font-size: 14px"><span style="color: black">
    Cảm ơn </span><span style="color: green">
        <strong>
            <asp:Label ID="lblEstoreName" runat="server"></asp:Label></strong></span> <span style="color: #000000">
                đã đăng ký gian hàng tại Chợnét 
                <br />
                Quản trị sẽ liên hệ với bạn qua email hoặc điện thoại trong thời gian sớm nhất.</span></span><span style="color: #000000"></span><p>
        <em><span style="color: #000000">Chú ý: <br />
    - Trong trường hợp cần trợ giúp bạn vui lòng vào đây <a href="http://chonet.vn/giupdo" target="_blank"><span
                style="color: blue">http://chonet.vn/giupdo</span></a> để xem hướng dẫn. </span>
        </em>
    </p>
        <p>
            <em><span style="color: #000000"></span></em>&nbsp;</p>
    </div>
</asp:Content>
