﻿using DataTemplate.Models;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DataTemplate;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public Person PersonProperty { get; set; }

    public MainWindow()
    {
        InitializeComponent();

        PersonProperty = new()
        {
            FirstName = "Virat",
            LastName = "Kohli",
            Profession = "Cricketer"
        };

        this.DataContext = this;
    }
}