using System;
using System.Data;
using System.Web.UI;
using CHONET.DataAccessLayer.Web;

public partial class eStoreNew : Page
{
    public int ChuCuaHangID;
    public int CuaHangID;
    public int NhomSanPhamID;

    void Page_PreInit(Object sender, EventArgs e)
    {
        CuaHang ch = new CuaHang();
        DataSet ds = ch.SelectByCuaHangID(int.Parse(Request["sid"]));

        if ((ds.Tables[0].Rows.Count > 0) && (ds.Tables[0].Rows[0]["LoaiCuaHangID"].ToString() == "26"))
        {
            //ContentPlaceHolderID = "contentEstore";
            this.MasterPageFile = "NewEstoreMaster.master";
        }
        if (Session["masterpage"] != null)
        {
            this.MasterPageFile = (String)Session["masterpage"];
        }
    } 
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["sid"] != null)
        {
            try
            {
                CuaHangID = int.Parse(Request.QueryString["sid"]);
                LoadCuaHang();
                if (Request.QueryString["nid"] != null)
                {
                    try
                    {
                        int tintucid = int.Parse(Request.QueryString["nid"]);
                        LoadTinTuc(tintucid);
                        LoadTinTucMoiVaCu();
                        //LoadTinTucCu();
                    }
                    catch (Exception ex)
                    {
                        Response.Redirect("./message.aspx?msg=" + ex.Message);
                    }
                }
                else
                {
                    LoadAllTinTuc();
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("./message.aspx?msg=" + ex.Message);
            }
        }
        else
        {
            if (Request.QueryString["nid"] != null)
            {
                try
                {
                    int tintucid = int.Parse(Request.QueryString["nid"]);
                    LoadTinTuc(tintucid);
                }
                catch (Exception ex)
                {
                    Response.Redirect("./message.aspx?msg=" + ex.Message);
                }
            }
            else
            {
                LoadTinTucForAll();
            }
        }
    }

    private void LoadTinTuc(int tintucid)
    {
        try
        {
            TinTuc tt = new TinTuc();
            DataSet ds = tt.SelectByID(tintucid);

            if (ds.Tables[0].Rows.Count > 0)
            {
                lblTieuDe.Text = ds.Tables[0].Rows[0]["tieude"].ToString();
                if (ds.Tables[0].Rows[0]["anh"] != null)
                {
                    spnImage.InnerHtml = "<br><br><img width=\"200px\" src=\"" + ds.Tables[0].Rows[0]["anh"]
                                         + "\" border=\"0\" /><br>";
                }

                spnTinTuc.InnerHtml = "<br>" +
                                      "<div>" + ds.Tables[0].Rows[0]["NoiDung"] + "</div>";
            }
        }
        catch (Exception ex)
        {
            Response.Redirect("../message.aspx?msg=" + ex.ToString().Replace("\r\n", " "));
        }
    }

    private void LoadAllTinTuc()
    {
        TinTuc tt = new TinTuc();
        DataSet ds = tt.SelectByNguoiDungID(ChuCuaHangID);
        lblTieuDe.Text = "Các tin mới nhất.";

        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            spnTinTuc.InnerHtml += "<br><a href=\"estorenews.aspx?nid="
                                   + dr["TinTucID"] + "&sid=" + CuaHangID
                                   + "\" ><b>" + dr["tieude"]
                                   + "</b><br><img border=\"0\"width=\"48\" src=\""
                                   + dr["anh"] + "\" /></a>&nbsp;&nbsp;"
                                   + dr["tomtat"] + "<br><a href=\"estorenews.aspx?nid="
                                   + dr["TinTucID"] + "&sid=" + CuaHangID
                                   + "\" >Xem tiếp</a><br><hr>";
        }
    }

    private void LoadTinTucForAll()
    {
        TinTuc tt = new TinTuc();
        DataSet ds = tt.SelectAdminNews();
        lblTieuDe.Text = "Các tin mới nhất.";

        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            spnTinTuc.InnerHtml += "<br><a href=\"estorenews.aspx?nid="
                                   + dr["TinTucID"]
                                   + "\" ><b>" + dr["tieude"]
                                   + "</b><br><img border=\"0\"width=\"48\" src=\""
                                   + dr["anh"] + "\" /></a>&nbsp;&nbsp;"
                                   + dr["tomtat"] + "<br><a href=\"estorenews.aspx?nid="
                                   + dr["TinTucID"]
                                   + "\" >Xem tiếp</a><br><hr>";
        }
    }

    private void LoadCuaHang()
    {
        CuaHang ch = new CuaHang();
        DataSet ds = ch.SelectByID(CuaHangID);
        if (ds.Tables[0].Rows.Count != 1)
        {
            Response.Redirect("./message.aspx?msg=Failed in loading store");
        }
        else
        {
            DataRow dr = ds.Tables[0].Rows[0];
            ChuCuaHangID = int.Parse(dr["NguoiDungID"].ToString());
        }
    }

    private void LoadTinTucMoiVaCu()
    {
        TinTuc tt = new TinTuc();
        DataSet ds = tt.SelectByNguoiDungIDPaging(ChuCuaHangID, 1, 10);

        string content = "<ul class=\"list-news\">";
        string content1 = "<ul class=\"list-news\">";
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++ )
        {
            DataRow dr = ds.Tables[0].Rows[i];
            if (i < 5)
            {
                content += "<li><a href=\"EstoreNews.aspx?sid=" + CuaHangID + "&nid=" + dr["TinTucID"].ToString() + "\">"
                    + dr["TieuDe"].ToString() + "</a></li>";
            }
            else
            {
                content1 += "<li><a href=\"EstoreNews.aspx?sid=" + CuaHangID + "&nid=" + dr["TinTucID"].ToString() + "\">"
                   + dr["TieuDe"].ToString() + "</a></li>";
            }
        }
        content += "</ul>";
        content1 += "</ul>";
        spnTinTucMoi.InnerHtml = content;
        spnTinTucCu.InnerHtml = content1;
    }
    private void LoadTinTucCu()
    {
        TinTuc tt = new TinTuc();
        DataSet ds = tt.SelectByNguoiDungIDPaging(ChuCuaHangID, 2, 5);

        string content = "<ul class=\"list-news\">";
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            content += "<li><a href=\"EstoreNews.aspx?sid=" + CuaHangID + "&nid=" + dr["TinTucID"].ToString() + "\">"
                + dr["TieuDe"].ToString() + "</a></li>";
        }
        content += "</ul>";
        
        spnTinTucCu.InnerHtml = content;
    }
}