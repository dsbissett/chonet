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
using CHONET.Common;
using CHONET.DataAccessLayer.Web;

public partial class Adm_OrderAdmin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Common.LoaiNguoiDungID() != 2) && (Common.LoaiNguoiDungID() != 3))
        {
            Response.Redirect("../message.aspx?msg=Access denied");
        }
        if (!Page.IsPostBack)
        {
            LoadData();
        }
    }
    
    private void LoadData()
    {
        int id = 0;

        if (Common.LoaiNguoiDungID() == 3)
        {
            id = 0;
        }
        else if (Common.LoaiNguoiDungID() == 2)
        {
            id = Common.NguoiDungID();
        }

        NhanXetSanPham nx = new NhanXetSanPham();
        DataSet ds = nx.SelectNhanXetSanPhamByNguoiDung(id);

        grdNhanXet.DataSource = ds.Tables[0];
        grdNhanXet.DataBind();
    }
    protected void pnlNhanXet_ContentRefresh(object sender, EventArgs e)
    {
        LoadData();
    }
}
