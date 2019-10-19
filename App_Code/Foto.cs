using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;

namespace Adm
{
    namespace FotoModule
    {
        public static class DataInfo
        {
            public static string FotoRazdel_FileName = "~/App_data/data/FotoRazdel.xml";

            public static string Foto_FileName = "~/App_data/data/Foto.xml";

            public static string FotoRazdel_ID_Counter = "FotoRazdel_ID_Counter";

            public static string Foto_ID_Counter = "Foto_ID_Counter";
        }
        /// <summary>
        /// Одна группа
        /// </summary>
        public class Foto
        {
            public int ID = 0;
            
            public string Desk = "";
        }

        public class FotoRazdel
        {
            public List<int> Items = new List<int>();

            public int ID = 0;

            public string Name = "";

            public string Desk = "";
        }

        public class List_FotoRazdel
        {
            public List<FotoRazdel> Items = new List<FotoRazdel>();

            public FotoRazdel FindByID(int id)
            {
                for (int i = 0; i < Items.Count; i++)
                {
                    if (Items[i].ID == id)
                    {
                        return Items[i];
                    }
                }
                return new FotoRazdel();
            }
        }

        public class List_Foto
        {
            public List<Foto> Items = new List<Foto>();

            public Foto FindByID(int id)
            {
                for (int i = 0; i < Items.Count; i++)
                {
                    if (Items[i].ID == id)
                    {
                        return Items[i];
                    }
                }
                return new Foto();
            }
        }
    }
}