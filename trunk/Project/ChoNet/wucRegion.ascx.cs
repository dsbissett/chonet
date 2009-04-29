using System;
using System.Web.UI;

public partial class wucRegion : UserControl
{
    public String clsRegion
    {
        get { return (String) ViewState["clsRegion"]; }
        set { ViewState["clsRegion"] = value; }
    }

    public String HrefRegion
    {
        get { return (String) ViewState["HrefRegion"]; }
        set { ViewState["HrefRegion"] = value; }
    }

    public String Title
    {
        get { return (String) ViewState["Title"]; }
        set { ViewState["Title"] = value; }
    }

    public String Width
    {
        get { return (String) ViewState["Width"]; }
        set { ViewState["Width"] = value; }
    }

    public bool ShowImage
    {
        get { return (bool) ViewState["ShowImage"]; }
        set { ViewState["ShowImage"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //Page.Title = this.Title;   
        imgNew.Visible = ShowImage;
    }
}