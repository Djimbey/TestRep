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
    namespace PagesModule
    {
        public static class DataInfo
        {
            public static string Pages_FileName = "~/App_data/data/Content.xml";
        }

        public class PagesList
        {
            public List<string> Pages = new List<string>();
        }
        
    }
}