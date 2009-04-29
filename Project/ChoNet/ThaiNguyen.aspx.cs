using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using CHONET.DataAccessLayer.Web;

public partial class _ThaiNguyen : Page
{
    private int intKhuVucID = 7;

    private void Page_Init(Object sender, EventArgs e)
    {
        Master.clsHome = "menu";
        Master.clsHP = "menu";
        Master.clsQN = "menu";
        Master.clsTN = "menu_ac";
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["UserFullName"] != null)
        //{
        //    tblDangNhap.Visible = false;
        //}
        //else
        //{
        //    tblDangNhap.Visible = true;
        //}
        if (!Page.IsPostBack)
        {
            LoadDanhMuc();
            LoadQuangCao01();
            LoadQuangCao10();
            LoadQuangCao02();
            LoadQuangCao03();
            LoadQuangCao04();
            LoadQuangCao05();
            LoadQuangCao06();
            LoadQuangCao07();
            LoadQuangCao08();
            LoadQuangCao09();
            LoadSanPham01();
            LoadSanPham02();
            LoadSanPham03();
            LoadSanPham04();
            LoadSanPham05();
            LoadSanPham06();
            LoadSanPham07();
            LoadGianHang();
        }
    }

    private void LoadDanhMuc()
    {
        try
        {
            NhomSanPham nsp = new NhomSanPham();
            DataSet ds = nsp.SelectNhomSanPhamByNhomChaID(0);
            ds.Tables[0].DefaultView.Sort = "SapXep ASC";

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    TableRow tr = new TableRow();
                    TableCell td = new TableCell();
                    //td.Style.Add("padding-left", "30px");
                    td.Text = "<a href=\"maincategory.aspx?rid=" + intKhuVucID + "&mcid=" + dr["NhomSanPhamID"] + "\">"
                              + dr["TenNhomSanPham"] + "</a>";
                    tr.Cells.Add(td);
                    tblDanhMuc.Rows.Add(tr);
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }
    }

    private void LoadQuangCao10()
    {
        QuangCao qcao = new QuangCao();
        DataSet ds = qcao.SelectQuangCaoAtViTriQuangCaoByLoaiNguoiDungIDAndKhuVuc(3, 10, intKhuVucID);
        if (ds.Tables[0].Rows.Count >= 1)
        {
            if (ds.Tables[0].Rows[0]["LoaiAnh"].ToString() == "FLASH")
            {
                spnQuangCao10.InnerHtml = "<object border:solid 1px #C9C3C3 classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
                                          +
                                          "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
                                          + "width=\"973\" height=\"111\" title=\"Quang Cao\">"
                                          + "<param name=\"movie\" value=\"" + ds.Tables[0].Rows[0]["DuongDanAnh"] +
                                          "\" />"
                                          + "<param name=\"quality\" value=\"high\" />"
                                          + "<embed src=\"" + ds.Tables[0].Rows[0]["DuongDanAnh"] +
                                          "\" quality=\"high\""
                                          +
                                          "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
                                          + "width=\"973\" height=\"111\"></embed></object>";
            }
            else
            {
                spnQuangCao10.InnerHtml = "<a href=\"" + ds.Tables[0].Rows[0]["DuongDan"]
                                          + "\" target=\"_blank\"><img alt=\"" + ds.Tables[0].Rows[0]["NoiDungQuangCao"]
                                          + "\" src=\"" + ds.Tables[0].Rows[0]["DuongDanAnh"] +
                                          "\" height=\"111px\" width=\"973px\" style=\"border:solid 1px #C9C3C3\"/></a>";
            }
        }
        else
        {
            spnQuangCao10.InnerHtml =
                "<img alt=\"Moi quang cao\" src=\"./images/advblank.jpg\" height=\"111px\" width=\"596px\" style=\"border:none\"/>";
        }
    }

    private void LoadQuangCao01()
    {
        QuangCao qcao = new QuangCao();
        DataSet ds = qcao.SelectQuangCaoAtViTriQuangCaoByLoaiNguoiDungIDAndKhuVuc(3, 1, intKhuVucID);
        if (ds.Tables[0].Rows.Count >= 1)
        {
            if (ds.Tables[0].Rows[0]["LoaiAnh"].ToString() == "FLASH")
            {
                spnQuangCao01.InnerHtml = "<object border:solid 1px #C9C3C3 classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
                                          +
                                          "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
                                          + "width=\"100%\" height=\"111\" title=\"Quang Cao\">"
                                          + "<param name=\"movie\" value=\"" + ds.Tables[0].Rows[0]["DuongDanAnh"] +
                                          "\" />"
                                          + "<param name=\"quality\" value=\"high\" />"
                                          + "<embed src=\"" + ds.Tables[0].Rows[0]["DuongDanAnh"] +
                                          "\" quality=\"high\""
                                          +
                                          "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
                                          + "width=\"100%\" height=\"111\"></embed></object>";
            }
            else
            {
                spnQuangCao01.InnerHtml = "<a href=\"" + ds.Tables[0].Rows[0]["DuongDan"]
                                          + "\" target=\"_blank\"><img alt=\"" + ds.Tables[0].Rows[0]["NoiDungQuangCao"]
                                          + "\" src=\"" + ds.Tables[0].Rows[0]["DuongDanAnh"] +
                                          "\" height=\"111px\" width=\"100%\" style=\"border:solid 1px #C9C3C3\"/></a>";
            }
        }
        else
        {
            spnQuangCao01.InnerHtml =
                "<img alt=\"Moi quang cao\" src=\"./images/advblank.jpg\" height=\"111px\" width=\"596px\" style=\"border:none\"/>";
        }
    }

    private void LoadQuangCao02()
    {
        QuangCao qcao = new QuangCao();
        DataSet ds = qcao.SelectQuangCaoAtViTriQuangCaoByLoaiNguoiDungIDAndKhuVuc(3, 2, intKhuVucID);
        if (ds.Tables[0].Rows.Count >= 1)
        {
            if (ds.Tables[0].Rows[0]["LoaiAnh"].ToString() == "FLASH")
            {
                spnQuangCao02.InnerHtml = "<object border:solid 1px #C9C3C3 classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
                                          +
                                          "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
                                          + "width=\"550\" height=\"216\" title=\"Quang Cao\">"
                                          + "<param name=\"movie\" value=\"" + ds.Tables[0].Rows[0]["DuongDanAnh"] +
                                          "\" />"
                                          + "<param name=\"quality\" value=\"high\" />"
                                          + "<embed src=\"" + ds.Tables[0].Rows[0]["DuongDanAnh"] +
                                          "\" quality=\"high\""
                                          +
                                          "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
                                          + "width=\"550\" height=\"216\"></embed></object>";
            }
            else
            {
                spnQuangCao02.InnerHtml = "<a href=\"" + ds.Tables[0].Rows[0]["DuongDan"]
                                          + "\" target=\"_blank\"><img alt=\"" + ds.Tables[0].Rows[0]["NoiDungQuangCao"]
                                          + "\" src=\"" + ds.Tables[0].Rows[0]["DuongDanAnh"] +
                                          "\" height=\"216px\" width=\"550px\" style=\"border:solid 1px #C9C3C3\"/></a>";
            }
        }
        else
        {
            spnQuangCao02.InnerHtml =
                "<img alt=\"Moi quang cao\" src=\"./images/advblank.jpg\" height=\"216px\" width=\"596px\" style=\"border:none\"/>";
        }
    }

    private void LoadQuangCao03()
    {
        QuangCao qcao = new QuangCao();
        DataSet ds = qcao.SelectQuangCaoAtViTriQuangCaoByLoaiNguoiDungIDAndKhuVuc(3, 3, intKhuVucID);
        int n = ds.Tables[0].Rows.Count;
        spnQuangCao03a.InnerHtml =
            "<img alt=\"Moi quang cao\" src=\"./images/advblank.jpg\" height=\"122px\" width=\"370px\" style=\"border:solid 1px #C9C3C3\"/>";
        spnQuangCao03b.InnerHtml =
            "<img alt=\"Moi quang cao\" src=\"./images/advblank.jpg\" height=\"122px\" width=\"370px\" style=\"border:solid 1px #C9C3C3\"/>";
        //spnQuangCao03c.InnerHtml = "<img alt=\"Moi quang cao\" src=\"./images/advblank.jpg\" height=\"122px\" width=\"370px\" style=\"border:solid 1px #C9C3C3\"/>";
        if (n >= 1)
        {
            if (ds.Tables[0].Rows[0]["LoaiAnh"].ToString() == "FLASH")
            {
                spnQuangCao03a.InnerHtml = "<object style=\"border:solid 1px #C9C3C3\" classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
                                           +
                                           "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
                                           + "width=\"370px\" height=\"122\" title=\"Quang Cao\">"
                                           + "<param name=\"movie\" value=\"" + ds.Tables[0].Rows[0]["DuongDanAnh"] +
                                           "\" />"
                                           + "<param name=\"quality\" value=\"high\" />"
                                           + "<embed src=\"" + ds.Tables[0].Rows[0]["DuongDanAnh"] +
                                           "\" quality=\"high\""
                                           +
                                           "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
                                           + "width=\"370px\" height=\"122\"></embed></object>";
            }
            else
            {
                spnQuangCao03a.InnerHtml = "<a href=\"" + ds.Tables[0].Rows[0]["DuongDan"]
                                           + "\" target=\"_blank\"><img alt=\"" +
                                           ds.Tables[0].Rows[0]["NoiDungQuangCao"]
                                           + "\" src=\"" + ds.Tables[0].Rows[0]["DuongDanAnh"] +
                                           "\" height=\"122px\" width=\"370pxpx\" style=\"border:solid 1px #C9C3C3\"/></a>";
            }
            if (n >= 2)
            {
                if (ds.Tables[0].Rows[1]["LoaiAnh"].ToString() == "FLASH")
                {
                    spnQuangCao03b.InnerHtml = "<object style=\"border:solid 1px #C9C3C3\" classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
                                               +
                                               "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
                                               + "width=\"370px\" height=\"122\" title=\"Quang Cao\">"
                                               + "<param name=\"movie\" value=\"" + ds.Tables[0].Rows[1]["DuongDanAnh"] +
                                               "\" />"
                                               + "<param name=\"quality\" value=\"high\" />"
                                               + "<embed src=\"" + ds.Tables[0].Rows[1]["DuongDanAnh"] +
                                               "\" quality=\"high\""
                                               +
                                               "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
                                               + "width=\"370px\" height=\"122\"></embed></object>";
                }
                else
                {
                    spnQuangCao03b.InnerHtml = "<a href=\"" + ds.Tables[0].Rows[1]["DuongDan"]
                                               + "\" target=\"_blank\"><img alt=\"" +
                                               ds.Tables[0].Rows[1]["NoiDungQuangCao"]
                                               + "\" src=\"" + ds.Tables[0].Rows[1]["DuongDanAnh"] +
                                               "\" height=\"122px\" width=\"370px\" style=\"border:solid 1px #C9C3C3\"/></a>";
                }
                //if (n >= 3)
                //{
                //    if (ds.Tables[0].Rows[2]["LoaiAnh"].ToString() == "FLASH")
                //    {
                //        spnQuangCao03c.InnerHtml = "<object style=\"border:solid 1px #C9C3C3\" classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
                //            + "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
                //            + "width=\"100%\" height=\"122\" title=\"Quang Cao\">"
                //            + "<param name=\"movie\" value=\"" + ds.Tables[0].Rows[2]["DuongDanAnh"].ToString() + "\" />"
                //            + "<param name=\"quality\" value=\"high\" />"
                //            + "<embed src=\"" + ds.Tables[0].Rows[2]["DuongDanAnh"].ToString() + "\" quality=\"high\""
                //            + "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
                //            + "width=\"100%\" height=\"122\"></embed></object>";
                //    }
                //    else
                //    {
                //        spnQuangCao03c.InnerHtml = "<a href=\"" + ds.Tables[0].Rows[2]["DuongDan"].ToString()
                //          + "\" target=\"_blank\"><img alt=\"" + ds.Tables[0].Rows[2]["NoiDungQuangCao"].ToString()
                //          + "\" src=\"" + ds.Tables[0].Rows[2]["DuongDanAnh"].ToString() + "\" height=\"122px\" width=\"100%\" style=\"border:solid 1px #C9C3C3\"/></a>";
                //    }
                //}
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
        DataSet ds = qcao.SelectQuangCaoAtViTriQuangCaoByLoaiNguoiDungIDAndKhuVuc(3, 4, intKhuVucID);
        int n = 2;
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
                          + "\" style=\"border:solid 1px #C9C3C3; width:207px;\"></a>";
            }
            td.Text = content;
            tr.Cells.Add(td);
            tblQuangCao04.Rows.Add(tr);
        }
    }

    private void LoadQuangCao05()
    {
        QuangCao qcao = new QuangCao();
        DataSet ds = qcao.SelectQuangCaoAtViTriQuangCaoByLoaiNguoiDungIDAndKhuVuc(3, 5, intKhuVucID);
        int n = ds.Tables[0].Rows.Count;
        spnQuangCao05a.InnerHtml =
            "<img alt=\"Moi quang cao\" src=\"./images/advblank.jpg\" height=\"122px\" width=\"370px\" style=\"border:solid 1px #C9C3C3\"/>";
        spnQuangCao05b.InnerHtml =
            "<img alt=\"Moi quang cao\" src=\"./images/advblank.jpg\" height=\"122px\" width=\"370px\" style=\"border:solid 1px #C9C3C3\"/>";
        //spnQuangCao05c.InnerHtml = "<img alt=\"Moi quang cao\" src=\"./images/advblank.jpg\" height=\"122px\" width=\"370px\" style=\"border:solid 1px #C9C3C3\"/>";
        if (n >= 1)
        {
            if (ds.Tables[0].Rows[0]["LoaiAnh"].ToString() == "FLASH")
            {
                spnQuangCao05a.InnerHtml = "<object style=\"border:solid 1px #C9C3C3\" classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
                                           +
                                           "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
                                           + "width=\"370px\" height=\"122\" title=\"Quang Cao\">"
                                           + "<param name=\"movie\" value=\"" + ds.Tables[0].Rows[0]["DuongDanAnh"] +
                                           "\" />"
                                           + "<param name=\"quality\" value=\"high\" />"
                                           + "<embed src=\"" + ds.Tables[0].Rows[0]["DuongDanAnh"] +
                                           "\" quality=\"high\""
                                           +
                                           "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
                                           + "width=\"370px\" height=\"122\"></embed></object>";
            }
            else
            {
                spnQuangCao05a.InnerHtml = "<a href=\"" + ds.Tables[0].Rows[0]["DuongDan"]
                                           + "\" target=\"_blank\"><img alt=\"" +
                                           ds.Tables[0].Rows[0]["NoiDungQuangCao"]
                                           + "\" src=\"" + ds.Tables[0].Rows[0]["DuongDanAnh"] +
                                           "\" height=\"122px\" width=\"370px\" style=\"border:solid 1px #C9C3C3\"/></a>";
            }
            if (n >= 2)
            {
                if (ds.Tables[0].Rows[1]["LoaiAnh"].ToString() == "FLASH")
                {
                    spnQuangCao05b.InnerHtml = "<object style=\"border:solid 1px #C9C3C3\" classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
                                               +
                                               "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
                                               + "width=\"370px\" height=\"122\" title=\"Quang Cao\">"
                                               + "<param name=\"movie\" value=\"" + ds.Tables[0].Rows[1]["DuongDanAnh"] +
                                               "\" />"
                                               + "<param name=\"quality\" value=\"high\" />"
                                               + "<embed src=\"" + ds.Tables[0].Rows[1]["DuongDanAnh"] +
                                               "\" quality=\"high\""
                                               +
                                               "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
                                               + "width=\"370px\" height=\"122\"></embed></object>";
                }
                else
                {
                    spnQuangCao05b.InnerHtml = "<a href=\"" + ds.Tables[0].Rows[1]["DuongDan"]
                                               + "\" target=\"_blank\"><img alt=\"" +
                                               ds.Tables[0].Rows[1]["NoiDungQuangCao"]
                                               + "\" src=\"" + ds.Tables[0].Rows[1]["DuongDanAnh"] +
                                               "\" height=\"122px\" width=\"370px\" style=\"border:solid 1px #C9C3C3\"/></a>";
                }
                //if (n >= 3)
                //{
                //    if (ds.Tables[0].Rows[2]["LoaiAnh"].ToString() == "FLASH")
                //    {
                //        spnQuangCao05c.InnerHtml = "<object style=\"border:solid 1px #C9C3C3\" classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
                //            + "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
                //            + "width=\"370px\" height=\"122\" title=\"Quang Cao\">"
                //            + "<param name=\"movie\" value=\"" + ds.Tables[0].Rows[2]["DuongDanAnh"].ToString() + "\" />"
                //            + "<param name=\"quality\" value=\"high\" />"
                //            + "<embed src=\"" + ds.Tables[0].Rows[2]["DuongDanAnh"].ToString() + "\" quality=\"high\""
                //            + "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
                //            + "width=\"370px\" height=\"122\"></embed></object>";
                //    }
                //    else
                //    {
                //        spnQuangCao05c.InnerHtml = "<a href=\"" + ds.Tables[0].Rows[2]["DuongDan"].ToString()
                //          + "\" target=\"_blank\"><img alt=\"" + ds.Tables[0].Rows[2]["NoiDungQuangCao"].ToString()
                //          + "\" src=\"" + ds.Tables[0].Rows[2]["DuongDanAnh"].ToString() + "\" height=\"122px\" width=\"370px\" style=\"border:solid 1px #C9C3C3\"/></a>";
                //    }
                //}
            }
        }
        else
        {
            tblQuangCao05.Visible = false;
        }
    }

    private void LoadQuangCao06()
    {
        QuangCao qcao = new QuangCao();
        DataSet ds = qcao.SelectQuangCaoAtViTriQuangCaoByLoaiNguoiDungIDAndKhuVuc(3, 6, intKhuVucID);
        int n = 5;
        if (ds.Tables[0].Rows.Count <= 5) n = ds.Tables[0].Rows.Count;

        for (int i = 0; i < n; i++)
        {
            TableRow tr = new TableRow();
            TableCell td = new TableCell();
            td.Style.Value = "padding-top: 4px;";
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
            tblQuangCao06.Rows.Add(tr);
        }
    }

    private void LoadQuangCao07()
    {
        QuangCao qcao = new QuangCao();
        DataSet ds = qcao.SelectQuangCaoAtViTriQuangCaoByLoaiNguoiDungIDAndKhuVuc(3, 7, intKhuVucID);
        int n = ds.Tables[0].Rows.Count;
        spnQuangCao07a.InnerHtml =
            "<img alt=\"Moi quang cao\" src=\"./images/advblank.jpg\" height=\"122px\" width=\"370px\" style=\"border:solid 1px #C9C3C3\"/>";
        spnQuangCao07b.InnerHtml =
            "<img alt=\"Moi quang cao\" src=\"./images/advblank.jpg\" height=\"122px\" width=\"370px\" style=\"border:solid 1px #C9C3C3\"/>";
        //spnQuangCao07c.InnerHtml = "<img alt=\"Moi quang cao\" src=\"./images/advblank.jpg\" height=\"122px\" width=\"370px\" style=\"border:solid 1px #C9C3C3\"/>";
        if (n >= 1)
        {
            if (ds.Tables[0].Rows[0]["LoaiAnh"].ToString() == "FLASH")
            {
                spnQuangCao07a.InnerHtml = "<object style=\"border:solid 1px #C9C3C3\" classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
                                           +
                                           "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
                                           + "width=\"370px\" height=\"122\" title=\"Quang Cao\">"
                                           + "<param name=\"movie\" value=\"" + ds.Tables[0].Rows[0]["DuongDanAnh"] +
                                           "\" />"
                                           + "<param name=\"quality\" value=\"high\" />"
                                           + "<embed src=\"" + ds.Tables[0].Rows[0]["DuongDanAnh"] +
                                           "\" quality=\"high\""
                                           +
                                           "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
                                           + "width=\"370px\" height=\"122\"></embed></object>";
            }
            else
            {
                spnQuangCao07a.InnerHtml = "<a href=\"" + ds.Tables[0].Rows[0]["DuongDan"]
                                           + "\" target=\"_blank\"><img alt=\"" +
                                           ds.Tables[0].Rows[0]["NoiDungQuangCao"]
                                           + "\" src=\"" + ds.Tables[0].Rows[0]["DuongDanAnh"] +
                                           "\" height=\"122px\" width=\"370px\" style=\"border:solid 1px #C9C3C3\"/></a>";
            }
            if (n >= 2)
            {
                if (ds.Tables[0].Rows[1]["LoaiAnh"].ToString() == "FLASH")
                {
                    spnQuangCao07b.InnerHtml = "<object style=\"border:solid 1px #C9C3C3\" classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
                                               +
                                               "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
                                               + "width=\"370px\" height=\"122\" title=\"Quang Cao\">"
                                               + "<param name=\"movie\" value=\"" + ds.Tables[0].Rows[1]["DuongDanAnh"] +
                                               "\" />"
                                               + "<param name=\"quality\" value=\"high\" />"
                                               + "<embed src=\"" + ds.Tables[0].Rows[1]["DuongDanAnh"] +
                                               "\" quality=\"high\""
                                               +
                                               "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
                                               + "width=\"370px\" height=\"122\"></embed></object>";
                }
                else
                {
                    spnQuangCao07b.InnerHtml = "<a href=\"" + ds.Tables[0].Rows[1]["DuongDan"]
                                               + "\" target=\"_blank\"><img alt=\"" +
                                               ds.Tables[0].Rows[1]["NoiDungQuangCao"]
                                               + "\" src=\"" + ds.Tables[0].Rows[1]["DuongDanAnh"] +
                                               "\" height=\"122px\" width=\"370px\" style=\"border:solid 1px #C9C3C3\"/></a>";
                }
                //if (n >= 3)
                //{
                //    if (ds.Tables[0].Rows[2]["LoaiAnh"].ToString() == "FLASH")
                //    {
                //        spnQuangCao07c.InnerHtml = "<object style=\"border:solid 1px #C9C3C3\" classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
                //            + "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
                //            + "width=\"370px\" height=\"122\" title=\"Quang Cao\">"
                //            + "<param name=\"movie\" value=\"" + ds.Tables[0].Rows[2]["DuongDanAnh"].ToString() + "\" />"
                //            + "<param name=\"quality\" value=\"high\" />"
                //            + "<embed src=\"" + ds.Tables[0].Rows[2]["DuongDanAnh"].ToString() + "\" quality=\"high\""
                //            + "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
                //            + "width=\"370px\" height=\"122\"></embed></object>";
                //    }
                //    else
                //    {
                //        spnQuangCao07c.InnerHtml = "<a href=\"" + ds.Tables[0].Rows[2]["DuongDan"].ToString()
                //          + "\" target=\"_blank\"><img alt=\"" + ds.Tables[0].Rows[2]["NoiDungQuangCao"].ToString()
                //          + "\" src=\"" + ds.Tables[0].Rows[2]["DuongDanAnh"].ToString() + "\" height=\"122px\" width=\"370px\" style=\"border:solid 1px #C9C3C3\"/></a>";
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
        DataSet ds = qcao.SelectQuangCaoAtViTriQuangCaoByLoaiNguoiDungIDAndKhuVuc(3, 8, intKhuVucID);
        int n = ds.Tables[0].Rows.Count;
        spnQuangCao08a.InnerHtml =
            "<img alt=\"Moi quang cao\" src=\"./images/advblank.jpg\" height=\"122px\" width=\"370px\" style=\"border:solid 1px #C9C3C3\"/>";
        spnQuangCao08b.InnerHtml =
            "<img alt=\"Moi quang cao\" src=\"./images/advblank.jpg\" height=\"122px\" width=\"370px\" style=\"border:solid 1px #C9C3C3\"/>";
        //spnQuangCao08c.InnerHtml = "<img alt=\"Moi quang cao\" src=\"./images/advblank.jpg\" height=\"122px\" width=\"370px\" style=\"border:solid 1px #C9C3C3\"/>";
        if (n >= 1)
        {
            if (ds.Tables[0].Rows[0]["LoaiAnh"].ToString() == "FLASH")
            {
                spnQuangCao08a.InnerHtml = "<object style=\"border:solid 1px #C9C3C3\" classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
                                           +
                                           "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
                                           + "width=\"370px\" height=\"122\" title=\"Quang Cao\">"
                                           + "<param name=\"movie\" value=\"" + ds.Tables[0].Rows[0]["DuongDanAnh"] +
                                           "\" />"
                                           + "<param name=\"quality\" value=\"high\" />"
                                           + "<embed src=\"" + ds.Tables[0].Rows[0]["DuongDanAnh"] +
                                           "\" quality=\"high\""
                                           +
                                           "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
                                           + "width=\"370px\" height=\"122\"></embed></object>";
            }
            else
            {
                spnQuangCao08a.InnerHtml = "<a href=\"" + ds.Tables[0].Rows[0]["DuongDan"]
                                           + "\" target=\"_blank\"><img alt=\"" +
                                           ds.Tables[0].Rows[0]["NoiDungQuangCao"]
                                           + "\" src=\"" + ds.Tables[0].Rows[0]["DuongDanAnh"] +
                                           "\" height=\"122px\" width=\"370px\" style=\"border:solid 1px #C9C3C3\"/></a>";
            }
            if (n >= 2)
            {
                if (ds.Tables[0].Rows[1]["LoaiAnh"].ToString() == "FLASH")
                {
                    spnQuangCao08b.InnerHtml = "<object style=\"border:solid 1px #C9C3C3\" classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
                                               +
                                               "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
                                               + "width=\"370px\" height=\"122\" title=\"Quang Cao\">"
                                               + "<param name=\"movie\" value=\"" + ds.Tables[0].Rows[1]["DuongDanAnh"] +
                                               "\" />"
                                               + "<param name=\"quality\" value=\"high\" />"
                                               + "<embed src=\"" + ds.Tables[0].Rows[1]["DuongDanAnh"] +
                                               "\" quality=\"high\""
                                               +
                                               "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
                                               + "width=\"370px\" height=\"122\"></embed></object>";
                }
                else
                {
                    spnQuangCao08b.InnerHtml = "<a href=\"" + ds.Tables[0].Rows[1]["DuongDan"]
                                               + "\" target=\"_blank\"><img alt=\"" +
                                               ds.Tables[0].Rows[1]["NoiDungQuangCao"]
                                               + "\" src=\"" + ds.Tables[0].Rows[1]["DuongDanAnh"] +
                                               "\" height=\"122px\" width=\"370px\" style=\"border:solid 1px #C9C3C3\"/></a>";
                }
                //if (n >= 3)
                //{
                //    if (ds.Tables[0].Rows[2]["LoaiAnh"].ToString() == "FLASH")
                //    {
                //        spnQuangCao08c.InnerHtml = "<object style=\"border:solid 1px #C9C3C3\" classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
                //            + "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
                //            + "width=\"370px\" height=\"122\" title=\"Quang Cao\">"
                //            + "<param name=\"movie\" value=\"" + ds.Tables[0].Rows[2]["DuongDanAnh"].ToString() + "\" />"
                //            + "<param name=\"quality\" value=\"high\" />"
                //            + "<embed src=\"" + ds.Tables[0].Rows[2]["DuongDanAnh"].ToString() + "\" quality=\"high\""
                //            + "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
                //            + "width=\"370px\" height=\"122\"></embed></object>";
                //    }
                //    else
                //    {
                //        spnQuangCao08c.InnerHtml = "<a href=\"" + ds.Tables[0].Rows[2]["DuongDan"].ToString()
                //          + "\" target=\"_blank\"><img alt=\"" + ds.Tables[0].Rows[2]["NoiDungQuangCao"].ToString()
                //          + "\" src=\"" + ds.Tables[0].Rows[2]["DuongDanAnh"].ToString() + "\" height=\"122px\" width=\"370px\" style=\"border:solid 1px #C9C3C3\"/></a>";
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
        DataSet ds = qcao.SelectQuangCaoAtViTriQuangCaoByLoaiNguoiDungIDAndKhuVuc(3, 9, intKhuVucID);
        int n = ds.Tables[0].Rows.Count;
        spnQuangCao09a.InnerHtml =
            "<img alt=\"Moi quang cao\" src=\"./images/advblank.jpg\" height=\"122px\" width=\"370px\" style=\"border:solid 1px #C9C3C3\"/>";
        spnQuangCao09b.InnerHtml =
            "<img alt=\"Moi quang cao\" src=\"./images/advblank.jpg\" height=\"122px\" width=\"370px\" style=\"border:solid 1px #C9C3C3\"/>";
        //spnQuangCao09c.InnerHtml = "<img alt=\"Moi quang cao\" src=\"./images/advblank.jpg\" height=\"122px\" width=\"370px\" style=\"border:solid 1px #C9C3C3\"/>";
        if (n >= 1)
        {
            if (ds.Tables[0].Rows[0]["LoaiAnh"].ToString() == "FLASH")
            {
                spnQuangCao09a.InnerHtml = "<object style=\"border:solid 1px #C9C3C3\" classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
                                           +
                                           "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
                                           + "width=\"370px\" height=\"122\" title=\"Quang Cao\">"
                                           + "<param name=\"movie\" value=\"" + ds.Tables[0].Rows[0]["DuongDanAnh"] +
                                           "\" />"
                                           + "<param name=\"quality\" value=\"high\" />"
                                           + "<embed src=\"" + ds.Tables[0].Rows[0]["DuongDanAnh"] +
                                           "\" quality=\"high\""
                                           +
                                           "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
                                           + "width=\"370px\" height=\"122\"></embed></object>";
            }
            else
            {
                spnQuangCao09a.InnerHtml = "<a href=\"" + ds.Tables[0].Rows[0]["DuongDan"]
                                           + "\" target=\"_blank\"><img alt=\"" +
                                           ds.Tables[0].Rows[0]["NoiDungQuangCao"]
                                           + "\" src=\"" + ds.Tables[0].Rows[0]["DuongDanAnh"] +
                                           "\" height=\"122px\" width=\"370px\" style=\"border:solid 1px #C9C3C3\"/></a>";
            }
            if (n >= 2)
            {
                if (ds.Tables[0].Rows[1]["LoaiAnh"].ToString() == "FLASH")
                {
                    spnQuangCao09b.InnerHtml = "<object style=\"border:solid 1px #C9C3C3\" classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
                                               +
                                               "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
                                               + "width=\"370px\" height=\"122\" title=\"Quang Cao\">"
                                               + "<param name=\"movie\" value=\"" + ds.Tables[0].Rows[1]["DuongDanAnh"] +
                                               "\" />"
                                               + "<param name=\"quality\" value=\"high\" />"
                                               + "<embed src=\"" + ds.Tables[0].Rows[1]["DuongDanAnh"] +
                                               "\" quality=\"high\""
                                               +
                                               "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
                                               + "width=\"370px\" height=\"122\"></embed></object>";
                }
                else
                {
                    spnQuangCao09b.InnerHtml = "<a href=\"" + ds.Tables[0].Rows[1]["DuongDan"]
                                               + "\" target=\"_blank\"><img alt=\"" +
                                               ds.Tables[0].Rows[1]["NoiDungQuangCao"]
                                               + "\" src=\"" + ds.Tables[0].Rows[1]["DuongDanAnh"] +
                                               "\" height=\"122px\" width=\"370px\" style=\"border:solid 1px #C9C3C3\"/></a>";
                }
                //if (n >= 3)
                //{
                //    if (ds.Tables[0].Rows[2]["LoaiAnh"].ToString() == "FLASH")
                //    {
                //        spnQuangCao09c.InnerHtml = "<object style=\"border:solid 1px #C9C3C3\" classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
                //            + "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
                //            + "width=\"370px\" height=\"122\" title=\"Quang Cao\">"
                //            + "<param name=\"movie\" value=\"" + ds.Tables[0].Rows[2]["DuongDanAnh"].ToString() + "\" />"
                //            + "<param name=\"quality\" value=\"high\" />"
                //            + "<embed src=\"" + ds.Tables[0].Rows[2]["DuongDanAnh"].ToString() + "\" quality=\"high\""
                //            + "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
                //            + "width=\"370px\" height=\"122\"></embed></object>";
                //    }
                //    else
                //    {
                //        spnQuangCao09c.InnerHtml = "<a href=\"" + ds.Tables[0].Rows[2]["DuongDan"].ToString()
                //          + "\" target=\"_blank\"><img alt=\"" + ds.Tables[0].Rows[2]["NoiDungQuangCao"].ToString()
                //          + "\" src=\"" + ds.Tables[0].Rows[2]["DuongDanAnh"].ToString() + "\" height=\"122px\" width=\"370px\" style=\"border:solid 1px #C9C3C3\"/></a>";
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
        DataSet ds = sp.SelectSanPhamAtViTriSanPhamByKhuVuc(2, intKhuVucID);
        int n = ds.Tables[0].Rows.Count;
        TableRow tr = new TableRow();
        for (int i = 0; i < 5; i++)
        {
            TableCell td = new TableCell();
            string content = "";
            if (i < n)
            {
                content += "<table class=\"product\" width=\"100%\" border=\"0\" cellspacing=\"4\" cellpadding=\"0\">";
                content += "<tr><td align=\"center\"><a href=\"productdetail.aspx?id=" +
                           ds.Tables[0].Rows[i]["SanPhamID"]
                           + "\"><img src=\"" + ds.Tables[0].Rows[i]["AnhSanPham"]
                           + "\" width=\"99\" height=\"89\" border=\"0\" style=\"border:#CCCCCC 1px solid\" /></a></td>";
                content += "</tr><tr><td align=\"center\"><a href=\"productdetail.aspx?id=" +
                           ds.Tables[0].Rows[i]["SanPhamID"]
                           + "\">" + ds.Tables[0].Rows[i]["TenSanPham"]
                           + "</a><br />Giá: <span class=\"price\">" +
                           String.Format("{0:0,0}", ds.Tables[0].Rows[i]["GiaSanPham"]).Replace(",", ".") +
                           "</span><br/>"
                           + ds.Tables[0].Rows[i]["DonViTienTe"] + "</tr></table>";
            }
            td.Text = content;
            td.Width = Unit.Percentage(20);
            td.VerticalAlign = VerticalAlign.Top;
            tr.Cells.Add(td);
        }
        tblSanPham02.Rows.Add(tr);
        tblSanPham02.Style.Value = "border:solid 1px #c9c3c5";
    }

    private void LoadSanPham03()
    {
        //San pham ua chuong
        SanPham sp = new SanPham();
        DataSet ds = sp.SelectTopFourSanPhamUaChuong();
        ds.Tables[0].DefaultView.RowFilter = "KhuVucID=" + intKhuVucID;
        int n = ds.Tables[0].DefaultView.Count;
        DataView dv = ds.Tables[0].DefaultView;
        TableRow tr = new TableRow();
        for (int i = 0; i < 4; i++)
        {
            TableCell td = new TableCell();
            string content = "";

            if (i < n)
            {
                content += "<table width=\"100%\" border=\"0\" cellspacing=\"4\" cellpadding=\"0\">";
                content += "<tr><td align=\"center\"><a href=\"productdetail.aspx?id=" + dv[i]["SanPhamID"]
                           + "\"><img src=\"" + dv[i]["AnhSanPham"]
                           +
                           "\" width=\"179\" height=\"159\" border=\"0\"  style=\"border:#CCCCCC 1px solid\" /></a></td>";
                content += "</tr><tr><td align=\"center\"><b><a href=\"productdetail.aspx?id=" + dv[i]["SanPhamID"]
                           + "\">" + dv[i]["TenSanPham"] + "</a></b> <br />";
                content += "Giá: <span class=\"price\">" +
                           String.Format("{0:0,0}", dv[i]["GiaSanPham"]).Replace(",", ".")
                           + "</span> " + dv[i]["DonViTienTe"] + "</td></tr></table>";
            }
            td.Text = content;
            td.Width = Unit.Percentage(25);
            td.VerticalAlign = VerticalAlign.Top;
            tr.Cells.Add(td);
        }
        tblSanPham03.Rows.Add(tr);
    }

    private void LoadSanPham04()
    {
        //LoadDanhMuc04
        NhomSanPham nsp = new NhomSanPham();
        DataSet ds = nsp.SelectNhomSanPhamByNhomChaID(0);
        DataRow[] dr = ds.Tables[0].Select("KhuVucShow=" + intKhuVucID);
        int n = 4;
        if (dr.Length < 4) n = dr.Length;
        TableRow tr = new TableRow();
        for (int i = 0; i < n; i++)
        {
            if ((!Page.IsPostBack && i == 0) || hidCatId.Value == "0")
                hidCatId.Value = dr[0]["NhomSanPhamID"].ToString();
            TableCell td = new TableCell();
            td.Width = Unit.Percentage(100/n);
            if (hidCatId.Value.Trim().Length > 0)
            {
                if (dr[i]["NhomSanPhamID"].ToString() == hidCatId.Value)
                {
                    string content = "";
                    content += "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">";
                    content += "<tr><td width=\"12\"></td>";
                    content += "<td class=\"nd2\">" + dr[i]["TenNhomSanPham"] + "</td>";
                    content += "<td width=\"12\"></td></tr></table>";
                    td.VerticalAlign = VerticalAlign.Bottom;
                    td.Text = content;
                    tr.Cells.Add(td);
                    //LoadSanPham04
                    SanPham sp = new SanPham();
                    DataSet sds = sp.SelectSanPhamAtViTriSanPhamInNhomSanPhamIDByKhuVuc(4,
                                                                                        int.Parse(
                                                                                            dr[i]["NhomSanPhamID"].
                                                                                                ToString()), intKhuVucID);
                    int sn = sds.Tables[0].Rows.Count;
                    for (int j = 0; j < 2; j++)
                    {
                        TableRow str = new TableRow();
                        for (int si = 0; si < 6; si++)
                        {
                            TableCell std = new TableCell();
                            string scontent = "";
                            if (j*6 + si < sn)
                            {
                                scontent +=
                                    "<table class=\"product\" width=\"100%\" border=\"0\" cellspacing=\"4\" cellpadding=\"0\">";
                                scontent += "<tr><td align=\"center\"><a href=\"productdetail.aspx?id=" +
                                            sds.Tables[0].Rows[j*6 + si]["SanPhamID"]
                                            + "\"><img src=\"" + sds.Tables[0].Rows[j*6 + si]["AnhSanPham"]
                                            +
                                            "\" alt=\"\" width=\"99\" height=\"89\" border=\"0\" style=\"border:#CCCCCC 1px solid\" /></a></td>";
                                scontent += "</tr><tr><td align=\"center\"><a href=\"productdetail.aspx?id=" +
                                            sds.Tables[0].Rows[j*6 + si]["SanPhamID"]
                                            + "\">" + sds.Tables[0].Rows[j*6 + si]["TenSanPham"]
                                            + "</a><br />";
                                scontent += "Giá: <span class=\"price\">" +
                                            String.Format("{0:0,0}", sds.Tables[0].Rows[j*6 + si]["GiaSanPham"]).Replace
                                                (",", ".")
                                            + "</span><br/>" + sds.Tables[0].Rows[j*6 + si]["DonViTienTe"] +
                                            "</td></tr></table>";
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
                    string content = "<a href=\"javascript:RefreshProduct04(" + dr[i]["NhomSanPhamID"] + ")\">" +
                                     dr[i]["TenNhomSanPham"] + "</a>";
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

    private void LoadSanPham05()
    {
        //San pham giam gia
        SanPham sp = new SanPham();
        DataSet ds = sp.SelectSanPhamGiamGia();
        ds.Tables[0].DefaultView.RowFilter = "KhuVucID=" + intKhuVucID;
        int n = ds.Tables[0].DefaultView.Count;
        DataView dv = ds.Tables[0].DefaultView;
        for (int j = 0; j < 3; j++)
        {
            TableRow tr = new TableRow();

            for (int i = 0; i < 4; i++)
            {
                TableCell td = new TableCell();
                string content = "";
                if (j*4 + i < n)
                {
                    content +=
                        "<table class=\"product\" width=\"100%\" border=\"0\" cellspacing=\"4\" cellpadding=\"0\">";
                    content += "<tr><td><a href=\"productdetail.aspx?id=" + dv[j*4 + i]["SanPhamID"]
                               + "\"><img src=\"" + dv[j*4 + i]["AnhSanPham"]
                               +
                               "\" alt=\"\" width=\"74\" height=\"66\" border=\"0\" style=\"border:#CCCCCC 1px solid\" /></a></td>";
                    content += "<td style=\"width:60%\"><a href=\"productdetail.aspx?id=" + dv[j*4 + i]["SanPhamID"]
                               + "\">" + dv[j*4 + i]["TenSanPham"]
                               + "</a><br />Giá cũ: <span class=\"oldprice\">"
                               + String.Format("{0:0,0}", dv[j*4 + i]["GiaSanPham"]).Replace(",", ".")
                               + "</span> " + dv[j*4 + i]["DonViTienTe"] + "<br/>";
                    content += "Giá mới: <span class=\"price\">"
                               + String.Format("{0:0,0}", dv[j*4 + i]["GiaKhuyenMai"]).Replace(",", ".")
                               + "</span> " + dv[j*4 + i]["DonViTienTe"] + "</td></tr></table>";
                }
                td.Text = content;
                td.HorizontalAlign = HorizontalAlign.Left;
                if (j == 0) td.Width = Unit.Percentage(25);
                tr.Cells.Add(td);
            }
            tblSanPham05.Rows.Add(tr);
        }
    }

    private void LoadSanPham06()
    {
        //San pham khuyen mai
        SanPham sp = new SanPham();
        DataSet ds = sp.SelectSanPhamKhuyenMai();
        ds.Tables[0].DefaultView.RowFilter = "KhuVucID=" + intKhuVucID;
        int n = ds.Tables[0].DefaultView.Count;
        DataView dv = ds.Tables[0].DefaultView;
        for (int j = 0; j < 3; j++)
        {
            TableRow tr = new TableRow();
            for (int i = 0; i < 2; i++)
            {
                TableCell td = new TableCell();
                string content = "";
                if (j*2 + i < n)
                {
                    content +=
                        "<table class=\"product\" width=\"100%\" border=\"0\" cellspacing=\"4\" cellpadding=\"0\">";
                    content += "<tr><td><a href=\"productdetail.aspx?id=" + dv[j*2 + i]["SanPhamID"]
                               + "\"><img src=\"" + dv[j*2 + i]["AnhSanPham"]
                               +
                               "\" alt=\"\" width=\"74\" height=\"66\" border=\"0\" style=\"border:#CCCCCC 1px solid\" /></a></td>";
                    content += "<td style=\"width:60%\"><a href=\"productdetail.aspx?id=" + dv[j*2 + i]["SanPhamID"]
                               + "\">" + dv[j*2 + i]["TenSanPham"]
                               + "</a><br />Giá: <span class=\"price\">" +
                               String.Format("{0:0,0}", dv[j*2 + i]["GiaSanPham"]).Replace(",", ".")
                               + "</span> " + dv[j*2 + i]["DonViTienTe"] + "</td></tr></table>";
                }
                td.Text = content;
                td.HorizontalAlign = HorizontalAlign.Left;
                if (j == 0) td.Width = Unit.Percentage(50);
                tr.Cells.Add(td);
            }
            tblSanPham06.Rows.Add(tr);
        }
        ds = sp.SelectTopFiveSanPhamSapHetKhuyenMai();
        int m = ds.Tables[0].Rows.Count;
        for (int j = 0; j < m; j++)
        {
            TableRow tr = new TableRow();
            TableCell td = new TableCell();
            string content = "";
            content += "<a href=\"productdetail.aspx?id=" + ds.Tables[0].Rows[j]["SanPhamID"]
                       + "\">" + ds.Tables[0].Rows[j]["TenSanPham"] + " - "
                       + string.Format("{0:dd/MM/yyyy}", ds.Tables[0].Rows[j]["KetThucKhuyenMai"]) + "</a>";
            td.Text = content;
            td.CssClass = "news_khuyenmai";
            tr.Cells.Add(td);
            tblSanPham06b.Rows.Add(tr);
        }
    }

    private void LoadSanPham07()
    {
        //San pham moi cap nhat
        SanPham sp = new SanPham();
        DataSet ds = sp.SelectSanPhamMoiCapNhat();
        ds.Tables[0].DefaultView.RowFilter = "KhuVucID=" + intKhuVucID;
        int n = ds.Tables[0].DefaultView.Count;
        DataView dv = ds.Tables[0].DefaultView;
        for (int j = 0; j < 4; j++)
        {
            TableRow tr = new TableRow();
            for (int i = 0; i < 1; i++)
            {
                TableCell td = new TableCell();
                string content = "";
                if (j*1 + i < n)
                {
                    content +=
                        "<table class=\"product1\" width=\"207\" border=\"0\" cellspacing=\"4\" cellpadding=\"0\">";
                    content += "<tr><td><a href=\"productdetail.aspx?id=" + dv[j*1 + i]["SanPhamID"]
                               + "\"><img src=\"" + dv[j*1 + i]["AnhSanPham"]
                               +
                               "\" alt=\"\" width=\"74\" height=\"66\" border=\"0\" style=\"border:#CCCCCC 1px solid\" /></a></td>";
                    content += "<td style=\"width:60%\"><a href=\"productdetail.aspx?id=" + dv[j*1 + i]["SanPhamID"]
                               + "\">" + dv[j*1 + i]["TenSanPham"]
                               + "</a><br />Giá: <span class=\"price\">" +
                               String.Format("{0:0,0}", dv[j*1 + i]["GiaSanPham"]).Replace(",", ".")
                               + "</span> " + dv[j*1 + i]["DonViTienTe"] + "</td></tr></table>";
                }
                td.Text = content;
                td.HorizontalAlign = HorizontalAlign.Left;
                if (j == 0) td.Width = Unit.Percentage(25);
                tr.Cells.Add(td);
            }
            tblSanPham07.Rows.Add(tr);
        }
    }

    private void LoadGianHang()
    {
        CuaHang ch = new CuaHang();
        DataSet ds = ch.SelectCuaHangAtViTriCuaHangByKhuVuc(1, intKhuVucID);
        int n = ds.Tables[0].Rows.Count;
        for (int j = 0; j < 4; j++)
        {
            TableRow tr = new TableRow();
            for (int i = 0; i < 4; i++)
            {
                TableCell td = new TableCell();
                string content = "";
                if (j*4 + i < n)
                {
                    content += "<table width=\"100%\" border=\"0\" cellspacing=\"4\" cellpadding=\"0\">";
                    content += "<tr><td><a href=\"estore.aspx?sid=" + ds.Tables[0].Rows[j*4 + i]["CuaHangID"]
                               + "\"><img src=\"" + ds.Tables[0].Rows[j*4 + i]["Anh"]
                               + "\" width=\"110\" height=\"73\" style=\"border:#ece2a4 1px solid\" /></a></td>";
                    content += "<td><a href=\"estore.aspx?sid=" + ds.Tables[0].Rows[j*4 + i]["CuaHangID"]
                               + "\"><b>" + ds.Tables[0].Rows[j*4 + i]["TenCuaHang"] + "</b></a></td></tr></table>";
                }
                td.Text = content;
                td.HorizontalAlign = HorizontalAlign.Left;
                if (j == 0) td.Width = Unit.Percentage(25);
                tr.Cells.Add(td);
            }
            tblGianHang.Rows.Add(tr);
        }
    }

    protected void pnlSanPham04_ContentRefresh(object sender, EventArgs e)
    {
        LoadSanPham04();
    }

    //protected void btnDangNhap_ServerClick(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        NguoiDung nguoidung = new NguoiDung();
    //        DataSet ds = nguoidung.SelectByField("taikhoan", txtTaiKhoan.Value.Trim(), "nvarchar");

    //        if (ds.Tables[0].Rows.Count > 0)
    //        {
    //            if ((ds.Tables[0].Rows[0]["matkhau"].ToString() == txtMatKhau.Value) &&
    //                (bool.Parse(ds.Tables[0].Rows[0]["KichHoat"].ToString()) == true))
    //            {
    //                Common.NguoiDungID = int.Parse(ds.Tables[0].Rows[0]["NguoiDungID"].ToString());
    //                Common.LoaiNguoiDungID = int.Parse(ds.Tables[0].Rows[0]["LoaiNguoiDungID"].ToString());
    //                Session.Add("UserFullName", ds.Tables[0].Rows[0]["HoVaTen"]);

    //                FormsAuthentication.RedirectFromLoginPage(txtTaiKhoan.Value.Trim(), false);
    //                tblDangNhap.Visible = false;
    //            }
    //            else
    //            {
    //                tblDangNhap.Visible = true;
    //                return;
    //            }
    //        }
    //        else
    //        {
    //            tblDangNhap.Visible = true;
    //            return;
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        Response.Redirect("Message.aspx?msg=" + ex.Message);
    //        return;
    //    }
    //}
}