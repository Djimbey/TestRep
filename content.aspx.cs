using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class Default2 : System.Web.UI.Page
{
    int id;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null && int.TryParse(Request.QueryString["id"], out id))
        {
            Adm.PagesModule.PagesList spl = Adm.Tools.Xmlwr.ReadFromFile<Adm.PagesModule.PagesList>(Server.MapPath(Adm.PagesModule.DataInfo.Pages_FileName));

            string s = "";

            phContent.Controls.Clear();

            switch (id)
            {
                case 0:
                    {
                        Response.Redirect("Default.aspx");
                        break;
                    }
                case 1:
                    {
                        s = "<h1>О компании</h1>";
                        Page.Title = "О компании | Лимпопо";
                        break;
                    }
                case 2:
                    {
                        s = "<h1>Как нас найти</h1>";
                        Page.Title = "Как нас найти | Лимпопо";
                        break;
                    }
                case 3:
                    {
                        s = "<h1>Наши скидки</h1>";
                        Page.Title = "Наши скидки | Лимпопо";
                        break;
                    }
                case 4:
                    {
                        s = "<h1>Прайс-лист</h1>";
                        Page.Title = "Прайс-лист | Лимпопо";
                        break;
                    }
            }

            s += spl.Pages[id];

            phContent.Controls.Add(new LiteralControl { Text = s });

        }
    }
}
