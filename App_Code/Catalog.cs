using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml;
using System.IO;
using System.Collections.Generic;

namespace Adm
{
    namespace TovarModule
    {
        public static class DataInfo
        {
            public static string Tovar_FileName = "~/App_data/data/Tovar.xml";
            public static string Tovar_ID_Counter = "Tovar_ID_Counter";
        }


        /// <summary>
        /// Класс для товара
        /// </summary>
        public class Tovar
        {
            /// <summary>
            /// Уникальный идентификатор
            /// </summary>
            public int ID = 0;
            /// <summary>
            /// Дата добавления
            /// </summary>
            public DateTime Date = DateTime.Now;
            /// <summary>
            /// Картинка
            /// </summary>
            public int Picture = 0;
            /// <summary>
            /// Фото
            /// </summary>
            public List<int> Fotos = new List<int>();
            /// <summary>
            /// Название
            /// </summary>
            public string Caption = "";
            /// <summary>
            /// Основное описание
            /// </summary>
            public string Desc = "";
            /// <summary>
            /// Краткое описание
            /// </summary>
            public string Text = "";
            /// <summary>
            /// Цена
            /// </summary>
            public string Price = "";
            /// <summary>
            /// Количество на складе
            /// </summary>
            public int Kol = 0;
            /// <summary>
            /// Раздел
            /// </summary>
            public int Section = 0;
            /// <summary>
            /// Лог изменений количества товара на складе
            /// </summary>
            public ListItemCollection Change = new ListItemCollection();
        }


        /// <summary>
        /// Класс для списка товаров
        /// </summary>
        public class ListTovar
        {
            public List<Tovar> Items = new List<Tovar>();

            public Tovar FindByID(int id)
            {
                for (int i = 0; i < Items.Count; i++)
                {
                    if (Items[i].ID == id)
                    {
                        return Items[i];
                    }
                }
                return null;
            }
        }

    }
}