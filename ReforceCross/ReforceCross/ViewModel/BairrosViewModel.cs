using Dapper;
using ReforceCross.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ReforceCross.ViewModel
{
    //ViewModel de Bairros, que usa uma lista de bairros.
    class BairrosViewModel
    {
        public List<Bairros> Bairros { get; set; }
        public BairrosViewModel()
        {
            Bairros = new List<Bairros>(LoadList());
        }
        //Busca todos os bairros cadastrados no banco de dados e salva em uma lista .
        public List<Bairros> LoadList()
        {
            List<Bairros> bairros = new List<Bairros>();
            using (IDbConnection connection = new SqlConnection(@"Data Source=DESKTOP-99ATQQ4;Initial Catalog=DBTRABALHO;User Id=sa;Password=1234;"))
            {
                bairros = connection.Query<Bairros>("SELECT DISTINCT BAIRRO FROM PROFESSOR").ToList();
            }
            return bairros;
        }
    }
}
