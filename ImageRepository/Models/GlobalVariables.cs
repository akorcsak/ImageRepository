namespace OriginalCardGen.Models
{
    public static class GlobalVariables
    {
        private static string sql_conn_str = "Data Source=SQL;Initial Catalog=ShopifyImageRepository;User ID=sa;Password=superior";

        public static string deployedPathFiles = getSetting("DeployedAppName");

        public static string logging = getSetting("Logging");

        public static bool sessionStatus = false;

        public static bool isDebug = false;

        public static bool isSeshActive
        {
            get { return sessionStatus; }
            set { sessionStatus = value; }
        }

        public static string getSetting(string key)
        {
            return System.Configuration.ConfigurationManager.AppSettings.Get(key);
        }

    public static string sqlConnStr
        {
            get { return sql_conn_str; }
        }


        private static string ID_fname = "none";

        private static string ID_lname = "none";

        public static string idFirstName
        {
            get { return ID_fname; }
            set { ID_fname = value; }
        }

        public static string idLastName
        {
            get { return ID_lname; }
            set { ID_lname = value; }
        }

        private static string address = " ";
        public static string ID_address
        {
            get { return address; }
            set { address = value;  }
        }


        public static string user = "";

        public static string userName
        {
            get { return user; }
            set { user = value; }
        }

    }
}