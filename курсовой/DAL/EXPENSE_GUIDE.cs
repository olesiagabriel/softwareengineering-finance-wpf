namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EXPENSE_GUIDE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EXPENSE_GUIDE()
        {
            EXPENSE = new HashSet<EXPENSE>();
        }

        [Key]
        public int expense_guide_code_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string expense_type { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EXPENSE> EXPENSE { get; set; }
    }
}
