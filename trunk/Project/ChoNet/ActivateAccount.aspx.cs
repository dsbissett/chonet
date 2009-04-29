using System;
using System.Data;
using System.Web.UI;
using CHONET.DataAccessLayer.Web;

public partial class ActivateAccount : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if ((Request.QueryString["ndid"] != null) && (Request.QueryString["activate"] != null))
            {
                int ndid = int.Parse(Request.QueryString["ndid"]);
                NguoiDung nd = new NguoiDung();
                DataSet ds = nd.SelectByID(ndid);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    string masokichhoat = ds.Tables[0].Rows[0]["MaSoKichHoat"].ToString();
                    bool blKichHoat = bool.Parse(ds.Tables[0].Rows[0]["KichHoat"].ToString());
                    if (Request.QueryString["activate"] == masokichhoat)
                    {
                        if (blKichHoat == false)
                        {
                            nd.UpdateFields(int.Parse(Request.QueryString["ndid"]), null, null, null, null,
                                            null, null, null, true, null, null, null, null, null, null, null, null, null,
                                            null, null);
                        }

                        divInform.InnerHtml =
                            "Tài khoản của bạn đã được kích hoạt. <br> Hãy nhấn <a href=login.aspx><span style=\"font-size:14px\">vào đây</span></a> để đăng nhập.";
                    }
                    else
                    {
                        divInform.InnerHtml =
                            "Mã số kích hoạt của bạn không đúng. <br> Hãy kiểm tra lại mail kích hoạt hoặc nhấn <a href=SendActiveMail.aspx><span style=\"font-size:14px\">vào đây</span></a> để nhận mail kích hoạt";
                    }
                }
                else
                {
                    divInform.InnerHtml =
                        "Đường dẫn kích hoạt của bạn không đúng. <br> Hãy kiểm tra lại mail kích hoạt hoặc nhấn <a href=SendActiveMail.aspx><span style=\"font-size:14px\">vào đây</span></a> để nhận mail kích hoạt";
                }
            }
            else
            {
                divInform.InnerHtml =
                    "Đường dẫn kích hoạt của bạn không đúng. <br> Hãy kiểm tra lại mail kích hoạt hoặc nhấn <a href=SendActiveMail.aspx><span style=\"font-size:14px\">vào đây</span></a> để nhận mail kích hoạt";
            }
        }
        catch (Exception ex)
        {
            Response.Redirect("message.aspx?msg=" + ex.ToString().Replace("\r\n", ""), false);
        }
    }
}