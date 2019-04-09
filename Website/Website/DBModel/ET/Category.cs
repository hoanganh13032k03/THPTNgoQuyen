namespace DBModel.ET
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using Resources;
    using System.ComponentModel;
    [Table("Category")]
    public partial class Category
    {
        [Display(Name = "CategoryID", ResourceType = typeof(Resources.ResourceAdmin))]
        public long CategoryID { get; set; }

        [Required(ErrorMessageResourceType = typeof(ResourceAdmin), ErrorMessageResourceName = "NameRequired")]
        [Display(Name = "CategoryName", ResourceType = typeof(Resources.ResourceAdmin))]
        [StringLength(250, ErrorMessageResourceType = typeof(ResourceAdmin), ErrorMessageResourceName = "CategoryNameLong")]
        public string Name { get; set; }

        [Display(Name = "MetaTitle", ResourceType = typeof(Resources.ResourceAdmin))]
        [StringLength(250, ErrorMessageResourceType = typeof(ResourceAdmin), ErrorMessageResourceName = "CategoryNameLong")]
        public string MetaTite { get; set; }

        [Display(Name = "CategoryParentID", ResourceType = typeof(Resources.ResourceAdmin))]
        public long? ParentID { get; set; }

        [StringLength(250)]
        [Display(Name = "Images", ResourceType = typeof(Resources.ResourceAdmin))]
        public string Image { get; set; }

        [Display(Name = "Description", ResourceType = typeof(Resources.ResourceAdmin))]
        [StringLength(250, ErrorMessageResourceType = typeof(ResourceAdmin), ErrorMessageResourceName = "CategoryNameLong")]
        public string Description { get; set; }

        [Display(Name = "Order", ResourceType = typeof(Resources.ResourceAdmin))]
        public int DisplayOrder { get; set; }

        [Display(Name = "TitleSeo", ResourceType = typeof(Resources.ResourceAdmin))]
        [StringLength(250, ErrorMessageResourceType = typeof(ResourceAdmin), ErrorMessageResourceName = "CategoryNameLong")]
        public string SeoTite { get; set; }

        [Display(Name = "CreatedDate", ResourceType = typeof(Resources.ResourceAdmin))]
        public DateTime CreateDate { get; set; }

        [Display(Name = "CreatedBy", ResourceType = typeof(Resources.ResourceAdmin))]
        public string CreateBy { get; set; }

        [Display(Name = "UpdatedBy", ResourceType = typeof(Resources.ResourceAdmin))]
        public string ModifiedBy { get; set; }

        [Display(Name = "UpdatedDate", ResourceType = typeof(Resources.ResourceAdmin))]
        public DateTime ModifiedDate { get; set; }

        [Display(Name = "MetaKeywords", ResourceType = typeof(Resources.ResourceAdmin))]
        [StringLength(250, ErrorMessageResourceType = typeof(ResourceAdmin), ErrorMessageResourceName = "CategoryNameLong")]
        public string MetakeyWords { get; set; }

        [Display(Name = "MetaDescription", ResourceType = typeof(Resources.ResourceAdmin))]
        [StringLength(250, ErrorMessageResourceType = typeof(ResourceAdmin), ErrorMessageResourceName = "CategoryNameLong")]
        public string MetaDescription { get; set; }

        [Display(Name = "Status", ResourceType = typeof(Resources.ResourceAdmin))]
        public bool Status { get; set; }

        [Display(Name = "ShowOnHome", ResourceType = typeof(Resources.ResourceAdmin))]
        public bool ShowOnHome { get; set; }

        [Display(Name = "Position", ResourceType = typeof(Resources.ResourceAdmin))]
        public byte Position { get; set; }

        [StringLength(5)]
        [Display(Name = "LanguageCode", ResourceType = typeof(Resources.ResourceAdmin))]
        public string LanguageID { get; set; }
    }
}
