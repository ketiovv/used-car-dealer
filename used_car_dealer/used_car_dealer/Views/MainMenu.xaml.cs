﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using used_car_dealer.ViewModels;

namespace used_car_dealer.Views
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu: UserControl
    {
        public MainMenu(MainMenuViewModel mainMenuViewModel)
        {
            InitializeComponent();
            DataContext = mainMenuViewModel;
        }
    }
}
