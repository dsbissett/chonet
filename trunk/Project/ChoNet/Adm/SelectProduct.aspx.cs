using System;
using System.Data;
using System.Web.UI;
using CHONET.Common;
using CHONET.DataAccessLayer.Web;
using Infragistics.WebUI.UltraWebGrid;

public partial class Adm_SelectProduct : Page
{
    private int PageSize = 10;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Common.LoaiNguoiDungID() == 2 || Common.LoaiNguoiDungID() == 3)
        {
            if (!Page.IsPostBack)
            {
                int pid = int.Parse(Request.QueryString["pid"]);
                if (Common.LoaiNguoiDungID() == 3)
                {
                    //Administrator
                    spanMax.InnerText = "0";
                    switch (pid)
                    {
                        case 1:
                            spanMax.InnerText = "1";
                            break;
                        case 2:
                            spanMax.InnerText = "5";
                            break;
                        case 3:
                            spanMax.InnerText = "4";
                            break;
                        case 4:
                            spanMax.InnerText = "12";
                            break;
                        case 5:
                            spanMax.InnerText = "12";
                            break;
                        case 6:
                            spanMax.InnerText = "6";
                            break;
                        case 7:
                            spanMax.InnerText = "12";
                            break;
                        case 11:
                            spanMax.InnerText = "5";
                            break;
                        case 12:
                            spanMax.InnerText = "4";
                            break;
                        case 13:
                            spanMax.InnerText = "12";
                            break;
                        case 14:
                            spanMax.InnerText = "12";
                            break;
                        case 21:
                            spanMax.InnerText = "1";
                            break;
                        case 22:
                            spanMax.InnerText = "4";
                            break;
                    }
                    if (spanMax.InnerText != "0")
                    {
                        if (Request.QueryString["rid"] != null)
                        {
                            int rid = int.Parse(Request.QueryString["rid"]);
                            spanSelect.InnerText = LoadSanPham(pid, rid, 1).ToString();
                        }
                        else
                        {
                            spanSelect.InnerText = LoadSanPham(pid, 1, 1).ToString();
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
                    switch (pid)
                    {
                        case 31:
                            spanMax.InnerText = "10";
                            break;
                        case 32:
                            spanMax.InnerText = "5";
                            break;
                    }
                    if (spanMax.InnerText != "0")
                    {
                        if (Request.QueryString["rid"] != null)
                        {
                            int rid = int.Parse(Request.QueryString["rid"]);
                            spanSelect.InnerText = LoadSanPham(pid, rid, 1).ToString();
                        }
                        else
                        {
                            spanSelect.InnerText = LoadSanPham(pid, 1, 1).ToString();
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
        string pid = Request.QueryString["pid"];
        int cid = 0; //categoryID
        string rid = Request.QueryString["rid"] ?? "";
        if (Request.QueryString["cid"] != null) cid = int.Parse(Request.QueryString["cid"]);
        int sid = 0; //storeID RESERVED
        foreach (UltraGridRow row in grdProduct.Rows)
        {
            if (row.Cells.FromKey("Selected").Text == "true")
            {
                ViTriSanPham vtsp = new ViTriSanPham();
                int sanphamID = int.Parse(row.Cells.FromKey("SanPhamID").Value.ToString());

                if (rid != "")
                {
                    if ((row.Cells.FromKey("ViTriSanPham").Text != pid) ||
                        (row.Cells.FromKey("ViTriSanPham").Text != rid))
                    {
                        vtsp.InsertFields(sanphamID, int.Parse(pid), sid, int.Parse(rid));
                    }
                }
                else
                {
                    if (row.Cells.FromKey("ViTriSanPham").Text != pid)
                    {
                        vtsp.InsertFields(sanphamID, int.Parse(pid), sid, null);
                    }
                }
            }
            else if (row.Cells.FromKey("Selected").Text == "false")
            {
                if (row.Cells.FromKey("ViTriSanPham").Text == pid)
                {
                    ViTriSanPham vtsp = new ViTriSanPham();
                    int vtspID = int.Parse(row.Cells.FromKey("ViTriSanPhamID").Value.ToString());
                    vtsp.Delete(vtspID);
                }
            }
        }

        if (Request.QueryString["rid"] != null)
        {
            //int rid = int.Parse(Request.QueryString["rid"]);
            spanSelect.InnerText =
                LoadSanPham(int.Parse(pid), int.Parse(rid), grdProduct.DisplayLayout.Pager.CurrentPageIndex).ToString();
        }
        else
        {
            spanSelect.InnerText =
                LoadSanPham(int.Parse(pid), grdProduct.DisplayLayout.Pager.CurrentPageIndex).ToString();
        }
    }

    private int LoadSanPham(int pid, int CurrentPage)
    {
        int RowStart = (CurrentPage - 1)*PageSize + 1;
        SanPham sp = new SanPham();
        DataSet ds = null;
        DataRow[] selectedRows = null;
        if (Common.LoaiNguoiDungID() == 3)
        {
            //Administrator
            if (pid == 4 || pid == 11 || pid == 12 || pid == 13 || pid == 14)
            {
                int cid = int.Parse(Request.QueryString["cid"]);
                ds = sp.SelectAllSanPhamAtViTriSanPhamInNhomSanPhamIDPaging(pid, cid, RowStart, PageSize);
                ds.Tables[0].Columns.Add("Selected", Type.GetType("System.String"));
                ds.Tables[0].Columns["Selected"].DefaultValue = "false";
                selectedRows = ds.Tables[0].Select("KhuVucID is null AND ViTriSanPham=" + pid);
                for (int i = 0; i < selectedRows.Length; i++)
                {
                    selectedRows[i]["Selected"] = "true";
                }
                ds.Tables[0].DefaultView.Sort = "SanPhamID DESC";
            }
            else
            {
                ds = sp.SelectAllSanPhamAtViTriSanPhamPaging(pid, RowStart, PageSize);

                ds.Tables[0].Columns.Add("Selected", Type.GetType("System.String"));
                ds.Tables[0].Columns["Selected"].DefaultValue = "false";
                selectedRows = ds.Tables[0].Select("KhuVucID is null AND ViTriSanPham=" + pid);
                for (int i = 0; i < selectedRows.Length; i++)
                {
                    selectedRows[i]["Selected"] = "true";
                }
                ds.Tables[0].DefaultView.Sort = "SanPhamID DESC";
            }
        }
        else if (Common.LoaiNguoiDungID() == 2)
        {
            //e-Store            
            ds = sp.SelectAllSanPhamAtViTriSanPhamByNguoiDungIDPaging(pid, Common.NguoiDungID(), RowStart, PageSize);
            ds.Tables[0].Columns.Add("Selected", Type.GetType("System.String"));
            ds.Tables[0].Columns["Selected"].DefaultValue = "false";
            selectedRows = ds.Tables[0].Select("KhuVucID is null AND ViTriSanPham=" + pid);
            for (int i = 0; i < selectedRows.Length; i++)
            {
                selectedRows[i]["Selected"] = "true";
            }
            ds.Tables[0].DefaultView.Sort = "SanPhamID DESC";
        }

        int NoOfPage = (int) Math.Ceiling(double.Parse(ds.Tables[1].Rows[0][0].ToString())/PageSize);

        grdProduct.DisplayLayout.Pager.PageCount = NoOfPage;

        string[] custompages = new string[NoOfPage];
        for (int i = 0; i < NoOfPage; i++)
        {
            custompages[i] = (i + 1).ToString();
        }
        grdProduct.DisplayLayout.Pager.CustomLabels = custompages;

        grdProduct.DataSource = ds.Tables[0].DefaultView;
        grdProduct.DataBind();
        if (selectedRows != null)
            return selectedRows.Length;

        return 0;
    }

    private int LoadSanPham(int pid, int KhuVucID, int CurrentPage)
    {
        int RowStart = (CurrentPage - 1)*PageSize + 1;
        DataRow[] selectedRows = null;
        SanPham sp = new SanPham();
        DataSet ds = null;
        if (Common.LoaiNguoiDungID() == 3)
        {
            //Administrator
            if (pid == 4 || pid == 11 || pid == 12 || pid == 13 || pid == 14)
            {
                int cid = int.Parse(Request.QueryString["cid"]);
                ds = sp.SelectAllSanPhamAtViTriSanPhamInNhomSanPhamIDPaging(pid, cid, RowStart, PageSize);
                ds.Tables[0].Columns.Add("Selected", Type.GetType("System.String"));
                ds.Tables[0].Columns["Selected"].DefaultValue = "false";
                selectedRows = ds.Tables[0].Select("ViTriSanPham=" + pid + " AND KhuVucID=" + KhuVucID);
                for (int i = 0; i < selectedRows.Length; i++)
                {
                    selectedRows[i]["Selected"] = "true";
                }
                ds.Tables[0].DefaultView.Sort = "SanPhamID DESC";
            }
            else
            {
                ds = sp.SelectAllSanPhamAtViTriSanPhamPaging(pid, RowStart, PageSize);

                ds.Tables[0].Columns.Add("Selected", Type.GetType("System.String"));
                ds.Tables[0].Columns["Selected"].DefaultValue = "false";
                selectedRows = ds.Tables[0].Select("ViTriSanPham=" + pid + " AND KhuVucID=" + KhuVucID);
                for (int i = 0; i < selectedRows.Length; i++)
                {
                    selectedRows[i]["Selected"] = "true";
                }
                ds.Tables[0].DefaultView.Sort = "SanPhamID DESC";
            }
        }
        else if (Common.LoaiNguoiDungID() == 2)
        {
            //e-Store      
            ds = sp.SelectAllSanPhamAtViTriSanPhamByNguoiDungIDPaging(pid, Common.NguoiDungID(), RowStart, PageSize);
            ds.Tables[0].Columns.Add("Selected", Type.GetType("System.String"));
            ds.Tables[0].Columns["Selected"].DefaultValue = "false";
            selectedRows = ds.Tables[0].Select("ViTriSanPham=" + pid + " AND KhuVucID=" + KhuVucID);
            for (int i = 0; i < selectedRows.Length; i++)
            {
                selectedRows[i]["Selected"] = "true";
            }
            ds.Tables[0].DefaultView.Sort = "SanPhamID DESC";
        }

        int NoOfPage = (int) Math.Ceiling(double.Parse(ds.Tables[1].Rows[0][0].ToString())/PageSize);

        grdProduct.DisplayLayout.Pager.PageCount = NoOfPage;

        string[] custompages = new string[NoOfPage];
        for (int i = 0; i < NoOfPage; i++)
        {
            custompages[i] = (i + 1).ToString();
        }
        grdProduct.DisplayLayout.Pager.CustomLabels = custompages;

        grdProduct.DataSource = ds.Tables[0].DefaultView;
        grdProduct.DataBind();
        if (selectedRows != null)
            return selectedRows.Length;

        return 0;
    }

    private int LoadSanPhamByNguoiDungID(int pid, int NguoiDungID, int CurrentPage)
    {
        int RowStart = (CurrentPage - 1)*PageSize + 1;
        SanPham sp = new SanPham();
        DataSet ds = null;
        DataRow[] selectedRows = null;
        if (Common.LoaiNguoiDungID() == 2)
        {
            //e-Store
            ds = sp.SelectAllSanPhamAtViTriSanPhamByNguoiDungIDPaging(pid, Common.NguoiDungID(), RowStart, PageSize);
            ds.Tables[0].Columns.Add("Selected", Type.GetType("System.String"));
            ds.Tables[0].Columns["Selected"].DefaultValue = "false";
            selectedRows = ds.Tables[0].Select("ViTriSanPham=" + pid);
            for (int i = 0; i < selectedRows.Length; i++)
            {
                selectedRows[i]["Selected"] = "true";
            }

            ds.Tables[0].DefaultView.Sort = "SanPhamID DESC";
            int NoOfPage = (int) Math.Ceiling(double.Parse(ds.Tables[1].Rows[0][0].ToString())/PageSize);

            grdProduct.DisplayLayout.Pager.PageCount = NoOfPage;

            string[] custompages = new string[NoOfPage];
            for (int i = 0; i < NoOfPage; i++)
            {
                custompages[i] = (i + 1).ToString();
            }
            grdProduct.DisplayLayout.Pager.CustomLabels = custompages;

            grdProduct.DataSource = ds.Tables[0].DefaultView;
            grdProduct.DataBind();

            return selectedRows.Length;
        }
        return 0;
    }

    protected void grdProduct_PageIndexChanged(object sender, PageEventArgs e)
    {
        spanSelect.InnerText = LoadSanPham(int.Parse(Request.QueryString["pid"]), e.NewPageIndex).ToString();
    }

    protected void btnSaveAndClose_Click(object sender, EventArgs e)
    {
        btnSave_Click(sender, e);
        string pid = Request.QueryString["pid"];
        int cid = 0; //categoryID
        if (Request.QueryString["cid"] != null) cid = int.Parse(Request.QueryString["cid"]);
        string strScript = "";
        if (pid == "4")
        {
            strScript = "<script language='JavaScript'>" + "window.parent.RefreshProduct04(" + cid + ");</script>";
        }
        else
        {
            strScript = "<script language='JavaScript'>" + "window.parent.RefreshProduct(" + pid + ");</script>";
        }

        ClientScript.RegisterStartupScript(GetType(), "Refresh", strScript);
    }

    protected void rbtPhanTrang_CheckedChanged(object sender, EventArgs e)
    {
        if (Request.QueryString["rid"] != null)
        {
            int rid = int.Parse(Request.QueryString["rid"]);
            spanSelect.InnerText =
                LoadSanPham(int.Parse(Request.QueryString["pid"]), rid, grdProduct.DisplayLayout.Pager.CurrentPageIndex)
                    .ToString();
        }
        else
        {
            spanSelect.InnerText =
                LoadSanPham(int.Parse(Request.QueryString["pid"]), grdProduct.DisplayLayout.Pager.CurrentPageIndex).
                    ToString();
        }
    }

    protected void grdProduct_InitializeLayout(object sender, LayoutEventArgs e)
    {
        e.Layout.Grid.Columns.FromKey("CheckBox").AllowRowFiltering = false;
        e.Layout.Grid.Columns.FromKey("TenSanPham").FilterOperatorDefaultValue = FilterComparisionOperator.Contains;
        e.Layout.Grid.Columns.FromKey("Anh").AllowRowFiltering = false;
        e.Layout.Grid.Columns.FromKey("DonViTienTe").AllowRowFiltering = false;
        e.Layout.Grid.Columns.FromKey("TenCuaHang").FilterOperatorDefaultValue = FilterComparisionOperator.Contains;
        e.Layout.Grid.Columns.FromKey("TenNhomSanPham").FilterOperatorDefaultValue = FilterComparisionOperator.Contains;
        if (rbtTatCa.Checked)
        {
            e.Layout.Pager.AllowPaging = false;
        }
        else
        {
            e.Layout.Pager.AllowPaging = true;
        }
    }

    protected void rbtTatCa_CheckedChanged(object sender, EventArgs e)
    {
        if (Request.QueryString["rid"] != null)
        {
            int rid = int.Parse(Request.QueryString["rid"]);
            spanSelect.InnerText = LoadSanPham(int.Parse(Request.QueryString["pid"]), rid, 0).ToString();
        }
        else
        {
            spanSelect.InnerText = LoadSanPham(int.Parse(Request.QueryString["pid"]), 0).ToString();
        }
    }
}