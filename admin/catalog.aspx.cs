using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_Default2 : System.Web.UI.Page
{
    static char[] ch = {'!','@','#','$','%',':',';','^','&','*'};
    static int id;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Adm.TovarModule.ListTovar lr = Adm.Tools.Xmlwr.ReadFromFile<Adm.TovarModule.ListTovar>(Server.MapPath(Adm.TovarModule.DataInfo.Tovar_FileName));
            for (int i = 0; i < lr.Items.Count; i++)
            {
                ListItem it = new ListItem();
                it.Text = lr.Items[i].Caption;
                it.Value = lr.Items[i].ID.ToString();
                ListBox1.Items.Add(it);
            }
            Adm.SectionModule.Sections sec = Adm.Tools.Xmlwr.ReadFromFile<Adm.SectionModule.Sections>(Server.MapPath(Adm.SectionModule.DataInfo.Section_FileName));
            DDL_Section.Items.Clear();
            DDL_Section.Items.Add(new ListItem("Не определено", "0"));
            for (int i = 0; i < sec.Items.Count; i++)
            {
                ListItem it1 = new ListItem();
                it1.Text = sec.Items[i].Caption;
                it1.Value = sec.Items[i].ID.ToString();
                DDL_Section.Items.Add(it1);
            }
        }
        LoadFotos();
    }

    void LoadFotos()
    {
        if (ListBox1.SelectedIndex > -1)
        {
            Adm.TovarModule.ListTovar lr = Adm.Tools.Xmlwr.ReadFromFile<Adm.TovarModule.ListTovar>(Server.MapPath(Adm.TovarModule.DataInfo.Tovar_FileName));
            Adm.TovarModule.Tovar r = lr.FindByID(int.Parse(ListBox1.SelectedValue));
            Adm.FotoModule.List_Foto lf = Adm.Tools.Xmlwr.ReadFromFile<Adm.FotoModule.List_Foto>(Server.MapPath(Adm.FotoModule.DataInfo.Foto_FileName));

            PlaceHolder1.Controls.Clear();

            if (System.IO.File.Exists(Server.MapPath("~/foto/") + r.Picture + "s.jpg"))
            {
                Image1.Visible = true;
                Image1.ImageUrl = "~/foto/" + r.Picture + "s.jpg";
            }
            else Image1.Visible = false;

            if (r.Fotos.Count > 0)
            {
                PlaceHolder1.Controls.Add(new Literal { Text = "<div id=\"carousel\"><a class=\"buttons prev\" href=\"#\"><<<</a><div class=\"viewport\">" });
                PlaceHolder1.Controls.Add(new Literal { Text = "<ul class=\"overview\">" });
                for (int i = 0; i < r.Fotos.Count; i++)
                {
                    Adm.FotoModule.Foto F = lf.FindByID(r.Fotos[i]);

                    PlaceHolder1.Controls.Add(new Literal { Text = "<li>" });
                    LinkButton lb = new LinkButton();
                    lb.ID = "im_" + r.Fotos[i];
                    lb.Controls.Add(new Literal { Text = String.Format("<img src='../foto/{0}s.jpg' style=\"border-width:0px\" />", r.Fotos[i]) });
                    lb.Click += new EventHandler(lb_Click);
                    PlaceHolder1.Controls.Add(lb);
                    if (F.Desk == "") 
                        PlaceHolder1.Controls.Add(new Literal { Text = "</li>" });
                    else
                        PlaceHolder1.Controls.Add(new Literal { Text = "<br /><span>" + F.Desk + "</span></li>" });
                }
                PlaceHolder1.Controls.Add(new Literal { Text = "</ul></div><a class=\"buttons next\" href=\"#\">>>></a></div>" });
            }
        }
    }

    void lb_Click(object sender, EventArgs e)
    {
        if (ListBox1.SelectedIndex > -1)
        {

            Adm.TovarModule.ListTovar lr = Adm.Tools.Xmlwr.ReadFromFile<Adm.TovarModule.ListTovar>(Server.MapPath(Adm.TovarModule.DataInfo.Tovar_FileName));
            Adm.TovarModule.Tovar r = lr.FindByID(int.Parse(ListBox1.SelectedValue));
            Adm.FotoModule.List_Foto lf = Adm.Tools.Xmlwr.ReadFromFile<Adm.FotoModule.List_Foto>(Server.MapPath(Adm.FotoModule.DataInfo.Foto_FileName));
            id = Convert.ToInt32(((LinkButton)sender).ID.Substring(3));
            Adm.FotoModule.Foto F = lf.FindByID(id);
            Panel1.Visible = true;
            TextBox1.Text = F.Desk;
        } 
    }

    protected void Button_Remove_Click(object sender, EventArgs e)
    {
        if (ListBox1.SelectedIndex > -1)
        {
            Adm.TovarModule.ListTovar lr = Adm.Tools.Xmlwr.ReadFromFile<Adm.TovarModule.ListTovar>(Server.MapPath(Adm.TovarModule.DataInfo.Tovar_FileName));
            Adm.TovarModule.Tovar r = lr.FindByID(int.Parse(ListBox1.SelectedValue));

            lr.Items.Remove(r);
            ListBox1.Items.Remove(ListBox1.SelectedItem);
            Adm.Tools.Xmlwr.WriteToFile(Server.MapPath(Adm.TovarModule.DataInfo.Tovar_FileName), lr);

            Panel2.Visible = false;
            Image1.Visible = false;
        }


    }

    protected void Button_Add_Click(object sender, EventArgs e)
    {
        Adm.TovarModule.ListTovar lr = Adm.Tools.Xmlwr.ReadFromFile<Adm.TovarModule.ListTovar>(Server.MapPath(Adm.TovarModule.DataInfo.Tovar_FileName));

        int c = Adm.Tools.Counters.GetValue(Adm.TovarModule.DataInfo.Tovar_ID_Counter, Server);
        c++;
        Adm.Tools.Counters.SetValue(Adm.TovarModule.DataInfo.Tovar_ID_Counter, c, Server);

        Adm.TovarModule.Tovar r = new Adm.TovarModule.Tovar();
        r.Caption = "Новый товар";
        r.ID = c;
        lr.Items.Add(r);
        ListItem it = new ListItem();
        it.Text = r.Caption;
        it.Value = r.ID.ToString();
        ListBox1.Items.Add(it);
        Adm.Tools.Xmlwr.WriteToFile(Server.MapPath(Adm.TovarModule.DataInfo.Tovar_FileName), lr);
        Image1.Visible = false;
    }

    protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ListBox1.SelectedIndex > -1)
        {
            Adm.TovarModule.ListTovar lr = Adm.Tools.Xmlwr.ReadFromFile<Adm.TovarModule.ListTovar>(Server.MapPath(Adm.TovarModule.DataInfo.Tovar_FileName));
            Adm.TovarModule.Tovar r = lr.FindByID(int.Parse(ListBox1.SelectedValue));

            Panel1.Visible = false;
            Tovar_Caption.Text = r.Caption;
            TB_Price.Text = r.Price;
            tbKol.Text = r.Kol.ToString();
            tbText.Text = r.Desc;
            DDL_Section.SelectedValue = r.Section.ToString();
            spaw1.Text = r.Desc;
            Panel2.Visible = true;
        }
    }

    protected void Topic_Save_Click(object sender, EventArgs e)
    {
        if (ListBox1.SelectedIndex > -1)
        {
            Adm.TovarModule.ListTovar lr = Adm.Tools.Xmlwr.ReadFromFile<Adm.TovarModule.ListTovar>(Server.MapPath(Adm.TovarModule.DataInfo.Tovar_FileName));
            Adm.TovarModule.Tovar r = lr.FindByID(int.Parse(ListBox1.SelectedValue));
            Adm.FotoModule.List_Foto lf = Adm.Tools.Xmlwr.ReadFromFile<Adm.FotoModule.List_Foto>(Server.MapPath(Adm.FotoModule.DataInfo.Foto_FileName));

            r.Caption = Tovar_Caption.Text;
            r.Desc = spaw1.Text;
            r.Text = tbText.Text;

            if (tbKol.Text != r.Kol.ToString())
            {
                int raz = int.Parse(tbKol.Text) - r.Kol;
                int.TryParse(tbKol.Text, out r.Kol);
                r.Change.Add(new ListItem(DateTime.Now.ToShortDateString(),raz.ToString()));
            }
            int.TryParse(DDL_Section.SelectedValue, out r.Section);
            r.Price = TB_Price.Text;

            if (FileUpload2.HasFile)
            {
                int c = Adm.Tools.Counters.GetValue(Adm.FotoModule.DataInfo.Foto_ID_Counter, Server);
                c++;
                Adm.Tools.Counters.SetValue(Adm.FotoModule.DataInfo.Foto_ID_Counter, c, Server);
                FileUpload2.SaveAs(Server.MapPath("~/foto/temp/" + c + ".jpg"));
                Adm.Tools.ImageTool.SaveImage(Server.MapPath("~/foto/temp/" + c + ".jpg"), Server.MapPath("~/foto/" + c + "s.jpg"), 160, 95);
                Adm.Tools.ImageTool.SaveImage(Server.MapPath("~/foto/temp/" + c + ".jpg"), Server.MapPath("~/foto/" + c + "b.jpg"), 800, 95);
                Adm.FotoModule.Foto F = new Adm.FotoModule.Foto();
                F.ID = c;
                F.Desk = r.Caption;
                lf.Items.Add(F);
                r.Picture = c;
            }

            Adm.Tools.Xmlwr.WriteToFile(Server.MapPath(Adm.TovarModule.DataInfo.Tovar_FileName), lr);
            Adm.Tools.Xmlwr.WriteToFile(Server.MapPath(Adm.FotoModule.DataInfo.Foto_FileName), lf);


            LoadFotos();
            ListBox1.Items[ListBox1.SelectedIndex].Text = r.Caption;

        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (ListBox1.SelectedIndex > -1)
        {
            Adm.TovarModule.ListTovar lr = Adm.Tools.Xmlwr.ReadFromFile<Adm.TovarModule.ListTovar>(Server.MapPath(Adm.TovarModule.DataInfo.Tovar_FileName));
            Adm.TovarModule.Tovar r = lr.FindByID(int.Parse(ListBox1.SelectedValue));
            Adm.FotoModule.List_Foto lf = Adm.Tools.Xmlwr.ReadFromFile<Adm.FotoModule.List_Foto>(Server.MapPath(Adm.FotoModule.DataInfo.Foto_FileName));

            if (FileUpload1.HasFile)
            {

                int c = Adm.Tools.Counters.GetValue(Adm.FotoModule.DataInfo.Foto_ID_Counter, Server);
                c++;
                Adm.Tools.Counters.SetValue(Adm.FotoModule.DataInfo.Foto_ID_Counter, c, Server);

                FileUpload1.SaveAs(Server.MapPath("~/foto/temp/" + c + ".jpg"));

                Adm.Tools.ImageTool.SaveImage(Server.MapPath("~/foto/temp/" + c + ".jpg"), Server.MapPath("~/foto/" + c.ToString() + "s.jpg"), 160, 95);
                Adm.Tools.ImageTool.SaveImage(Server.MapPath("~/foto/temp/" + c + ".jpg"), Server.MapPath("~/foto/" + c.ToString() + "b.jpg"), 800, 95);
                r.Fotos.Add(c);
                Adm.FotoModule.Foto F = new Adm.FotoModule.Foto();
                F.ID = c;
                lf.Items.Add(F);
                Adm.Tools.Xmlwr.WriteToFile(Server.MapPath(Adm.TovarModule.DataInfo.Tovar_FileName), lr);
                Adm.Tools.Xmlwr.WriteToFile(Server.MapPath(Adm.FotoModule.DataInfo.Foto_FileName), lf);
                LoadFotos();
            }

        }
    }


    protected void Btn_Remove_foto_Click(object sender, EventArgs e)
    {
        Adm.TovarModule.ListTovar lr = Adm.Tools.Xmlwr.ReadFromFile<Adm.TovarModule.ListTovar>(Server.MapPath(Adm.TovarModule.DataInfo.Tovar_FileName));
        Adm.TovarModule.Tovar r = lr.FindByID(int.Parse(ListBox1.SelectedValue));
        Adm.FotoModule.List_Foto lf = Adm.Tools.Xmlwr.ReadFromFile<Adm.FotoModule.List_Foto>(Server.MapPath(Adm.FotoModule.DataInfo.Foto_FileName));

        r.Fotos.Remove(id);

        Adm.FotoModule.Foto F = lf.FindByID(id);

        lf.Items.Remove(F);

        System.IO.File.Delete(Server.MapPath("~/foto/" + id.ToString() + "b.jpg"));
        System.IO.File.Delete(Server.MapPath("~/foto/" + id.ToString() + "s.jpg"));


        Adm.Tools.Xmlwr.WriteToFile(Server.MapPath(Adm.TovarModule.DataInfo.Tovar_FileName), lr);
        Adm.Tools.Xmlwr.WriteToFile(Server.MapPath(Adm.FotoModule.DataInfo.Foto_FileName), lf);
        LoadFotos();


    }
    protected void Save_foto_Click(object sender, EventArgs e)
    {
        Adm.TovarModule.ListTovar lr = Adm.Tools.Xmlwr.ReadFromFile<Adm.TovarModule.ListTovar>(Server.MapPath(Adm.TovarModule.DataInfo.Tovar_FileName));
        Adm.TovarModule.Tovar r = lr.FindByID(int.Parse(ListBox1.SelectedValue));
        Adm.FotoModule.List_Foto lf = Adm.Tools.Xmlwr.ReadFromFile<Adm.FotoModule.List_Foto>(Server.MapPath(Adm.FotoModule.DataInfo.Foto_FileName));

        Panel1.Visible = false;

        Adm.FotoModule.Foto F = lf.FindByID(id);

        F.Desk = TextBox1.Text;

        Adm.Tools.Xmlwr.WriteToFile(Server.MapPath(Adm.FotoModule.DataInfo.Foto_FileName), lf);
        LoadFotos();
    }
}