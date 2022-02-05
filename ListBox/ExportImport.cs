using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ListBox
{
    public class ExportImport
    {
        public static void ExportToTXTFile(ObservableCollection<string> list)
        {
            var path = OpenFile();
            using var file = new StreamWriter(path, append: false);
            foreach (var item in list)
                file.WriteLine(item);
        }
        public static ObservableCollection<string> ImportFromTXTFile(ObservableCollection<string> list)
        {
            var path = OpenFile();
            using var file = new StreamReader(path);
            while (file.EndOfStream != true) 
            {
                list.Add(file.ReadLine());
            }
            return list;
        }
        public static void ExportToXMLFile(ObservableCollection<string> list)
        {
            var path = OpenFileXML();
            using var file = new StreamWriter(path, append: false);
            var xml = new XmlSerializer(list.GetType());
            xml.Serialize(file, list);

        }
        public static ObservableCollection<string> ImportFromXMLFile(ObservableCollection<string> list)
        {
            var path = OpenFileXML();
            using var file = new StreamReader(path);
            var xml = new XmlSerializer(list.GetType());
            var listXml = (ObservableCollection<string>)xml.Deserialize(file);
            foreach (var item in listXml)
            {
                list.Add(item);
            }
            return list;
        }
        public static string OpenFile()
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files (*.txt)|*.txt";
            return openFileDialog.ShowDialog() == true ? openFileDialog.FileName : string.Empty;
        }
        public static string OpenFileXML()
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Xml Files (*.xml)|*.xml";
            return openFileDialog.ShowDialog() == true ? openFileDialog.FileName : string.Empty;
        }
    }
}
