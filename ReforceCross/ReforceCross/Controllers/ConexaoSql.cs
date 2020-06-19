using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace ReforceCross.Controllers
{
    class ConexaoSql
    {
        SqlConnection con = new SqlConnection();

        public ConexaoSql()
        {
            con.ConnectionString = @"Data Source =.\SQLEXPRESS; Initial Catalog = DBTRABALHO;user= sa;password = 1234";
        }
        //metodo da classe que abre a conexão executa a query passada por parametro, depois fecha a conexão sql
        public void ExercutarComandoSQL(SqlCommand sqlCommand)
        {
            con.Open();
            sqlCommand.Connection = con;
            sqlCommand.ExecuteNonQuery();
            con.Close();
        }
    }
}
