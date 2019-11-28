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
        public MainWindow()
        {
            //InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window1 f = new Window1();
            f.Show();
            this.Close();
        }

        private void Grid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
           /**/
        }
    }
}
