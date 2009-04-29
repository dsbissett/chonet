using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using CHONET.DataAccessLayer.Web;
using Infragistics.WebUI.UltraWebNavigator;

public partial class _Default : Page
{
    private void Page_Init(Object sender, EventArgs e)
    {
        Master.clsHome = "menu_ac";
        Master.clsHP = "menu";
        Master.clsQN = "menu";
        Master.clsTN = "menu";
    }

    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!Page.IsPostBack)
        {
            LoadUltraMenu();         
                        
            LoadAllQuangCao();
            //LoadSanPham01();
            LoadSanPham02();
            //LoadSanPham03();
            LoadSanPham04();
            //LoadSanPham05();
            //LoadSanPham06();
            LoadSanPham07(10, 1);
            //LoadGianHang();
            GetAllSanPhamUC_Top4_GG_KM_GH();
            LoadSanPhamDaXem();
            LoadTinTuc();
            LoadHoTroTrucTuyen();
        }
    }

    private void LoadUltraMenu()
    {
        NhomSanPham nsp = new NhomSanPham();

        //get Nhomsanpham
        DataSet ds;

        if (Cache["Menu"] == null)
        {
            ds = nsp.SelectAllNhomSanPhamByLevel();
            Cache["menu"] = ds;
        }
        else
        {
            ds = (DataSet) Cache["menu"];
        }

            ds.Relations.Add("menu", ds.Tables[0].Columns["NhomSanPhamID"],
                ds.Tables[1].Columns["NhomChaID"], false);
        ds.Relations.Add("menucon", ds.Tables[1].Columns["NhomSanPhamID"],
            ds.Tables[2].Columns["NhomChaID"], false);
        //ds.WriteXml(Server.MapPath("." + "\\menu.xml"), XmlWriteMode.WriteSchema);
        //ds.WriteXml(Server.MapPath(".") + "\\menu.xml");
        //
        //DataView dv = ds1.Tables[0].DefaultView;
        uwmMenu.DataSource = ds;

        uwmMenu.Levels[0].ColumnName = "TenNhomSanPham";
        // this.uwmMenu.Levels[i].LevelImage = "../../../ig_common/images/dir.png";
        uwmMenu.Levels[0].RelationName = "menu";
        uwmMenu.Levels[0].LevelKeyField = "NhomSanPhamID";
        uwmMenu.Levels[0].TargetUrlName = "TargetUrl";

        uwmMenu.Levels[1].ColumnName = "TenNhomSanPham";
        // this.uwmMenu.Levels[i].LevelImage = "../../../ig_common/images/dir.png";
        uwmMenu.Levels[1].RelationName = "menucon";
        uwmMenu.Levels[1].LevelKeyField = "NhomSanPhamID";
        uwmMenu.Levels[1].TargetUrlName = "TargetUrl";

        uwmMenu.Levels[2].ColumnName = "TenNhomSanPham";
        // this.uwmMenu.Levels[i].LevelImage = "../../../ig_common/images/dir.png";
        //uwmMenu.Levels[1].RelationName = "con";         
        uwmMenu.Levels[2].TargetUrlName = "TargetUrl";
        uwmMenu.Levels[2].LevelKeyField = "NhomSanPhamID";

        uwmMenu.DataMember = ds.Tables[0].TableName;
        uwmMenu.DataBind();
    }

    //private void LoadDanhMuc()
    //{
    //    try
    //    {
    //        NhomSanPham nsp = new NhomSanPham();
    //        DataSet ds = new DataSet("Danh mục sản phẩm");

    //        int NhomChaID = int.Parse("0" + Request.QueryString["mcid"].ToString());
    //        ds = nsp.SelectNhomSanPhamByNhomChaID(NhomChaID);
    //        ds.Tables[0].DefaultView.Sort = "SapXep ASC";
    //        LoadMenu(NhomChaID);

    //        //LoadMenu();
    //    }
    //    catch (Exception ex)
    //    {
    //        Response.Write(ex.ToString());
    //    }
    //}
    private void LoadQuangCao10()
    {
        QuangCao qcao = new QuangCao();
        DataSet ds = qcao.SelectQuangCaoAtViTriQuangCaoByLoaiNguoiDungID(3, 10);
        if (ds.Tables[0].Rows.Count >= 1)
        {
            if (ds.Tables[0].Rows[0]["LoaiAnh"].ToString() == "FLASH")
            {
                spnQuangCao10.InnerHtml = "<object border:solid 1px #C9C3C3 classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
                                          +
                                          "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
                                          + "width=\"980\" height=\"111\" title=\"Quang Cao\">"
                                          + "<param name=\"movie\" value=\"" + ds.Tables[0].Rows[0]["DuongDanAnh"] +
                                          "\" />"
                                          + "<param name=\"quality\" value=\"high\" />"
                                          + "<embed src=\"" + ds.Tables[0].Rows[0]["DuongDanAnh"] +
                                          "\" quality=\"high\""
                                          +
                                          "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
                                          + "width=\"980\" height=\"216\"></embed></object>";
            }
            else
            {
                spnQuangCao10.InnerHtml = "<a href=\"" + ds.Tables[0].Rows[0]["DuongDan"]
                                          + "\" target=\"_blank\"><img alt=\"" + ds.Tables[0].Rows[0]["NoiDungQuangCao"]
                                          + "\" src=\"" + ds.Tables[0].Rows[0]["DuongDanAnh"] +
                                          "\" height=\"111px\" width=\"980px\" style=\"border:solid 1px #C9C3C3\"/></a>";
            }
        }
        //else
        //{
        //    spnQuangCao10.InnerHtml = "<img alt=\"Moi quang cao\" src=\"./images/advblank.jpg\" height=\"216px\" width=\"596px\" style=\"border:none\"/>";
        //}
    }

    private void LoadQuangCao02()
    {
        QuangCao qcao = new QuangCao();
        DataSet ds = qcao.SelectQuangCaoAtViTriQuangCaoByLoaiNguoiDungID(3, 2);
        if (ds.Tables[0].Rows.Count >= 1)
        {
            if (ds.Tables[0].Rows[0]["LoaiAnh"].ToString() == "FLASH")
            {
                spnQuangCao02.InnerHtml = "<object style=\"z-index:1\" z-index:1  border:solid 1px #C9C3C3 classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
                                          +
                                          "z-index=\"0\" codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
                                          + "width=\"550\" height=\"216\" title=\"Quang Cao\">"
                                          + "<param name=\"movie\" value=\"" + ds.Tables[0].Rows[0]["DuongDanAnh"] +
                                          "\" />"
                                          + "<param name=\"quality\" value=\"high\" />"
                                          + "<param name=\"wmode\" value=\"transparent\" />"
                                          + "<embed wmode=\"transparent\" src=\"" + ds.Tables[0].Rows[0]["DuongDanAnh"] +
                                          "\" quality=\"high\""
                                          +
                                          "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
                                          + "width=\"550\" height=\"216\" style=\"z-index:1\"></embed></object>";
            }
            else
            {
                spnQuangCao02.InnerHtml = "<a href=\"" + ds.Tables[0].Rows[0]["DuongDan"]
                                          + "\" target=\"_blank\" style=\"z-index:1\"><img alt=\"" +
                                          ds.Tables[0].Rows[0]["NoiDungQuangCao"]
                                          + "\" src=\"" + ds.Tables[0].Rows[0]["DuongDanAnh"] +
                                          "\" height=\"216px\" width=\"550px\" style=\"z-index:1;border:solid 1px #C9C3C3\"/></a>";
            }
        }
        //else
        //{
        //    spnQuangCao02.InnerHtml = "<img alt=\"Moi quang cao\" src=\"./images/advblank.jpg\" height=\"216px\" width=\"500px\" style=\"border:none\"/>";
        //}
    }

    private void LoadQuangCao03()
    {
        QuangCao qcao = new QuangCao();
        DataSet ds = qcao.SelectQuangCaoAtViTriQuangCaoByLoaiNguoiDungID(3, 3);
        int n = ds.Tables[0].Rows.Count;
        spnQuangCao03a.InnerHtml =
            "<img alt=\"Moi quang cao\" src=\"./images/advblank.jpg\" height=\"122px\" width=\"365px\" style=\"border:solid 1px #C9C3C3\"/>";
        spnQuangCao03b.InnerHtml =
            "<img alt=\"Moi quang cao\" src=\"./images/advblank.jpg\" height=\"122px\" width=\"365px\" style=\"border:solid 1px #C9C3C3\"/>";
        //spnQuangCao03c.InnerHtml = "<img alt=\"Moi quang cao\" src=\"./images/advblank.jpg\" height=\"122px\" width=\"365px\" style=\"border:solid 1px #C9C3C3\"/>";
        if (n >= 1)
        {
            if (ds.Tables[0].Rows[0]["LoaiAnh"].ToString() == "FLASH")
            {
                spnQuangCao03a.InnerHtml = "<object style=\"border:solid 1px #C9C3C3\" classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
                                           +
                                           "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
                                           + "width=\"365px\" height=\"122\" title=\"Quang Cao\">"
                                           + "<param name=\"movie\" value=\"" + ds.Tables[0].Rows[0]["DuongDanAnh"] +
                                           "\" />"
                                           + "<param name=\"quality\" value=\"high\" />"
                                           + "<embed src=\"" + ds.Tables[0].Rows[0]["DuongDanAnh"] +
                                           "\" quality=\"high\""
                                           +
                                           "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
                                           + "width=\"365px\" height=\"122\"></embed></object>";
            }
            else
            {
                spnQuangCao03a.InnerHtml = "<a href=\"" + ds.Tables[0].Rows[0]["DuongDan"]
                                           + "\" target=\"_blank\"><img alt=\"" +
                                           ds.Tables[0].Rows[0]["NoiDungQuangCao"]
                                           + "\" src=\"" + ds.Tables[0].Rows[0]["DuongDanAnh"] +
                                           "\" height=\"122px\" width=\"365pxpx\" style=\"border:solid 1px #C9C3C3\"/></a>";
            }
            if (n >= 2)
            {
                if (ds.Tables[0].Rows[1]["LoaiAnh"].ToString() == "FLASH")
                {
                    spnQuangCao03b.InnerHtml = "<object style=\"border:solid 1px #C9C3C3\" classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
                                               +
                                               "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
                                               + "width=\"365px\" height=\"122\" title=\"Quang Cao\">"
                                               + "<param name=\"movie\" value=\"" + ds.Tables[0].Rows[1]["DuongDanAnh"] +
                                               "\" />"
                                               + "<param name=\"quality\" value=\"high\" />"
                                               + "<embed src=\"" + ds.Tables[0].Rows[1]["DuongDanAnh"] +
                                               "\" quality=\"high\""
                                               +
                                               "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
                                               + "width=\"365px\" height=\"122\"></embed></object>";
                }
                else
                {
                    spnQuangCao03b.InnerHtml = "<a href=\"" + ds.Tables[0].Rows[1]["DuongDan"]
                                               + "\" target=\"_blank\"><img alt=\"" +
                                               ds.Tables[0].Rows[1]["NoiDungQuangCao"]
                                               + "\" src=\"" + ds.Tables[0].Rows[1]["DuongDanAnh"] +
                                               "\" height=\"122px\" width=\"365px\" style=\"border:solid 1px #C9C3C3\"/></a>";
                }
            }
        }
        else
        {
            tblQuangCao03.Visible = false;
        }
    }

    private void LoadQuangCao04()
    {
        QuangCao qcao = new QuangCao();
        DataSet ds = qcao.SelectQuangCaoAtViTriQuangCaoByLoaiNguoiDungID(3, 4);
        int n = 5;
        if (ds.Tables[0].Rows.Count <= 2) n = ds.Tables[0].Rows.Count;

        for (int i = 0; i < n; i++)
        {
            TableRow tr = new TableRow();
            TableCell td = new TableCell();
            td.Style.Value = "padding-top: 4px; padding-left:4px";
            string content = "";
            if (ds.Tables[0].Rows[i]["LoaiAnh"].ToString() == "FLASH")
            {
                content = "<object style=\"border:solid 1px #C9C3C3\" classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
                          +
                          "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
                          + "width=\"200\" height=\"155\" title=\"Quang Cao\">"
                          + "<param name=\"movie\" value=\"" + ds.Tables[0].Rows[i]["DuongDanAnh"] + "\" />"
                          + "<param name=\"quality\" value=\"high\" />"
                          + "<embed src=\"" + ds.Tables[0].Rows[i]["DuongDanAnh"] + "\" quality=\"high\""
                          +
                          "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
                          + "width=\"200\" height=\"155\"></embed></object>";
            }
            else
            {
                content = "<a href=\"" + ds.Tables[0].Rows[i]["DuongDan"]
                          + "\" target=\"_blank\"><img alt=\"" + ds.Tables[0].Rows[i]["NoiDungQuangCao"]
                          + "\" src=\"" + ds.Tables[0].Rows[i]["DuongDanAnh"]
                          + "\" style=\"border:solid 1px #C9C3C3; width:200px;\"></a>";
            }
            td.Text = content;
            tr.Cells.Add(td);
            tblQuangCao04.Rows.Add(tr);
        }
    }

    private void LoadQuangCao05()
    {
        QuangCao qcao = new QuangCao();
        DataSet ds = qcao.SelectQuangCaoAtViTriQuangCaoByLoaiNguoiDungID(3, 5);
        int n = ds.Tables[0].Rows.Count;
        spnQuangCao05a.InnerHtml =
            "<img alt=\"Moi quang cao\" src=\"./images/advblank.jpg\" height=\"122px\" width=\"365px\" style=\"border:solid 1px #C9C3C3\"/>";
        spnQuangCao05b.InnerHtml =
            "<img alt=\"Moi quang cao\" src=\"./images/advblank.jpg\" height=\"122px\" width=\"365px\" style=\"border:solid 1px #C9C3C3\"/>";
        //spnQuangCao05c.InnerHtml = "<img alt=\"Moi quang cao\" src=\"./images/advblank.jpg\" height=\"122px\" width=\"365px\" style=\"border:solid 1px #C9C3C3\"/>";
        if (n >= 1)
        {
            if (ds.Tables[0].Rows[0]["LoaiAnh"].ToString() == "FLASH")
            {
                spnQuangCao05a.InnerHtml = "<object style=\"border:solid 1px #C9C3C3\" classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
                                           +
                                           "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
                                           + "width=\"365px\" height=\"122\" title=\"Quang Cao\">"
                                           + "<param name=\"movie\" value=\"" + ds.Tables[0].Rows[0]["DuongDanAnh"] +
                                           "\" />"
                                           + "<param name=\"quality\" value=\"high\" />"
                                           + "<embed src=\"" + ds.Tables[0].Rows[0]["DuongDanAnh"] +
                                           "\" quality=\"high\""
                                           +
                                           "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
                                           + "width=\"365px\" height=\"122\"></embed></object>";
            }
            else
            {
                spnQuangCao05a.InnerHtml = "<a href=\"" + ds.Tables[0].Rows[0]["DuongDan"]
                                           + "\" target=\"_blank\"><img alt=\"" +
                                           ds.Tables[0].Rows[0]["NoiDungQuangCao"]
                                           + "\" src=\"" + ds.Tables[0].Rows[0]["DuongDanAnh"] +
                                           "\" height=\"122px\" width=\"365px\" style=\"border:solid 1px #C9C3C3\"/></a>";
            }
            if (n >= 2)
            {
                if (ds.Tables[0].Rows[1]["LoaiAnh"].ToString() == "FLASH")
                {
                    spnQuangCao05b.InnerHtml = "<object style=\"border:solid 1px #C9C3C3\" classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
                                               +
                                               "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
                                               + "width=\"365px\" height=\"122\" title=\"Quang Cao\">"
                                               + "<param name=\"movie\" value=\"" + ds.Tables[0].Rows[1]["DuongDanAnh"] +
                                               "\" />"
                                               + "<param name=\"quality\" value=\"high\" />"
                                               + "<embed src=\"" + ds.Tables[0].Rows[1]["DuongDanAnh"] +
                                               "\" quality=\"high\""
                                               +
                                               "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
                                               + "width=\"365px\" height=\"122\"></embed></object>";
                }
                else
                {
                    spnQuangCao05b.InnerHtml = "<a href=\"" + ds.Tables[0].Rows[1]["DuongDan"]
                                               + "\" target=\"_blank\"><img alt=\"" +
                                               ds.Tables[0].Rows[1]["NoiDungQuangCao"]
                                               + "\" src=\"" + ds.Tables[0].Rows[1]["DuongDanAnh"] +
                                               "\" height=\"122px\" width=\"365px\" style=\"border:solid 1px #C9C3C3\"/></a>";
                }
                //if (n >= 3)
                //{
                //    if (ds.Tables[0].Rows[2]["LoaiAnh"].ToString() == "FLASH")
                //    {
                //        spnQuangCao05c.InnerHtml = "<object style=\"border:solid 1px #C9C3C3\" classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
                //            + "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
                //            + "width=\"365px\" height=\"122\" title=\"Quang Cao\">"
                //            + "<param name=\"movie\" value=\"" + ds.Tables[0].Rows[2]["DuongDanAnh"].ToString() + "\" />"
                //            + "<param name=\"quality\" value=\"high\" />"
                //            + "<embed src=\"" + ds.Tables[0].Rows[2]["DuongDanAnh"].ToString() + "\" quality=\"high\""
                //            + "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
                //            + "width=\"365px\" height=\"122\"></embed></object>";
                //    }
                //    else
                //    {
                //        spnQuangCao05c.InnerHtml = "<a href=\"" + ds.Tables[0].Rows[2]["DuongDan"].ToString()
                //          + "\" target=\"_blank\"><img alt=\"" + ds.Tables[0].Rows[2]["NoiDungQuangCao"].ToString()
                //          + "\" src=\"" + ds.Tables[0].Rows[2]["DuongDanAnh"].ToString() + "\" height=\"122px\" width=\"365px\" style=\"border:solid 1px #C9C3C3\"/></a>";
                //    }
                //}
            }
        }
        else
        {
            tblQuangCao05.Visible = false;
        }
    }

    private void LoadQuangCao07()
    {
        QuangCao qcao = new QuangCao();
        DataSet ds = qcao.SelectQuangCaoAtViTriQuangCaoByLoaiNguoiDungID(3, 7);
        int n = ds.Tables[0].Rows.Count;
        spnQuangCao07a.InnerHtml =
            "<img alt=\"Moi quang cao\" src=\"./images/advblank.jpg\" height=\"122px\" width=\"365px\" style=\"border:solid 1px #C9C3C3\"/>";
        spnQuangCao07b.InnerHtml =
            "<img alt=\"Moi quang cao\" src=\"./images/advblank.jpg\" height=\"122px\" width=\"365px\" style=\"border:solid 1px #C9C3C3\"/>";
        //spnQuangCao07c.InnerHtml = "<img alt=\"Moi quang cao\" src=\"./images/advblank.jpg\" height=\"122px\" width=\"365px\" style=\"border:solid 1px #C9C3C3\"/>";
        if (n >= 1)
        {
            if (ds.Tables[0].Rows[0]["LoaiAnh"].ToString() == "FLASH")
            {
                spnQuangCao07a.InnerHtml = "<object style=\"border:solid 1px #C9C3C3\" classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
                                           +
                                           "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
                                           + "width=\"365px\" height=\"122\" title=\"Quang Cao\">"
                                           + "<param name=\"movie\" value=\"" + ds.Tables[0].Rows[0]["DuongDanAnh"] +
                                           "\" />"
                                           + "<param name=\"quality\" value=\"high\" />"
                                           + "<embed src=\"" + ds.Tables[0].Rows[0]["DuongDanAnh"] +
                                           "\" quality=\"high\""
                                           +
                                           "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
                                           + "width=\"365px\" height=\"122\"></embed></object>";
            }
            else
            {
                spnQuangCao07a.InnerHtml = "<a href=\"" + ds.Tables[0].Rows[0]["DuongDan"]
                                           + "\" target=\"_blank\"><img alt=\"" +
                                           ds.Tables[0].Rows[0]["NoiDungQuangCao"]
                                           + "\" src=\"" + ds.Tables[0].Rows[0]["DuongDanAnh"] +
                                           "\" height=\"122px\" width=\"365px\" style=\"border:solid 1px #C9C3C3\"/></a>";
            }
            if (n >= 2)
            {
                if (ds.Tables[0].Rows[1]["LoaiAnh"].ToString() == "FLASH")
                {
                    spnQuangCao07b.InnerHtml = "<object style=\"border:solid 1px #C9C3C3\" classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
                                               +
                                               "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
                                               + "width=\"365px\" height=\"122\" title=\"Quang Cao\">"
                                               + "<param name=\"movie\" value=\"" + ds.Tables[0].Rows[1]["DuongDanAnh"] +
                                               "\" />"
                                               + "<param name=\"quality\" value=\"high\" />"
                                               + "<embed src=\"" + ds.Tables[0].Rows[1]["DuongDanAnh"] +
                                               "\" quality=\"high\""
                                               +
                                               "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
                                               + "width=\"365px\" height=\"122\"></embed></object>";
                }
                else
                {
                    spnQuangCao07b.InnerHtml = "<a href=\"" + ds.Tables[0].Rows[1]["DuongDan"]
                                               + "\" target=\"_blank\"><img alt=\"" +
                                               ds.Tables[0].Rows[1]["NoiDungQuangCao"]
                                               + "\" src=\"" + ds.Tables[0].Rows[1]["DuongDanAnh"] +
                                               "\" height=\"122px\" width=\"365px\" style=\"border:solid 1px #C9C3C3\"/></a>";
                }
                //if (n >= 3)
                //{
                //    if (ds.Tables[0].Rows[2]["LoaiAnh"].ToString() == "FLASH")
                //    {
                //        spnQuangCao07c.InnerHtml = "<object style=\"border:solid 1px #C9C3C3\" classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
                //            + "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
                //            + "width=\"365px\" height=\"122\" title=\"Quang Cao\">"
                //            + "<param name=\"movie\" value=\"" + ds.Tables[0].Rows[2]["DuongDanAnh"].ToString() + "\" />"
                //            + "<param name=\"quality\" value=\"high\" />"
                //            + "<embed src=\"" + ds.Tables[0].Rows[2]["DuongDanAnh"].ToString() + "\" quality=\"high\""
                //            + "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
                //            + "width=\"365px\" height=\"122\"></embed></object>";
                //    }
                //    else
                //    {
                //        spnQuangCao07c.InnerHtml = "<a href=\"" + ds.Tables[0].Rows[2]["DuongDan"].ToString()
                //          + "\" target=\"_blank\"><img alt=\"" + ds.Tables[0].Rows[2]["NoiDungQuangCao"].ToString()
                //          + "\" src=\"" + ds.Tables[0].Rows[2]["DuongDanAnh"].ToString() + "\" height=\"122px\" width=\"365px\" style=\"border:solid 1px #C9C3C3\"/></a>";
                //    }
                //}
            }
        }
        else
        {
            tblQuangCao07.Visible = false;
        }
    }

    private void LoadQuangCao08()
    {
        QuangCao qcao = new QuangCao();
        DataSet ds = qcao.SelectQuangCaoAtViTriQuangCaoByLoaiNguoiDungID(3, 8);
        int n = ds.Tables[0].Rows.Count;
        spnQuangCao08a.InnerHtml =
            "<img alt=\"Moi quang cao\" src=\"./images/advblank.jpg\" height=\"122px\" width=\"365px\" style=\"border:solid 1px #C9C3C3\"/>";
        spnQuangCao08b.InnerHtml =
            "<img alt=\"Moi quang cao\" src=\"./images/advblank.jpg\" height=\"122px\" width=\"365px\" style=\"border:solid 1px #C9C3C3\"/>";
        //spnQuangCao08c.InnerHtml = "<img alt=\"Moi quang cao\" src=\"./images/advblank.jpg\" height=\"122px\" width=\"365px\" style=\"border:solid 1px #C9C3C3\"/>";
        if (n >= 1)
        {
            if (ds.Tables[0].Rows[0]["LoaiAnh"].ToString() == "FLASH")
            {
                spnQuangCao08a.InnerHtml = "<object style=\"border:solid 1px #C9C3C3\" classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
                                           +
                                           "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
                                           + "width=\"365px\" height=\"122\" title=\"Quang Cao\">"
                                           + "<param name=\"movie\" value=\"" + ds.Tables[0].Rows[0]["DuongDanAnh"] +
                                           "\" />"
                                           + "<param name=\"quality\" value=\"high\" />"
                                           + "<embed src=\"" + ds.Tables[0].Rows[0]["DuongDanAnh"] +
                                           "\" quality=\"high\""
                                           +
                                           "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
                                           + "width=\"365px\" height=\"122\"></embed></object>";
            }
            else
            {
                spnQuangCao08a.InnerHtml = "<a href=\"" + ds.Tables[0].Rows[0]["DuongDan"]
                                           + "\" target=\"_blank\"><img alt=\"" +
                                           ds.Tables[0].Rows[0]["NoiDungQuangCao"]
                                           + "\" src=\"" + ds.Tables[0].Rows[0]["DuongDanAnh"] +
                                           "\" height=\"122px\" width=\"365px\" style=\"border:solid 1px #C9C3C3\"/></a>";
            }
            if (n >= 2)
            {
                if (ds.Tables[0].Rows[1]["LoaiAnh"].ToString() == "FLASH")
                {
                    spnQuangCao08b.InnerHtml = "<object style=\"border:solid 1px #C9C3C3\" classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
                                               +
                                               "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
                                               + "width=\"365px\" height=\"122\" title=\"Quang Cao\">"
                                               + "<param name=\"movie\" value=\"" + ds.Tables[0].Rows[1]["DuongDanAnh"] +
                                               "\" />"
                                               + "<param name=\"quality\" value=\"high\" />"
                                               + "<embed src=\"" + ds.Tables[0].Rows[1]["DuongDanAnh"] +
                                               "\" quality=\"high\""
                                               +
                                               "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
                                               + "width=\"365px\" height=\"122\"></embed></object>";
                }
                else
                {
                    spnQuangCao08b.InnerHtml = "<a href=\"" + ds.Tables[0].Rows[1]["DuongDan"]
                                               + "\" target=\"_blank\"><img alt=\"" +
                                               ds.Tables[0].Rows[1]["NoiDungQuangCao"]
                                               + "\" src=\"" + ds.Tables[0].Rows[1]["DuongDanAnh"] +
                                               "\" height=\"122px\" width=\"365px\" style=\"border:solid 1px #C9C3C3\"/></a>";
                }
                //if (n >= 3)
                //{
                //    if (ds.Tables[0].Rows[2]["LoaiAnh"].ToString() == "FLASH")
                //    {
                //        spnQuangCao08c.InnerHtml = "<object style=\"border:solid 1px #C9C3C3\" classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
                //            + "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
                //            + "width=\"365px\" height=\"122\" title=\"Quang Cao\">"
                //            + "<param name=\"movie\" value=\"" + ds.Tables[0].Rows[2]["DuongDanAnh"].ToString() + "\" />"
                //            + "<param name=\"quality\" value=\"high\" />"
                //            + "<embed src=\"" + ds.Tables[0].Rows[2]["DuongDanAnh"].ToString() + "\" quality=\"high\""
                //            + "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
                //            + "width=\"365px\" height=\"122\"></embed></object>";
                //    }
                //    else
                //    {
                //        spnQuangCao08c.InnerHtml = "<a href=\"" + ds.Tables[0].Rows[2]["DuongDan"].ToString()
                //          + "\" target=\"_blank\"><img alt=\"" + ds.Tables[0].Rows[2]["NoiDungQuangCao"].ToString()
                //          + "\" src=\"" + ds.Tables[0].Rows[2]["DuongDanAnh"].ToString() + "\" height=\"122px\" width=\"365px\" style=\"border:solid 1px #C9C3C3\"/></a>";
                //    }
                //}
            }
        }
        else
        {
            tblQuangCao08.Visible = false;
        }
    }

    private void LoadQuangCao09()
    {
        QuangCao qcao = new QuangCao();
        DataSet ds = qcao.SelectQuangCaoAtViTriQuangCaoByLoaiNguoiDungID(3, 9);
        int n = ds.Tables[0].Rows.Count;
        spnQuangCao09a.InnerHtml =
            "<img alt=\"Moi quang cao\" src=\"./images/advblank.jpg\" height=\"122px\" width=\"365px\" style=\"border:solid 1px #C9C3C3\"/>";
        spnQuangCao09b.InnerHtml =
            "<img alt=\"Moi quang cao\" src=\"./images/advblank.jpg\" height=\"122px\" width=\"365px\" style=\"border:solid 1px #C9C3C3\"/>";
        //spnQuangCao09c.InnerHtml = "<img alt=\"Moi quang cao\" src=\"./images/advblank.jpg\" height=\"122px\" width=\"365px\" style=\"border:solid 1px #C9C3C3\"/>";
        if (n >= 1)
        {
            if (ds.Tables[0].Rows[0]["LoaiAnh"].ToString() == "FLASH")
            {
                spnQuangCao09a.InnerHtml = "<object style=\"border:solid 1px #C9C3C3\" classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
                                           +
                                           "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
                                           + "width=\"365px\" height=\"122\" title=\"Quang Cao\">"
                                           + "<param name=\"movie\" value=\"" + ds.Tables[0].Rows[0]["DuongDanAnh"] +
                                           "\" />"
                                           + "<param name=\"quality\" value=\"high\" />"
                                           + "<embed src=\"" + ds.Tables[0].Rows[0]["DuongDanAnh"] +
                                           "\" quality=\"high\""
                                           +
                                           "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
                                           + "width=\"365px\" height=\"122\"></embed></object>";
            }
            else
            {
                spnQuangCao09a.InnerHtml = "<a href=\"" + ds.Tables[0].Rows[0]["DuongDan"]
                                           + "\" target=\"_blank\"><img alt=\"" +
                                           ds.Tables[0].Rows[0]["NoiDungQuangCao"]
                                           + "\" src=\"" + ds.Tables[0].Rows[0]["DuongDanAnh"] +
                                           "\" height=\"122px\" width=\"365px\" style=\"border:solid 1px #C9C3C3\"/></a>";
            }
            if (n >= 2)
            {
                if (ds.Tables[0].Rows[1]["LoaiAnh"].ToString() == "FLASH")
                {
                    spnQuangCao09b.InnerHtml = "<object style=\"border:solid 1px #C9C3C3\" classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
                                               +
                                               "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
                                               + "width=\"365px\" height=\"122\" title=\"Quang Cao\">"
                                               + "<param name=\"movie\" value=\"" + ds.Tables[0].Rows[1]["DuongDanAnh"] +
                                               "\" />"
                                               + "<param name=\"quality\" value=\"high\" />"
                                               + "<embed src=\"" + ds.Tables[0].Rows[1]["DuongDanAnh"] +
                                               "\" quality=\"high\""
                                               +
                                               "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
                                               + "width=\"365px\" height=\"122\"></embed></object>";
                }
                else
                {
                    spnQuangCao09b.InnerHtml = "<a href=\"" + ds.Tables[0].Rows[1]["DuongDan"]
                                               + "\" target=\"_blank\"><img alt=\"" +
                                               ds.Tables[0].Rows[1]["NoiDungQuangCao"]
                                               + "\" src=\"" + ds.Tables[0].Rows[1]["DuongDanAnh"] +
                                               "\" height=\"122px\" width=\"365px\" style=\"border:solid 1px #C9C3C3\"/></a>";
                }
                //if (n >= 3)
                //{
                //    if (ds.Tables[0].Rows[2]["LoaiAnh"].ToString() == "FLASH")
                //    {
                //        spnQuangCao09c.InnerHtml = "<object style=\"border:solid 1px #C9C3C3\" classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
                //            + "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
                //            + "width=\"365px\" height=\"122\" title=\"Quang Cao\">"
                //            + "<param name=\"movie\" value=\"" + ds.Tables[0].Rows[2]["DuongDanAnh"].ToString() + "\" />"
                //            + "<param name=\"quality\" value=\"high\" />"
                //            + "<embed src=\"" + ds.Tables[0].Rows[2]["DuongDanAnh"].ToString() + "\" quality=\"high\""
                //            + "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
                //            + "width=\"365px\" height=\"122\"></embed></object>";
                //    }
                //    else
                //    {
                //        spnQuangCao09c.InnerHtml = "<a href=\"" + ds.Tables[0].Rows[2]["DuongDan"].ToString()
                //          + "\" target=\"_blank\"><img alt=\"" + ds.Tables[0].Rows[2]["NoiDungQuangCao"].ToString()
                //          + "\" src=\"" + ds.Tables[0].Rows[2]["DuongDanAnh"].ToString() + "\" height=\"122px\" width=\"365px\" style=\"border:solid 1px #C9C3C3\"/></a>";
                //    }
                //}
            }
        }
        else
        {
            tblQuangCao09.Visible = false;
        }
    }

    private void LoadSanPham01()
    {
        //Scrolling
        //SanPham sp = new SanPham();
        //DataSet ds = sp.SelectSanPhamAtViTriSanPham(1);
        //int n = 20;
        //if (ds.Tables[0].Rows.Count < n) n = ds.Tables[0].Rows.Count;
        //for (int i = 0; i < n; i++)
        //{
        //    TableRow tr = new TableRow();
        //    TableCell td1 = new TableCell();
        //    TableCell td2 = new TableCell();
        //    string content1 = "<a href=\"productdetail.aspx?id=" + ds.Tables[0].Rows[i]["SanPhamID"].ToString() 
        //        + "\"><img src=\"" + ds.Tables[0].Rows[i]["AnhSanPham"].ToString()
        //        + "\" alt=\"" + ds.Tables[0].Rows[i]["TenSanPham"].ToString()
        //        + "\" width=\"65\" height=\"62\" style=\"border:#CCCCCC 1px solid\" /></a>";
        //    string content2 = "<a href=\"productdetail.aspx?id=" + ds.Tables[0].Rows[i]["SanPhamID"].ToString() + "\">" 
        //        + ds.Tables[0].Rows[i]["TenSanPham"].ToString() + "</a>";
        //    td1.Text = content1;
        //    td2.Text = content2;
        //    td1.Width = Unit.Percentage(45);
        //    td2.Width = Unit.Percentage(55);
        //    td2.HorizontalAlign = HorizontalAlign.Left;
        //    tr.Cells.Add(td1);
        //    tr.Cells.Add(td2);
        //    tblSanPham01.Rows.Add(tr);
        //}
    }

    private void LoadSanPham02()
    {
        //Under main adv
        SanPham sp = new SanPham();
        DataSet ds = sp.SelectSanPhamAtViTriSanPham(2);
        int n = ds.Tables[0].Rows.Count;

        for (int j = 0; j < 2; j++)
        {
            TableRow tr = new TableRow();
            for (int i = 0; i < 6; i++)
            {
                TableCell td = new TableCell();
                string content = "";
                int t = j*6 + i;
                if (t < n)
                {
                    //string tensanpham = ds.Tables[0].Rows[i]["TenSanPham"].ToString() +
                    //" " + ds.Tables[0].Rows[i]["TenSanPhamPhu"].ToString();
                    //if (tensanpham.Length > 20) tensanpham = tensanpham.Substring(0, 20) + "...";

                    content +=
                        "<table class=\"product\" width=\"100%\" border=\"0\" cellspacing=\"4\" cellpadding=\"0\">";
                    content += "<tr><td align=\"center\"><a href=\"productdetail.aspx?id=" +
                               ds.Tables[0].Rows[t]["SanPhamID"]
                               + "\"><img src=\"" + ds.Tables[0].Rows[t]["AnhSanPham"]
                               + "\" alt=\"" + ds.Tables[0].Rows[t]["TenSanPham"] +
                               " width=\"69\" height=\"60\" border=\"0\" style=\"border:#CCCCCC 1px solid\" /></a></td>";
                    content += "</tr><tr><td align=\"center\"><a href=\"productdetail.aspx?id=" +
                               ds.Tables[0].Rows[t]["SanPhamID"]
                               + "\">" //+ tensanpham
                               + "</a><span class=\"price\">" +
                               String.Format("{0:0,0}", ds.Tables[0].Rows[t]["GiaSanPham"]).Replace(",", ".") +
                               "</span>"
                               + "</tr></table>";
                }
                td.Text = content;
                td.Width = Unit.Percentage(16);
                td.VerticalAlign = VerticalAlign.Top;
                tr.Cells.Add(td);
            }

            tblSanPham02.Rows.Add(tr);
            tblSanPham02.Style.Value = "border:solid 1px #c9c3c5";
        }
    }
    
    private void LoadSanPham04()
    {
        //LoadDanhMuc04
        tblDanhMuc04.Controls.Clear();
        tblSanPham04.Controls.Clear();
        NhomSanPham nsp = new NhomSanPham();
        DataSet ds;
        if (Cache["dmnsp"] == null)
        {
            ds = nsp.SelectRanDomNhomSanPhamShowed();
            Cache["dmnsp"] = ds;
        }
        else
        {
            ds = (DataSet)Cache["dmnsp"];
        }

        DataRow[] dr = ds.Tables[0].Select();
        int n = 4;
        if (dr.Length < 4) n = dr.Length;
        TableRow tr = new TableRow();
        for (int i = 0; i < n; i++)
        {
            if ((!Page.IsPostBack && i == 0) || hidCatId.Value == "0" || hidCatId.Value == "") hidCatId.Value = dr[0]["NhomSanPhamID"].ToString();
            TableCell td = new TableCell();
            td.Width = Unit.Percentage(100 / n);
            if (hidCatId.Value.Trim().Length > 0)
            {
                if (dr[i]["NhomSanPhamID"].ToString() == hidCatId.Value)
                {
                    string content = "";
                    content += "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">";
                    content += "<tr><td width=\"12\"></td>";
                    content += "<td class=\"nd2\">" + dr[i]["TenNhomSanPham"].ToString() + "</td>";
                    content += "<td width=\"12\"></td></tr></table>";
                    td.VerticalAlign = VerticalAlign.Bottom;
                    td.Text = content;
                    tr.Cells.Add(td);
                    //LoadSanPham04
                    SanPham sp = new SanPham();
                    DataSet sds = sp.SelectSanPhamAtViTriSanPhamInNhomSanPhamID(4, int.Parse(dr[i]["NhomSanPhamID"].ToString()));
                    int sn = sds.Tables[0].Rows.Count;
                    for (int j = 0; j < 2; j++)
                    {
                        TableRow str = new TableRow();
                        for (int si = 0; si < 5; si++)
                        {
                            TableCell std = new TableCell();
                            string scontent = "";
                            if (j * 5 + si < sn)
                            {
                                string tensanpham = sds.Tables[0].Rows[j * 5 + si]["TenSanPham"].ToString() +
                                       " " + sds.Tables[0].Rows[j * 5 + si]["TenSanPhamPhu"].ToString();
                                if (tensanpham.Length > 20) tensanpham = tensanpham.Substring(0, 20) + "...";

                                scontent += "<table class=\"product\" width=\"100%\" border=\"0\" cellspacing=\"4\" cellpadding=\"0\">";
                                scontent += "<tr><td align=\"center\"><a href=\"productdetail.aspx?id=" + sds.Tables[0].Rows[j * 5 + si]["SanPhamID"].ToString()
                                    + "\">" + tensanpham + "<br><img src=\"" + sds.Tables[0].Rows[j * 5 + si]["AnhSanPham"].ToString()
                                    + "\" alt=\"" + sds.Tables[0].Rows[j * 5 + si]["TenSanPham"].ToString() + "\" width=\"99\" height=\"89\" border=\"0\" style=\"border:#CCCCCC 1px solid\" /></a></td>";
                                scontent += "</tr><tr><td align=\"center\"><a href=\"productdetail.aspx?id=" + sds.Tables[0].Rows[j * 5 + si]["SanPhamID"].ToString()
                                    + "\">" + "</a>";
                                scontent += "<span class=\"price\">" + String.Format("{0:0,0}", sds.Tables[0].Rows[j * 5 + si]["GiaSanPham"]).Replace(",", ".")
                                    + "</span>" + sds.Tables[0].Rows[j * 5 + si]["DonViTienTe"].ToString() + "</td></tr></table>";
                            }
                            std.Text = scontent;
                            if (j == 0) std.Width = Unit.Percentage(16);
                            str.Cells.Add(std);
                        }
                        tblSanPham04.Rows.Add(str);
                    }
                }
                else
                {
                    string content = "<a href=\"javascript:RefreshProduct04(" + dr[i]["NhomSanPhamID"].ToString() + ")\">" + dr[i]["TenNhomSanPham"].ToString() + "</a>";
                    td.CssClass = "nd1";
                    td.Text = content;
                    tr.Cells.Add(td);
                }
            }
            else
            {
                td.Text = "Selected Tab parameter is misisng!";
                tr.Cells.Add(td);
            }
        }
        tblDanhMuc04.Rows.Add(tr);
    }
    
    private void LoadSanPham07(int pagesize, int rowstart)
    {
        //San pham moi cap nhat
        SanPham sp = new SanPham();
        DataSet ds = sp.SelectSanPhamMoiCapNhatPaging(pagesize, rowstart);
        int n = ds.Tables[0].Rows.Count;
        for (int j = 0; j < 5; j++)
        {
            TableRow tr = new TableRow();
            for (int i = 0; i < 2; i++)
            {
                TableCell td = new TableCell();
                string content = "";
                if (j*2 + i < n)
                {
                    content +=
                        "<table class=\"product1\" width=\"105\" border=\"0\" cellspacing=\"4\" cellpadding=\"0\">";
                    content += "<tr><td><a href=\"productdetail.aspx?id=" + ds.Tables[0].Rows[j*2 + i]["SanPhamID"]
                               + "\"><img src=\"" + ds.Tables[0].Rows[j*2 + i]["AnhSanPham"]
                               + "\" alt=\"" + ds.Tables[0].Rows[j*2 + i]["TenSanPham"] + " "
                               + ds.Tables[0].Rows[j*2 + i]["TenSanPhamPhu"]
                               +
                               "\" width=\"74\" height=\"66\" border=\"0\" style=\"border:#CCCCCC 1px solid\" /></a></td>";
                    content += "<td style=\"width:60%\"><a href=\"productdetail.aspx?id=" +
                               ds.Tables[0].Rows[j*2 + i]["SanPhamID"]
                               + "\">" + "</td></tr></table>";
                }
                td.Text = content;
                td.HorizontalAlign = HorizontalAlign.Left;
                if (j == 0) td.Width = Unit.Percentage(25);
                tr.Cells.Add(td);
            }
            tblSanPham07.Rows.Add(tr);
        }
    }

    private void LoadSanPhamDaXem()
    {
        if (Session["tblSanPhamDaXem"] != null)
        {
            DataTable tableSanPhamDaXem = (DataTable) Session["tblSanPhamDaXem"];
            int n = tableSanPhamDaXem.Rows.Count;
            for (int i = 0; i < n; i++)
            {
                TableRow tr = new TableRow();
                TableCell td = new TableCell();
                DataRow dr = tableSanPhamDaXem.Rows[i];
                string content = "";
                string tensanpham = dr["TenSanPham"] +
                                    dr["TenSanPhamPhu"].ToString();
                if (tensanpham.Length > 20) tensanpham = tensanpham.Substring(0, 20) + "...";

                content += "<table class=\"product1\" width=\"100%\" border=\"0\" cellspacing=\"4\" cellpadding=\"0\">";
                content += "<tr><td align=\"left\" style=\"width:74px\"><a href=\"productdetail.aspx?id=" +
                           dr["SanPhamID"]
                           + "\"><img src=\"" + dr["AnhSanPham"]
                           + "\" alt=\"" + dr["TenSanPham"]
                           + "\" width=\"74\" height=\"66\" border=\"0\" style=\"border:#CCCCCC 1px solid\" /></a></td>";
                content += "<td align=\"left\" style=\"width:80%\"><a href=\"productdetail.aspx?id=" + dr["SanPhamID"]
                           + "\">" + tensanpham + "</a><br />";
                content += "<span class=\"price\">" + String.Format("{0:0,0}", dr["GiaSanPham"]).Replace(",", ".")
                           + "</span> " + dr["DonViTienTe"] + " </td></tr></table>";
                td.Text = content;
                td.HorizontalAlign = HorizontalAlign.Center;
                tr.Cells.Add(td);
                tblSanPhamDaXem.Rows.Add(tr);
            }
        }
    }
    protected void pnlSanPham04_ContentRefresh(object sender, EventArgs e)
    {
        LoadSanPham04();
    }
    protected void tmDanhMuc_Tick(object sender, EventArgs e)
    {
        NhomSanPham nsp = new NhomSanPham();
        DataSet ds;

        ds = nsp.SelectRanDomNhomSanPhamShowed();
        if (Cache["dmnsp"] != null)
            Cache.Remove("dmnsp");
        Cache["dmnsp"] = ds;

        LoadSanPham04();
    }
    protected void pnlTinTuc_ContentRefresh(object sender, EventArgs e)
    {
        LoadTinTuc();
    }

    private void LoadTinTuc()
    {
        TinTuc tt = new TinTuc();
        int currentrow;
        int totalrows;
        if ((ViewState["currentrow"] != null) && (ViewState["totalrow"] != null))
        {
            currentrow = int.Parse(ViewState["currentrow"].ToString());
            totalrows = int.Parse(ViewState["totalrow"].ToString());
        }
        else
        {
            currentrow = 1;
            totalrows = 1;
        }

        if (HidTinTuc.Value == "down")
        {
            if (currentrow != totalrows)
            {
                currentrow += 1;
            }
            else
            {
                currentrow = 1;
            }
        }
        else if (HidTinTuc.Value == "up")
        {
            if (currentrow != 1)
            {
                currentrow -= 1;
            }
            else
            {
                currentrow = totalrows;
            }
        }

        DataSet ds = tt.GetTinTucByThuTu(currentrow);
        ViewState["totalrow"] = ds.Tables[1].Rows[0][0].ToString();
        ViewState["currentrow"] = currentrow;

        if (ds.Tables[0].Rows.Count > 0)
        {
            lblTieuDe.Text = ds.Tables[0].Rows[0]["TieuDe"].ToString();
            divTinTuc.InnerText = ds.Tables[0].Rows[0]["TomTat"].ToString();
        }
    }

    protected void Timer1_Tick(object sender, EventArgs e)
    {
        LoadQuangCao10();
    }

    protected void tmquangcao02_Tick(object sender, EventArgs e)
    {
        LoadQuangCao02();
    }

    protected void tmquangcao04_Tick(object sender, EventArgs e)
    {
        LoadQuangCao04();
    }

    protected void Timer1_Tick1(object sender, EventArgs e)
    {
        LoadQuangCao03();
    }

    protected void tmQuangCao5_Tick(object sender, EventArgs e)
    {
        LoadQuangCao05();
    }

    protected void tmQuangCao7_Tick(object sender, EventArgs e)
    {
        LoadQuangCao07();
    }

    protected void tmQuangCao8_Tick(object sender, EventArgs e)
    {
        LoadQuangCao08();
    }

    protected void tmQuangCao9_Tick(object sender, EventArgs e)
    {
        LoadQuangCao09();
    }

    private void LoadHoTroTrucTuyen()
    {
        HoTroTrucTuyen ht = new HoTroTrucTuyen();
        DataSet ds = ht.SelectByCuaHangID(0);

        string content = "";
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DataRow dr = ds.Tables[0].Rows[i];
                content += "<a href=\"ymsgr:sendIM?" + dr["YM"]
                           + "\"><img src=\"http://opi.yahoo.com/online?u="
                           + dr["YM"] + "&t=1\" border=\"0\">" +
                           dr["TenHoTro"] + "</a><br>";
            }
            supporters.InnerHtml = content;
        }
    }

    private void LoadAllQuangCao()
    {
        QuangCao qcao = new QuangCao();
        DataSet ds;
        if (Cache["dsallquangcao"] == null)
        {
            ds = qcao.SelectQuangCaoAtViTriQuangCaoByLoaiNguoiDungIDForHomePage(3, "1,2,3,4,5,6,7,8,9,10");
            Cache["dsallquangcao"] = ds;
        }
        else
        {
            ds = (DataSet) Cache["dsallquangcao"];
        }
        if (ds.Tables[0].Rows.Count >= 1)
        {
            for (int i = 0; i < 10; i++)
            {
                ds.Tables[0].DefaultView.RowFilter = "ViTriQuangCao = " + (i + 1);
                DataView dv = ds.Tables[0].DefaultView;
                if (dv.Count > 0)
                {
                    switch (i)
                    {
                        case 0:
                            if (dv[0]["LoaiAnh"].ToString() == "FLASH")
                            {
                                spnQuangCao01.InnerHtml = "<object border:solid 1px #C9C3C3 classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
                                                          +
                                                          "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
                                                          + "width=\"100%\" height=\"111\" title=\"Quang Cao\">"
                                                          + "<param name=\"movie\" value=\"" + dv[0]["DuongDanAnh"] +
                                                          "\" />"
                                                          + "<param name=\"quality\" value=\"high\" />"
                                                          + "<embed src=\"" + dv[0]["DuongDanAnh"] +
                                                          "\" quality=\"high\""
                                                          +
                                                          "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
                                                          + "width=\"100%\" height=\"111\"></embed></object>";
                            }
                            else
                            {
                                spnQuangCao01.InnerHtml = "<a href=\"" + dv[0]["DuongDan"]
                                                          + "\" target=\"_blank\"><img alt=\"" +
                                                          dv[0]["NoiDungQuangCao"]
                                                          + "\" src=\"" + dv[0]["DuongDanAnh"] +
                                                          "\" height=\"111px\" width=\"100%\" style=\"border:solid 1px #C9C3C3\"/></a>";
                            }
                            break;
                        case 1:
                            if (dv[0]["LoaiAnh"].ToString() == "FLASH")
                            {
                                spnQuangCao02.InnerHtml = "<object style=\"z-index:1\" z-index:1  border:solid 1px #C9C3C3 classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
                                                          +
                                                          "z-index=\"0\" codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
                                                          + "width=\"550\" height=\"216\" title=\"Quang Cao\">"
                                                          + "<param name=\"movie\" value=\"" + dv[0]["DuongDanAnh"] +
                                                          "\" />"
                                                          + "<param name=\"quality\" value=\"high\" />"
                                                          + "<param name=\"wmode\" value=\"transparent\" />"
                                                          + "<embed wmode=\"transparent\" src=\"" + dv[0]["DuongDanAnh"] +
                                                          "\" quality=\"high\""
                                                          +
                                                          "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
                                                          +
                                                          "width=\"550\" height=\"216\" style=\"z-index:1\"></embed></object>";
                            }
                            else
                            {
                                spnQuangCao02.InnerHtml = "<a href=\"" + dv[0]["DuongDan"]
                                                          + "\" target=\"_blank\" style=\"z-index:1\"><img alt=\"" +
                                                          dv[0]["NoiDungQuangCao"]
                                                          + "\" src=\"" + dv[0]["DuongDanAnh"] +
                                                          "\" height=\"216px\" width=\"550px\" style=\"z-index:1;border:solid 1px #C9C3C3\"/></a>";
                            }
                            break;
                        case 2:
                            int n = dv.Count;
                            spnQuangCao03a.InnerHtml =
                                "<img alt=\"Moi quang cao\" src=\"./images/advblank.jpg\" height=\"122px\" width=\"365px\" style=\"border:solid 1px #C9C3C3\"/>";
                            spnQuangCao03b.InnerHtml =
                                "<img alt=\"Moi quang cao\" src=\"./images/advblank.jpg\" height=\"122px\" width=\"365px\" style=\"border:solid 1px #C9C3C3\"/>";
                            //spnQuangCao03c.InnerHtml = "<img alt=\"Moi quang cao\" src=\"./images/advblank.jpg\" height=\"122px\" width=\"365px\" style=\"border:solid 1px #C9C3C3\"/>";
                            if (n >= 1)
                            {
                                if (dv[0]["LoaiAnh"].ToString() == "FLASH")
                                {
                                    spnQuangCao03a.InnerHtml = "<object style=\"border:solid 1px #C9C3C3\" classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
                                                               +
                                                               "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
                                                               + "width=\"365px\" height=\"122\" title=\"Quang Cao\">"
                                                               + "<param name=\"movie\" value=\"" + dv[0]["DuongDanAnh"] +
                                                               "\" />"
                                                               + "<param name=\"quality\" value=\"high\" />"
                                                               + "<embed src=\"" + dv[0]["DuongDanAnh"] +
                                                               "\" quality=\"high\""
                                                               +
                                                               "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
                                                               + "width=\"365px\" height=\"122\"></embed></object>";
                                }
                                else
                                {
                                    spnQuangCao03a.InnerHtml = "<a href=\"" + dv[0]["DuongDan"]
                                                               + "\" target=\"_blank\"><img alt=\"" +
                                                               dv[0]["NoiDungQuangCao"]
                                                               + "\" src=\"" + dv[0]["DuongDanAnh"] +
                                                               "\" height=\"122px\" width=\"365pxpx\" style=\"border:solid 1px #C9C3C3\"/></a>";
                                }
                                if (n >= 2)
                                {
                                    if (dv[1]["LoaiAnh"].ToString() == "FLASH")
                                    {
                                        spnQuangCao03b.InnerHtml = "<object style=\"border:solid 1px #C9C3C3\" classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
                                                                   +
                                                                   "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
                                                                   +
                                                                   "width=\"365px\" height=\"122\" title=\"Quang Cao\">"
                                                                   + "<param name=\"movie\" value=\"" +
                                                                   dv[1]["DuongDanAnh"] + "\" />"
                                                                   + "<param name=\"quality\" value=\"high\" />"
                                                                   + "<embed src=\"" + dv[1]["DuongDanAnh"] +
                                                                   "\" quality=\"high\""
                                                                   +
                                                                   "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
                                                                   + "width=\"365px\" height=\"122\"></embed></object>";
                                    }
                                    else
                                    {
                                        spnQuangCao03b.InnerHtml = "<a href=\"" + dv[1]["DuongDan"]
                                                                   + "\" target=\"_blank\"><img alt=\"" +
                                                                   dv[1]["NoiDungQuangCao"]
                                                                   + "\" src=\"" + dv[1]["DuongDanAnh"] +
                                                                   "\" height=\"122px\" width=\"365px\" style=\"border:solid 1px #C9C3C3\"/></a>";
                                    }
                                }
                            }
                            else
                            {
                                tblQuangCao03.Visible = false;
                            }
                            break;
                        case 3:
                            n = 5;
                            if (dv.Count <= 2) n = dv.Count;

                            for (int j = 0; j < n; j++)
                            {
                                TableRow tr = new TableRow();
                                TableCell td = new TableCell();
                                td.Style.Value = "padding-top: 4px; padding-left:4px";
                                string content = "";
                                if (dv[j]["LoaiAnh"].ToString() == "FLASH")
                                {
                                    content = "<object style=\"border:solid 1px #C9C3C3\" classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
                                              +
                                              "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
                                              + "width=\"200\" height=\"155\" title=\"Quang Cao\">"
                                              + "<param name=\"movie\" value=\"" + dv[j]["DuongDanAnh"] + "\" />"
                                              + "<param name=\"quality\" value=\"high\" />"
                                              + "<embed src=\"" + dv[j]["DuongDanAnh"] + "\" quality=\"high\""
                                              +
                                              "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
                                              + "width=\"200\" height=\"155\"></embed></object>";
                                }
                                else
                                {
                                    content = "<a href=\"" + dv[j]["DuongDan"]
                                              + "\" target=\"_blank\"><img alt=\"" + dv[j]["NoiDungQuangCao"]
                                              + "\" src=\"" + dv[j]["DuongDanAnh"]
                                              + "\" style=\"border:solid 1px #C9C3C3; width:200px;\"></a>";
                                }
                                td.Text = content;
                                tr.Cells.Add(td);
                                tblQuangCao04.Rows.Add(tr);
                            }
                            break;
                        case 4:
                            n = dv.Count;
                            spnQuangCao05a.InnerHtml =
                                "<img alt=\"Moi quang cao\" src=\"./images/advblank.jpg\" height=\"122px\" width=\"365px\" style=\"border:solid 1px #C9C3C3\"/>";
                            spnQuangCao05b.InnerHtml =
                                "<img alt=\"Moi quang cao\" src=\"./images/advblank.jpg\" height=\"122px\" width=\"365px\" style=\"border:solid 1px #C9C3C3\"/>";
                            //spnQuangCao05c.InnerHtml = "<img alt=\"Moi quang cao\" src=\"./images/advblank.jpg\" height=\"122px\" width=\"365px\" style=\"border:solid 1px #C9C3C3\"/>";
                            if (n >= 1)
                            {
                                if (dv[0]["LoaiAnh"].ToString() == "FLASH")
                                {
                                    spnQuangCao05a.InnerHtml = "<object style=\"border:solid 1px #C9C3C3\" classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
                                                               +
                                                               "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
                                                               + "width=\"365px\" height=\"122\" title=\"Quang Cao\">"
                                                               + "<param name=\"movie\" value=\"" + dv[0]["DuongDanAnh"] +
                                                               "\" />"
                                                               + "<param name=\"quality\" value=\"high\" />"
                                                               + "<embed src=\"" + dv[0]["DuongDanAnh"] +
                                                               "\" quality=\"high\""
                                                               +
                                                               "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
                                                               + "width=\"365px\" height=\"122\"></embed></object>";
                                }
                                else
                                {
                                    spnQuangCao05a.InnerHtml = "<a href=\"" + dv[0]["DuongDan"]
                                                               + "\" target=\"_blank\"><img alt=\"" +
                                                               dv[0]["NoiDungQuangCao"]
                                                               + "\" src=\"" + dv[0]["DuongDanAnh"] +
                                                               "\" height=\"122px\" width=\"365px\" style=\"border:solid 1px #C9C3C3\"/></a>";
                                }
                                if (n >= 2)
                                {
                                    if (dv[1]["LoaiAnh"].ToString() == "FLASH")
                                    {
                                        spnQuangCao05b.InnerHtml = "<object style=\"border:solid 1px #C9C3C3\" classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
                                                                   +
                                                                   "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
                                                                   +
                                                                   "width=\"365px\" height=\"122\" title=\"Quang Cao\">"
                                                                   + "<param name=\"movie\" value=\"" +
                                                                   dv[1]["DuongDanAnh"] + "\" />"
                                                                   + "<param name=\"quality\" value=\"high\" />"
                                                                   + "<embed src=\"" + dv[1]["DuongDanAnh"] +
                                                                   "\" quality=\"high\""
                                                                   +
                                                                   "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
                                                                   + "width=\"365px\" height=\"122\"></embed></object>";
                                    }
                                    else
                                    {
                                        spnQuangCao05b.InnerHtml = "<a href=\"" + dv[1]["DuongDan"]
                                                                   + "\" target=\"_blank\"><img alt=\"" +
                                                                   dv[1]["NoiDungQuangCao"]
                                                                   + "\" src=\"" + dv[1]["DuongDanAnh"] +
                                                                   "\" height=\"122px\" width=\"365px\" style=\"border:solid 1px #C9C3C3\"/></a>";
                                    }
                                }
                            }
                            else
                            {
                                tblQuangCao05.Visible = false;
                            }
                            break;
                        case 5:
                            //spn = spnQuangCao06a;
                            //spn1 = spnQuangCao06b;
                            break;
                        case 6:
                            n = dv.Count;
                            spnQuangCao07a.InnerHtml =
                                "<img alt=\"Moi quang cao\" src=\"./images/advblank.jpg\" height=\"122px\" width=\"365px\" style=\"border:solid 1px #C9C3C3\"/>";
                            spnQuangCao07b.InnerHtml =
                                "<img alt=\"Moi quang cao\" src=\"./images/advblank.jpg\" height=\"122px\" width=\"365px\" style=\"border:solid 1px #C9C3C3\"/>";
                            //spnQuangCao07c.InnerHtml = "<img alt=\"Moi quang cao\" src=\"./images/advblank.jpg\" height=\"122px\" width=\"365px\" style=\"border:solid 1px #C9C3C3\"/>";
                            if (n >= 1)
                            {
                                if (dv[0]["LoaiAnh"].ToString() == "FLASH")
                                {
                                    spnQuangCao07a.InnerHtml = "<object style=\"border:solid 1px #C9C3C3\" classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
                                                               +
                                                               "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
                                                               + "width=\"365px\" height=\"122\" title=\"Quang Cao\">"
                                                               + "<param name=\"movie\" value=\"" + dv[0]["DuongDanAnh"] +
                                                               "\" />"
                                                               + "<param name=\"quality\" value=\"high\" />"
                                                               + "<embed src=\"" + dv[0]["DuongDanAnh"] +
                                                               "\" quality=\"high\""
                                                               +
                                                               "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
                                                               + "width=\"365px\" height=\"122\"></embed></object>";
                                }
                                else
                                {
                                    spnQuangCao07a.InnerHtml = "<a href=\"" + dv[0]["DuongDan"]
                                                               + "\" target=\"_blank\"><img alt=\"" +
                                                               dv[0]["NoiDungQuangCao"]
                                                               + "\" src=\"" + dv[0]["DuongDanAnh"] +
                                                               "\" height=\"122px\" width=\"365px\" style=\"border:solid 1px #C9C3C3\"/></a>";
                                }
                                if (n >= 2)
                                {
                                    if (dv[1]["LoaiAnh"].ToString() == "FLASH")
                                    {
                                        spnQuangCao07b.InnerHtml = "<object style=\"border:solid 1px #C9C3C3\" classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
                                                                   +
                                                                   "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
                                                                   +
                                                                   "width=\"365px\" height=\"122\" title=\"Quang Cao\">"
                                                                   + "<param name=\"movie\" value=\"" +
                                                                   dv[1]["DuongDanAnh"] + "\" />"
                                                                   + "<param name=\"quality\" value=\"high\" />"
                                                                   + "<embed src=\"" + dv[1]["DuongDanAnh"] +
                                                                   "\" quality=\"high\""
                                                                   +
                                                                   "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
                                                                   + "width=\"365px\" height=\"122\"></embed></object>";
                                    }
                                    else
                                    {
                                        spnQuangCao07b.InnerHtml = "<a href=\"" + dv[1]["DuongDan"]
                                                                   + "\" target=\"_blank\"><img alt=\"" +
                                                                   dv[1]["NoiDungQuangCao"]
                                                                   + "\" src=\"" + dv[1]["DuongDanAnh"] +
                                                                   "\" height=\"122px\" width=\"365px\" style=\"border:solid 1px #C9C3C3\"/></a>";
                                    }
                                }
                            }
                            else
                            {
                                tblQuangCao07.Visible = false;
                            }
                            break;
                        case 7:
                            n = dv.Count;
                            spnQuangCao08a.InnerHtml =
                                "<img alt=\"Moi quang cao\" src=\"./images/advblank.jpg\" height=\"122px\" width=\"365px\" style=\"border:solid 1px #C9C3C3\"/>";
                            spnQuangCao08b.InnerHtml =
                                "<img alt=\"Moi quang cao\" src=\"./images/advblank.jpg\" height=\"122px\" width=\"365px\" style=\"border:solid 1px #C9C3C3\"/>";
                            //spnQuangCao08c.InnerHtml = "<img alt=\"Moi quang cao\" src=\"./images/advblank.jpg\" height=\"122px\" width=\"365px\" style=\"border:solid 1px #C9C3C3\"/>";
                            if (n >= 1)
                            {
                                if (dv[0]["LoaiAnh"].ToString() == "FLASH")
                                {
                                    spnQuangCao08a.InnerHtml = "<object style=\"border:solid 1px #C9C3C3\" classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
                                                               +
                                                               "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
                                                               + "width=\"365px\" height=\"122\" title=\"Quang Cao\">"
                                                               + "<param name=\"movie\" value=\"" + dv[0]["DuongDanAnh"] +
                                                               "\" />"
                                                               + "<param name=\"quality\" value=\"high\" />"
                                                               + "<embed src=\"" + dv[0]["DuongDanAnh"] +
                                                               "\" quality=\"high\""
                                                               +
                                                               "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
                                                               + "width=\"365px\" height=\"122\"></embed></object>";
                                }
                                else
                                {
                                    spnQuangCao08a.InnerHtml = "<a href=\"" + dv[0]["DuongDan"]
                                                               + "\" target=\"_blank\"><img alt=\"" +
                                                               dv[0]["NoiDungQuangCao"]
                                                               + "\" src=\"" + dv[0]["DuongDanAnh"] +
                                                               "\" height=\"122px\" width=\"365px\" style=\"border:solid 1px #C9C3C3\"/></a>";
                                }
                                if (n >= 2)
                                {
                                    if (dv[1]["LoaiAnh"].ToString() == "FLASH")
                                    {
                                        spnQuangCao08b.InnerHtml = "<object style=\"border:solid 1px #C9C3C3\" classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
                                                                   +
                                                                   "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
                                                                   +
                                                                   "width=\"365px\" height=\"122\" title=\"Quang Cao\">"
                                                                   + "<param name=\"movie\" value=\"" +
                                                                   dv[1]["DuongDanAnh"] + "\" />"
                                                                   + "<param name=\"quality\" value=\"high\" />"
                                                                   + "<embed src=\"" + dv[1]["DuongDanAnh"] +
                                                                   "\" quality=\"high\""
                                                                   +
                                                                   "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
                                                                   + "width=\"365px\" height=\"122\"></embed></object>";
                                    }
                                    else
                                    {
                                        spnQuangCao08b.InnerHtml = "<a href=\"" + dv[1]["DuongDan"]
                                                                   + "\" target=\"_blank\"><img alt=\"" +
                                                                   dv[1]["NoiDungQuangCao"]
                                                                   + "\" src=\"" + dv[1]["DuongDanAnh"] +
                                                                   "\" height=\"122px\" width=\"365px\" style=\"border:solid 1px #C9C3C3\"/></a>";
                                    }
                                }
                            }
                            else
                            {
                                tblQuangCao08.Visible = false;
                            }
                            break;
                        case 8:
                            n = dv.Count;
                            spnQuangCao09a.InnerHtml =
                                "<img alt=\"Moi quang cao\" src=\"./images/advblank.jpg\" height=\"122px\" width=\"365px\" style=\"border:solid 1px #C9C3C3\"/>";
                            spnQuangCao09b.InnerHtml =
                                "<img alt=\"Moi quang cao\" src=\"./images/advblank.jpg\" height=\"122px\" width=\"365px\" style=\"border:solid 1px #C9C3C3\"/>";
                            //spnQuangCao09c.InnerHtml = "<img alt=\"Moi quang cao\" src=\"./images/advblank.jpg\" height=\"122px\" width=\"365px\" style=\"border:solid 1px #C9C3C3\"/>";
                            if (n >= 1)
                            {
                                if (dv[0]["LoaiAnh"].ToString() == "FLASH")
                                {
                                    spnQuangCao09a.InnerHtml = "<object style=\"border:solid 1px #C9C3C3\" classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
                                                               +
                                                               "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
                                                               + "width=\"365px\" height=\"122\" title=\"Quang Cao\">"
                                                               + "<param name=\"movie\" value=\"" + dv[0]["DuongDanAnh"] +
                                                               "\" />"
                                                               + "<param name=\"quality\" value=\"high\" />"
                                                               + "<embed src=\"" + dv[0]["DuongDanAnh"] +
                                                               "\" quality=\"high\""
                                                               +
                                                               "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
                                                               + "width=\"365px\" height=\"122\"></embed></object>";
                                }
                                else
                                {
                                    spnQuangCao09a.InnerHtml = "<a href=\"" + dv[0]["DuongDan"]
                                                               + "\" target=\"_blank\"><img alt=\"" +
                                                               dv[0]["NoiDungQuangCao"]
                                                               + "\" src=\"" + dv[0]["DuongDanAnh"] +
                                                               "\" height=\"122px\" width=\"365px\" style=\"border:solid 1px #C9C3C3\"/></a>";
                                }
                                if (n >= 2)
                                {
                                    if (dv[1]["LoaiAnh"].ToString() == "FLASH")
                                    {
                                        spnQuangCao09b.InnerHtml = "<object style=\"border:solid 1px #C9C3C3\" classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
                                                                   +
                                                                   "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
                                                                   +
                                                                   "width=\"365px\" height=\"122\" title=\"Quang Cao\">"
                                                                   + "<param name=\"movie\" value=\"" +
                                                                   dv[1]["DuongDanAnh"] + "\" />"
                                                                   + "<param name=\"quality\" value=\"high\" />"
                                                                   + "<embed src=\"" + dv[1]["DuongDanAnh"] +
                                                                   "\" quality=\"high\""
                                                                   +
                                                                   "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
                                                                   + "width=\"365px\" height=\"122\"></embed></object>";
                                    }
                                    else
                                    {
                                        spnQuangCao09b.InnerHtml = "<a href=\"" + dv[1]["DuongDan"]
                                                                   + "\" target=\"_blank\"><img alt=\"" +
                                                                   dv[1]["NoiDungQuangCao"]
                                                                   + "\" src=\"" + dv[1]["DuongDanAnh"] +
                                                                   "\" height=\"122px\" width=\"365px\" style=\"border:solid 1px #C9C3C3\"/></a>";
                                    }
                                }
                            }
                            else
                            {
                                tblQuangCao09.Visible = false;
                            }
                            break;
                        case 9:
                            if (dv[0]["LoaiAnh"].ToString() == "FLASH")
                            {
                                spnQuangCao10.InnerHtml = "<object border:solid 1px #C9C3C3 classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
                                                          +
                                                          "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
                                                          + "width=\"980\" height=\"111\" title=\"Quang Cao\">"
                                                          + "<param name=\"movie\" value=\"" + dv[0]["DuongDanAnh"] +
                                                          "\" />"
                                                          + "<param name=\"quality\" value=\"high\" />"
                                                          + "<embed src=\"" + dv[0]["DuongDanAnh"] +
                                                          "\" quality=\"high\""
                                                          +
                                                          "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
                                                          + "width=\"980\" height=\"216\"></embed></object>";
                            }
                            else
                            {
                                spnQuangCao10.InnerHtml = "<a href=\"" + dv[0]["DuongDan"]
                                                          + "\" target=\"_blank\"><img alt=\"" +
                                                          dv[0]["NoiDungQuangCao"]
                                                          + "\" src=\"" + dv[0]["DuongDanAnh"] +
                                                          "\" height=\"111px\" width=\"980px\" style=\"border:solid 1px #C9C3C3\"/></a>";
                            }
                            break;
                    }
                }
            }
        }
    }

    private void GetAllSanPhamUC_Top4_GG_KM_GH()
    {
        SanPham sp = new SanPham();
        DataSet ds;
        if (Cache["dsallsanpham"] == null)
        {
            ds = sp.SelectSPUc_Top4_GG_KM_GH();
            Cache["dsallsanpham"] = ds;
        }
        else
        {
            ds = (DataSet) Cache["dsallsanpham"];
        }
        int n = 0;
        TableRow tr;
        //ua chuong        
        DataTable dtUc = null;
        if (ds.Tables.Count >= 1)
        {
            dtUc = ds.Tables[0];
            n = dtUc.Rows.Count;
            tr = new TableRow();
            for (int i = 0; i < 5; i++)
            {
                TableCell td = new TableCell();
                string content = "";
                if (i < n)
                {
                    string tensanpham = dtUc.Rows[i]["TenSanPham"] +
                                        " " + dtUc.Rows[i]["TenSanPhamPhu"];
                    if (tensanpham.Length > 20) tensanpham = tensanpham.Substring(0, 20) + "...";

                    content += "<table width=\"100%\" border=\"0\" cellspacing=\"4\" cellpadding=\"0\">";
                    content += "<tr><td align=\"center\"><a href=\"productdetail.aspx?id=" + dtUc.Rows[i]["SanPhamID"]
                               + "\"><img src=\"" + dtUc.Rows[i]["AnhSanPham"]
                               +
                               "\" width=\"179\" height=\"159\" border=\"0\"  style=\"border:#CCCCCC 1px solid\" /></a></td>";
                    content += "</tr><tr><td align=\"center\"><b><a href=\"productdetail.aspx?id=" +
                               ds.Tables[0].Rows[i]["SanPhamID"]
                               + "\">" + tensanpham + "</a></b> <br />";
                    content += "<span class=\"price\">" +
                               String.Format("{0:0,0}", dtUc.Rows[i]["GiaSanPham"]).Replace(",", ".")
                               + "</span> " + dtUc.Rows[i]["DonViTienTe"] + "</td></tr></table>";
                }
                td.Text = content;
                td.Width = Unit.Percentage(25);
                td.VerticalAlign = VerticalAlign.Top;
                tr.Cells.Add(td);
            }
            tblSanPham03.Rows.Add(tr);
        }


        ///giam gia
        DataTable dtgg = null;
        if (ds.Tables.Count >= 3)
        {
            dtgg = ds.Tables[2];
            n = dtgg.Rows.Count;
            for (int j = 0; j < 1; j++)
            {
                tr = new TableRow();
                const int sosp = 5;
                for (int i = 0; i < sosp; i++)
                {
                    TableCell td = new TableCell();
                    string content = "";
                    if (j*sosp + i < n)
                    {
                        string tensanpham = dtgg.Rows[j*sosp + i]["TenSanPham"] +
                                            " " + dtgg.Rows[j*sosp + i]["TenSanPhamPhu"];
                        if (tensanpham.Length > 20) tensanpham = tensanpham.Substring(0, 20) + "...";

                        content +=
                            "<table class=\"product\" width=\"100%\" border=\"0\" cellspacing=\"4\" cellpadding=\"0\">";
                        content += "<tr><td align=\"center\"><a href=\"productdetail.aspx?id=" +
                                   dtgg.Rows[j*sosp + i]["SanPhamID"]
                                   + "\">" + tensanpham + "<br><img src=\"" + dtgg.Rows[j*sosp + i]["AnhSanPham"]
                                   + "\" alt=\"" + dtgg.Rows[j*sosp + i]["TenSanPham"] +
                                   "\" width=\"74\" height=\"66\" border=\"0\" style=\"border:#CCCCCC 1px solid\" /></a>";
                        content += "<a href=\"productdetail.aspx?id=" + dtgg.Rows[j*sosp + i]["SanPhamID"]
                                   + "\">" + "</a><br><span class=\"oldprice\">"
                                   + String.Format("{0:0,0}", dtgg.Rows[j*sosp + i]["GiaSanPham"]).Replace(",", ".")
                                   + "VNĐ </span>";
                        content += "<br><span class=\"price\">"
                                   + String.Format("{0:0,0}", dtgg.Rows[j*sosp + i]["GiaKhuyenMai"]).Replace(",", ".")
                                   + "VNĐ </span></td></tr></table>";
                    }
                    td.Text = content;
                    td.HorizontalAlign = HorizontalAlign.Left;
                    if (j == 0) td.Width = Unit.Percentage(20);
                    tr.Cells.Add(td);
                }
                tblSanPham05.Rows.Add(tr);
            }
        }
        //km
        DataTable dtkm = null;
        if (ds.Tables.Count >= 4)
        {
            dtkm = ds.Tables[3];
            n = dtkm.Rows.Count;
            for (int j = 0; j < 3; j++)
            {
                tr = new TableRow();
                int sosp = 5;
                for (int i = 0; i < sosp; i++)
                {
                    TableCell td = new TableCell();
                    string content = "";
                    if (j*sosp + i < n)
                    {
                        string tensanpham = dtkm.Rows[j*sosp + i]["TenSanPham"] +
                                            " " + dtkm.Rows[j*sosp + i]["TenSanPhamPhu"];
                        if (tensanpham.Length > 20) tensanpham = tensanpham.Substring(0, 20) + "...";
                        string km = dtkm.Rows[j*sosp + i]["MoTaKhuyenMai"].ToString().Length > 25
                                        ?
                                            dtkm.Rows[j*sosp + i]["MoTaKhuyenMai"].ToString().Substring(0, 25)
                                        :
                                            dtkm.Rows[j*sosp + i]["MoTaKhuyenMai"].ToString();
                        content +=
                            "<table class=\"product\" width=\"100%\" border=\"0\" cellspacing=\"4\" cellpadding=\"0\">";
                        content += "<tr><td align=center><a href=\"productdetail.aspx?id=" +
                                   dtkm.Rows[j*sosp + i]["SanPhamID"]
                                   + "\">" + tensanpham + "<br><img src=\"" + dtkm.Rows[j*sosp + i]["AnhSanPham"]
                                   + "\" alt=\"" + dtkm.Rows[j*sosp + i]["TenSanPham"] +
                                   "\" width=\"74\" height=\"66\" border=\"0\" style=\"border:#CCCCCC 1px solid\" />";
                        content += "<br></a>" + km
                                   + "<br /><span class=\"price\">" +
                                   String.Format("{0:0,0}", dtkm.Rows[j*sosp + i]["GiaSanPham"]).Replace(",", ".")
                                   + " VNĐ </span> </td></tr></table>";
                    }
                    td.Text = content;
                    td.HorizontalAlign = HorizontalAlign.Left;
                    if (j == 0) td.Width = Unit.Percentage(25);
                    tr.Cells.Add(td);
                }
                tblSanPham06.Rows.Add(tr);
            }
        }
    }
}