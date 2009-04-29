using System;
using System.Web.UI;
using CHONET.DataAccessLayer.Web;

public partial class Comment : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["UserFullName"] != null)
                txtNguoiNhanXet.Text = Session["UserFullName"].ToString();
        }
    }

    protected void btnGuiNhanXet_Click(object sender, EventArgs e)
    {
        try
        {
            NhanXetSanPham nhanxet = new NhanXetSanPham();
            nhanxet.InsertFields(int.Parse(Request.QueryString["id"]), null, txtNguoiNhanXet.Text, txtNoiDung.Text);

            string strScript = "<script language='JavaScript'>" +
                               "dialogArguments.opener.TabSelected(3,true);this.close();</script>";
            ClientScript.RegisterStartupScript(Type.GetType("System.String"), "Refresh", strScript);
        }
        catch (Exception ex)
        {
            Response.Redirect("Message.aspx?msg=" + ex.ToString().Replace("\r\n", ""));
        }
    }
}