using ReforceCross.Models;
using ReforceCross.ViewModel;
using System.Collections.ObjectModel;
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
    public partial class MainDetail : ContentPage
    {
        public ListView ListView;
        public MainDetail()
        {
            InitializeComponent();



            BindingContext = new ProfessorViewModel();

            ListView = profContatos;

            //popula o picker com resultados da query de bairros unicos do bd
            picker_bairros.Title = "Selecione um Bairro";
            List<Bairros> bairros = new BairrosViewModel().LoadList();
            foreach (Bairros bairro in bairros)
            {
                picker_bairros.Items.Add(bairro.BAIRRO);
            }
        }
        //envia objeto professor para a view professoritemdetail para binding na proxima view (envia o objeto como parametro da nova pagina)
        private async void profContatos_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Professor professor = e.Item as Professor;
            if (professor == null)
            {
                return;
            }
            ListView.SelectedItem = null;
            await Navigation.PushAsync(new ProfessorItemDetail(professor));
        }

        //atualiza o bindingcontext da pagina baseado na opção selecionada no picker (professorviewmodel com a sobrecarga string)
        private void picker_bairros_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindingContext = new ProfessorViewModel(picker_bairros.SelectedItem.ToString());
        }
    }
}