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
using CHONET.DataAccessLayer.Web;
using CHONET.Common;

public partial class Admin_AddProperty : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Common.LoaiNguoiDungID() == 3)
        {
            txtTenThuocTinh.Focus();
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["subid"] != null)
                {
                    LoadData(Request.QueryString["subid"].ToString());
                }
                txtTenThuocTinh.Text = Request.QueryString["ten"].ToString();
            }
        }
        else
        {
            Response.Redirect("../message.aspx?msg=Access denied");
        }
    }

    private void LoadData(string Id)
    {
        try
        {
            NhomSanPham nhomsanpham = new NhomSanPham();
            DataSet ds = nhomsanpham.SelectByID(System.Convert.ToInt32(Id));

            if (ds.Tables[0].Rows.Count > 0)
            {
                txtTenThuocTinh.Text = ds.Tables[0].Rows[0]["TenNhomSanPham"].ToString();
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
            ThuocTinh tt = new ThuocTinh();
            if (Request.QueryString["pid"] == null)
            {
                tt.InsertFields(int.Parse(ddlNhomSanPham.SelectedValue), txtTenThuocTinh.Text, null);
            }
            else
            {
                tt.UpdateFields(System.Convert.ToInt32(Request.QueryString["pid"].ToString()), int.Parse(ddlNhomSanPham.SelectedValue), txtTenThuocTinh.Text, null);
            }
            string strScript = "<script language='JavaScript'>" + "window.parent.RefreshCat();</script>";
            ClientScript.RegisterStartupScript(this.GetType(), "Refresh", strScript);
        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }        
    }
}
