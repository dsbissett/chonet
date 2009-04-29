using System;
using System.Configuration;
using System.Data;
using System.Web.UI;
using CHONET.Common;
using CHONET.DataAccessLayer.Web;

public partial class SendActiveMail : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void btnSend_Click(object sender, EventArgs e)
    {
        try
        {
            NguoiDung nd = new NguoiDung();
            DataSet ds = nd.SelectByField("email", txtEmail.Text.Trim(), "nvarchar");

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (bool.Parse(ds.Tables[0].Rows[0]["KichHoat"].ToString()) == false)
                {
                    string emailto = txtEmail.Text;
                    string emailfrom = ConfigurationManager.AppSettings["EmailFrom"];
                    string emailsubject = "Kích hoạt tài khoản từ CHONET.VN";
                    string emailbody =
                        Common.GetEmailHTMLTemplate(Server.MapPath(".") +
                                                    ConfigurationManager.AppSettings["TemplateKichHoat"]);
                    string smtpserver = ConfigurationManager.AppSettings["smtpserver"];
                    string emailcc = "";
                    string emailbcc = "";
                    string name = ds.Tables[0].Rows[0]["HoVaTen"].ToString();
                    string ndid = ds.Tables[0].Rows[0]["NguoiDungID"].ToString();
                    string activatecode = ds.Tables[0].Rows[0]["MaSoKichHoat"].ToString();
                    string taikhoan = ds.Tables[0].Rows[0]["TaiKhoan"].ToString();
                    string matkhau = ds.Tables[0].Rows[0]["MatKhau"].ToString();

                    //emailbody = emailbody.Replace("[[name]]", ds.Tables[0].Rows[0]["HoVaTen"].ToString());
                    //emailbody = emailbody.Replace("[[linkkichhoat]]", "http://chonet.vn/ActivateAccount.aspx?ndid=" + ds.Tables[0].Rows[0]["NguoiDungID"].ToString()
                    //    + "&activate=" + ds.Tables[0].Rows[0]["MaSoKichHoat"].ToString());
                    //emailbody = emailbody.Replace("[[taikhoan]]",ds.Tables[0].Rows[0]["TaiKhoan"].ToString());
                    //emailbody = emailbody.Replace("[[password]]", ds.Tables[0].Rows[0]["MatKhau"].ToString());
                    //emailbody = emailbody.Replace("[[email]]", txtEmail.Text);

                    //Common.SendMail(emailto, emailfrom, emailsubject, emailbody, smtpserver, emailcc, emailbcc);
                    Common.SendActiveMail(txtEmail.Text, emailsubject, emailbody, name, ndid, activatecode, taikhoan,
                                          matkhau, emailto);

                    Response.Redirect(
                        "Inform.aspx?msg=Hệ thống đã gửi thư kích hoạt đến hộp thư của bạn. Hãy kiểm tra và làm theo hướng dẫn!",
                        false);
                    return;
                }
                else
                {
                    Response.Redirect("Inform.aspx?msg=Tài khoản của bạn đã được kích hoạt!", false);
                    return;
                }
            }
        }
        catch (Exception ex)
        {
            Response.Redirect("message.aspx?msg=" + ex.ToString().Replace("\r\n", ""));
        }
    }
}