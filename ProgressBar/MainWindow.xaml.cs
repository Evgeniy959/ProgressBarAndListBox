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
        string path = null;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            var filePath = OpenFile();
            TextFile.Text = File.ReadAllText(filePath);
            path = filePath;
            StreamReader inStream = new StreamReader("filePath");
            int i = 0;
            string line = "";
            while ((line = inStream.ReadLine()) != null)
            {
                listBox1.Items.Add(inStream.ReadLine());
                i++;
            }
            progressBar1.Maximum = i;
            listBox1.SelectedIndex = 0;
        }
        private string OpenFile()
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files (*.txt)|*.txt";
            return openFileDialog.ShowDialog() == true ? openFileDialog.FileName : string.Empty;
        }
        /*private int Count()
        {
            ProgressBar progbar = new ProgressBar();
            progbar.IsIndeterminate = false;
            
        }*/
        

        /*private void button1_Click(object sender, EventArgs e)
        {
            StreamReader inStream = new StreamReader("filePath");
            int i = 0;
            string line = "";
            while ((line = inStream.ReadLine()) != null)
            {
                listBox1.Items.Add(inStream.ReadLine());
                i++;
            }
            progressBar1.Maximum = i;
            listBox1.SelectedIndex = 0;
        }*/

        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                progressBar1.Value = listBox1.SelectedIndex;
            }
        }
    }
}
