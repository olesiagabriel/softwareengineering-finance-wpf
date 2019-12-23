using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using BLL.Models;
using System.Windows;



namespace курсовой.ViewModel
{
  public  class EditMyProfileView: VM
    {
        USER_Model user;
        DBDataOperation bd;
        public Window thisW;
        private string _Name;
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
                OnProperty("Name");
            }
        }
        private string _Surname;
        public string Surname
        {
            get
            {
                return _Surname;
            }
            set
            {
                _Surname = value;
                OnProperty("Surname");
            }
        }
        private string _Login;
        public string Login
        {
            get
            {
                return _Login;
            }
            set
            {
                _Login = value;
                OnProperty("Login");
            }
        }
        private string _Password;
        public string Password
        {
            get
            {
                return _Password;
            }
            set
            {
                _Password = value;
                OnProperty("Password");
            }
        }
      
        private string _Limit;
        public string Limit
        {
            get
            {
                return _Limit;
            }
            set
            {
                _Limit = value;
                OnProperty("Limit");
            }

        }

        private double _Limit2;
        public double Limit2
        {
            get
            {
                return _Limit2;
            }
            set
            {
                _Limit2 = value;
                OnProperty("Limit2");
            }

        }


        public RelayCommand UpdateUSER
        {
            get
            {
                return new RelayCommand(o =>
                {
                    USER_Model user2 = new USER_Model();
                    user2.user_code_ID = App.id;
                    user2.name = Name;
                    user2.surname = Surname;
                    user2.password =Password;
                    user2.login = Login;
                    user2.limit_size = (decimal)Convert.ToDouble( Limit);
                    bd.UpdateUSER(user2);
                    MessageBox.Show("Изменения сохранены");
                    Window2 f = new Window2();
                    f.Show();
                    thisW.Close();
                });
            }
        }

        public RelayCommand Cancel
        {
            get
            {
                return new RelayCommand(o =>
                {
                    Window2 f = new Window2();
                    f.Show();
                    thisW.Close();

                });
            }
        }
        public EditMyProfileView(DBDataOperation myBd, Window w2)
        {
            bd = myBd;
            user = bd.GetUSER(App.id)[0];
            Name =user.name;
            Surname = user.surname;
            Login = user.login;
            Password = user.password;
        
            Limit = user.limit_size.ToString();
            thisW = w2;
            DateTime Date2 = DateTime.Now;
            DateTime Date1 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            List<Order> or = bd.GetEXPENSESELECT(Date1, Date2, App.id);
            double r = 0;
            for (int i=0; i<or.Count; i++)
            {
                r += (double)or[i].expense_size;
            }
            Limit2 = Convert.ToDouble(Limit) - r;
        }
    }
}

