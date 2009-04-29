using System;
using System.Web.UI;
using CHONET.DataAccessLayer.Web;

public partial class AskAndAnswer : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["UserFullName"] != null)
                txtNguoiHoi.Text = Session["UserFullName"].ToString();
        }
    }

    protected void btnGuiCauHoi_Click(object sender, EventArgs e)
    {
        try
        {
            HoiDapSanPham hoidap = new HoiDapSanPham();
            //hoidap.InsertFields(int.Parse(Request.QueryString["id"].ToString()), null, txtNguoiHoi.Text, txtNoiDung.Text, null);

            string strScript = "<script language='JavaScript'>" +
                               "dialogArguments.opener.TabSelected(2,true);this.close();</script>";
            ClientScript.RegisterStartupScript(Type.GetType("System.String"), "Refresh", strScript);
        }
        catch (Exception ex)
        {
            Response.Redirect("Message.aspx?msg=" + ex.ToString().Replace("\r\n", ""));
        }
    }
}