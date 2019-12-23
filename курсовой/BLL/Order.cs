using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public class Order
    {
        public int expense_code_ID { get; set; }

        public int? expense_user_FK { get; set; }

        public int? expense_guide_FK { get; set; }


        public DateTime? expense_date { get; set; }

        public decimal? expense_size { get; set; }
        public int expense_guide_code_ID { get; set; }


        public string expense_type { get; set; }
    }
}
