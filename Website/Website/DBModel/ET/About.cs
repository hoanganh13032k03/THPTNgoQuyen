namespace DBModel.ET
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using Resources;

    [Table("About")]
    public partial class About
    {
        [Display(Name = "CategoryID", ResourceType = typeof(Resources.ResourceAdmin))]
        public long AboutID { get; set; }

        [StringLength(250, ErrorMessageResourceType = typeof(ResourceAdmin), ErrorMessageResourceName = "TitleLong")]
        public string Name { get; set; }

        [StringLength(250, ErrorMessageResourceType = typeof(ResourceAdmin), ErrorMessageResourceName = "TitleLong")]
        [Display(Name = "MetaTitle", ResourceType = typeof(Resources.ResourceAdmin))]
        public string MetaTite { get; set; }

        [StringLength(250, ErrorMessageResourceType = typeof(ResourceAdmin), ErrorMessageResourceName = "TitleLong")]
        [Display(Name = "AboutDescription", ResourceType = typeof(Resources.ResourceAdmin))]
        public string Description { get; set; }

        [StringLength(250, ErrorMessageResourceType = typeof(ResourceAdmin), ErrorMessageResourceName = "TitleLong")]
        public string Video { get; set; }

        [StringLength(250)]
        [Display(Name = "Address", ResourceType = typeof(Resources.ResourceAdmin))]
        public string Address { get; set; }

        [StringLength(250, ErrorMessageResourceType = typeof(ResourceAdmin), ErrorMessageResourceName = "TitleLong")]
        public string Email { get; set; }

        [StringLength(250, ErrorMessageResourceType = typeof(ResourceAdmin), ErrorMessageResourceName = "TitleLong")]
        public string Phone { get; set; }

        [StringLength(250, ErrorMessageResourceType = typeof(ResourceAdmin), ErrorMessageResourceName = "TitleLong")]
        public string Facebook { get; set; }

        [StringLength(250, ErrorMessageResourceType = typeof(ResourceAdmin), ErrorMessageResourceName = "TitleLong")]
        public string Twitter { get; set; }

        [StringLength(250, ErrorMessageResourceType = typeof(ResourceAdmin), ErrorMessageResourceName = "TitleLong")]
        public string Googleplus { get; set; }

        [StringLength(250, ErrorMessageResourceType = typeof(ResourceAdmin), ErrorMessageResourceName = "TitleLong")]
        [Display(Name = "AboutImages", ResourceType = typeof(Resources.ResourceAdmin))]
        public string Image { get; set; }

        [Column(TypeName = "ntext")]
        [Display(Name = "AboutContent", ResourceType = typeof(Resources.ResourceAdmin))]
        public string Detail { get; set; }

        [Display(Name = "CreatedBy", ResourceType = typeof(Resources.ResourceAdmin))]
        [StringLength(100)]
        public string CreateBy { get; set; }
        [Display(Name = "CreatedDate", ResourceType = typeof(Resources.ResourceAdmin))]
        public DateTime? CreateDate { get; set; }

        [StringLength(100)]
        [Display(Name = "UpdatedBy", ResourceType = typeof(Resources.ResourceAdmin))]
        public string ModifiedBy { get; set; }

        [Display(Name = "UpdatedDate", ResourceType = typeof(Resources.ResourceAdmin))]
        public DateTime? ModifiedDate { get; set; }

        [Display(Name = "MetaKeywords", ResourceType = typeof(Resources.ResourceAdmin))]
        [StringLength(250, ErrorMessageResourceType = typeof(ResourceAdmin), ErrorMessageResourceName = "TitleLong")]
        public string MetakeyWords { get; set; }

        [Display(Name = "MetaDescription", ResourceType = typeof(Resources.ResourceAdmin))]
        [StringLength(250, ErrorMessageResourceType = typeof(ResourceAdmin), ErrorMessageResourceName = "TitleLong")]
        public string MetaDescription { get; set; }

        [StringLength(5)]
        [Display(Name = "LanguageCode", ResourceType = typeof(Resources.ResourceAdmin))]
        public string LanguageID { get; set; }
        [Display(Name = "Status", ResourceType = typeof(Resources.ResourceAdmin))]
        public bool Status { get; set; }
    }
}
