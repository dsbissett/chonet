using System;
using System.Web.UI;

public partial class Inform : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["msg"] != null)
        {
            lblInform.Text = Request.QueryString["msg"];
            divInformUser.Visible = false;
            divInformEstore.Visible = false;
        }
        else if (Request.QueryString["type"] == "user")
        {
            divInformUser.Visible = true;
            divInformEstore.Visible = false;
            lblInform.Visible = false;
            lblName.Text = Request.QueryString["name"];
            lblEmail.Text = Request.QueryString["email"];
        }
        else if (Request.QueryString["type"] == "estore")
        {
            divInformUser.Visible = false;
            divInformEstore.Visible = true;
            lblInform.Visible = false;
            lblEstoreName.Text = Request.QueryString["name"];
            //lblEmail.Text = Request.QueryString["email"].ToString();
        }
    }
}