using Dapper;
using ReforceCross.Controllers;
using ReforceCross.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace ReforceCross.ViewModel
{
    //ViewModel disciplinas, que usa uma lista  de disciplias.
    class DisciplinasViewModel
    {
        public ObservableCollection<Disciplinas> Disciplinas { get; set; }
        public DisciplinasViewModel()

        {
            Disciplinas = new ObservableCollection<Disciplinas>(LoadList() as List<Disciplinas>);
        }
        //Busca todas as disciplinas cadastradas no banco de dados e salva em uma lista .
        public List<Disciplinas> LoadList()
        {
            List<Disciplinas> disciplinas = new List<Disciplinas>();

            using (IDbConnection connection =
                new SqlConnection(@"Data Source =DESKTOP-99ATQQ4; Initial Catalog = DBTRABALHO;User Id= sa;Password = 1234"))
            {
                disciplinas = connection.Query<Disciplinas>("SELECT * FROM DISCIPLINAS").ToList();
            }
            return disciplinas;
        }
    }
}
