using System;
using System.Configuration;
using System.Data;
using System.Web.UI;
using CHONET.Common;
using CHONET.DataAccessLayer.Web;

public partial class LostPassword : Page
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
                string emailfrom = ConfigurationManager.AppSettings["EmailFrom"];
                string emailsubject = "Quên mật khẩu "; // +Session["UserFullName"].ToString();
                string emailbody = "Mật khẩu được gửi theo yêu cầu của bạn: ";
                emailbody += " Tên truy cập: " + ds.Tables[0].Rows[0]["TaiKhoan"];
                emailbody += " Mật khẩu: " + ds.Tables[0].Rows[0]["MatKhau"];
                string smtpserver = ConfigurationManager.AppSettings["smtpserver"];
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