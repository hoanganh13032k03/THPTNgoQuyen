namespace DBModel.ET
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.ComponentModel;
    using Resources;


    [Table("NoteCalender")]
    public partial class NoteCalender
    {
        [Key]
        [Display(Name = "ID", ResourceType = typeof(Resources.ResourceAdmin))]
        public long NoteID { get; set; }

        [Column(TypeName = "text")]
        [Display(Name = "Content", ResourceType = typeof(Resources.ResourceAdmin))]
        public string Detail { get; set; }

        [StringLength(10)]
        public string Year { get; set; }

        public byte Week { get; set; }

        [Display(Name = "CreatedDate", ResourceType = typeof(Resources.ResourceAdmin))]
        public DateTime CreateDate { get; set; }

        [StringLength(100)]
        [Display(Name = "CreatedBy", ResourceType = typeof(Resources.ResourceAdmin))]
        public string CreatedBy { get; set; }

        [StringLength(100)]
        [Display(Name = "UpdatedBy", ResourceType = typeof(Resources.ResourceAdmin))]
        public string ModifiedBy { get; set; }

        [Display(Name = "UpdatedDate", ResourceType = typeof(Resources.ResourceAdmin))]
        public DateTime ModifiedDate { get; set; }
        [Display(Name = "Status", ResourceType = typeof(Resources.ResourceAdmin))]
        public bool Status { get; set; }
    }
}
