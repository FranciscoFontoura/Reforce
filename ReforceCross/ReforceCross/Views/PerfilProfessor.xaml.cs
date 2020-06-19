using Dapper;
using ReforceCross.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ReforceCross.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PerfilProfessor : ContentPage
    {
        public PerfilProfessor(Usuarios usuarios)
        {
            InitializeComponent();
            List<Professor> professor = new List<Professor>();

            using (IDbConnection connection = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=DBTRABALHO;User Id=sa;Password=1234;"))
            {
                professor = connection.Query<Professor>($"SELECT * FROM PROFESSOR WHERE ID='{usuarios.IDPROF}'").ToList();
            }

            BindingContext = professor[0];
        }
    }
}