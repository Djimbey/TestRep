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
using Adm.NewsModule;

public partial class Default2 : System.Web.UI.Page
{
    int id;

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

        List_News ln = Adm.Tools.Xmlwr.ReadFromFile<List_News>(Server.MapPath(DataInfo.News_FileName));
        phNews.Controls.Clear();
        LiteralControl Lit = new LiteralControl();

        if (Request.QueryString["id"] != null && int.TryParse(Request.QueryString["id"], out id))
        {
            NewsItem n = ln.FindByID(id);
            Page.Title = n.Title+" | Лимпопо";
            Lit.Text = "<h1>"+n.Title+"</h1>";
            Lit.Text += "<b>" + n.Announce + "</b><br /><br />";
            Lit.Text += n.Text + "<br /><br />";
        }
        else
        {
            Page.Title = "Новости | Лимпопо";
            if (ln.Items.Count > 0)
            {

                int page_num;
                int col_it = 5;
                if (Request.QueryString["str"] != null)
                {
                    int.TryParse(Request.QueryString["str"], out page_num);  // Текущая Страница
                }
                else
                {
                    page_num = 1;
                }
                int page_col;
                if (ln.Items.Count / col_it != 0)
                    page_col = ln.Items.Count / col_it + 1;
                else page_col = ln.Items.Count / col_it;

                Lit.Text = "<h1>Новости</h1>";

                ln.Items.Reverse();
                for (int i = col_it * (page_num - 1); i < ln.Items.Count && i < page_num * col_it; i++)
                {
                    NewsItem n = ln.Items[i];
                    Lit.Text += "<div class='NewsDate'>" + n.Date.Day + " " + ToMon(n.Date.Month) + " " + n.Date.Year + " г.</div>";
                    Lit.Text += "<a class='NewsTitle' href='news.aspx?id="+n.ID.ToString()+"'>" + n.Title + "</a>";
                    Lit.Text += "<p style='margin-top: 0;'>" + n.Announce + "</p>";
                }
                ln.Items.Reverse();

                if (ln.Items.Count > col_it)
                {
                    int t1, tn;

                    Lit.Text += "<div id='paginator'><span><div id='paginator_cont'>";
                    if (page_num - 5 < 1)
                        t1 = 1;
                    else
                        t1 = page_num - 5;

                    if (page_col > page_num + 5)
                        tn = page_num + 5;
                    else
                        tn = page_col;

                    if (page_num > 1) Lit.Text += "<div class='page_prev'><a href = 'news.aspx?str=" + Convert.ToString(page_num - 1) + "'>предыдущая</a></div>";

                    for (int i = t1; i <= tn; i++)
                    {
                        if (i != page_num)
                            Lit.Text += "<div class='page'><a href = 'news.aspx?str=" + i.ToString() + "'>" + i.ToString() + "</a></div>";
                        else Lit.Text += "<div class='page_act'><span>" + page_num.ToString() + "</span></div>";
                    }
                    if (page_num < page_col)
                        Lit.Text += "<div class='page'><a href = 'news.aspx?str=" + Convert.ToString(page_num + 1) + "'>следующая</a></div>";

                    Lit.Text += "</div></span></div>";

                }

                Lit.Text += "</div>";

            }
        }

        phNews.Controls.Add(Lit);
    
    }
}
