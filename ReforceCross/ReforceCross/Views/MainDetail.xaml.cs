﻿using ReforceCross.Models;
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

            picker_bairros.Title = "Selecione um Bairro";
            List<Bairros> bairros = new BairrosViewModel().LoadList();
            foreach (Bairros bairro in bairros)
            {
                picker_bairros.Items.Add(bairro.BAIRRO);
            }
        }

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

        private void picker_bairros_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindingContext = new ProfessorViewModel(picker_bairros.SelectedItem.ToString());
        }
    }
}