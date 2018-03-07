using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CrewManTest.Models
{
    public class Tripulante
    {
        public int Num { get; set; }
        public string Nome { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { set; get; }

        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        public static bool IsValid(string _username, string _password)
        {
            using (var cn = new SqlConnection(Models.SQLHelper.ConnectionString))
            {
                string _sql = @"SELECT [Username] FROM [dbo].UserLogin " +
                       @"WHERE [Username] = @u AND [Password] = @p";
                
                var parameters = new[]
                  {
                        new SqlParameter("@u",_username),
                        new SqlParameter("@p", Helpers.SHA1.Encode(_password))
                        
                    };

                int result = Models.SQLHelper.ExecuteNonQuery(cn, _sql, parameters);
                
                if (result>0)
                {
                    return true;
                }
                else
                {
                  return false;
                }
            }
        }



    }



}
