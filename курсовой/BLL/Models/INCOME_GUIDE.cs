using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL.Models
{
    public class INCOME_GUIDE_Model
    {
       
        public int income_guide_code_ID { get; set; }

      
        public string income_type { get; set; }

        public INCOME_GUIDE_Model() { }
        public INCOME_GUIDE_Model(INCOME_GUIDE i)
        {
            income_guide_code_ID = i.income_guide_code_ID;
            income_type = i.income_type;
            
        }
    }
}
