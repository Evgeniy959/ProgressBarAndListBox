using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private ObservableCollection<string> _list;
        public MainWindow()
        {
            InitializeComponent();
            _list = new ObservableCollection<string>();
            List.ItemsSource = _list;
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            _list.Add(AddText.Text);
        }
        private void List_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_list.Contains(List.SelectedItem))
            {
                AddText.Text = List.SelectedItem.ToString();
                _list.Remove(List.SelectedItem.ToString());                
            }
        }
    }
}
