using System;
using System.Configuration;
using System.Data;
using System.Security.Cryptography;
using System.Web.UI;
using CHONET.Common;
using CHONET.DataAccessLayer.Web;

public partial class Register : Page
{
    private int ndid;
    private string randomString = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //txtTaiKhoan.Attributes.Add("onblur", "return lostfocus();");
            // btnDangKy.Attributes.Add("onclick", "return btn_onclick();");
            wdcNgaySinh.Value = DateTime.Now;
            txtTaiKhoan.Focus();
        }
    }

    protected void btnDangKy_Click(object sender, EventArgs e)
    {
        try
        {
            NguoiDung nguoidung = new NguoiDung();
            if (nguoidung.CheckExistTenTruyCap(0, txtTaiKhoan.Text))
            {
                lblErr.Text = "Tên truy cập đã tồn tại!";
            }
            else if (CheckEmail() == false)
            {
                lblEmailError.Text = "Email đã được sử dụng!";
            }
            else
            {
                lblErr.Text = "";
                int intLoaiNguoiDung = rbtUser.Checked ? 1 : 2;
                bool? blGioiTinh = null;
                if (rbtGioiTinhNam.Checked || rbtGioiTinhNu.Checked)
                {
                    blGioiTinh = rbtGioiTinhNam.Checked;
                }

                try
                {
                    //if (intLoaiNguoiDung == 1)
                    //{
                    //    nguoidung.InsertFields(txtHoVaTen.Text, txtTaiKhoan.Text, txtMatKhau.Text, DateTime.Parse(wdcNgaySinh.Value.ToString()),
                    //        blGioiTinh, txtEmail.Text, null, true, txtDienThoaiDiDong.Text,
                    //        null, intLoaiNguoiDung, txtDiaChi.Text, txtYM.Text,
                    //        txtSoChungMinhThu.Text, null, null, null, null, null);
                    //}
                    //else
                    //{               
                    randomString = GenerateActiveCode();
                    ndid = nguoidung.InsertFields(txtHoVaTen.Text, txtTaiKhoan.Text, txtMatKhau.Text,
                                                  DateTime.Parse(wdcNgaySinh.Value.ToString()),
                                                  blGioiTinh, txtEmail.Text, randomString, false,
                                                  txtDienThoaiDiDong.Text,
                                                  null, intLoaiNguoiDung, txtDiaChi.Text, txtYM.Text,
                                                  txtSoChungMinhThu.Text, null, null, null, null, null);
                    //}
                }
                catch (Exception ex)
                {
                    Response.Redirect("message.aspx?msg=" + ex.Message);
                    return;
                }

                string template =
                    Common.GetEmailHTMLTemplate(Server.MapPath(".") +
                                                ConfigurationManager.AppSettings["TemplateKichHoat"]);
                string subject = "Kích hoạt tài khoản từ CHONET.VN";
                Common.SendActiveMail(txtEmail.Text, subject, template, txtHoVaTen.Text, ndid.ToString(), randomString,
                                      txtTaiKhoan.Text, txtMatKhau.Text, txtEmail.Text);
                Response.Redirect("Inform.aspx?type=user&name=" + txtHoVaTen.Text + "&email=" + txtEmail.Text, false);
                return;
            }
        }
        catch (Exception ex)
        {
            Response.Redirect("message.aspx?msg=" + ex.Message.Replace("\r\n", ""), false);
            return;
        }
    }

    private string GenerateActiveCode()
    {
        string randomString = "";
        byte[] randomArray = new byte[10];
        RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
        rng.GetBytes(randomArray);
        randomString = Convert.ToBase64String(randomArray);

        //randomString = rd.;
        return randomString.Substring(0, 10);
    }

    private bool CheckEmail()
    {
        NguoiDung nd = new NguoiDung();
        DataSet ds = nd.SelectByField("email", txtEmail.Text.Trim(), "nvarchar");
        if (ds.Tables[0].Rows.Count > 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    private void SendMail(string template, string subject)
    {
        try
        {
            string emailto = txtEmail.Text;
            string emailfrom = ConfigurationManager.AppSettings["EmailFrom"];
            string emailsubject = subject;
            string emailbody = template;
            string smtpserver = ConfigurationManager.AppSettings["smtpserver"];
            string emailcc = "";
            string emailbcc = "";

            emailbody = emailbody.Replace("[[name]]", txtHoVaTen.Text);
            emailbody = emailbody.Replace("[[linkkichhoat]]",
                                          "http://chonet.vn/ActivateAccount.aspx?ndid=" + ndid + "&activate="
                                          + randomString);
            emailbody = emailbody.Replace("[[taikhoan]]", txtTaiKhoan.Text);
            emailbody = emailbody.Replace("[[password]]", txtMatKhau.Text);
            emailbody = emailbody.Replace("[[email]]", txtEmail.Text);

            Common.SendMail(emailto, emailfrom, emailsubject, emailbody, smtpserver, emailcc, emailbcc);
        }
        catch (Exception ex)
        {
            Response.Redirect("message.aspx?msg=" + ex.ToString().Replace("\r\n", ""), false);
        }
    }
}