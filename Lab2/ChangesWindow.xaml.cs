using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Lab2
{
    /// <summary>
    /// Логика взаимодействия для ChangesWindow.xaml
    /// </summary>
    public partial class ChangesWindow : Window
    {
        public ChangesWindow(List<string> added, List<string> deleted)
        {
            InitializeComponent();
            Added_List.ItemsSource = added;
            Deleted_List.ItemsSource = deleted;
        }
    }
}
