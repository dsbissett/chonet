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

public partial class Adm_AskAnswerAdmin : System.Web.UI.Page
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

        HoiDapSanPham hd = new HoiDapSanPham();
        DataSet ds = hd.SelectHoiDapSanPhamByNguoiDung(id);

        grdHoiDap.DataSource = ds.Tables[0];
        grdHoiDap.DataBind();
    }
    protected void pnlHoiDap_ContentRefresh(object sender, EventArgs e)
    {
        LoadData();
    }
}
