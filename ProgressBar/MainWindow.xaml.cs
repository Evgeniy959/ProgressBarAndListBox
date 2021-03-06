using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace ProgressBar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void CountByte_Click(object sender, RoutedEventArgs e)
        {
            var filePath = OpenFile();
            byte[] bytes = File.ReadAllBytes(filePath);
            TextFile.Text = bytes.Length.ToString();
            ProgressBar1.Value = bytes.Length;
        }
        private void CountText_Click(object sender, RoutedEventArgs e)
        {
            var filePath = OpenFile();
            StreamReader inStream = new StreamReader(filePath);
            int i = 0;
            while (inStream.EndOfStream != true)
            {
                listBox1.Items.Add(inStream.ReadLine());
                i++;
            }
            /*ProgressBar1.Maximum = i;
            TextFile.Text = ProgressBar1.Maximum.ToString();*/
            ProgressBar1.Value = i;            
            TextFile.Text = ProgressBar1.Value.ToString();
            //TextFile.Text = i.ToString();
            //listBox1.SelectedIndex = 0;
        }
        private void CountWord_Click(object sender, RoutedEventArgs e)
        {
            var filePath = OpenFile();
            var str = File.ReadAllText(filePath);
            TextFile1.Text = str;
            string[] textStr = str.Split(' ', '\n');
            TextFile.Text = textStr.Length.ToString();
            ProgressBar1.Value = textStr.Length;
        }
        private string OpenFile()
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files (*.txt)|*.txt";
            return openFileDialog.ShowDialog() == true ? openFileDialog.FileName : string.Empty;
        }
        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            /*if (listBox1.SelectedIndex != -1)
            {
                progressBar1.Value = listBox1.SelectedIndex+1;
            }*/
            ProgressBar1.Value = listBox1.SelectedIndex+1;
            TextFile.Text = listBox1.SelectedItem.ToString();

        }
    }
}
