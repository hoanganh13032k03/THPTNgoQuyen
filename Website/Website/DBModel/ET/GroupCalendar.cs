namespace DBModel.ET
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using Resources;
    using System.ComponentModel;

    [Table("GroupCalendar")]
    public partial class GroupCalendar
    {
        [Key]
        [Display(Name = "CategoryID", ResourceType = typeof(Resources.ResourceAdmin))]
        public long GroupID { get; set; }

        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(100)]
        [DisplayName("Ghi chú")]
        public string Note { get; set; }

        [Display(Name = "CreatedDate", ResourceType = typeof(Resources.ResourceAdmin))]
        public DateTime CreateDate { get; set; }

        [StringLength(100)]
        [Display(Name = "CreatedBy", ResourceType = typeof(Resources.ResourceAdmin))]
        public string CreatedBy { get; set; }

        [Display(Name = "Position", ResourceType = typeof(Resources.ResourceAdmin))]
        public int DisplayOrder { get; set; }

        [Display(Name = "Status", ResourceType = typeof(Resources.ResourceAdmin))]
        public bool Status { get; set; }
    }
}
