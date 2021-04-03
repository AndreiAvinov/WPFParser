using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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


namespace Lab2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static string file = "data.xlsx";
        public MainWindow()
        {
            
            if (!File.Exists(file))
            {
                using (var client = new WebClient())
                {
                    client.DownloadFile("https://bdu.fstec.ru/files/documents/thrlist.xlsx", file);
                }
            }
            InitializeComponent();
        }

        private void DB_Update_Button_Click(object sender, RoutedEventArgs e)
        {
            var dataFromFile = ExcelParser.GetDataFromFile(file);
            MessageBox.Show(dataFromFile.Count.ToString());
            Data_Table.ItemsSource = new Pagination().PagedTable(dataFromFile).DefaultView;
        }
    }
}
