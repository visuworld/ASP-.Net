using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using JeecUp.Models;

namespace JeecUp.DAL
{
    public class DbLayer : DbContext
    {
        public DbLayer() : base("Conn")
        { }

        SqlConnection dbcon;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["Conn"].ToString();
            dbcon = new SqlConnection(constring);
        }

        // Calling Db Proc Start 

        public RegisterModel InsertData_Regform(RegisterModel model)
        {
            var SqlParams = new SqlParameter[]
            {
                new SqlParameter{ParameterName="@name",Value=model.name},
                new SqlParameter{ParameterName="@fathername",Value=model.fathername},
                new SqlParameter{ParameterName="@mothername",Value=model.mothername},
                new SqlParameter{ParameterName="@dob",Value=model.dob},
                new SqlParameter{ParameterName="@gender",Value=model.gender},
                new SqlParameter{ParameterName="@mobile",Value=model.mobile},
                new SqlParameter{ParameterName="@email",Value=model.email},
                new SqlParameter{ParameterName="@password",Value=model.password},
                new SqlParameter{ParameterName="@confirmpassword",Value=model.confirmpassword},
            };

            var proc = @"Proc_InsertData @name,@fathername,@mothername,@dob,@gender,@mobile,@email,@password,@confirmpassword";
            var list = this.Database.SqlQuery<RegisterModel>(proc, SqlParams).ToList().FirstOrDefault();
            return list;
        
        }                                      

    }
}