using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CrewManTest.Models
{
    public class crew
    {
        public int Num { get; set; }
        public string Nome { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { set; get; }
        public DataTable Dtb { set; get; }


        public static DataTable GetStoreProcLetter(string p1)
        {   
            
            using (var cn = new SqlConnection(Models.SQLHelper.ConnectionString))
            {
                string StoreName = "SP_CrewList_ByLetter";
                
                var parameters = new[]
                  {
                        new SqlParameter("@letra",p1)
               
                  };
                var ds = Models.SQLHelper.ExecuteStorePrc(cn, StoreName, parameters);
               DataTable Dtb = ds.Tables[0];
                return Dtb;
                
               
            }

        }
        public static DataTable GetStoreProcSearch(string p1)
        {

            using (var cn = new SqlConnection(Models.SQLHelper.ConnectionString))
            {
                string StoreName = "SP_CrewList_search";

                var parameters = new[]
                  {
                        new SqlParameter("@nome",p1)

                  };
                var ds = Models.SQLHelper.ExecuteStorePrc(cn, StoreName, parameters);
                DataTable Dtb = ds.Tables[0];
                return Dtb;


            }

        }

    }
}
