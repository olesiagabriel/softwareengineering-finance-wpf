using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL.Models
{
    public class INCOME_Model

    {
       
        public int income_code_ID { get; set; }

        public int? income_user_FK { get; set; }

        public int? income_guide_FK { get; set; }

        public DateTime? income_date { get; set; }

        public decimal? income_size { get; set; }

       public INCOME_Model() { }
        public INCOME_Model(INCOME i)
        {
            income_code_ID = i.income_code_ID;
            income_user_FK = i.income_user_FK;
            income_guide_FK = i.income_guide_FK;
            income_date = i.income_date;
            income_size = i.income_size;
        }
    }
}
