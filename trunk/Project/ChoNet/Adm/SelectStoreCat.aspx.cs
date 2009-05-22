using System;
using System.Data;
using System.Web.UI;
using CHONET.Common;
using CHONET.DataAccessLayer.Web;
using Infragistics.WebUI.UltraWebGrid;

public partial class Adm_SelectStoreCat : Page
{
    private int CuaHangID;
    private int NhomChaID;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Common.LoaiNguoiDungID() == 2)
        {
            CuaHangID = int.Parse(Request.QueryString["sid"]);
            NhomChaID = int.Parse(Request.QueryString["did"]);
            if (!Page.IsPostBack)
            {
                LoadDanhMuc(CuaHangID, NhomChaID);
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
        foreach (UltraGridRow row in grdCat.Rows)
        {
            //int id = int.Parse(row.Cells.FromKey("NhomSanPhamID").Value.ToString());
            int NhomSanPhamID = 0;
            CuaHangNhomSanPham chnsp = new CuaHangNhomSanPham();
            if (row.Cells.FromKey("Selected").Value != null)
            {
                if (bool.Parse(row.Cells.FromKey("Selected").Value.ToString()))
                {
                    NhomSanPhamID = int.Parse(row.Cells.FromKey("NhomSanPhamID").Value.ToString());
                    chnsp.InsertFields(CuaHangID, NhomSanPhamID, null);
                }
            }
        }
        string strScript = "<script language='JavaScript'>" + "window.parent.Refresh();</script>";
        ClientScript.RegisterStartupScript(GetType(), "Refresh", strScript);
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