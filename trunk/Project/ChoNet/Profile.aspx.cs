using System;
using System.Data;
using System.Web.UI;
using CHONET.Common;
using CHONET.DataAccessLayer.Web;

public partial class Admin_Profile : Page
{
    private int uid;

    protected void Page_Load(object sender, EventArgs e)
    {
        uid = Common.NguoiDungID();

        if (!Page.IsPostBack)
        {
            LoadData();
            //btnLuu.Attributes.Add("onclick", "return btnLuu_Click()");
            txtHoVaTen.Focus();
        }
    }

    private void LoadData()
    {
        try
        {
            NguoiDung nguoidung = new NguoiDung();
            DataSet ds = nguoidung.SelectByID(uid);

            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                txtHoVaTen.Text = dr["HoVaTen"].ToString();
                txtEmail.Text = dr["Email"].ToString();
                txtDiaChi.Text = dr["DiaChi"].ToString();
                txtDienThoaiCoDinh.Text = dr["DienThoaiCoDinh"].ToString();
                txtDienThoaiDiDong.Text = dr["DienThoaiDiDong"].ToString();
                txtSoChungMinhThu.Text = dr["SoChungMinhThu"].ToString();
                txtYM.Text = dr["YM"].ToString();

                if (dr["GioiTinh"].ToString() != "")
                {
                    rbtGioiTinhNam.Checked = bool.Parse(dr["GioiTinh"].ToString());
                }
                hidMatKhau.Value = dr["MatKhau"].ToString();
                if (dr["NgaySinh"].ToString() != "")
                {
                    wdcNgaySinh.Value = DateTime.Parse(dr["NgaySinh"].ToString());
                }
                else
                {
                    wdcNgaySinh.Value = DateTime.Now.AddYears(-30);
                }
                txtTaiKhoan.Text = dr["TaiKhoan"].ToString();
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }
    }

    protected void btnLuu_Click(object sender, EventArgs e)
    {
        try
        {
            NguoiDung nguoidung = new NguoiDung();


            nguoidung.UpdateFields(uid, txtHoVaTen.Text, txtTaiKhoan.Text, null,
                                   DateTime.Parse(wdcNgaySinh.Value.ToString()), rbtGioiTinhNam.Checked ? true : false,
                                   txtEmail.Text, null, null, txtDienThoaiDiDong.Text, txtDienThoaiCoDinh.Text, null,
                                   txtDiaChi.Text,
                                   txtYM.Text, txtSoChungMinhThu.Text.Trim(), null, null, null, null, null);

            lblInform.Text = "Thông tin của bạn đã được cập nhật";
            LoadData();
        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }
    }
}