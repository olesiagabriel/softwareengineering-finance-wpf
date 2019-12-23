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
   public class RegistrationView: VM
    {
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
        private string _Password2;
        public string Password2
        {
            get
            {
                return _Password2;
            }
            set
            {
                _Password2 = value;
                OnProperty("Password2");
            }

        }


        public RelayCommand Registration
        {
            get
            {
                return new RelayCommand(o =>
                {
                    if (Name != "" && Surname!= "" && Login!= "" && Password != "" && Password2 != "")
                    {
                        if (Password != Password2)
                        {
                            MessageBox.Show("Пароли не совпадают");
                        }
                        else
                        {
                            
                           
                            if (bd.GetUSER(Login))
                            {
                                MessageBox.Show("Данный логин занят");
                            }
                            else
                            {

                                
                                USER_Model u = new USER_Model();
                                u.name = Name;
                                u.surname = Surname;
                                u.login = Login;
                                u.password = Password;
                                bd.CreateUSER(u);
                                MessageBox.Show("Пользователь добавлен");
                                MainWindow m = new MainWindow();
                                m.Show();
                                thisW.Close();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Не все поля заполнены");
                    }
                });
            }
        }

        public RelayCommand Cancel
        {
            get
            {
                return new RelayCommand(o =>
                { MainWindow f = new MainWindow();
                    f.Show();
                    thisW.Close();
                   
                });
            }
        }
        public RegistrationView(DBDataOperation myBd,Window w2)
        {
            bd = myBd;
            Name = "";
            Surname = "";
            Login = "";
            Password = "";
            Password2 = "";
            thisW= w2;
            
        }
    }

}
