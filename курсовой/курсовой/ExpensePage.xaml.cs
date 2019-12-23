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
using BLL;
using BLL.Models;
using курсовой.ViewModel;

namespace курсовой
{
    /// <summary>
    /// Логика взаимодействия для Window4.xaml
    /// </summary>
    public partial class Window4 : Window
    {
        DBDataOperation bd = new DBDataOperation();
        public Window4()
        {
            InitializeComponent();
            DataContext = new ExpenseView(bd, this);
        }
    }
}
