using System;
using System.Data;
using System.Web.UI;
using CHONET.DataAccessLayer.Web;

public partial class News : Page
{
    protected void Page_Load(object sender, EventArgs e)
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

    private void LoadTinTucForAll()
    {
        TinTuc tt = new TinTuc();
        DataSet ds = tt.SelectAdminNews();
        lblTieuDe.Text = "Các tin mới nhất.";

        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            spnTinTuc.InnerHtml += "<br><a href=\"news.aspx?nid="
                                   + dr["TinTucID"]
                                   + "\" ><b>" + dr["tieude"]
                                   + "</b><br><img border=\"0\"width=\"48\" src=\""
                                   + dr["anh"] + "\" /></a>&nbsp;&nbsp;"
                                   + dr["tomtat"] + "<br><a href=\"news.aspx?nid="
                                   + dr["TinTucID"]
                                   + "\" >Xem tiếp</a><br><hr>";
        }
    }
}