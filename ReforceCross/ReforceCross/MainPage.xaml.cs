using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ReforceCross.Views;

namespace ReforceCross
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            
        }
        //navega para a pagina de login do professor
        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginProfessor());
        }
        //navega para a pagina de lista de professores
        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Main());
        }
    }
}
