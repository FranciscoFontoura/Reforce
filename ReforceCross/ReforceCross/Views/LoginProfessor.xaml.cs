using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ReforceCross.Models;

namespace ReforceCross.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginProfessor : ContentPage
    {
        public LoginProfessor()
        {
            InitializeComponent();
            string senha = User.ToString();
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CadastroProfessor());
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }
    }
}

