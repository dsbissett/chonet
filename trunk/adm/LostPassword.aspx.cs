using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using CHONET.Common;
using CHONET.DataAccessLayer.Web;

public partial class LostPassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnGui_Click(object sender, EventArgs e)
    {
        try
        {
            NguoiDung nguoidung = new NguoiDung();
            DataSet ds = nguoidung.SelectByField("email", txtEmail.Text.Trim(), "nvarchar");
            if (ds.Tables[0].Rows.Count > 0)
            {
                string emailto = txtEmail.Text;
                string emailfrom = System.Configuration.ConfigurationManager.AppSettings["EmailFrom"].ToString();
                string emailsubject = "Quên mật khẩu "; // +Session["UserFullName"].ToString();
                string emailbody = "Mật khẩu được gửi theo yêu cầu của bạn: ";
                emailbody += " Tên truy cập: " + ds.Tables[0].Rows[0]["TaiKhoan"].ToString();
                emailbody += " Mật khẩu: " + ds.Tables[0].Rows[0]["MatKhau"].ToString();
                string smtpserver = System.Configuration.ConfigurationManager.AppSettings["smtpserver"].ToString();
                string emailcc = "";
                string emailbcc = "";

                Common.SendMail(emailto, emailfrom, emailsubject, emailbody, smtpserver, emailcc, emailbcc);                
            }
            string strScript = "<script language='JavaScript'>" + "this.close();</script>";
            ClientScript.RegisterStartupScript(Type.GetType("System.String"), "Refresh", strScript);
        }
        catch (Exception ex)
        {
            Response.Redirect("message.aspx?msg=" + ex.ToString().Replace("\r\n", ""));
        }
    }
}
