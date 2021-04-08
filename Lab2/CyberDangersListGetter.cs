using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;

namespace Lab2
{
    static class CyberDangersListGetter
    {
        public static string FileURI { get; set; } = "https://bdu.fstec.ru/files/documents/thrlist.xlsx";
        private static string localFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"DangersParser\cached.xml");
        private static string localDBPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"DangersParser\db.xlsx");

        public static List<CyberDanger> Get()
        {
            if (!File.Exists(localFilePath))
            {
                Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DangersParser"));
                MessageBoxResult result = MessageBox.Show("Локальная база угоз не обнаружена, загрузить?", "Предупреждение", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    return GetFromWeb();
                }
                else
                {
                    return null;
                }
            }
            return GetFromLocal();
        }

        private static void SaveToLocal(List<CyberDanger> dangersList)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<CyberDanger>));
            using (TextWriter writer = new StreamWriter(localFilePath))
            {
                serializer.Serialize(writer, dangersList);
            }
        }

        private static List<CyberDanger> GetFromLocal()
        {
            List<CyberDanger> resList;
            XmlSerializer serializer = new XmlSerializer(typeof(List<CyberDanger>));
            using(FileStream fs = new FileStream(localFilePath, FileMode.Open))
            {   
                resList = (List<CyberDanger>)serializer.Deserialize(fs);
            }
            return resList;
        }

        private static List<CyberDanger> GetFromWeb()
        {
            using (var client = new WebClient())
            {
                try
                {
                    client.DownloadFile(FileURI, localDBPath);
                }
                catch (WebException)
                {
                    MessageBoxResult result = MessageBox.Show("Файл не доступен, попробовать ещё раз?", "Ошибка", MessageBoxButton.YesNo, MessageBoxImage.Error);
                    if (result == MessageBoxResult.Yes)
                    {
                        return GetFromWeb();
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            var list = ExcelParser.GetDataFromFile(localDBPath);
            SaveToLocal(list);
            return list;
        }
    }
}
