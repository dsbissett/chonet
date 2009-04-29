using System;
using System.Configuration;
using System.Data;
using System.Web.UI;
using CHONET.Common;
using CHONET.DataAccessLayer.Web;

public partial class Admin_AddUser : Page
{
    private string ACTION = "";
    private int id;

    protected void Page_Load(object sender, EventArgs e)
    {
        lblTonTaiTenTruyCap.Text = "";
        if (Common.LoaiNguoiDungID() == 3)
        {
            if (Request.QueryString["id"] == null)
            {
                ACTION = "ADD";
                rbtNam.Checked = true;
                wdcNgaySinh.Value = DateTime.Now;
                ddlLoaiNguoiDung.Enabled = true;
                txtMatKhau.Disabled = false;
                btnReset.Visible = false;
                btnSendMail.Visible = false;
            }
            else
            {
                ACTION = "EDIT";
                id = Convert.ToInt32(Request.QueryString["id"]);
                ddlLoaiNguoiDung.Enabled = false;
                txtMatKhau.Disabled = true;
                btnReset.Visible = true;
                btnSendMail.Visible = true;
            }

            if (!Page.IsPostBack)
            {
                LoadLoaiNguoiDung();
                if (ACTION == "EDIT")
                {
                    LoadData();
                }
            }
        }
        else
        {
            Response.Redirect("../message.aspx?msg=Access denied");
        }
    }

    private void LoadLoaiNguoiDung()
    {
        LoaiNguoiDung loainguoidung = new LoaiNguoiDung();
        DataSet ds = loainguoidung.SelectAll();
        DataTable dt = ds.Tables[0];

        ddlLoaiNguoiDung.DataSource = dt;
        ddlLoaiNguoiDung.DataTextField = "LoaiNguoiDung";
        ddlLoaiNguoiDung.DataValueField = "LoaiNguoiDungID";
        ddlLoaiNguoiDung.DataBind();
    }

    private void LoadData()
    {
        try
        {
            NguoiDung nguoidung = new NguoiDung();
            DataTable dt = nguoidung.SelectByID(id).Tables[0];

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    txtHoVaTen.Value = dr["HoVaTen"].ToString();
                    txtTaiKhoan.Value = dr["TaiKhoan"].ToString();
                    txtMatKhau.Value = "******";
                    hidmatkhau.Value = dr["MatKhau"].ToString();
                    hidActiveCode.Value = dr["MaSoKichHoat"].ToString();
                    txtEmail.Value = dr["Email"].ToString();
                    txtYM.Value = dr["YM"].ToString();
                    if (dr["GioiTinh"].ToString() != "")
                    {
                        if (Convert.ToBoolean(dr["GioiTinh"].ToString()))
                        {
                            rbtNam.Checked = true;
                        }
                        else
                        {
                            rbtNu.Checked = true;
                        }
                    }
                    txtDienThoaiDiDong.Value = dr["DienThoaiDiDong"].ToString();
                    txtDienThoaiCoDinh.Value = dr["DienThoaiCoDinh"].ToString();
                    if (dr["NgaySinh"].ToString() != "")
                    {
                        wdcNgaySinh.Value = (DateTime) dr["NgaySinh"];
                    }
                    else
                    {
                        wdcNgaySinh.Value = DateTime.Now;
                    }

                    if ((dr["KichHoat"].ToString() != "") && Convert.ToBoolean(dr["KichHoat"]))
                    {
                        chkKichHoat.Checked = true;
                    }
                    else
                    {
                        chkKichHoat.Checked = false;
                    }

                    ddlLoaiNguoiDung.SelectedValue = dr["LoaiNguoiDungID"].ToString();

                    if ((ddlLoaiNguoiDung.SelectedValue == "1") && chkKichHoat.Checked)
                        ddlLoaiNguoiDung.Enabled = true;
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }
    }

    protected void btnLuu_ServerClick(object sender, EventArgs e)
    {
        try
        {
            NguoiDung nguoidung = new NguoiDung();
            if (ACTION == "ADD")
            {
                if (nguoidung.CheckExistTenTruyCap(0, txtTaiKhoan.Value.Trim()) != true)
                {
                    nguoidung.InsertFields(txtHoVaTen.Value, txtTaiKhoan.Value, txtMatKhau.Value,
                                           Convert.ToDateTime(wdcNgaySinh.Value),
                                           (rbtNam.Checked ? true : false), txtEmail.Value, null, chkKichHoat.Checked,
                                           txtDienThoaiDiDong.Value, txtDienThoaiCoDinh.Value,
                                           Convert.ToInt32(ddlLoaiNguoiDung.SelectedValue), null, txtYM.Value, null, 1,
                                           null, null, null, null);
                }
                else
                {
                    lblTonTaiTenTruyCap.Text = "Tên truy cập đã tồn tại";
                    //ValidationSummary1.HeaderText = "Có lỗi xảy ra";
                    return;
                }
            }
            else if (ACTION == "EDIT")
            {
                if (nguoidung.CheckExistTenTruyCap(id, txtTaiKhoan.Value.Trim()) != true)
                {
                    nguoidung.UpdateFields(id, txtHoVaTen.Value, txtTaiKhoan.Value, null, (DateTime) wdcNgaySinh.Value,
                                           rbtNam.Checked ? true : false, txtEmail.Value, null, chkKichHoat.Checked,
                                           txtDienThoaiDiDong.Value, txtDienThoaiCoDinh.Value,
                                           Convert.ToInt32(ddlLoaiNguoiDung.SelectedValue), null, txtYM.Value, null,
                                           null, null, null, null, null);
                    //nguoidung.UpdateFields(id, txtHoVaTen.Value, null, txtMatKhau.Value, null,
                    //    null, txtEmail.Value, txtDienThoaiDiDong.Value, txtDienThoaiCoDinh.Value,
                    //    null, "", chkKichHoat.Checked, 1, "", 0, "", true);
                }
                else
                {
                    lblTonTaiTenTruyCap.Text = "Tên truy cập đã tồn tại";
                    //ValidationSummary1.HeaderText = "Có lỗi xảy ra";
                    return;
                }
            }
            string strScript = "<script language='JavaScript'>" + "window.parent.Refresh();</script>";
            ClientScript.RegisterStartupScript(Type.GetType("System.String"), "Refresh", strScript);
        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }
    }

    private void SendMail(string matkhau, string subject, string body)
    {
        try
        {
            if (txtEmail.Value != "")
            {
                string emailto = txtEmail.Value;
                string emailfrom = ConfigurationManager.AppSettings["EmailFrom"];
                string emailsubject = subject;
                string emailbody = body;
                string smtpserver = ConfigurationManager.AppSettings["smtpserver"];
                string emailcc = "";
                string emailbcc = "";

                emailbody = emailbody.Replace("[[name]]", txtHoVaTen.Value);
                emailbody = emailbody.Replace("[[linkkichhoat]]",
                                              "http://chonet.vn/ActivateAccount.aspx?ndid=" + id + "&activate="
                                              + hidActiveCode.Value);
                emailbody = emailbody.Replace("[[taikhoan]]", txtTaiKhoan.Value);
                emailbody = emailbody.Replace("[[password]]", matkhau);

                Common.SendMail(emailto, emailfrom, emailsubject, emailbody, smtpserver, emailcc, emailbcc);
            }
            else
            {
                Response.Redirect("../message.aspx?msg=" + "Lỗi gửi email", false);
            }
        }
        catch (Exception ex)
        {
            Response.Redirect("message.aspx?msg=" + ex.ToString().Replace("\r\n", ""), false);
        }
    }

    protected void btnReset_ServerClick(object sender, EventArgs e)
    {
        NguoiDung nd = new NguoiDung();
        nd.UpdateFields(id, txtHoVaTen.Value, txtTaiKhoan.Value, "12345", (DateTime) wdcNgaySinh.Value,
                        rbtNam.Checked ? true : false, txtEmail.Value, null, chkKichHoat.Checked,
                        txtDienThoaiDiDong.Value, txtDienThoaiCoDinh.Value,
                        Convert.ToInt32(ddlLoaiNguoiDung.SelectedValue), null, null, null, null, txtYM.Value, null, null,
                        null);

        hidmatkhau.Value = "12345";
        SendMail("12345", "Đặt lại mật khẩu từ CHONET.VN",
                 "Chúng tôi đã đặt lại mật khẩu cho bạn [[taikhoan]], mật khẩu mới là: [[password]]");
    }

    protected void btnSendMail_ServerClick(object sender, EventArgs e)
    {
        if (chkKichHoat.Checked == false)
        {
            string emailto = txtEmail.Value;
            string emailfrom = ConfigurationManager.AppSettings["EmailFrom"];
            string emailsubject = "Kích hoạt tài khoản từ CHONET.VN";
            string emailbody =
                Common.GetEmailHTMLTemplate(Server.MapPath("..") + ConfigurationManager.AppSettings["TemplateGianHang"]);
            string smtpserver = ConfigurationManager.AppSettings["smtpserver"];
            string emailcc = "";
            string emailbcc = "";
            //SendMail(hidmatkhau.Value, "Kích hoạt tài khoản từ CHONET.VN", Common.GetEmailHTMLTemplate(Server.MapPath("..") + System.Configuration.ConfigurationManager.AppSettings["TemplateGianHang"].ToString()));
            Common.SendActiveMail(txtEmail.Value, emailsubject, emailbody, txtHoVaTen.Value, id.ToString(),
                                  hidActiveCode.Value, txtTaiKhoan.Value, hidmatkhau.Value, txtEmail.Value);
        }
    }
}