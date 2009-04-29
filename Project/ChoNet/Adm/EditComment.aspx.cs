using System;
using System.Data;
using System.Web.UI;
using CHONET.Common;
using CHONET.DataAccessLayer.Web;

public partial class Adm_EditComment : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Common.LoaiNguoiDungID() != 1)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["cid"] != null)
                {
                    LoadData(Request.QueryString["cid"]);
                }
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
            NhanXetSanPham nx = new NhanXetSanPham();
            DataSet ds = nx.SelectByID(Convert.ToInt32(Id));

            if (ds.Tables[0].Rows.Count > 0)
            {
                txtNoiDung.Text = ds.Tables[0].Rows[0]["NoiDung"].ToString();
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
            if (txtNoiDung.Text.Trim() != "")
            {
                NhanXetSanPham nx = new NhanXetSanPham();
                if (Request.QueryString["cid"] != null)
                {
                    nx.UpdateFields(Convert.ToInt32(Request.QueryString["cid"]), null, null,
                                    null, txtNoiDung.Text);
                }
                string strScript = "<script language='JavaScript'>" + "window.parent.Refresh();</script>";
                ClientScript.RegisterStartupScript(GetType(), "Refresh", strScript);
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }
    }
}