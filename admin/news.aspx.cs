using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class news : System.Web.UI.Page
{
   static int i1, i2;
            
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Adm.NewsModule.List_News ln = Adm.Tools.Xmlwr.ReadFromFile<Adm.NewsModule.List_News>(Server.MapPath(Adm.NewsModule.DataInfo.News_FileName));
            for (int i = 0; i < ln.Items.Count; i++)
            {
                ListItem it = new ListItem();
                it.Text = ln.Items[i].Title;
                it.Value = ln.Items[i].ID.ToString();
                ListBox1.Items.Add(it);
            }
        }
    }

       
    protected void Button_Remove_Click(object sender, EventArgs e)
    {
        if (ListBox1.SelectedIndex > -1)
        {
            Adm.NewsModule.List_News ln = Adm.Tools.Xmlwr.ReadFromFile<Adm.NewsModule.List_News>(Server.MapPath(Adm.NewsModule.DataInfo.News_FileName));
            Adm.NewsModule.NewsItem n = ln.FindByID(int.Parse(ListBox1.SelectedValue));

            ln.Items.Remove(n);
            ListBox1.Items.Remove(ListBox1.SelectedItem);
            Adm.Tools.Xmlwr.WriteToFile(Server.MapPath(Adm.NewsModule.DataInfo.News_FileName), ln);
        }
        
    }

    protected void Button_Add_Click(object sender, EventArgs e)
    {
        Adm.NewsModule.List_News ln = Adm.Tools.Xmlwr.ReadFromFile<Adm.NewsModule.List_News>(Server.MapPath(Adm.NewsModule.DataInfo.News_FileName));

        int c = Adm.Tools.Counters.GetValue(Adm.NewsModule.DataInfo.News_ID_Counter, Server);
        c++;
        Adm.Tools.Counters.SetValue(Adm.NewsModule.DataInfo.News_ID_Counter, c, Server);

        Adm.NewsModule.NewsItem n = new Adm.NewsModule.NewsItem();
        n.Title = "Новость от "+DateTime.Today.ToShortDateString();
        n.ID = c;
        n.Date = DateTime.Now;
        ln.Items.Add(n);
        ListItem it = new ListItem();
        it.Text = n.Title;
        it.Value = n.ID.ToString();
        ListBox1.Items.Add(it);
        Adm.Tools.Xmlwr.WriteToFile(Server.MapPath(Adm.NewsModule.DataInfo.News_FileName), ln);

    }

    protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ListBox1.SelectedIndex > -1)
        {
            Adm.NewsModule.List_News ln = Adm.Tools.Xmlwr.ReadFromFile<Adm.NewsModule.List_News>(Server.MapPath(Adm.NewsModule.DataInfo.News_FileName));
            Adm.NewsModule.NewsItem n = ln.FindByID(int.Parse(ListBox1.SelectedValue));

            TB_Title.Text = n.Title;
            News_Annotation.Text = n.Announce;
            
            News_DT.Text = n.Date.ToString();
            spaw1.Text = n.Text;
        }
    }       

    protected void Topic_Save_Click(object sender, EventArgs e)
    {
        if (ListBox1.SelectedIndex > -1)
        {
            Adm.NewsModule.List_News ln = Adm.Tools.Xmlwr.ReadFromFile<Adm.NewsModule.List_News>(Server.MapPath(Adm.NewsModule.DataInfo.News_FileName));
            Adm.NewsModule.NewsItem n = ln.FindByID(int.Parse(ListBox1.SelectedValue));

            n.Announce = News_Annotation.Text;
            n.Title = TB_Title.Text;
            n.Text = spaw1.Text;
            n.Date = Convert.ToDateTime(News_DT.Text);
            

            Adm.Tools.Xmlwr.WriteToFile(Server.MapPath(Adm.NewsModule.DataInfo.News_FileName), ln);

            ListBox1.Items[ListBox1.SelectedIndex].Text = n.Title;

        }
    }

}