using System;
using System.Data;
using System.Web.UI;
using CHONET.Common;
using CHONET.DataAccessLayer.Web;

public partial class Admin_UpgradeStore : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Common.LoaiNguoiDungID() == 3)
        {
            //txtTenNhomCon.Focus();
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["sid"] != null)
                {
                    LoadData(Request.QueryString["sid"]);
                }
                //txtTenNhomSanPham.Text = Request.QueryString["ten"].ToString();
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
            CuaHang ch = new CuaHang();
            DataSet ds = ch.SelectByID(Convert.ToInt32(Id));

            if (ds.Tables[0].Rows.Count > 0)
            {
                txtTenCuaHang.Text = ds.Tables[0].Rows[0]["TenCuaHang"].ToString();
                if (ds.Tables[0].Rows[0]["LoaiCuaHang"].ToString() != "")
                {
                    ddlLoaiGianHang.SelectedValue = ds.Tables[0].Rows[0]["LoaiCuaHang"].ToString();
                }
                else
                {
                    ddlLoaiGianHang.SelectedIndex = 0;
                }
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
            CuaHang ch = new CuaHang();
            ch.UpdateFields(int.Parse(Request.QueryString["sid"]),
                            null, null, null, null, null, null,
                            null, null, null, null, null, null, null, null, null, null,
                            null, null, null, null, null, null, null,
                            short.Parse(ddlBaoDam.SelectedValue), short.Parse(ddlLoaiGianHang.SelectedValue));

            string strScript = "<script language='JavaScript'>" + "window.parent.Refresh();</script>";
            ClientScript.RegisterStartupScript(GetType(), "Refresh", strScript);
        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }
    }
}