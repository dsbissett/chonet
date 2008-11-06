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
using Infragistics.WebUI.UltraWebGrid;

public partial class Admin_SelectStore : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Common.LoaiNguoiDungID() == 2 || Common.LoaiNguoiDungID() == 3)
        {
            if (!Page.IsPostBack)
            {
                int sid = int.Parse(Request.QueryString["sid"]);
                if (Common.LoaiNguoiDungID() == 3)
                {
                    //Administrator
                    spanMax.InnerText = "0";
                    switch (sid)
                    {
                        case 1:
                            spanMax.InnerText = "16";
                            break;                        
                        case 11:
                            spanMax.InnerText = "9";
                            break;
                    }
                    if (spanMax.InnerText != "0")
                    {
                        if (Request.QueryString["rid"] != null)
                        {
                            int rid = int.Parse(Request.QueryString["rid"]);
                            spanSelect.InnerText = LoadCuaHang(sid, rid).ToString();
                        }
                        else
                        {
                            spanSelect.InnerText = LoadCuaHang(sid).ToString();
                        }                        
                    }
                    else
                    {
                        Response.Redirect("../message.aspx?msg=Invalid parameter");
                    }
                }
                else
                {
                    //e-Store
                    spanMax.InnerText = "0";
                    switch (sid)
                    {
                        case 51:
                            spanMax.InnerText = "3";
                            break;                        
                    }
                    if (spanMax.InnerText != "0")
                    {
                        if (Request.QueryString["rid"] != null)
                        {
                            int rid = int.Parse(Request.QueryString["rid"]);
                            spanSelect.InnerText = LoadCuaHang(sid, rid).ToString();
                        }
                        else
                        {
                            spanSelect.InnerText = LoadCuaHang(sid).ToString();
                        }  
                    }
                    else
                    {
                        Response.Redirect("../message.aspx?msg=Invalid parameter");
                    }
                }
            }
        }
        else
        {
            Response.Redirect("../message.aspx?msg=Access denied");
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {

        string sid = Request.QueryString["sid"];        
        foreach (Infragistics.WebUI.UltraWebGrid.UltraGridRow row in grdStore.Rows)
        {
            if (row.Cells.FromKey("Selected").Text == "true")
            {
                ViTriCuaHang vtch = new ViTriCuaHang();
                int cuahangID = int.Parse(row.Cells.FromKey("CuaHangID").Value.ToString());
                if (Request.QueryString["rid"] != null)
                {
                    if ((row.Cells.FromKey("KhuVucID").Text != Request.QueryString["rid"]) || (row.Cells.FromKey("ViTriCuaHang").Text != sid))
                    {
                        int rid = int.Parse("0" + Request.QueryString["rid"]);
                        vtch.InsertFields(cuahangID, int.Parse(sid), Common.NguoiDungID(), rid);
                    }
                }
                else
                {
                    if (row.Cells.FromKey("ViTriCuaHang").Text != sid)
                    {
                        //insert
                        vtch.InsertFields(cuahangID, int.Parse(sid), Common.NguoiDungID(), null);
                    }
                }
            }
            else if (row.Cells.FromKey("Selected").Text == "false")
            {
                if (row.Cells.FromKey("ViTriCuaHang").Text == sid)
                {
                    ViTriCuaHang vtch = new ViTriCuaHang();
                    int vtchID = int.Parse(row.Cells.FromKey("ViTriCuaHangID").Value.ToString());
                    vtch.Delete(vtchID);
                }
            }
        }
        if (Request.QueryString["rid"] != null)
        {
            spanSelect.InnerText = LoadCuaHang(int.Parse(sid), int.Parse(Request.QueryString["rid"])).ToString();
        }
        else
        {
            spanSelect.InnerText = LoadCuaHang(int.Parse(sid)).ToString();
        }          
    }
    private int LoadCuaHang(int ViTriCuaHang)
    {
        if (Common.LoaiNguoiDungID() == 3)
        {
            //For administrator
            CuaHang ch = new CuaHang();
            DataSet ds = ch.SelectAllCuaHangAtViTriCuaHang(ViTriCuaHang);
            
            ds.Tables[0].Columns.Add("Selected", Type.GetType("System.String"));
            ds.Tables[0].Columns["Selected"].DefaultValue = "false";
            DataRow[] selectedRows = ds.Tables[0].Select("ViTriCuaHang=" + ViTriCuaHang.ToString());
            for (int i = 0; i < selectedRows.Length; i++)
            {
                selectedRows[i]["Selected"] = "true";
            }
            grdStore.DataSource = ds;
            grdStore.DataBind();
            return selectedRows.Length;
        }
        else if (Common.LoaiNguoiDungID() == 2)
        {
            //For e-store manager 
            QuangCao qcao = new QuangCao();
            CuaHang ch = new CuaHang();
            DataSet ds = ch.SelectAllCuaHangAtViTriCuaHangByNguoiDungID(Common.NguoiDungID(), ViTriCuaHang);
            ds.Tables[0].Columns.Add("Selected", Type.GetType("System.String"));
            ds.Tables[0].Columns["Selected"].DefaultValue = "false";
            DataRow[] selectedRows = ds.Tables[0].Select("ViTriCuaHang=" + ViTriCuaHang.ToString());
            for (int i = 0; i < selectedRows.Length; i++)
            {
                selectedRows[i]["Selected"] = "true";
            }
            grdStore.DataSource = ds;
            grdStore.DataBind();
            return selectedRows.Length;
        }
        return 0;

    }
    private int LoadCuaHang(int ViTriCuaHang, int KhuVucID)
    {
        if (Common.LoaiNguoiDungID() == 3)
        {
            //For administrator
            CuaHang ch = new CuaHang();
            DataSet ds = ch.SelectAllCuaHangAtViTriCuaHang(ViTriCuaHang);
            
            ds.Tables[0].Columns.Add("Selected", Type.GetType("System.String"));
            ds.Tables[0].Columns["Selected"].DefaultValue = "false";
            DataRow[] selectedRows = ds.Tables[0].Select("ViTriCuaHang=" + ViTriCuaHang.ToString() + " AND KhuVucID=" + KhuVucID);
            for (int i = 0; i < selectedRows.Length; i++)
            {
                selectedRows[i]["Selected"] = "true";
            }
            grdStore.DataSource = ds;
            grdStore.DataBind();
            return selectedRows.Length;
        }
        else if (Common.LoaiNguoiDungID() == 2)
        {
            //For e-store manager 
            QuangCao qcao = new QuangCao();
            CuaHang ch = new CuaHang();
            DataSet ds = ch.SelectAllCuaHangAtViTriCuaHangByNguoiDungID(Common.NguoiDungID(), ViTriCuaHang);
            ds.Tables[0].Columns.Add("Selected", Type.GetType("System.String"));
            ds.Tables[0].Columns["Selected"].DefaultValue = "false";
            DataRow[] selectedRows = ds.Tables[0].Select("ViTriCuaHang=" + ViTriCuaHang.ToString() + " AND KhuVucID=" + KhuVucID);
            for (int i = 0; i < selectedRows.Length; i++)
            {
                selectedRows[i]["Selected"] = "true";
            }
            grdStore.DataSource = ds;
            grdStore.DataBind();
            return selectedRows.Length;
        }
        return 0;

    }
    protected void grdStore_InitializeLayout(object sender, Infragistics.WebUI.UltraWebGrid.LayoutEventArgs e)
    {
        e.Layout.Grid.Columns.FromKey("CheckBox").AllowRowFiltering = false;
        e.Layout.Grid.Columns.FromKey("TenCuaHang").FilterOperatorDefaultValue = FilterComparisionOperator.Contains;
        e.Layout.Grid.Columns.FromKey("Logo").AllowRowFiltering = false;
        e.Layout.Grid.Columns.FromKey("GioiThieu").FilterOperatorDefaultValue = FilterComparisionOperator.Contains;
        if (rbtTatCa.Checked == true)
        {
            e.Layout.Pager.AllowPaging = false;
        }
        else
        {
            e.Layout.Pager.AllowPaging = true;
        }
    }
    protected void grdStore_PageIndexChanged(object sender, Infragistics.WebUI.UltraWebGrid.PageEventArgs e)
    {
        int sid = int.Parse(Request.QueryString["sid"]);
        spanSelect.InnerText = LoadCuaHang(sid).ToString();
    }
    protected void btnSaveAndClose_Click(object sender, EventArgs e)
    {
        btnSave_Click(sender, e);
        string strScript = "<script language='JavaScript'>" + "window.parent.RefreshStore();</script>";
        ClientScript.RegisterStartupScript(this.GetType(), "Refresh", strScript);
    }
    protected void rbtPhanTrang_CheckedChanged(object sender, EventArgs e)
    {
        int sid = int.Parse(Request.QueryString["sid"]);
        if (Request.QueryString["rid"] != null)
        {
            int rid = int.Parse(Request.QueryString["rid"]);
            spanSelect.InnerText = LoadCuaHang(sid, rid).ToString();
        }
        else
        {
            spanSelect.InnerText = LoadCuaHang(sid).ToString();
        }
    }
    protected void rbtTatCa_CheckedChanged(object sender, EventArgs e)
    {
        int sid = int.Parse(Request.QueryString["sid"]);
        if (Request.QueryString["rid"] != null)
        {
            int rid = int.Parse(Request.QueryString["rid"]);
            spanSelect.InnerText = LoadCuaHang(sid, rid).ToString();
        }
        else
        {
            spanSelect.InnerText = LoadCuaHang(sid).ToString();
        }
    }
}
