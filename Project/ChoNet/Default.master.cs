using System;
using System.Data;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using CHONET.Common;
using CHONET.DataAccessLayer.Web;

public partial class Master_Default : MasterPage
{
    public int intItems;

    public String clsHome
    {
        get
        {
            return (String)
                   ViewState["clsHome"];
        }
        set { ViewState["clsHome"] = value; }
    }

    public String clsTN
    {
        get
        {
            return (String)
                   ViewState["clsTN"];
        }
        set { ViewState["clsTN"] = value; }
    }

    public String clsHP
    {
        get
        {
            return (String)
                   ViewState["clsHP"];
        }
        set { ViewState["clsHP"] = value; }
    }

    public String clsQN
    {
        get
        {
            return (String)
                   ViewState["clsQN"];
        }
        set { ViewState["clsQN"] = value; }
    }

    private void Page_Init(Object sender, EventArgs e)
    {
        clsHome = "menu_ac";
        clsHP = "menu";
        clsQN = "menu";
        clsTN = "menu";

        KhuVuc kv = new KhuVuc();
        DataSet ds;
        if (Cache["kv"] == null)
        {
            ds = kv.SelectByField("HienThi", "True", "bit");
            Cache["kv"] = ds;
        }
        else
        {
            ds = (DataSet) Cache["kv"];
        }
        ds.Tables[0].DefaultView.Sort = "SapXep";
        foreach (DataRowView dr in ds.Tables[0].DefaultView)
        {
            wucRegion wuc = (wucRegion) Page.LoadControl("wucRegion.ascx");
            wuc.Title = dr["TenKhuVuc"].ToString();
            wuc.HrefRegion = "RegionHome.aspx?rid=" + dr["KhuVucID"];
            wuc.clsRegion = "menu";

            wuc.ShowImage = dr["bak3"].ToString() == "1";
            if (Request.QueryString["rid"] != null)
            {
                clsHome = "menu";

                if (Request.QueryString["rid"] == dr["KhuVucID"].ToString())
                {
                    wuc.clsRegion = "menu_ac";
                    Page.Title = dr["tenkhuvuc"].ToString();
                }
            }

            wuc.Width = "width:130px";
            pnlHomeMenu.Controls.Add(wuc);
        }
        tdRegionMenu.Width = (1024 - (ds.Tables[0].Rows.Count + 1)*120).ToString();
        //pnlHomeMenu.Width = Unit.Pixel(ds.Tables[0].Rows.Count * 120);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LoadNhomSanPham();
            ViewState["URL"] = Request.Url;
        }
        if (Session["UserFullName"] != null)
        {
            tbl1.Visible = false;
            tbl2.Visible = true;
            if (Common.LoaiNguoiDungID() == 2 || Common.LoaiNguoiDungID() == 3) lnkAdm.Visible = true;
            //if (Common.LoaiNguoiDungID() == 2)
            //{
            //    CuaHang ch = new CuaHang();
            //    ch.SelectByNguoiDungID(Common.NguoiDungID);
            //    hplGianHang.Visible = true;
            //}
            //else
            //    hplGianHang.Visible = false;
        }
        else
        {
            tbl2.Visible = false;
            tbl1.Visible = true;
        }
        intItems = Session["dtShoppingCart"] != null ? ((DataTable) Session["dtShoppingCart"]).Rows.Count : 0;
        //LoadSanPham01();
        //cphMain.       
    }

    private void LoadNhomSanPham()
    {
        NhomSanPham nhomsanpham = new NhomSanPham();

        DataSet ds = nhomsanpham.SelectNhomSanPhamByNhomChaID(0);

        ddlNhomSanPham.Items.Insert(0, "Danh mục sản phẩm");
        ddlNhomSanPham.Items[0].Value = "0";

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem item = new ListItem("+ " + ds.Tables[0].Rows[i]["TenNhomSanPham"],
                                         ds.Tables[0].Rows[i]["NhomSanPhamID"].ToString());
            ddlNhomSanPham.Items.Add(item);
            DataSet subds =
                nhomsanpham.SelectNhomSanPhamByNhomChaID(int.Parse(ds.Tables[0].Rows[i]["NhomSanPhamID"].ToString()));
            for (int j = 0; j < subds.Tables[0].Rows.Count; j++)
            {
                ListItem subitem = new ListItem("+.... " + subds.Tables[0].Rows[j]["TenNhomSanPham"],
                                                subds.Tables[0].Rows[j]["NhomSanPhamID"].ToString());
                ddlNhomSanPham.Items.Add(subitem);
            }
        }
    }

    protected void Submit1_ServerClick(object sender, EventArgs e)
    {
        Response.Redirect("search.aspx?keyword=" + Server.UrlEncode(txtSearch.Value) + "&cid=" +
                          ddlNhomSanPham.Items[ddlNhomSanPham.SelectedIndex].Value);
    }

    //private void LoadSanPham01()
    //{
    //    //SanPham sp = new SanPham();
    //    int ViTriSanPham = 1;
    //    //switch (Page.Header.Title.ToLower())
    //    //{
    //        //case "trang chủ":
    //            //ViTriSanPham = 1;
    //           // break;
    //        //case "danh mục con":
    //        //    ViTriSanPham = 21;
    //        //    break;
    //   // }
    //    if (ViTriSanPham != 9999)
    //    {
    //        SanPham sp = new SanPham();
    //        DataSet ds = sp.SelectSanPhamAtViTriSanPham(ViTriSanPham);
    //        int n = 20;
    //        if (ds.Tables[0].Rows.Count < n) n = ds.Tables[0].Rows.Count;
    //        for (int i = 0; i < n; i++)
    //        {
    //            string content1 = "";
    //            content1 += "<table class=\"product1\" width=\"300px\" border=\"0\" cellspacing=\"4\" cellpadding=\"0\">";
    //            content1 += "<tr><td align=\"center\"><a href=\"productdetail.aspx?id=" + ds.Tables[0].Rows[i]["SanPhamID"].ToString()
    //                + "\"><img src=\"" + ds.Tables[0].Rows[i]["AnhSanPham"].ToString()
    //                + "\" width=\"99\" height=\"89\" border=\"0\" style=\"border:#CCCCCC 1px solid\" /></a></td>";
    //            content1 += "<td align=\"Left\"><strong>SẢN PHẨM ĐÓN GIỜ VÀNG</strong><br /><a href=\"productdetail.aspx?id=" + ds.Tables[0].Rows[i]["SanPhamID"].ToString()
    //                + "\">" + ds.Tables[0].Rows[i]["TenSanPham"].ToString()
    //                + "</a><br />Giá: <span class=\"price\">" + String.Format("{0:0,0}", ds.Tables[0].Rows[i]["GiaSanPham"]).Replace(",", ".") + "</span>"
    //            + ds.Tables[0].Rows[i]["DonViTienTe"].ToString() + "</td></tr></table>";
    //            spnSanPham00.InnerHtml = content1;

    //        }           
    //    }
    //}
    protected void lnkSignOut_Click(object sender, EventArgs e)
    {
        if (Session.IsNewSession != true)
        {
            FormsAuthentication.SignOut();
            Session.Clear();
        }
        Response.Redirect("default.aspx");
    }
}