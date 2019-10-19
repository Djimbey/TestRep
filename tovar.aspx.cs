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

            phContent.Controls.Clear();

            Adm.TovarModule.ListTovar lt = Adm.Tools.Xmlwr.ReadFromFile<Adm.TovarModule.ListTovar>(Server.MapPath(Adm.TovarModule.DataInfo.Tovar_FileName));
            Adm.FotoModule.List_Foto lf = Adm.Tools.Xmlwr.ReadFromFile<Adm.FotoModule.List_Foto>(Server.MapPath(Adm.FotoModule.DataInfo.Foto_FileName));
            Adm.TovarModule.Tovar it = lt.FindByID(id);

            LiteralControl Lit = new LiteralControl();

            if (it != null)
            {

                Lit.Text += "<h1>" + it.Caption + "</h1>";
                if (it.Picture > 0)
                {
                    Adm.FotoModule.Foto F = lf.FindByID(it.Picture);
                    if (F != null)
                    {
                        System.Drawing.Image img = System.Drawing.Image.FromFile(Server.MapPath("~/foto/" + it.Picture + "s.jpg"));
                        int w = img.Width;
                        int h = img.Height;
                        if (img.Width > 200)
                        {
                            float m = (float)w / h;
                            w = 200;
                            h = Convert.ToInt32(w / m);
                        }
                        Lit.Text += "<a title='" + F.Desk + "' rel='lightbox[1]' href='foto/" + F.ID.ToString() + "b.jpg'><img style=\"width:" + w + "px; height:" + h + "px; float:left; margin: 0 20px 20px 0; border: solid 2px #d4d4d4\" src='foto/" + F.ID.ToString() + "s.jpg' /></a>";
                        
                    }
                }

                Lit.Text += "<br /><b>Цена: </b>" + it.Price+ "<br />";
                Lit.Text += "<br />" + it.Text;

                Lit.Text += "<br clear='left' /><br />" + it.Desc + "<br /><br />";

                if (it.Fotos.Count > 0)
                {

                    for (int i = 0; i < it.Fotos.Count; i++)
                    {
                        Adm.FotoModule.Foto F = lf.FindByID(it.Fotos[i]);
                        if (F != null)
                        {
                            System.Drawing.Image img = System.Drawing.Image.FromFile(Server.MapPath("~/foto/" + it.Fotos[i] + "s.jpg"));
                            int w = img.Width;
                            int h = img.Height;
                            if (img.Width > 200)
                            {
                                float m = (float)w / h;
                                w = 200;
                                h = Convert.ToInt32(w / m);
                            }
                            Lit.Text += "<a title='" + F.Desk + "' rel='lightbox[" + id.ToString() + "]' href='foto/" + it.Fotos[i].ToString() + "b.jpg'><img style=\"border-width:0px; margin-right: 10px; width:" + w + "px; height:" + h + "px;\" src='foto/" + it.Fotos[i].ToString() + "s.jpg' /></a>";
                        }
                    }
                }
            }

            phContent.Controls.Add(Lit);

        }

    }
}
