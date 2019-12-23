using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL.Models
{
    public class EXPENSE_Model
    {
      
        public int expense_code_ID { get; set; }

        public int? expense_user_FK { get; set; }

        public int? expense_guide_FK { get; set; }


        public DateTime? expense_date { get; set; }

        public decimal? expense_size { get; set; }

        public EXPENSE_Model() { }
        public EXPENSE_Model(EXPENSE e)
        {
            expense_code_ID = e.expense_code_ID;
            expense_user_FK = e.expense_user_FK;
            expense_guide_FK =e.expense_guide_FK;
            expense_date = e.expense_date;
            expense_size = e.expense_size;

        }

      
    }
}
