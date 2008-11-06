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

public partial class Adm_SelectStoreCat : System.Web.UI.Page
{
    int CuaHangID = 0;
    int NhomChaID = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Common.LoaiNguoiDungID() == 2)
        {
            CuaHangID = int.Parse(Request.QueryString["sid"].ToString());
            NhomChaID = int.Parse(Request.QueryString["did"].ToString());
            if (!Page.IsPostBack)
            {
                LoadDanhMuc(CuaHangID, NhomChaID );                
            }
        }
        else
        {
            Response.Redirect("../message.aspx?msg=Access denied"); 
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        //int firstCatId = 0;
        foreach (Infragistics.WebUI.UltraWebGrid.UltraGridRow row in grdCat.Rows)
        {
            //int id = int.Parse(row.Cells.FromKey("NhomSanPhamID").Value.ToString());
            int NhomSanPhamID = 0;
            CuaHangNhomSanPham chnsp = new CuaHangNhomSanPham();
            if (row.Cells.FromKey("Selected").Value != null)
            {
                if (bool.Parse(row.Cells.FromKey("Selected").Value.ToString()) == true)
                {
                    NhomSanPhamID = int.Parse(row.Cells.FromKey("NhomSanPhamID").Value.ToString());
                    chnsp.InsertFields(CuaHangID, NhomSanPhamID);
                }
            }                   
        }
        string strScript = "<script language='JavaScript'>" + "window.parent.Refresh();</script>";
        ClientScript.RegisterStartupScript(this.GetType(), "Refresh", strScript);
    }
    private void LoadDanhMuc(int CuaHangid, int NhomChaID)
    {
        NhomSanPham nsp = new NhomSanPham();
        DataSet ds = nsp.SelectNhomSanPhamNotInCuaHangbyCuaHangID(CuaHangid, NhomChaID);
        DataRow[] selectedRows = ds.Tables[0].Select("Show=true");
        grdCat.DataSource = ds;
        grdCat.DataBind();
        //return selectedRows.Length;
    }

}
