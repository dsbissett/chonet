using System;
using System.Web.UI;

public partial class Message : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string strMessage = Request.QueryString.Get("msg");
        if (strMessage != null)
        {
            lblMessage.Text = Server.UrlDecode(strMessage);
        }
    }
}