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

public partial class admin_page : System.Web.UI.Page
{
    string name;
    int id;

    protected void Page_Load(object sender, EventArgs e)
    {


        if (Request.QueryString["name"] != null)
        {
            name = Request.QueryString["name"];
        }
        else
            name="main";

        switch(name)
        {
            case "main":
                {
                    id = 0;
                    break;
                }
            case "about":
                {
                    id = 1;
                    break;
                }
            case "find":
                {
                    id = 2;
                    break;
                }
            case "discont":
                {
                    id = 3;
                    break;
                }
            case "price":
                {
                    id = 4;
                    break;
                }
            default:
                {

                    Response.Redirect("~/admin/");
                    break;
                }
        }
        
            if (!Page.IsPostBack)
            {

                Adm.PagesModule.PagesList spl = Adm.Tools.Xmlwr.ReadFromFile<Adm.PagesModule.PagesList>(Server.MapPath(Adm.PagesModule.DataInfo.Pages_FileName));
                if (id > spl.Pages.Count - 1)
                {
                    spaw2.Text = "";
                }
                else
                {
                    spaw2.Text = spl.Pages[id];
                }
                switch (id)
                {
                    case 0: lblSC.Text = "<b>Главная</b>"; break;
                    case 1: lblSC.Text = "<b>О компании</b>"; break;
                    case 2: lblSC.Text = "<b>Как нас найти</b>"; break;
                    case 3: lblSC.Text = "<b>Наши скидки</b>"; break;
                    case 4: lblSC.Text = "<b>Прайс-лист</b>"; break;
                }
            }
        
    }

    protected void Topic_Save_Click(object sender, EventArgs e)
    {
        Adm.PagesModule.PagesList spl = Adm.Tools.Xmlwr.ReadFromFile<Adm.PagesModule.PagesList>(Server.MapPath(Adm.PagesModule.DataInfo.Pages_FileName));
        if (id > spl.Pages.Count - 1)
        {
            spl.Pages.Add(spaw2.Text);
        }
        else
        {
            spl.Pages[id] = spaw2.Text;
        }
        Adm.Tools.Xmlwr.WriteToFile(Server.MapPath(Adm.PagesModule.DataInfo.Pages_FileName), spl);

    }
}
