﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace ReforceCross.Controllers
{//Classe para realizar uma conexão com o banco.
    class ConexaoSql
    {
        SqlConnection con = new SqlConnection();
        
        public ConexaoSql()
        {
            con.ConnectionString = @"Data Source =DESKTOP-99ATQQ4; Initial Catalog = DBTRABALHO;user= sa;password = 1234";
        }
        //Método para execução de query
        public void ExercutarComandoSQL(SqlCommand sqlCommand)
        {
            con.Open();
            sqlCommand.Connection = con;
            sqlCommand.ExecuteNonQuery();
            con.Close();
        }
    }
}
