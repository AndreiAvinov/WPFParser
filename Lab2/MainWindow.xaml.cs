using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private Pagination dataPaging = new Pagination();
        private List<CyberDanger> cyberDangers = new List<CyberDanger>();

        public MainWindow()
        {
            InitializeComponent();
            dataPaging.PageIndex = 0;
            int[] recordsToShow = { 15, 50, 100 };
            foreach (int recordsPerPage in recordsToShow)
            {
                RowsPerPage_Box.Items.Add(recordsPerPage);
            }
            dataPaging.RecordsPerPage = Convert.ToInt32(RowsPerPage_Box.SelectedItem);
            cyberDangers = CyberDangersListGetter.Get();
            dataPaging.CyberDangers = cyberDangers;
            Data_Table.ItemsSource = dataPaging.SetPaging();
            PageInfo_Label.Content = PageNumberDisplay();
        }

        public string PageNumberDisplay()
        {
            int totalPages = (cyberDangers.Count + dataPaging.RecordsPerPage - 1) / dataPaging.RecordsPerPage;
            return "Страница " + (dataPaging.PageIndex + 1) + " из " + totalPages;
        }
        private void DB_Update_Button_Click(object sender, RoutedEventArgs e)
        {
            cyberDangers = CyberDangersListGetter.GetWithChanges(cyberDangers);
        }

        private void FirstPage_Button_Click(object sender, RoutedEventArgs e)
        {
            Data_Table.ItemsSource = dataPaging.First();
            PageInfo_Label.Content = PageNumberDisplay();
        }

        private void PreviousPage_Button_Click(object sender, RoutedEventArgs e)
        {
            Data_Table.ItemsSource = dataPaging.Previous();
            PageInfo_Label.Content = PageNumberDisplay();
        }

        private void NextPage_Button_Click(object sender, RoutedEventArgs e)
        {
            Data_Table.ItemsSource = dataPaging.Next();
            PageInfo_Label.Content = PageNumberDisplay();
        }

        private void LastPage_Button_Click(object sender, RoutedEventArgs e)
        {
            Data_Table.ItemsSource = dataPaging.Last();
            PageInfo_Label.Content = PageNumberDisplay();
        }

        private void RowsPerPage_Box_Changed(object sender, SelectionChangedEventArgs e)
        {
            dataPaging.RecordsPerPage = Convert.ToInt32(RowsPerPage_Box.SelectedItem);
            Data_Table.ItemsSource = dataPaging.First();
            PageInfo_Label.Content = PageNumberDisplay();
        }

        private void DeleteLocalFiles_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Directory.Delete(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DangersParser"), true);
                MessageBox.Show("Локальные файлы успешно удалены");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Упс, что то пошло не так, не удалось удалить локальные файлы\n{ex.Message}");
            }
        }

        private void Data_Table_RowClick(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
