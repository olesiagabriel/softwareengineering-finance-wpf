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
using System.Windows.Navigation;
using System.Windows.Shapes;
using BLL.Models;
using BLL;
using курсовой.ViewModel;

namespace курсовой
{
   
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// /*9.	Учет домашних финансов
   /* Ведение расходов и доходов для членов семьи.Расходы складываются из 
    * покупок товаров и трат на услуги.Учесть различные источники дохода.
    * Приложение должно предоставлять функцию формирования бюджета и  информировать
    * о превышении установленного лимита на бюджет.Предоставить возможность формирования
    * отчета «Итоговое сальдо» за указанный период.
 */
    public partial class MainWindow : Window
    {
        public int id = 0;
        DBDataOperation bd = new DBDataOperation();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowsView(bd, this);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
           
        }

        private void Grid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
           
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
          
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
           
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Window3 f = new Window3();
            f.Show();
            this.Close();
        }

        private void TextBox1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
