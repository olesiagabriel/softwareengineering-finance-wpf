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
using курсовой.ViewModel;
using BLL;
using BLL.Models;

namespace курсовой
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        DBDataOperation bd = new DBDataOperation();
        public Window1()
        {
            InitializeComponent();
            DataContext = new EditMyProfileView(bd, this);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
