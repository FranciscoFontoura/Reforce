using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ReforceCross.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Main : MasterDetailPage
    {
        public Main()
        {
            InitializeComponent();
            MasterPage.ListView.ItemSelected += ListView_ItemSelected;
        }
        //evento do clique na lista do menu hamburguer, volta para pagina principal
        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}