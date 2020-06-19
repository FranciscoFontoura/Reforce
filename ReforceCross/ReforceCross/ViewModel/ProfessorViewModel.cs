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
        //primeiro construtor, sem parametros, para criar lista de todos os professores
        public ProfessorViewModel()
        {
            Professor = new ObservableCollection<Professor>(LoadList("") as List<Professor>);
        }
        //segundo construtor, com sobrecarga string que cria a lista de professores filtradas por bairro
        public ProfessorViewModel(string query)
        {
            Professor = new ObservableCollection<Professor>(LoadList(query) as List<Professor>);
        }
        //metodo que retorna lista de professores baseada na query feita sob a lista de bairros
        public List<Professor> LoadList(string query)
        {
            List<Professor> professores = new List<Professor>();

            if (query == "")
            {
                using (IDbConnection connection = new SqlConnection(@"Data Source=DESKTOP-99ATQQ4;Initial Catalog=DBTRABALHO;User Id=sa;Password=1234;"))
                {
                    professores = connection.Query<Professor>("SELECT P.*,D.NOME AS DISCIPLINA FROM PROFESSOR P JOIN DISCIPLINASEPROFESSORES DP ON P.ID = DP.IDPROF JOIN DISCIPLINAS D ON DP.IDMATERIA = D.ID; ").ToList();

                }
                return professores;
            }
            else
            {
                using (IDbConnection connection = new SqlConnection(@"Data Source =DESKTOP-99ATQQ4; Initial Catalog = DBTRABALHO;User Id= sa;Password = 1234"))
                {
                    professores = connection.Query<Professor>($"SELECT P.*,D.NOME AS DISCIPLINA FROM PROFESSOR P JOIN DISCIPLINASEPROFESSORES DP ON P.ID = DP.IDPROF JOIN DISCIPLINAS D ON DP.IDMATERIA = D.ID WHERE BAIRRO = '{query}'").ToList();

                }
                return professores;
            }

        }

    }
}
