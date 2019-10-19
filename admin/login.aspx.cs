using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class loginadmin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button_Send_Click(object sender, EventArgs e)
    {
        if (TextBox_Login.Text == "admin" && TextBox_Pass.Text == "qwerty")
        {
                HttpCookie cook = new HttpCookie("login");
                cook["admin"] = "logged";                
                DateTime dt = DateTime.Now;
                cook.Expires = dt.AddMonths(1);
                Response.Cookies.Add(cook);
                Session["login"] = "logged";
                Response.Redirect("~/admin/");
            
        }
    }
}