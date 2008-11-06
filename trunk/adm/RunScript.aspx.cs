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
using CHONET.DataAccessLayer;
using System.Data.SqlClient;
using CHONET.Common;

public partial class Adm_RunScript : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblMessage.Text = "";
        if (Common.LoaiNguoiDungID() != 3)
            Response.Redirect("../message.aspx?msg=Access denied");
    }
    protected void btnRun_Click(object sender, EventArgs e)
    {
        if (txtCode.Text == "vt82@chonet.vn")
        {
            try
            {
                DataAccess objDataAccess = new DataAccess();
                string command = txtScript.Text;
                int goPos = command.IndexOf("GO");
               
                do
                {
                    using (SqlCommand sqlCmd = new SqlCommand())
                    {
                        //sqlCmd.Connection = sqlConn;
                        sqlCmd.CommandType = CommandType.Text;
                        if (goPos <= 0)
                        {
                            sqlCmd.CommandText = command;
                        }
                        else
                        {
                            sqlCmd.CommandText = command.Substring(0, goPos);
                        }
                        command = command.Replace(command.Substring(0, goPos + 2), "");
                        objDataAccess.ExecuteNonQuery(sqlCmd);
                        goPos = command.IndexOf("GO");
                    }
                } while (goPos > 0);

                lblMessage.Text = "Script đã đc thực thi thành công";
            }
            catch (Exception ex)
            {
                Response.Redirect("../message.aspx?msg=" + ex.ToString().Replace("\r\n", ""));
            }
        }
        else
        {
            lblMessage.Text = "Invalid confirmation code";
        }
    }
    protected void btnRunSelect_Click(object sender, EventArgs e)
    {
        if (txtCode.Text == "vt82@chonet.vn")
        {
            try
            {
                DataAccess objDataAccess = new DataAccess();
                DataSet ds = null;                

                using (SqlCommand sqlCmd = new SqlCommand())
                {
                    //sqlCmd.Connection = sqlConn;
                    sqlCmd.CommandType = CommandType.Text;
                    sqlCmd.CommandText = txtScript.Text;                     
                    ds = objDataAccess.ExecuteQuery(sqlCmd, "table");                    
                }



                GridView1.DataSource = ds;
                GridView1.DataBind();
                lblMessage.Text = "Script đã đc thực thi thành công";
            }
            catch (Exception ex)
            {
                Response.Redirect("../message.aspx?msg=" + ex.ToString().Replace("\r\n", ""));
            }
        }
        else
        {
            lblMessage.Text = "Invalid confirmation code";
        }
    }
}
