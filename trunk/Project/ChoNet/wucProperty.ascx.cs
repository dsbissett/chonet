using System;
using System.Data;
using System.Web.UI;
using CHONET.DataAccessLayer.Web;

public partial class wucProperty : UserControl
{
    public String PropertyName
    {
        get { return (String) ViewState["PropertyName"]; }
        set { ViewState["PropertyName"] = value; }
    }

    public int PropertyID
    {
        get { return int.Parse(("0" + ViewState["PropertyID"])); }
        set { ViewState["PropertyID"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            lblName.Text = PropertyName;
            LoadSubProperties(PropertyID);
        }
    }

    private void LoadSubProperties(int ThuocTinhId)
    {
        try
        {
            divProperties.InnerHtml = "";
            ThuocTinh tt = new ThuocTinh();
            DataSet ds = tt.SelectByThuocTinhChaID(ThuocTinhId);

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    int ThuocTinhConID = int.Parse(dr["ThuocTinhID"].ToString());
                    if (CheckShowedProperty(ThuocTinhConID))
                    {
                        divProperties.InnerHtml = "";
                        DataSet dstt = tt.SelectByID(ThuocTinhConID);

                        if (dstt.Tables[0].Rows.Count > 0)
                        {
                            for (int i = 0; i < dstt.Tables[0].Rows.Count; i++)
                            {
                                string strHref = "&spid=" + ThuocTinhConID + "_" + ThuocTinhId;
                                if (Request.Url.ToString().IndexOf(strHref) != -1)
                                {
                                    //Request.Url.ToString().Replace(strHref + "_del", "");
                                    divProperties.InnerHtml += "<a style='color:pink;' href=\"" + Request.Url;
                                    divProperties.InnerHtml += "\">";
                                    divProperties.InnerHtml += dstt.Tables[0].Rows[i]["TenThuocTinh"].ToString().Trim();
                                    divProperties.InnerHtml += "</a>";
                                    divProperties.InnerHtml += "&nbsp;&nbsp;   <a href=\"" + Request.Url;
                                    divProperties.InnerHtml +=
                                        "\" ><img style='cursor:hand;width:12px;border:0px;' src=\"images/del.gif\" ></img></a><br>";
                                    divProperties.InnerHtml = divProperties.InnerHtml.Replace(strHref, "");
                                }
                                //else
                                //{
                                //   // Request.Url.ToString().Replace(strHref, strHref + "_del");
                                //    divProperties.InnerHtml += "<a style='color:pink;' href=\"" + this.Request.Url;
                                //    divProperties.InnerHtml += "\">";
                                //    divProperties.InnerHtml += dstt.Tables[0].Rows[i]["TenThuocTinh"].ToString().Trim();
                                //    divProperties.InnerHtml += "</a>";
                                //    divProperties.InnerHtml += "&nbsp;&nbsp;   <a href=\"" + this.Request.Url;
                                //    divProperties.InnerHtml += "\" ><img style='cursor:hand;width:8px;border:0px;' src=\"images/delete.gif\" ></img></a><br>";
                                //    divProperties.InnerHtml = divProperties.InnerHtml.ToString().Replace(strHref, strHref + "_del");
                                //}
                            }
                        }
                        break;
                    }
                    else
                    {
                        divProperties.InnerHtml += "<a style='color:pink;' href=\"" + Request.Url;
                        //if (Request.QueryString["spid"] == null)
                        divProperties.InnerHtml += "&spid=" + dr["ThuocTinhID"] + "_" + ThuocTinhId;
                        //else
                        //{
                        //    string strSpid = this.Request.Url.;
                        //    divProperties.InnerHtml.Replace("", "");
                        //}
                        divProperties.InnerHtml += "\">";
                        divProperties.InnerHtml += dr["TenThuocTinh"].ToString().Trim();
                        divProperties.InnerHtml += "</a><br>";
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());
        }
    }

    private bool CheckShowedProperty(int ThuocTinhConID)
    {
        if (Request.QueryString["spid"] != null)
        {
            string[] spid = Request.QueryString["spid"].Split(',');
            for (int i = 0; i < spid.Length; i++)
            {
                if (spid.GetValue(i).ToString().Split('_')[0] == ThuocTinhConID.ToString())
                {
                    return true;
                }
            }
        }
        return false;
    }
}