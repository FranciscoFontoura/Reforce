using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ReforceCross.Models;
using System.Data;
using Dapper;
using System.Net.Mail;

namespace ReforceCross.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginProfessor : ContentPage
    {
        public LoginProfessor()
        {
            InitializeComponent();

        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CadastroProfessor());
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            List<Usuarios> usuario = new List<Usuarios>();
            if (User.Text == null)
            {
                await DisplayAlert("usuario invalido", "favor inserir usuario", "ok");
            }
            else
            {
                using (IDbConnection connection = new SqlConnection(@"Data Source =DESKTOP-99ATQQ4; Initial Catalog = DBTRABALHO;User Id= sa;Password = 1234"))
                {
                    usuario = connection.Query<Usuarios>($"SELECT * FROM USUARIO WHERE LOGINUSER='{User.Text}'").ToList();
                }
                if (usuario[0].SENHA == Password.Text)
                {
                    await Navigation.PushAsync(new PerfilProfessor(usuario[0]));
                }
                else
                {
                    await DisplayAlert("Senha ou usuário errado!", "favor tentar novamente", "ok!");
                }
            }

        }
    }
}

