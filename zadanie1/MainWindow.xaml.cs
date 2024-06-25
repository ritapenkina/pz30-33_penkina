using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace pz1_penkina
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            txtEditor.MouseDoubleClick += TxtEditor_MouseDoubleClick;
        }

        private void TxtEditor_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Text files (*.txt)|*.txt",
                DefaultExt = "txt",
                RestoreDirectory = true
            };

            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                string fileText = File.ReadAllText(filePath);
                txtEditor.Text = fileText;
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Text files (*.txt)|*.txt",
                DefaultExt = "txt",
                RestoreDirectory = true
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                string filePath = saveFileDialog.FileName;
                File.WriteAllText(filePath, txtEditor.Text);
            }
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            txtEditor.Text = string.Empty;
        }
    }
}

