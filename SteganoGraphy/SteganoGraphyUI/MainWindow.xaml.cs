using SteganoGraphy.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace SteganoGraphyUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SteganoGraphy.Steganography sg = new SteganoGraphy.Steganography();
        private int maxChars;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                sg.WriteMessage(input.Text);
                MessageBox.Show("OK");
                sg.SaveImage(@out.Text);
            }
            catch (NoFileLoadedException)
            {
                MessageBox.Show("Nie załadowano obrazka!");
            }
        }

        private void load(object sender, RoutedEventArgs e)
        {
            if (File.Exists(path.Text))
            {
                try
                {
                    maxChars = sg.LoadImage(path.Text);
                    max.Content = maxChars;
                    MessageBox.Show("OK");
                }
                catch (InvalidFileException)
                {
                    MessageBox.Show("Błąd podczas ładowania pliku");
                }
            }
            else
            {
                MessageBox.Show("Błąd podczas ładowania pliku");
            }

        }

        private void button1_Copy_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                input.Text = sg.ReadMessage(input.Text);
            }
            catch (NoFileLoadedException)
            {
                MessageBox.Show("Nie załadowano obrazka!");
            }
        }

        private void input_KeyDown(object sender, KeyEventArgs e)
        {
            //   current.Content = input.Text.Length;
        }

        private void input_TextChanged(object sender, TextChangedEventArgs e)
        {
            current.Content = input.Text.Length;
        }

        private void out_TextChanged(object sender, TextChangedEventArgs e)
        {
        }
    }
}
