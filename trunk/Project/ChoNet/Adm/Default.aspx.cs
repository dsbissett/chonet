using System;
using System.Web.UI;
using CHONET.Common;

public partial class Admin_Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Common.LoaiNguoiDungID() == 1)
        {
            Response.Redirect("../message.aspx?msg=Access denied");
        }
    }
}