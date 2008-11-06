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

public partial class Adm_SelectCatRegion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Common.LoaiNguoiDungID() == 3)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["rid"] != null)
                {
                    int rid = int.Parse(Request.QueryString["rid"]);
                    spanSelect.InnerText = LoadDanhMuc(rid).ToString();
                }                
                
                spanMax.InnerText = "4";
            }
        }
        else
        {
            Response.Redirect("../message.aspx?msg=Access denied"); 
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        int firstCatId = 0;
        foreach (Infragistics.WebUI.UltraWebGrid.UltraGridRow row in grdCat.Rows)
        {
            int id = int.Parse(row.Cells.FromKey("NhomSanPhamID").Value.ToString());
            NhomSanPham nsp = new NhomSanPham();
            if (Request.QueryString["rid"] != null)
            {
                int rid = int.Parse(Request.QueryString["rid"]);
                if ((row.Cells.FromKey("Selected").Text != null) && (bool.Parse(row.Cells.FromKey("Selected").Text) == true))
                nsp.UpdateFields(id, null, null, null, null, null, null, null, null, null, null, rid);
                else
                nsp.UpdateFields(id, null, null, null, null, null, null, null, null, null, null, 0);
            }
                        
            if (firstCatId == 0)
            {
                if ((row.Cells.FromKey("Selected").Text != null) && (bool.Parse(row.Cells.FromKey("Selected").Text) == true)) firstCatId = id;
            }
        }
        string strScript = "<script language='JavaScript'>" + "window.parent.RefreshProduct04(" + firstCatId.ToString() + ");</script>";
        ClientScript.RegisterStartupScript(this.GetType(), "Refresh", strScript);
    }
  
    private int LoadDanhMuc(int KhuVucID)
    {
        NhomSanPham nsp = new NhomSanPham();
        DataSet ds = nsp.SelectNhomSanPhamByNhomChaID(0);
        DataRow[] selectedRows = ds.Tables[0].Select("KhuVucShow=" + KhuVucID);
        ds.Tables[0].Columns.Add("Selected", Type.GetType("System.String"));
        ds.Tables[0].Columns["Selected"].DefaultValue = "false";
        for (int i = 0; i < selectedRows.Length; i++)
        {
            selectedRows[i]["Selected"] = "True";
        }
        grdCat.DataSource = ds;
        grdCat.DataBind();
        return selectedRows.Length;
    }
}