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

public partial class Admin_UpgradeStore : System.Web.UI.Page
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
                    LoadData(Request.QueryString["sid"].ToString());
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
            DataSet ds = ch.SelectByID(System.Convert.ToInt32(Id));

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
            ch.UpdateFields(int.Parse(Request.QueryString["sid"].ToString()), null, null, null, null, null, null,
            null, null, null, null, null, null, null, null, null, null,
            null, null, null, null, null, null, null, short.Parse(ddlBaoDam.SelectedValue), short.Parse(ddlLoaiGianHang.SelectedValue));

            string strScript = "<script language='JavaScript'>" + "window.parent.Refresh();</script>";
            ClientScript.RegisterStartupScript(this.GetType(), "Refresh", strScript);
        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }        
    }
}
