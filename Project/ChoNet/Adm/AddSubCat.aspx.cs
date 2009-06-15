using System;
using System.Data;
using System.Web.UI;
using CHONET.Common;
using CHONET.DataAccessLayer.Web;

public partial class Admin_AddSubCat : Page
{
    private string CuaHangID="0";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Common.LoaiNguoiDungID() == 3)
        {
            txtTenNhomCon.Focus();
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["subid"] != null)
                {
                    LoadData(Request.QueryString["subid"]);
                }
                txtTenNhomSanPham.Text = Request.QueryString["ten"];
            }
        }
        else if (Common.LoaiNguoiDungID()==2)
        {
            txtTenNhomCon.Focus();
            if (Request.QueryString["sid"] != null)
            {
                CuaHangID = Request.QueryString["sid"];
            }
            if (!Page.IsPostBack)
            {               
                if (Request.QueryString["id"] != null)
                {
                    LoadDataForCuaHang(Request.QueryString["id"]);
                }
                txtTenNhomSanPham.Text = Request.QueryString["ten"];
            } 
        }
        else
        {
            Response.Redirect("../message.aspx?msg=Access denied");
        }
    }

    private void LoadDataForCuaHang(string Id)
    {
        try
        {
            NhomSanPhamCuaHang nhomsanpham = new NhomSanPhamCuaHang();
            DataSet ds = nhomsanpham.SelectByID(Convert.ToInt32(Id));

            if (ds.Tables[0].Rows.Count > 0)
            {
                txtTenNhomCon.Text = ds.Tables[0].Rows[0]["TenNhomSanPham"].ToString();
                txtThuTu.Text = ds.Tables[0].Rows[0]["SapXep"].ToString();
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }
    }

    private void LoadData(string Id)
    {
        try
        {
            NhomSanPham nhomsanpham = new NhomSanPham();
            DataSet ds = nhomsanpham.SelectByID(Convert.ToInt32(Id));

            if (ds.Tables[0].Rows.Count > 0)
            {
                txtTenNhomCon.Text = ds.Tables[0].Rows[0]["TenNhomSanPham"].ToString();
                txtThuTu.Text = ds.Tables[0].Rows[0]["SapXep"].ToString();
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
            if (Common.LoaiNguoiDungID() == 3)
            {
                NhomSanPham nhomsanpham = new NhomSanPham();
                if (Request.QueryString["subid"] == null)
                {
                    nhomsanpham.InsertFields(txtTenNhomCon.Text, null, Convert.ToInt32(Request.QueryString["id"]), false,
                                             Convert.ToInt32(txtThuTu.Text), null, null, null, null, null, null);
                }
                else
                {
                    nhomsanpham.UpdateFields(Convert.ToInt32(Request.QueryString["subid"]), txtTenNhomCon.Text, null,
                                             Convert.ToInt32(Request.QueryString["id"]), null,
                                             Convert.ToInt32(txtThuTu.Text), null, null, null, null, null, null);
                }
            }
            else if (Common.LoaiNguoiDungID()==2)
            {
                NhomSanPhamCuaHang nhomsanpham = new NhomSanPhamCuaHang();
                if (Request.QueryString["subid"] == null)
                {
                    nhomsanpham.InsertFields(Convert.ToInt32(Request.QueryString["id"]), 0
                        , Convert.ToInt32(txtThuTu.Text), int.Parse(CuaHangID), txtTenNhomCon.Text);
                }
                else
                {
                    nhomsanpham.UpdateFields(Convert.ToInt32(Request.QueryString["subid"]),
                                             Convert.ToInt32(Request.QueryString["id"]), 0,
                                             Convert.ToInt32(txtThuTu.Text), null, txtTenNhomCon.Text);
                }
            }
            string strScript = "<script language='JavaScript'>" + "window.parent.RefreshCat();</script>";
            ClientScript.RegisterStartupScript(GetType(), "Refresh", strScript);
        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }
    }
}