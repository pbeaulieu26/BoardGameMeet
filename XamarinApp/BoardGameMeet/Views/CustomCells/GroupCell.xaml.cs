﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BoardGameMeet.Views.CustomCells
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GroupCell : ViewCell
    {
        public GroupCell()
        {
            InitializeComponent();
        }
    }
}