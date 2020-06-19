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

        public List<Bairros> LoadList()
        {
            List<Bairros> bairros = new List<Bairros>();
            using (IDbConnection connection = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=ReforceDB;User Id=sa;Password=123456;"))
            {
                bairros = connection.Query<Bairros>("SELECT DISTINCT BAIRRO FROM PROFESSOR").ToList();
            }
            return bairros;
        }
    }
}
