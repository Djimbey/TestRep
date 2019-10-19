using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Adm.Tools;

public partial class admin_MasterAdmin : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["login"] != null)
        {
            if (Session["login"].ToString() == "logged")
            {

            }
            else
            {
                Response.Redirect("~/admin/login.aspx");
            }
        }
        else
        {
            if (Request.Cookies["login"] != null)
            {
                HttpCookie cook = Request.Cookies["login"];
                string Admin = cook["admin"];
                if (Admin == "logged")
                {
                }
                else
                {
                    Response.Redirect("~/admin/login.aspx");
                }
            }
            else
            {
                Response.Redirect("~/admin/login.aspx");
            }
        }
    }

    protected void exit_Click(object sender, EventArgs e)
    {
        HttpCookie cook = new HttpCookie("login");
        cook["admin"] = "";
        cook.Expires = DateTime.Now.AddDays(-1d);
        Response.Cookies.Add(cook);
        Session["login"] = null;
        Response.Redirect("login.aspx");
    }
}
