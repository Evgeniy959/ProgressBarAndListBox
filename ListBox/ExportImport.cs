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
        public static void ExportToTXTFile(string str)
        {
            var list = new MainWindow();
            var path = OpenFile();
            using var file = new StreamWriter(path, append: true);
            foreach (var item in list._list)
                file.WriteLine(item);
        }
        //public static string ImportToTXTFile(string path )
        /*public static string ImportToTXTFile(string str)
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
        //public static void ExportToXMLFile(ObservableCollection<Student> students, string path)
        /*public static void ExportToXMLFile(string str, string path)
        {
            using var file = new StreamWriter(path, append: false);
            var xml = new XmlSerializer(str.GetType());
            xml.Serialize(file, str);

        }
        //public static ObservableCollection<Student> ImportFromXMLFile(string path)
        public static string ImportFromXMLFile(string path)
        {
            using var file = new StreamReader(path);
            var xml = new XmlSerializer(typeof(string));
            return (string)xml.Deserialize(file);
        }*/
        public static string OpenFile()
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files (*.txt)|*.txt";
            return openFileDialog.ShowDialog() == true ? openFileDialog.FileName : string.Empty;
        }
    }
}
