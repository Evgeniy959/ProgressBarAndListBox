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
            //TextFile.Text = File.ReadAllText(filePath);
            //TextFile.Text = filePath.Length.ToString();
            //var fileByte = filePath.Length.ToString();
            progressBar1.Maximum = filePath.Length;
            int i = 0;
            //foreach (var b in filePath) 
            //while (filePath.Length != 0) 
            while (File.ReadAllBytes(filePath) != null) 
            {
                byte[] bytes = File.ReadAllBytes(filePath);
                i++;
                progressBar1.Value = bytes[i];
                //bytes[i];
            }
            //progressBar1.Value = i;
            TextFile.Text = progressBar1.Value.ToString();


            //var arrByte = File.ReadAllBytes(filePath);
            //path = filePath;

        }
        private void CountText_Click(object sender, RoutedEventArgs e)
        {
            var filePath = OpenFile();
            path = filePath;
            StreamReader inStream = new StreamReader(filePath);
            int i = 0;
            string line = "";
            while ((line = inStream.ReadLine()) != null)
            {
                listBox1.Items.Add(inStream.ReadLine());
                //listBox1.Items.Add(line);
                i++;
                
            }
            /*progressBar1.Maximum = i;
            TextFile.Text = progressBar1.Maximum.ToString();*/
            progressBar1.Value = i;
            TextFile.Text = progressBar1.Value.ToString();
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
            /*if (listBox1.SelectedIndex != -1)
            {
                progressBar1.Value = listBox1.SelectedIndex;
            }*/
            progressBar1.Value = listBox1.SelectedIndex;
        }
    }
}
