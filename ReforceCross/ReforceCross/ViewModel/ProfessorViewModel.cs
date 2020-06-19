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
            Professor = new ObservableCollection<Professor>(LoadList("") as List<Professor>);
        }
        public ProfessorViewModel(string query)
        {
            Professor = new ObservableCollection<Professor>(LoadList(query) as List<Professor>);
        }

        public List<Professor> LoadList(string query)
        {
            List<Professor> professores = new List<Professor>();

            if (query == "")
            {
                using (IDbConnection connection = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=DBTRABALHO;User Id=sa;Password=1234;"))
                {
                    professores = connection.Query<Professor>("SELECT * FROM PROFESSOR").ToList();

                }
                return professores;
            }
            else
            {
                using (IDbConnection connection = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=DBTRABALHO;User Id=sa;Password=1234;"))
                {
                    professores = connection.Query<Professor>($"SELECT * FROM PROFESSOR WHERE BAIRRO='{query}'").ToList();

                }
                return professores;
            }

        }

    }
}
