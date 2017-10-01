using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRMSystem.DAL
{
    public class Connection
    {
        public static string ConnectionString
        {
            get
            {
                return "Server=DESKTOP-PVFC580\\SQLEXPRESS;Database=CentiSoftCRM;Integrated Security=SSPI;";
            }
        }

    }
}