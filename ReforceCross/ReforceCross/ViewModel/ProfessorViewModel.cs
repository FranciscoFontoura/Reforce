using Dapper;
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
    public class ProfessorViewModel
    {
        public ObservableCollection<Professor> Professor { get; set; }
        public ProfessorViewModel()
        {
            Professor = new ObservableCollection<Professor>(LoadList() as List<Professor>);
        }

        public List<Professor> LoadList()
        {
            List<Professor> professores = new List<Professor>();
            
            using (IDbConnection connection =
                new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=ReforceDB;User Id=sa;Password=123456;"))
            {
                professores = connection.Query<Professor>("SELECT * FROM PROFESSOR P JOIN DISCIPLINASEPROFESSORES DP ON P.IDPROF=DP.IDPROF JOIN DISCIPLINA D ON D.IDMATERIA=DP.IDMATERIA").ToList();

            }
            return professores;
        }

    }
}
