using System;
using System.Data;
using System.Web.UI;
using CHONET.Common;
using CHONET.DataAccessLayer.Web;
using Infragistics.WebUI.UltraWebGrid;

public partial class Admin_SelectAdv : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Common.LoaiNguoiDungID() == 2 || Common.LoaiNguoiDungID() == 3)
        {
            if (!Page.IsPostBack)
            {
                int aid = int.Parse(Request.QueryString["aid"]);
                if (Common.LoaiNguoiDungID() == 3)
                {
                    //    //Administrator
                    //    spanMax.InnerText = "0";
                    //    switch (aid)
                    //    {
                    //        case 1:
                    //            spanMax.InnerText = "1";
                    //            break;
                    //        case 2:
                    //            spanMax.InnerText = "1";
                    //            break;
                    //        case 3:
                    //            spanMax.InnerText = "2";
                    //            break;
                    //        case 4:
                    //            spanMax.InnerText = "2";
                    //            break;
                    //        case 5:
                    //            spanMax.InnerText = "2";
                    //            break;
                    //        case 6:
                    //            spanMax.InnerText = "5";
                    //            break;
                    //        case 7:
                    //            spanMax.InnerText = "2";
                    //            break;
                    //        case 8:
                    //            spanMax.InnerText = "2";
                    //            break;
                    //        case 9:
                    //            spanMax.InnerText = "2";
                    //            break;
                    //        case 10:
                    //            spanMax.InnerText = "1";
                    //            break;
                    //        case 11:
                    //            spanMax.InnerText = "1";
                    //            break;
                    //        case 12:
                    //            spanMax.InnerText = "1";
                    //            break;
                    //        case 13:
                    //            spanMax.InnerText = "4";
                    //            break;
                    //        case 23:
                    //            spanMax.InnerText = "1";
                    //            break;
                    //        case 22:
                    //            spanMax.InnerText = "4";
                    //            break;
                    //    }
                    //if (spanMax.InnerText != "0")
                    //{                                                
                    if (Request.QueryString["rid"] != null)
                    {
                        int rid = int.Parse(Request.QueryString["rid"]);
                        spanSelect.InnerText = LoadQuangCaoByKhuVuc(aid, rid).ToString();
                    }
                    else
                    {
                        if (aid == 11 || aid == 12 || aid == 13)
                        {
                            int cid = int.Parse(Request.QueryString["cid"]);
                            spanSelect.InnerText = LoadQuangCao(aid, cid).ToString();
                        }
                        else
                        {
                            spanSelect.InnerText = LoadQuangCao(aid).ToString();
                        }
                    }
                    //}
                    //else
                    //{
                    //Response.Redirect("../message.aspx?msg=Invalid parameter");
                    //}
                }
                else
                {
                    //e-Store
                    //spanMax.InnerText = "0";
                    //switch (aid)
                    //{
                    //    //case 31:
                    //    //    spanMax.InnerText = "1";
                    //    //    break;
                    //    //case 32:
                    //    //    spanMax.InnerText = "4";
                    //    //    break;
                    //    case 41:
                    //        spanMax.InnerText = "1";
                    //        break;
                    //    case 42:
                    //        spanMax.InnerText = "3";
                    //        break;
                    //    case 51:
                    //        spanMax.InnerText = "1";
                    //        break;
                    //    case 52:
                    //        spanMax.InnerText = "1";
                    //        break;
                    //    case 53:
                    //        spanMax.InnerText = "1";
                    //        break;
                    //    case 54:
                    //        spanMax.InnerText = "1";
                    //        break;
                    //}
                    //if (spanMax.InnerText != "0")
                    //{
                    spanSelect.InnerText = LoadQuangCao(aid).ToString();
                    //}
                    //else
                    //{
                    //    Response.Redirect("../message.aspx?msg=Invalid parameter");
                    //}
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
        string aid = Request.QueryString["aid"];
        string cid = Request.QueryString["cid"];
        string rid = Request.QueryString["rid"] ?? "";
        foreach (UltraGridRow row in grdAdv.Rows)
        {
            if (row.Cells.FromKey("Selected").Text == "true")
            {
                ViTriQuangCao vtqc = new ViTriQuangCao();
                int quangcaoID = int.Parse(row.Cells.FromKey("QuangCaoID").Value.ToString());
                if (rid != "")
                {
                    if ((row.Cells.FromKey("ViTriQuangCao").Text != aid) || (row.Cells.FromKey("KhuVucID").Text != rid))
                    {
                        vtqc.InsertFields(quangcaoID, int.Parse(aid), int.Parse("0" + cid), int.Parse(rid), null);
                    }
                }
                else
                {
                    if (row.Cells.FromKey("ViTriQuangCao").Text != aid)
                    {
                        //insert                                                
                        if (aid == "11" || aid == "12" || aid == "13")
                        {
                            vtqc.InsertFields(quangcaoID, int.Parse(aid), int.Parse(cid), null, null);
                        }
                        else
                        {
                            vtqc.InsertFields(quangcaoID, int.Parse(aid), null, null, null);
                        }
                    }
                    else if (row.Cells.FromKey("KhuVucID").Text != null)
                    {
                        if (aid == "11" || aid == "12" || aid == "13")
                        {
                            vtqc.InsertFields(quangcaoID, int.Parse(aid), int.Parse(cid), null, null);
                        }
                        else
                        {
                            vtqc.InsertFields(quangcaoID, int.Parse(aid), null, null, null);
                        }
                    }
                }
            }
            else if (row.Cells.FromKey("Selected").Text == "false")
            {
                if (row.Cells.FromKey("ViTriQuangCao").Text == aid)
                {
                    ViTriQuangCao vtqc = new ViTriQuangCao();
                    int vtqcID = int.Parse(row.Cells.FromKey("ViTriQuangCaoID").Value.ToString());
                    vtqc.Delete(vtqcID);
                }
            }
        }
        if (Request.QueryString["rid"] != null)
        {
            int id = int.Parse(Request.QueryString["rid"]);
            spanSelect.InnerText = LoadQuangCaoByKhuVuc(int.Parse(aid), id).ToString();
        }
        else
        {
            if (aid == "11" || aid == "12" || aid == "13")
            {
                spanSelect.InnerText = LoadQuangCao(int.Parse(aid), int.Parse(cid)).ToString();
            }
            else
            {
                spanSelect.InnerText = LoadQuangCao(int.Parse(aid)).ToString();
            }
        }
    }

    private int LoadQuangCaoByKhuVuc(int ViTriQuangCao, int KhuVucID)
    {
        if (Common.LoaiNguoiDungID() == 3)
        {
            //For administrator
            QuangCao qcao = new QuangCao();
            DataSet ds = qcao.SelectAllQuangCaoAtViTriQuangCaoByLoaiNguoiDungID(Common.LoaiNguoiDungID(), ViTriQuangCao);
            ds.Tables[0].Columns.Add("Selected", Type.GetType("System.String"));
            ds.Tables[0].Columns["Selected"].DefaultValue = "false";
            DataRow[] selectedRows = ds.Tables[0].Select("ViTriQuangCao=" + ViTriQuangCao + " AND KhuVucID=" + KhuVucID);
            for (int i = 0; i < selectedRows.Length; i++)
            {
                selectedRows[i]["Selected"] = "true";
            }
            ds.Tables[0].DefaultView.Sort = "QuangCaoID DESC";
            grdAdv.DataSource = ds.Tables[0].DefaultView;
            grdAdv.DataBind();
            return selectedRows.Length;
        }
        else if (Common.LoaiNguoiDungID() == 2)
        {
            //For e-store manager 
            QuangCao qcao = new QuangCao();
            DataSet ds = qcao.SelectAllQuangCaoAtViTriQuangCaoByNguoiDungID(Common.NguoiDungID(), ViTriQuangCao);
            ds.Tables[0].Columns.Add("Selected", Type.GetType("System.String"));
            ds.Tables[0].Columns["Selected"].DefaultValue = "false";
            DataRow[] selectedRows = ds.Tables[0].Select("ViTriQuangCao=" + ViTriQuangCao + " AND KhuVucID=" + KhuVucID);
            for (int i = 0; i < selectedRows.Length; i++)
            {
                selectedRows[i]["Selected"] = "true";
            }
            ds.Tables[0].DefaultView.Sort = "QuangCaoID DESC";
            grdAdv.DataSource = ds.Tables[0].DefaultView;
            grdAdv.DataBind();
            return selectedRows.Length;
        }
        return 0;
    }

    private int LoadQuangCao(int ViTriQuangCao, int NhomSanPhamID)
    {
        if (Common.LoaiNguoiDungID() == 3)
        {
            //For administrator (11, 12, 13)
            QuangCao qcao = new QuangCao();
            DataSet ds = qcao.SelectAllQuangCaoAtViTriQuangCaoByNhomSanPhamID(NhomSanPhamID, ViTriQuangCao);
            ds.Tables[0].Columns.Add("Selected", Type.GetType("System.String"));
            ds.Tables[0].Columns["Selected"].DefaultValue = "false";
            DataRow[] selectedRows = ds.Tables[0].Select("KhuVucID is null AND ViTriQuangCao=" + ViTriQuangCao);
            for (int i = 0; i < selectedRows.Length; i++)
            {
                selectedRows[i]["Selected"] = "true";
            }
            ds.Tables[0].DefaultView.Sort = "QuangCaoID DESC";
            grdAdv.DataSource = ds.Tables[0].DefaultView;
            grdAdv.DataBind();
            return selectedRows.Length;
        }
        return 0;
    }

    private int LoadQuangCao(int ViTriQuangCao)
    {
        if (Common.LoaiNguoiDungID() == 3)
        {
            //For administrator
            QuangCao qcao = new QuangCao();
            DataSet ds = qcao.SelectAllQuangCaoAtViTriQuangCaoByLoaiNguoiDungID(Common.LoaiNguoiDungID(), ViTriQuangCao);
            ds.Tables[0].Columns.Add("Selected", Type.GetType("System.String"));
            ds.Tables[0].Columns["Selected"].DefaultValue = "false";
            DataRow[] selectedRows = ds.Tables[0].Select("KhuVucID is null AND ViTriQuangCao=" + ViTriQuangCao);
            for (int i = 0; i < selectedRows.Length; i++)
            {
                selectedRows[i]["Selected"] = "true";
            }
            ds.Tables[0].DefaultView.Sort = "QuangCaoID DESC";
            grdAdv.DataSource = ds.Tables[0].DefaultView;
            grdAdv.DataBind();
            return selectedRows.Length;
        }
        else if (Common.LoaiNguoiDungID() == 2)
        {
            //For e-store manager 
            QuangCao qcao = new QuangCao();
            DataSet ds = qcao.SelectAllQuangCaoAtViTriQuangCaoByNguoiDungID(Common.NguoiDungID(), ViTriQuangCao);
            ds.Tables[0].Columns.Add("Selected", Type.GetType("System.String"));
            ds.Tables[0].Columns["Selected"].DefaultValue = "false";
            DataRow[] selectedRows = ds.Tables[0].Select("KhuVucID is null AND ViTriQuangCao=" + ViTriQuangCao);
            for (int i = 0; i < selectedRows.Length; i++)
            {
                selectedRows[i]["Selected"] = "true";
            }
            ds.Tables[0].DefaultView.Sort = "QuangCaoID DESC";
            grdAdv.DataSource = ds.Tables[0].DefaultView;
            grdAdv.DataBind();
            return selectedRows.Length;
        }
        return 0;
    }

    protected void grdAdv_InitializeLayout(object sender, LayoutEventArgs e)
    {
        e.Layout.Grid.Columns.FromKey("CheckBox").AllowRowFiltering = false;
        e.Layout.Grid.Columns.FromKey("DuongDan").FilterOperatorDefaultValue = FilterComparisionOperator.Contains;
        e.Layout.Grid.Columns.FromKey("NoiDungQuangCao").FilterOperatorDefaultValue = FilterComparisionOperator.Contains;
        e.Layout.Grid.Columns.FromKey("Anh").AllowRowFiltering = false;
        if (rbtTatCa.Checked)
        {
            e.Layout.Pager.AllowPaging = false;
        }
        else
        {
            e.Layout.Pager.AllowPaging = true;
        }
    }

    protected void grdAdv_PageIndexChanged(object sender, PageEventArgs e)
    {
        int aid = int.Parse(Request.QueryString["aid"]);
        if (Request.QueryString["rid"] != null)
        {
            int rid = int.Parse(Request.QueryString["rid"]);
            spanSelect.InnerText = LoadQuangCaoByKhuVuc(aid, rid).ToString();
        }
        else
        {
            if (aid == 11 || aid == 12 || aid == 13)
            {
                int cid = int.Parse(Request.QueryString["cid"]);
                spanSelect.InnerText = LoadQuangCao(aid, cid).ToString();
            }
            else
            {
                spanSelect.InnerText = LoadQuangCao(aid).ToString();
            }
        }
    }

    protected void btnSaveAndClose_Click(object sender, EventArgs e)
    {
        btnSave_Click(sender, e);
        string aid = Request.QueryString["aid"];
        string strScript = "<script language='JavaScript'>" + "window.parent.RefreshAdv(" + aid + ");</script>";
        ClientScript.RegisterStartupScript(GetType(), "Refresh", strScript);
    }

    protected void rbtPhanTrang_CheckedChanged(object sender, EventArgs e)
    {
        int aid = int.Parse(Request.QueryString["aid"]);
        if (Request.QueryString["rid"] != null)
        {
            int rid = int.Parse(Request.QueryString["rid"]);
            spanSelect.InnerText = LoadQuangCaoByKhuVuc(aid, rid).ToString();
        }
        else
        {
            if (aid == 11 || aid == 12 || aid == 13)
            {
                int cid = int.Parse(Request.QueryString["cid"]);
                spanSelect.InnerText = LoadQuangCao(aid, cid).ToString();
            }
            else
            {
                spanSelect.InnerText = LoadQuangCao(aid).ToString();
            }
        }
    }

    protected void rbtTatCa_CheckedChanged(object sender, EventArgs e)
    {
        int aid = int.Parse(Request.QueryString["aid"]);
        if (Request.QueryString["rid"] != null)
        {
            int rid = int.Parse(Request.QueryString["rid"]);
            spanSelect.InnerText = LoadQuangCaoByKhuVuc(aid, rid).ToString();
        }
        else
        {
            if (aid == 11 || aid == 12 || aid == 13)
            {
                int cid = int.Parse(Request.QueryString["cid"]);
                spanSelect.InnerText = LoadQuangCao(aid, cid).ToString();
            }
            else
            {
                spanSelect.InnerText = LoadQuangCao(aid).ToString();
            }
        }
    }
}