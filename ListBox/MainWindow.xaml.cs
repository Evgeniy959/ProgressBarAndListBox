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
using System.Xml.Serialization;

namespace ListBox
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<string> list;
        public MainWindow()
        {
            InitializeComponent();
            list = new ObservableCollection<string>();
            ListUsers.ItemsSource = list;
        }
        private void OpenTXTButton_Click(object sender, RoutedEventArgs e)
        {
            list.Clear();
            ExportImport.ImportFromTXTFile(list);
        }
        private void OpenXMLButton_Click(object sender, RoutedEventArgs e)
        {
            list.Clear();
            ExportImport.ImportFromXMLFile(list);
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageInfo;
            string messageBox = "Пользователь уже существует";
            if (!list.Contains(AddText.Text))
            {
                list.Add(AddText.Text);
            }
            else messageInfo = MessageBox.Show(messageBox);
        }
        private void AddTXTButton_Click(object sender, RoutedEventArgs e)
        {
            ExportImport.ExportToTXTFile(list);
        }
        private void AddXMLButton_Click(object sender, RoutedEventArgs e)
        {
            ExportImport.ExportToXMLFile(list);
        }
        private void List_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (list.Contains(ListUsers.SelectedItem))
            {
                AddText.Text = ListUsers.SelectedItem.ToString();
                list.Remove(ListUsers.SelectedItem.ToString());                
            }
        }
    }
}
