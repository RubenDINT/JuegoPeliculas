﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
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

namespace JuegoPeliculas
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PeliculasVM peliculasVM;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void VerPistaCheckbox_Click(object sender, RoutedEventArgs e)
        {
            PistaTextBlock.Visibility = Visibility.Visible;
        }

        private void SeleccionarJsonButton_Click(object sender, RoutedEventArgs e)
        {
            DialogService.OpenFileDialogService();
            // Movido del constructor de MainWindow
            peliculasVM = new PeliculasVM();
            this.DataContext = peliculasVM;
        }

        private void GuardarJsonButton_Click(object sender, RoutedEventArgs e)
        {
            DialogService.SaveFileDialogService();
        }

        private void AñadirPeliculaButton_Click(object sender, RoutedEventArgs e)
        {
            // Se haría aquí??
            try
            {
                peliculasVM.ListaPeliculas.Add(new Pelicula(TituloTextBox.Text, PistaTextBox.Text, ImagenTextBox.Text,
                                                            DificultadComboBox.SelectedItem.ToString(), 
                                                            GenerosComboBox.SelectedItem.ToString()));
            }
            catch (NullReferenceException ex)
            {
                DialogService.MessageBoxService("Tienes que rellenar todos los campos para añadir una película", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
