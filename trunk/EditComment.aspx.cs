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

public partial class Adm_EditComment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Common.LoaiNguoiDungID() != 1)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["cid"] != null)
                {
                    LoadData(Request.QueryString["cid"].ToString());
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
            DataSet ds = nx.SelectByID(System.Convert.ToInt32(Id));

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
                    nx.UpdateFields(System.Convert.ToInt32(Request.QueryString["cid"].ToString()), null, null,
                        null, txtNoiDung.Text);
                }
                string strScript = "<script language='JavaScript'>" + "window.parent.Refresh();</script>";
                ClientScript.RegisterStartupScript(this.GetType(), "Refresh", strScript);
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }
    }
}
