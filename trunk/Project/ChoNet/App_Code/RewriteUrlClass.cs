using System;
using System.Web;

public class RewriteUrlClass : IHttpModule
{
    #region IHttpModule Members

    public void Dispose()
    {
    }


    public void Init(HttpApplication context)
    {
        context.BeginRequest += Context_BeginRequest;
    }

    #endregion

    private static void Context_BeginRequest(object sender, EventArgs e)
    {
        HttpApplication httpApplication = (HttpApplication) sender;

        string url = httpApplication.Request.RawUrl.ToLower();


        // Nếu là Url ảo như sau"

        if (url.Contains("/default.aspvn"))
        {
            // Thì Url thực mà Server cần xử lý là:

            httpApplication.Context.RewritePath("Default.aspx");
        }


        // Nếu là Url ảo như sau"

        if (url.Contains("/login.aspvn"))
        {
            // Thì Url thực mà Server cần xử lý là:

            httpApplication.Context.RewritePath("Login.aspx");
        }


        // Tùy thuộc vào quy tắt Rewrite mà chúng ta xử lý.

        // Một trong những cách hiệu quả nhất là dùng Regex Expression.
    }
}