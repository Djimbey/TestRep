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

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        Adm.PagesModule.PagesList spl = Adm.Tools.Xmlwr.ReadFromFile<Adm.PagesModule.PagesList>(Server.MapPath(Adm.PagesModule.DataInfo.Pages_FileName));

        string s = "";

        phContent.Controls.Clear();

        s = "<h1>Лимпопо</h1>";

        s += spl.Pages[0];

        phContent.Controls.Add(new LiteralControl { Text = s });

    }
}
