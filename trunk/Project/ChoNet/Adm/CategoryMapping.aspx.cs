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
public partial class Adm_CategoryMapping : System.Web.UI.Page
{
    private int CuaHangID;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            CuaHangID = int.Parse(Session["CuaHangID"].ToString());                       
            BindToGrid();
        }

    }

    private void BindToGrid()
    {
        NhomSanPham nsp = new NhomSanPham();

        DataSet ds = nsp.SelectNhomSanPhamByCuaHangID(CuaHangID);

        grvNhomSanPham.DataSource = ds.Tables[0];
        grvNhomSanPham.DataBind();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        CuaHangNhomSanPham chnsp = new CuaHangNhomSanPham();
        for(int i = 0; i< grvNhomSanPham.Rows.Count; i++ )
        {
            TextBox txt = (TextBox) grvNhomSanPham.Rows[i].Cells[2].FindControl("txtDisplayName");
            if (txt != null)
            chnsp.UpdateFields(int.Parse(grvNhomSanPham.DataKeys[i].Value.ToString()), null, null, txt.Text);
        }
    }
}
