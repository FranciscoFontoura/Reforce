using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Internals;
using ReforceCross.Controllers;
using ReforceCross.ViewModel;
using ReforceCross.Models;
using System.Security.Cryptography.X509Certificates;
using Dapper;
using System.Data;

namespace ReforceCross.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
   
    public partial class CadastroProfessor : ContentPage
    {
        //No construtor eu carrego as disciplinas em um picker, para seleção do usuário.
        public CadastroProfessor()
        {
            InitializeComponent();

            profDisciplina.Title = "Selecione uma Disciplina";
            List<Disciplinas> disciplinas = new DisciplinasViewModel().LoadList();

            foreach (Disciplinas disciplina in disciplinas)
            {
                profDisciplina.Items.Add(disciplina.NOME);
            }

        }
//Ação do clique do botão de cadastro passando todos os dados inseridos pelo usuário.
        private async void btnSalvar_Click(object sender, EventArgs e)
        {
            if (profSenha.Text == profSenhaConfirm.Text)
            {
                Cadastro cad = new Cadastro();
                cad.Cadastrar(
                    DateTime.Now,
                    profNome.Text,
                    profSobrenome.Text,
                    profCep.Text,
                    profRua.Text,
                    profBairro.Text,
                    profCidade.Text,
                    profUf.Text,
                    int.Parse(profNumero.Text),
                    profComplemento.Text,
                    profMail.Text,
                    profFixo.Text,
                    profCel.Text,
                    SqlMoney.Parse(profValor.Text),
                    profUsuario.Text,
                    profSenha.Text,
                    GetIdMateria(),
                    'P'
                    ); ;
                DisplayAlert("Cadastro Concluido Com Sucesso", "Obrigado", "!");
                await Navigation.PushAsync(new MainPage());

            }
            else
            {
                DisplayAlert("As duas senhas são diferentes!", "favor colocar senhas iguais", "OK!");
            }
        }

        //Método que busca a ID da matéria, para que eu possa passar no cadastro.
        private int GetIdMateria()
        {
            List<int> id = new List<int>();
            using (IDbConnection connection = new SqlConnection(@"Data Source=DESKTOP-99ATQQ4;Initial Catalog=DBTRABALHO;User Id=sa;Password=1234;"))
            {
                id = connection.Query<int>($"SELECT ID FROM DISCIPLINAS WHERE NOME = '{profDisciplina.SelectedItem}'").AsList();

                int a = 0;
                foreach (int x in id)
                {
                    a = x;
                }
                return a;
            }
        }
    }
}