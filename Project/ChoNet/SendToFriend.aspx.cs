using System;
using System.Configuration;
using System.Web.UI;
using CHONET.Common;

public partial class SendToFriend : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["URL"] != null)
            {
                txtNoiDungKemTheo.Text = Request.QueryString["URL"];
            }
        }
    }


    protected void btnGui_Click(object sender, EventArgs e)
    {
        try
        {
            string emailto = txtNguoiNhan.Text;
            string emailfrom = ConfigurationManager.AppSettings["EmailFrom"];
            string emailsubject = "Bạn nhận được tin từ "; // +Session["UserFullName"].ToString();
            string emailbody = txtNoiDungKemTheo.Text;
            string smtpserver = ConfigurationManager.AppSettings["smtpserver"];
            string emailcc = "";
            string emailbcc = "";

            Common.SendMail(emailto, emailfrom, emailsubject, emailbody, smtpserver, emailcc, emailbcc);

            string strScript = "<script language='JavaScript'>" + "this.close();</script>";
            ClientScript.RegisterStartupScript(Type.GetType("System.String"), "Refresh", strScript);
        }
        catch (Exception ex)
        {
            Response.Redirect("Message.aspx?msg=" + ex.ToString().Replace("\r\n", " "));
        }
    }
}