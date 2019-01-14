namespace DBModel.ET
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using Resources;

    [Table("Category")]
    public partial class Category
    {
        [Display(Name = "CategoryID", ResourceType = typeof(Resources.ResourceAdmin))]
        public long CategoryID { get; set; }

        [Required(ErrorMessageResourceType = typeof(ResourceAdmin), ErrorMessageResourceName = "CategoryRequired")]
        [Display(Name = "CategoryName", ResourceType = typeof(Resources.ResourceAdmin))]
        [StringLength(250, ErrorMessageResourceType = typeof(ResourceAdmin), ErrorMessageResourceName = "CategoryNameLong")]
        public string Name { get; set; }

        [Display(Name = "CategoryMetaTitle", ResourceType = typeof(Resources.ResourceAdmin))]
        [StringLength(250, ErrorMessageResourceType = typeof(ResourceAdmin), ErrorMessageResourceName = "CategoryNameLong")]
        public string MetaTite { get; set; }

        [Display(Name = "CategoryParentID", ResourceType = typeof(Resources.ResourceAdmin))]
        public long ParentID { get; set; }

        [StringLength(250)]
        public string Image { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        public int DisplayOrder { get; set; }

        [StringLength(250)]
        public string SeoTite { get; set; }

        public DateTime CreateDate { get; set; }

        [StringLength(100)]
        public string CreateBy { get; set; }

        [StringLength(100)]
        public string ModifiedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        [StringLength(250)]
        public string MetakeyWords { get; set; }

        [StringLength(250)]
        public string MetaDescription { get; set; }

        public bool IsIntroduced { get; set; }

        public bool Status { get; set; }

        public bool ShowOnHome { get; set; }

        public byte Position { get; set; }

        [StringLength(5)]
        public string LanguageID { get; set; }
    }
}
