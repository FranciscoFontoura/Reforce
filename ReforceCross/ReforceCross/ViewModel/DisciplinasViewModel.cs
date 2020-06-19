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
    class DisciplinasViewModel
    {
        public ObservableCollection<Disciplinas> Disciplinas { get; set; }
        public DisciplinasViewModel()

        {
            Disciplinas = new ObservableCollection<Disciplinas>(LoadList() as List<Disciplinas>);
        }
        public List<Disciplinas> LoadList()
        {
            List<Disciplinas> disciplinas = new List<Disciplinas>();

            using (IDbConnection connection =
                new SqlConnection(@"Data Source =.\SQLEXPRESS; Initial Catalog = DBTRABALHO;User Id= sa;Password = 1234"))
            {
                disciplinas = connection.Query<Disciplinas>("SELECT * FROM DISCIPLINAS").ToList();
            }
            return disciplinas;
        }
    }
}
