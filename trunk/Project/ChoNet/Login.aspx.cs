using System;
using System.Data;
using System.Web.Security;
using System.Web.UI;
using CHONET.DataAccessLayer.Web;

public partial class Login : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //lblTaiKhoanKhongTonTai.Visible = false;
        lblErr.Visible = false;
        //Page.Form.DefaultFocus = txtTaiKhoan.ClientID;
        //btnDangNhap.Attributes.Add("onclick", "return btnDangNhap_Click();");
        txtTaiKhoan.Attributes.Add("onkeypress", "return clickButton(event,'" + btnDangNhap.ClientID + "')");
        txtMatKhau.Attributes.Add("onkeypress", "return clickButton(event,'" + btnDangNhap.ClientID + "')");
    }

    protected void btnDangNhap_Click(object sender, EventArgs e)
    {
        try
        {
            NguoiDung nguoidung = new NguoiDung();
            DataSet ds = nguoidung.SelectByField("taikhoan", txtTaiKhoan.Text.Trim(), "nvarchar");

            if (ds.Tables[0].Rows.Count > 0)
            {
                if ((ds.Tables[0].Rows[0]["matkhau"].ToString() == txtMatKhau.Text) &&
                    bool.Parse(ds.Tables[0].Rows[0]["KichHoat"].ToString()))
                {
                    Session.Clear();
                    Session.Add("LoaiNguoiDungID", ds.Tables[0].Rows[0]["LoaiNguoiDungID"]);
                    Session.Add("NguoiDungID", ds.Tables[0].Rows[0]["NguoiDungID"]);
                    Session.Add("UserFullName", ds.Tables[0].Rows[0]["HoVaTen"]);
                    Session.Add("NguoiDungEmail", ds.Tables[0].Rows[0]["Email"]);

                    FormsAuthentication.RedirectFromLoginPage(txtTaiKhoan.Text.Trim(), false);
                }
                else
                {
                    lblErr.Visible = true;
                    lblErr.Text = "Mật khẩu không đúng, hãy nhập lại";
                }
            }
            else
            {
                lblErr.Visible = true;
                lblErr.Text = "Tên truy nhập không tồn tại";
            }
        }
        catch (Exception ex)
        {
            Response.Redirect("Message.aspx?msg=" + ex.Message);
            return;
        }
    }
}