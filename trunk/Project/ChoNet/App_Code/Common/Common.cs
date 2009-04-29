using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Web;
using CHONET.DataAccessLayer;

/// <summary>
/// Summary description for Common
/// </summary>
namespace CHONET.Common
{
    public class Common
    {
        //public static int LoaiNguoiDungID;
        //public static int NguoiDungID;        
        public static DataTable tblSanPhamDaXem;
        //Check User belong Units
        public DataSet UnitsPermissionCheck(int USER_ID)
        {
            //GetPermissionUserForUnits
            DataAccess objDataAccess = new DataAccess();
            DataSet dsResult = new DataSet();
            dsResult.Locale = CultureInfo.CurrentCulture;
            using (SqlCommand sqlCmd = new SqlCommand())
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "GetPermissionUserForUnits";
                sqlCmd.Parameters.Add("@USER_ID", SqlDbType.BigInt).Value = USER_ID;
                dsResult = objDataAccess.ExecuteQuery(sqlCmd, "PermissionUserForUnits");
                return dsResult;
            }
        }

        public static int LoaiNguoiDungID()
        {
            if (!SessionIsOK())
            {
                //HttpContext.Current.Response.Redirect("../message.aspx?msg=Session timed out!");
                return 0;
            }
            else
            {
                return (int) (HttpContext.Current.Session["LoaiNguoiDungID"]);
            }
        }

        public static int NguoiDungID()
        {
            if (!SessionIsOK())
            {
                //HttpContext.Current.Response.Redirect("../message.aspx?msg=Session timed out!");
                return 0;
            }
            else
            {
                return (int) (HttpContext.Current.Session["NguoiDungID"]);
            }
        }

        public static string NguoiDungEmail()
        {
            if (!SessionIsOK())
            {
                //HttpContext.Current.Response.Redirect("../message.aspx?msg=Session timed out!");
                return null;
            }
            else
            {
                return HttpContext.Current.Session["NguoiDungEmail"].ToString();
            }
        }

        public static bool SessionIsOK()
        {
            if (HttpContext.Current.Session["NguoiDungID"] == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool SendMail(string emailTo, string emailFrom, string emailSubject, string emailBody,
                                    string smtpServer, string mailCC, string mailBcc)
        {
            bool blSuccess = true;
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(emailFrom);
                mail.Subject = emailSubject;
                mail.To.Add(emailTo);
                mail.Body = emailBody;
                mail.IsBodyHtml = true;
                NetworkCredential mailAuthentication = new NetworkCredential("chonet@chonet.vn", "qaz@12345");
                //mail.BodyEncoding.EncodingName = "UTF-8";
                SmtpClient smtpClient = new SmtpClient(smtpServer);
                smtpClient.Credentials = mailAuthentication;
                smtpClient.Send(mail);
            }
            catch (Exception ex)
            {
                blSuccess = false;
                throw ex;
            }
            return blSuccess;
        }

        public static string GetEmailHTMLTemplate(string fileTemplateName)
        {
            string str = "";
            StreamReader sr = null;
            try
            {
                sr = File.OpenText(fileTemplateName);
                str = sr.ReadToEnd();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
            }
            finally
            {
                if (sr != null)
                {
                    sr.Close();
                }
            }
            return str;
        }

        public static bool SendActiveMail(string emailto, string subject, string template, string name, string ndid,
                                          string activecode, string taikhoan, string matkhau, string email)
        {
            try
            {
                //string emailto = emailto;
                string emailfrom = ConfigurationManager.AppSettings["EmailFrom"];
                string emailsubject = subject;
                string emailbody = template;
                string smtpserver = ConfigurationManager.AppSettings["smtpserver"];
                string emailcc = "";
                string emailbcc = "";

                emailbody = emailbody.Replace("[[name]]", name);
                emailbody = emailbody.Replace("[[linkkichhoat]]",
                                              "http://chonet.vn/ActivateAccount.aspx?ndid=" + ndid + "&activate="
                                              + activecode);
                emailbody = emailbody.Replace("[[taikhoan]]", taikhoan);
                emailbody = emailbody.Replace("[[password]]", matkhau);
                emailbody = emailbody.Replace("[[email]]", email);

                return SendMail(emailto, emailfrom, emailsubject, emailbody, smtpserver, emailcc, emailbcc);
            }
            catch
            {
                return false;
            }
        }

        public static void ResizeFromStream(string ImageSavePath, int MaxSideSize, Stream Buffer)
        {
            int intNewWidth;
            int intNewHeight;

            Image imgInput = Image.FromStream(Buffer);

            //Determine image format
            ImageFormat fmtImageFormat = imgInput.RawFormat;

            //get image original width and height
            int intOldWidth = imgInput.Width;
            int intOldHeight = imgInput.Height;

            //determine if landscape or portrait
            int intMaxSide;

            if (intOldWidth >= intOldHeight)
            {
                intMaxSide = intOldWidth;
            }
            else
            {
                intMaxSide = intOldHeight;
            }


            if (intMaxSide > MaxSideSize)
            {
                //set new width and height
                double dblCoef = MaxSideSize/(double) intMaxSide;
                intNewWidth = Convert.ToInt32(dblCoef*intOldWidth);
                intNewHeight = Convert.ToInt32(dblCoef*intOldHeight);
            }
            else
            {
                intNewWidth = intOldWidth;
                intNewHeight = intOldHeight;
            }
            //create new bitmap
            Bitmap bmpResized = new Bitmap(imgInput, intNewWidth, intNewHeight);

            //save bitmap to disk
            bmpResized.Save(ImageSavePath, fmtImageFormat);

            //release used resources
            imgInput.Dispose();
            bmpResized.Dispose();
            Buffer.Close();
        }
    }
}