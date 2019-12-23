using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL.Models
{
    public class EXPENSE_GUIDE_Model
    {

        public int expense_guide_code_ID { get; set; }


        public string expense_type { get; set; }

        public EXPENSE_GUIDE_Model() { }
        public EXPENSE_GUIDE_Model(EXPENSE_GUIDE e)
        {
            expense_guide_code_ID = e.expense_guide_code_ID;
            expense_type = e.expense_type;

        }
    }
}
