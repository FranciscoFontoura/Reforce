﻿using ReforceCross.Models;
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
    public partial class ProfessorItemDetail : ContentPage
    {
        public ProfessorItemDetail(Professor professor)
        {
            InitializeComponent();
            BindingContext = professor;
        }
    }
}