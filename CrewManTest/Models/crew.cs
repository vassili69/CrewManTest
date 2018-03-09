using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CrewManTest.Models
{
    public class crew
    {
        public int Num { get; set; }
        public string Nome { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { set; get; }


        public static void GetStoreProc(string p1)
        {   
            
            using (var cn = new SqlConnection(Models.SQLHelper.ConnectionString))
            {
                string StoreName = "SP_CrewList_ByLetter";
                
                var parameters = new[]
                  {
                        new SqlParameter("@letra",p1)
               
                  };

                var reader = Models.SQLHelper.ExecuteStorePrc(cn,StoreName,parameters);
                
               /* if (reader.HasRows)
                {
                    return "a";
                }
                else
                {
                  return "b";
                }*/
            }

        }
                        
    }
}
