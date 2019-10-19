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
    int str;

    protected void Page_Load(object sender, EventArgs e)
    {
        string s = "";

        phCat.Controls.Clear();

        Adm.SectionModule.Sections secs = Adm.Tools.Xmlwr.ReadFromFile<Adm.SectionModule.Sections>(Server.MapPath(Adm.SectionModule.DataInfo.Section_FileName));

        if (Request.QueryString["id"] != null && int.TryParse(Request.QueryString["id"], out id))
        {
            Adm.SectionModule.Section sec = secs.FindByID(id);

            if (sec != null)
                s += "<h1>" + sec.Caption + "</h1>";

            Adm.TovarModule.ListTovar lr = Adm.Tools.Xmlwr.ReadFromFile<Adm.TovarModule.ListTovar>(Server.MapPath(Adm.TovarModule.DataInfo.Tovar_FileName));

            for (int i = 0; i < lr.Items.Count; i++)
            {
                if (lr.Items[i].Section == id)
                    s += "<div class='item'><a href='tovar.aspx?id=" + lr.Items[i].ID.ToString() + "'><img src='foto/" + lr.Items[i].Picture + "s.jpg' /></a><div class='t'>" + lr.Items[i].Caption + "</div><div>" + lr.Items[i].Price + "</div></div>";
            }

        }

        else
        {
            Adm.TovarModule.ListTovar lr = Adm.Tools.Xmlwr.ReadFromFile<Adm.TovarModule.ListTovar>(Server.MapPath(Adm.TovarModule.DataInfo.Tovar_FileName));
            s += "<h1>Каталог</h1>";
            for (int i = 0; i < lr.Items.Count; i++)
            {
                    s += "<div class='item'><a href='tovar.aspx?id=" + lr.Items[i].ID.ToString() + "'><img src='foto/" + lr.Items[i].Picture + "s.jpg' /></a><div class='t'>" + lr.Items[i].Caption + "</div><div>" + lr.Items[i].Price + "</div></div>";
            }
        }

        phCat.Controls.Add(new LiteralControl(s));

    }
}
