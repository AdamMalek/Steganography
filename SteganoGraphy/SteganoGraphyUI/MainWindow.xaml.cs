using System;
using System.Collections.Generic;
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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            sg.LoadImage(path.Text);
            sg.WriteMessage(input.Text);
            sg.SaveImage(@out.Text);
        }

        private void button1_Copy_Click(object sender, RoutedEventArgs e)
        {
            sg.LoadImage(path.Text);
            input.Text = sg.ReadMessage(input.Text);
        }
    }
}
