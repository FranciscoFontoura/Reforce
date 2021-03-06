﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ReforceCross.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainMaster : ContentPage
    {
        public ListView ListView;

        public MainMaster()
        {
            InitializeComponent();

            BindingContext = new MainMasterViewModel();
            ListView = MenuItemsListView;
        }

        class MainMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MainMasterMenuItem> MenuItems { get; set; }

            public MainMasterViewModel()
            {
                MenuItems = new ObservableCollection<MainMasterMenuItem>(new[]
                {
                    new MainMasterMenuItem { Id = 0, Title = "Page 1" },
                    new MainMasterMenuItem { Id = 1, Title = "Page 2" },
                    new MainMasterMenuItem { Id = 2, Title = "Page 3" },
                    new MainMasterMenuItem { Id = 3, Title = "Page 4" },
                    new MainMasterMenuItem { Id = 4, Title = "Voltar a página principal" },
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}