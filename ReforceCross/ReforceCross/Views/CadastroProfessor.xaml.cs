using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Internals;

namespace ReforceCross.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CadastroProfessor : ContentPage
    {
        public CadastroProfessor()
        {
            InitializeComponent();
            profDisciplina.Title = "Selecione uma Disciplina";
            var disciplinas = new List<string> { "Matematica","História","Portugues","Física"};
            foreach (String disciplina in disciplinas)
            {
                profDisciplina.Items.Add(disciplina);
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (profSenha.Text == profSenhaConfirm.Text)
            {
                SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=ReforceDB;User Id=sa;Password=123456;");

                string SQL = "INSERT INTO Professor (nome, disciplina, bairro, usuario, senha) values (@nome, @disciplina, @bairro, @usuario, @senha)";

                SqlCommand c = new SqlCommand(SQL, conn);

                c.Parameters.AddWithValue("@nome", profNome.Text);
                c.Parameters.AddWithValue("@disciplina", profDisciplina.SelectedIndex);
                c.Parameters.AddWithValue("@bairro", profBairro.Text);
                c.Parameters.AddWithValue("@usuario", profUsuario.Text);
                c.Parameters.AddWithValue("@senha", profSenha.Text);

                conn.Open();
                c.ExecuteNonQuery();
                conn.Close();
                
            }
            else
            {
                DisplayAlert("As duas senhas são diferentes!","favor colocar senhas iguais","OK!");
            }
        }
    }
}