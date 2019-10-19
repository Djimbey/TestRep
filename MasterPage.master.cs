using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;

public partial class MasterPage : System.Web.UI.MasterPage
{


    protected string ToMon(int k)
    {
        switch (k)
        {
            case 1:
                {
                    return "января";
                    break;
                }
            case 2:
                {
                    return "февраля";
                    break;
                }
            case 3:
                {
                    return "марта";
                    break;
                }
            case 4:
                {
                    return "апреля";
                    break;
                }
            case 5:
                {
                    return "мая";
                    break;
                }
            case 6:
                {
                    return "июня";
                    break;
                }
            case 7:
                {
                    return "июля";
                    break;
                }
            case 8:
                {
                    return "августа";
                    break;
                }
            case 9:
                {
                    return "сентября";
                    break;
                }
            case 10:
                {
                    return "октября";
                    break;
                }
            case 11:
                {
                    return "ноября";
                    break;
                }
            case 12:
                {
                    return "декабря";
                    break;
                }
            default:
                {
                    return "января";
                }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        Adm.SectionModule.Sections s = Adm.Tools.Xmlwr.ReadFromFile<Adm.SectionModule.Sections>(Server.MapPath(Adm.SectionModule.DataInfo.Section_FileName));
        Adm.TovarModule.ListTovar lr = Adm.Tools.Xmlwr.ReadFromFile<Adm.TovarModule.ListTovar>(Server.MapPath(Adm.TovarModule.DataInfo.Tovar_FileName));

        string s1 = "";

        phCat.Controls.Clear();

        for (int i = 0; i < s.Items.Count; i++)
        {
            s1 += "<p><a class='menu_items' href='catalog.aspx?id="+s.Items[i].ID.ToString()+"'>" + s.Items[i].Caption + "</a></p>";
        }

        s1 += "<p><a class='menu_items' href='catalog.aspx'>Все разделы</a></p>";

        phCat.Controls.Add(new LiteralControl(s1));

        phRecent.Controls.Clear();

        s1 = "";
        DateTime dt = DateTime.Now.AddMonths(-10);
        Adm.TovarModule.Tovar t = new Adm.TovarModule.Tovar();

        for (int i = 0; i < lr.Items.Count; i++)
        {
            if (lr.Items[i].Date > dt)
            {
                dt = lr.Items[i].Date;
                t = lr.Items[i];
            }
        }

        s1 += "<div class='item' style='float: none; margin: 10px auto;'><a href='tovar.aspx?id=" + t.ID.ToString() + "'><img src='foto/" + t.Picture + "s.jpg' /></a><div class='t'>" + t.Caption + "</div><div>" + t.Price + "</div></div>";

        phRecent.Controls.Add(new LiteralControl(s1));

        phNews.Controls.Clear();
        s1 = "";

        Adm.NewsModule.List_News ln = Adm.Tools.Xmlwr.ReadFromFile<Adm.NewsModule.List_News>(Server.MapPath(Adm.NewsModule.DataInfo.News_FileName));

        if (ln.Items.Count > 0)
        {

            ln.Items.Reverse();

            for (int i = 0; i < ln.Items.Count && i < 3; i++)
            {
                s1 += "<div class='RNews'>";
                s1 += "<div class='Date'>" + ln.Items[i].Date.Day + " " + ToMon(ln.Items[i].Date.Month) + " " + ln.Items[i].Date.Year + " г.</div>";
                s1 += "<a href=news.aspx?id=" + ln.Items[i].ID.ToString() + " class='News'>" + ln.Items[i].Title + "</a>";
                s1 += "</div>";
            }

            s1 += "<br /><a class='allnews' href='news.aspx'>Все новости</a>";

            phNews.Controls.Add(new LiteralControl { Text = s1 });

        }
    }
}
