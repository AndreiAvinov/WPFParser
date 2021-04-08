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
                
                MessageBoxResult result = MessageBox.Show("Локальная база угоз не обнаружена, загрузить?", "Предупреждение", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    var dangersList = GetFromWeb();
                    SaveToLocal(dangersList);
                    return dangersList;
                }
                else
                {
                    return null;
                }
            }
            return GetFromLocal();
        }

        public static List<CyberDanger> GetWithChanges(List<CyberDanger> cyberDangersOld)
        {
            var cyberDangersNew = GetFromWeb();
            SaveToLocal(cyberDangersNew);
            cyberDangersNew = GetFromLocal();
            var added = new List<string>();
            var deleted = new List<string>();
            foreach (var danger in cyberDangersOld)
            {
                if (!cyberDangersNew.Contains(danger))
                {
                    deleted.Add(danger.ToShortString());
                }
            }
            foreach (var danger in cyberDangersNew)
            {
                if (!cyberDangersOld.Contains(danger))
                {
                    added.Add(danger.ToShortString());
                }
            }
            if (added.Count == 0 && deleted.Count == 0)
            {
                MessageBox.Show("Никаких изменений не обнаружено");
                return cyberDangersOld;
            }
            MessageBoxResult result = MessageBox.Show("База успешно обновлена, показать изменения?", "Успешное обновление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                ChangesWindow changesWindow = new ChangesWindow(added, deleted);
                changesWindow.Show();
            }
            return cyberDangersNew;
        }

        private static void SaveToLocal(List<CyberDanger> dangersList)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<CyberDanger>));
            using (StreamWriter writer = new StreamWriter(localFilePath))
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
            Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DangersParser"));
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
            return list;
        }
    }
}
