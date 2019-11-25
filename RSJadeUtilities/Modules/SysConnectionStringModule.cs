using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace RSJadeUtilities.Modules
{
    class SysConnectionStringModule
    {
        // =====================
        // Get Connection String 
        // =====================
        public static String GetConnectionString()
        {
            String path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"SysConnectionString.json");

            String json;
            using (StreamReader trmRead = new StreamReader(path)) { json = trmRead.ReadToEnd(); }

            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            Models.SysConnectionStringModel sysConnectionStringEntity = javaScriptSerializer.Deserialize<Models.SysConnectionStringModel>(json);

            String connectionString = sysConnectionStringEntity.ConnectionString;

            return connectionString;
        }
    }
}
