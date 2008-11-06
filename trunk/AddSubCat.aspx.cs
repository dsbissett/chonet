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

public partial class Admin_AddSubCat : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Common.LoaiNguoiDungID() == 3)
        {
            txtTenNhomCon.Focus();
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["subid"] != null)
                {
                    LoadData(Request.QueryString["subid"].ToString());
                }
                txtTenNhomSanPham.Text = Request.QueryString["ten"].ToString();
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
            NhomSanPham nhomsanpham = new NhomSanPham();
            if (Request.QueryString["subid"] == null)
            {
                nhomsanpham.InsertFields(txtTenNhomCon.Text, null, System.Convert.ToInt32(Request.QueryString["id"].ToString()), false,
                    System.Convert.ToInt32(txtThuTu.Text), null, null, null, null, null, null);
            }
            else
            {
                nhomsanpham.UpdateFields(System.Convert.ToInt32(Request.QueryString["subid"].ToString()),txtTenNhomCon.Text, null, 
                    System.Convert.ToInt32(Request.QueryString["id"].ToString()), null,
                    System.Convert.ToInt32(txtThuTu.Text), null, null, null, null, null, null);
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
