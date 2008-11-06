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
using CHONET.DataAccessLayer.Web;
using CHONET.Common;

public partial class Admin_Cat2Config : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Common.LoaiNguoiDungID() == 3)
        {
            if (!Page.IsPostBack)
            {
                LoadQuangCao23();
                LoadQuangCao22();
            }
        }
        else
        {
            Response.Redirect("../message.aspx?msg=Access denied");
        }
    }
    private void LoadQuangCao23()
    {
        QuangCao qcao = new QuangCao();
        DataSet ds = qcao.SelectQuangCaoAtViTriQuangCaoByLoaiNguoiDungID(Common.LoaiNguoiDungID(), 23);
        if (ds.Tables[0].Rows.Count >= 1)
        {
            if (ds.Tables[0].Rows[0]["LoaiAnh"].ToString() == "FLASH")
            {
                spnQuangCao23.InnerHtml = "<object border:solid 1px #C9C3C3 classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
                    + "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
                    + "width=\"100%\" height=\"216\" title=\"Quang Cao\">"
                    + "<param name=\"movie\" value=\"." + ds.Tables[0].Rows[0]["DuongDanAnh"].ToString() + "\" />"
                    + "<param name=\"quality\" value=\"high\" />"
                    + "<embed src=\"" + ds.Tables[0].Rows[0]["DuongDanAnh"].ToString() + "\" quality=\"high\""
                    + "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
                    + "width=\"100%\" height=\"216\"></embed></object>";
            }
            else
            {
                spnQuangCao23.InnerHtml = "<a href=\"" + ds.Tables[0].Rows[0]["DuongDan"].ToString()
                   + "\" target=\"_blank\"><img alt=\"" + ds.Tables[0].Rows[0]["NoiDungQuangCao"].ToString()
                   + "\" src=\"." + ds.Tables[0].Rows[0]["DuongDanAnh"].ToString() + "\" height=\"216px\" width=\"100%\" style=\"border:solid 1px #C9C3C3\"/></a>";
            }
        }
        else
        {
            spnQuangCao23.InnerHtml = "<img alt=\"Moi quang cao\" src=\"../images/advblank.jpg\" height=\"216px\" width=\"596px\" style=\"border:none\"/>";
        }
    }
    private void LoadQuangCao22()
    {
        QuangCao qcao = new QuangCao();
        DataSet ds = qcao.SelectQuangCaoAtViTriQuangCaoByLoaiNguoiDungID(Common.LoaiNguoiDungID(), 22);
        int n = 4;
        if (ds.Tables[0].Rows.Count <= 4) n = ds.Tables[0].Rows.Count;

        for (int i = 0; i < n; i++)
        {
            TableRow tr = new TableRow();
            TableCell td = new TableCell();
            td.Style.Value = "padding-top: 4px;";
            string content = "";
            if (ds.Tables[0].Rows[i]["LoaiAnh"].ToString() == "FLASH")
            {
                content = "<object style=\"border:solid 1px #C9C3C3\" classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\""
                            + "codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\""
                            + "width=\"220\" height=\"155\" title=\"Quang Cao\">"
                            + "<param name=\"movie\" value=\"." + ds.Tables[0].Rows[i]["DuongDanAnh"].ToString() + "\" />"
                            + "<param name=\"quality\" value=\"high\" />"
                            + "<embed src=\"." + ds.Tables[0].Rows[i]["DuongDanAnh"].ToString() + "\" quality=\"high\""
                            + "pluginspage=\"http://www.macromedia.com/go/getflashplayer\" type=\"application/x-shockwave-flash\""
                            + "width=\"220\" height=\"155\"></embed></object></a>";
            }
            else
            {
                content = "<a href=\"" + ds.Tables[0].Rows[i]["DuongDan"].ToString()
                            + "\" target=\"_blank\"><img alt=\"" + ds.Tables[0].Rows[i]["NoiDungQuangCao"].ToString()
                            + "\" src=\"." + ds.Tables[0].Rows[i]["DuongDanAnh"].ToString()
                            + "\" style=\"border:solid 1px #C9C3C3; width:220px;\">";
            }
            td.Text = content;
            tr.Cells.Add(td);
            tblQuangCao22.Rows.Add(tr);
        }
    }
    protected void pnlQuangCao23_ContentRefresh(object sender, EventArgs e)
    {
        LoadQuangCao23();
    }
    protected void pnlQuangCao22_ContentRefresh(object sender, EventArgs e)
    {
        LoadQuangCao22();
    }
}
