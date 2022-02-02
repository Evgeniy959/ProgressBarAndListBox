using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace ListBox
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<string> _list;
        public MainWindow()
        {
            InitializeComponent();
            _list = new ObservableCollection<string>();
            List.ItemsSource = _list;
        }
        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            var path = OpenFile();
            //StreamReader file = new StreamReader(path);
            using var file = new StreamReader(path);
            /*string line;
            while ((line = file.ReadLine()) != null)*/
            while (file.EndOfStream != true)
            {
                _list.Add(file.ReadLine());
            }
            //ExportImport.ImportToTXTFile(List.Items);
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            //string str = null;
            MessageBoxResult messageInfo;
            string messageBox = "Пользователь уже существует";
            if (!_list.Contains(AddText.Text))
            {
                _list.Add(AddText.Text);
                //ExportImport.ExportToTXTFile(AddText.Text);
                //ExportImport.ExportToTXTFile(_list.Contains));
                //ExportImport.ExportToTXTFile(_list.ToString());

                //var path = "NEW.txt";
                var path = OpenFile();
                using var file = new StreamWriter(path, append: false);
                foreach (var item in _list)
                    file.WriteLine(item);
            }
            else messageInfo = MessageBox.Show(messageBox);
        }
        private void List_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_list.Contains(List.SelectedItem))
            {
                AddText.Text = List.SelectedItem.ToString();
                _list.Remove(List.SelectedItem.ToString());                
            }
        }
        //public static string ImportToTXTFile(string path )
        /*public static string ImportToTXTFile()
        {
            var path = OpenFile();
            //path = OpenFile();
            using var file = new StreamReader(path);
            //string str = File.ReadAllText(path);
            //string[] str = File.ReadAllLines(path);
            //string str = null;
            while (file.EndOfStream != true)
            {
                str = file.ReadLine();
                //return str;
            }
            //str = file.ReadLine();
            //str = File.ReadAllText(path);
            return str;
        }*/
        private string OpenFile()
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files (*.txt)|*.txt";
            return openFileDialog.ShowDialog() == true ? openFileDialog.FileName : string.Empty;
        }
    }
}
