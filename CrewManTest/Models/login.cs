using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CrewManTest.Models
{
    public class login
    {
             
        [Required (ErrorMessage = "* Introduza o utilizador")]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "* Introduza a password")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]

        public string Password { get; set; }

        public static bool IsValid(string p1, string p2)
        {
            using (var cn = new SqlConnection(Models.SQLHelper.ConnectionString))
            {
                string _sql = @"SELECT [Username] FROM [dbo].UserLogin " +
                       @"WHERE [Username] = @u AND [Password] = @p";
                string pass;
                pass = Helpers.SHA1.Encode(p2.ToString());
                var parameters = new[]
                  {
                        new SqlParameter("@u",p1.ToString()),
                        new SqlParameter("@p",pass)
                        
                    };

                var reader = Models.SQLHelper.ExecuteReader(cn, System.Data.CommandType.Text, _sql, parameters);
                
                if (reader.HasRows)
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
