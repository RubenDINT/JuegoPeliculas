using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace JuegoPeliculas
{
    class DialogService
    {
        private static string archivoSeleccionado;

        public static string ArchivoSeleccionado { get => archivoSeleccionado; set => archivoSeleccionado = value; }

        public static void OpenFileDialogService(string tipoArchivo)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            // Dependiendo del tipo de archivo pasado por parámetros, se permitirá seleccionar un tipo de archivos u otro
            if(tipoArchivo == "json") openFileDialog.Filter = "JSON File (*.json)|*.json";
            if (tipoArchivo == "imagen") openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;";


            bool? resultado = openFileDialog.ShowDialog();

            if (resultado == true)
            {
                archivoSeleccionado = openFileDialog.FileName;
                MessageBoxService($"Archivo {openFileDialog.SafeFileName} cargado");
            }
        }

        public static void SaveFileDialogService()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "JSON File (*.json)|*.json";
            bool? resultado = saveFileDialog.ShowDialog();
            
            if(resultado == true)
            {
                try
                {
                    File.WriteAllText(saveFileDialog.FileName, File.ReadAllText(archivoSeleccionado));
                    MessageBoxService($"Archivo {saveFileDialog.SafeFileName} guardado");
                }
                catch (ArgumentNullException)
                {
                    MessageBoxService("Tienes que cargar un archivo JSON antes", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        public static void MessageBoxService(string mensaje, string titulo, MessageBoxButton boxButton, MessageBoxImage messageBoxImage)
        {
            MessageBox.Show(mensaje, titulo, boxButton, messageBoxImage);
        }

        public static void MessageBoxService(string mensaje)
        {
            MessageBox.Show(mensaje);
        }
    }
}
