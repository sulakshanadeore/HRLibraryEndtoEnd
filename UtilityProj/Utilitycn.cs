using Microsoft.Data.SqlClient;

namespace UtilityProj
{
    public static class Utilitycn
    {
        static Utilitycn()
         {
           _cn = "Data Source=.\\sqlexpress;Initial Catalog=EndToEndProj;Integrated Security=True;Trust Server Certificate=True";
        }
        private static string _cn=null;
        public  static  string cnString
        {
            get { return _cn; }
            private set
            {
                _cn=value;  
            }
        }

        public static SqlConnection ReturnCn() 
        {
            SqlConnection cn=new SqlConnection(cnString);
            return cn;
        
        }

    }
}

