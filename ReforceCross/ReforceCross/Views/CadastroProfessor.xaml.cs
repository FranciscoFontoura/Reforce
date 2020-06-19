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

namespace ReforceCross.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CadastroProfessor : ContentPage
    {
        public CadastroProfessor()
        {
            InitializeComponent();
            profDisciplina.Title = "Selecione uma Disciplina";
            List<Disciplinas> disciplinas = new DisciplinasViewModel().LoadList();

            foreach (Disciplinas disciplina in disciplinas)
            {
                profDisciplina.Items.Add(disciplina.NOME);
            }
            profDisponibilidade.Title = "Selecione sua Disponibilidade!";
            var disponibilide = new List<string> { "A", "O", "P" };
            foreach (String disp in disponibilide)
            {
                profDisponibilidade.Items.Add(disp);
            }

        }

        private void btnSalvar_Click(object sender, EventArgs e)
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
                    profFixo.Text,
                    profCel.Text,
                    profMail.Text,
                    (char)profDisciplina.SelectedItem,
                    SqlMoney.Parse(profValor.Text),
                    profUsuario.Text,
                    profSenha.Text,
                    'P'
                    );
                /*public void Cadastrar(DateTime dtcadastro, string nome, string sobrenome, string cep, string rua, string bairro, 
            string cidade,string uf, int numero, string complemento, string fixo, string celular, string mail, char disp, 
            SqlMoney valor, string loginuser, string senha, char tipousuario)*/
            }
            else
            {
                DisplayAlert("As duas senhas são diferentes!", "favor colocar senhas iguais", "OK!");
            }
        }
    }
}