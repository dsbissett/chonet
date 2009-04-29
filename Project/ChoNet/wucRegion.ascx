<%@ Control Language="C#" AutoEventWireup="true" CodeFile="wucRegion.ascx.cs" Inherits="wucRegion" %>
<td class="<%=clsRegion%>" style="<%=Width%>" align="center" valign="middle">
    <table cellspacing="0" cellpadding="0" border="0">
        <tbody>
            <tr>
                <td align="center" width="28%" valign="middle">
                    <img runat="server" id="imgNew" height="23" src="images/skmoi.png" width="30" style="border: 0px" /></td>
                <td nowrap width="72%" align="center" valign="middle">
                    <a href="<%=HrefRegion%>"><span style="color: #000099">
                        <%=Title%>
                    </span></a>
                </td>
            </tr>
        </tbody>
    </table>
</td>
