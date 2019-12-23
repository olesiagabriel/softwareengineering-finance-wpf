using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL.Models
{
   public class USER_Model
    {
       
        public int user_code_ID { get; set; }

      
        public string name { get; set; }

     
        public string surname { get; set; }

       
        public string login { get; set; }

   
        public string password { get; set; }

        public decimal? limit_size { get; set; }

        public USER_Model() { }
        public USER_Model(USER u)
        {
            user_code_ID = u.user_code_ID;
            name = u.name;
            surname = u.surname;
            login = u.login;
            password = u.password;
            limit_size = u.limit_size;
        }
    }
}
