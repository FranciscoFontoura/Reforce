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
    class BairrosViewModel
    {
        public List<Bairros> Bairros { get; set; }

        public BairrosViewModel()
        {
            Bairros = new List<Bairros>(LoadList());
        }
        //carrega e retorna a lista e bairros unicos da tabela de professores do bd
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
