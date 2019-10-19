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
using System.Xml.Serialization;
using System.IO;
using System.Collections.Generic;

namespace Adm
{
    namespace NewsModule
    {
        public static class DataInfo
        {
            public static string News_FileName = "~/App_data/Data/News.xml";
            public static string News_ID_Counter = "News_ID_Counter";
        }
        /// <summary>
        /// Класс для одной новости
        /// </summary>
        public class NewsItem
        {
            /// <summary>
            /// Уникальный идентификатор новости
            /// </summary>
            [XmlAttribute]
            public int ID = 0;
            /// <summary>
            /// Дата публикации
            /// </summary>
            [XmlAttribute]
            public DateTime Date = new DateTime();
            /// <summary>
            /// Заголовок новости
            /// </summary>
            public string Title = "";
            /// <summary>
            /// Аннотация
            /// </summary>
            public string Announce = "";
            /// <summary>
            /// Текст
            /// </summary>
            public string Text = "";
            /// <summary>
            /// Заголовок страницы
            /// </summary>
            public string PageTitle = "";
            /// <summary>
            /// Принадлежность разделу. 0 - ресторан, 1 - гостиница, 2 - центр отдыха
            /// </summary>
            public int Section = 0;
        }

        public class List_News
        {
            public List<NewsItem> Items = new List<NewsItem>();

            
            
            public NewsItem FindByID(int id)
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