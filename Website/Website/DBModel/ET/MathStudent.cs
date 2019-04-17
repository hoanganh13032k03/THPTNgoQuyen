namespace DBModel.ET
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using Resources;
    using System.ComponentModel;
    [Table("MathStudent")]
    public partial class MathStudent
    {
        [Key]
        [Display(Name = "CategoryID", ResourceType = typeof(Resources.ResourceAdmin))]
        public long MathsID { get; set; }

        [Display(Name = "CategoryParentID", ResourceType = typeof(Resources.ResourceAdmin))]
        public long GroupMathsID { get; set; }

        
        [StringLength(250, ErrorMessageResourceType = typeof(ResourceAdmin), ErrorMessageResourceName = "TitleLong")]
        public string Name { get; set; }

        [StringLength(250)]
        [Display(Name = "Images", ResourceType = typeof(Resources.ResourceAdmin))]
        public string Image { get; set; }

        [Display(Name = "Order", ResourceType = typeof(Resources.ResourceAdmin))]
        public int? DisplayOrder { get; set; }

        [Column(TypeName = "xml")]
        public string Sources { get; set; }

        [Display(Name = "Description", ResourceType = typeof(Resources.ResourceAdmin))]
        [StringLength(250, ErrorMessageResourceType = typeof(ResourceAdmin), ErrorMessageResourceName = "CategoryNameLong")]
        public string Description { get; set; }

        [Display(Name = "CreatedDate", ResourceType = typeof(Resources.ResourceAdmin))]
        public DateTime? CreateDate { get; set; }

        [StringLength(100)]
        [Display(Name = "CreatedBy", ResourceType = typeof(Resources.ResourceAdmin))]
        public string CreateBy { get; set; }

        [StringLength(100)]
        [Display(Name = "UpdatedBy", ResourceType = typeof(Resources.ResourceAdmin))]
        public string ModifiedBy { get; set; }

        [Display(Name = "UpdatedDate", ResourceType = typeof(Resources.ResourceAdmin))]
        public DateTime? ModifiedDate { get; set; }

        [StringLength(5)]
        [Display(Name = "LanguageCode", ResourceType = typeof(Resources.ResourceAdmin))]
        public string LanguageID { get; set; }

        [Display(Name = "Status", ResourceType = typeof(Resources.ResourceAdmin))]
        public bool? Status { get; set; }
    }
}
