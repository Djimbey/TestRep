using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;

namespace Adm
{
    namespace SectionModule
    {
        public static class DataInfo
        {
            public static string Section_FileName = "~/App_data/data/Sections.xml";
        }
        /// <summary>
        /// Одна группа
        /// </summary>
        public class Section
        {
            public int ID = 0;
            
            public string Caption = "";
        }


        public class Sections
        {
            public List<Section> Items = new List<Section>();

            public Section FindByID(int id)
            {
                for (int i = 0; i < Items.Count; i++)
                {
                    if (Items[i].ID == id)
                    {
                        return Items[i];
                    }
                }
                return new Section();
            }
        }
    }
}