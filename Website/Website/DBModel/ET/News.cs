namespace DBModel.ET
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using Resources;

    public partial class News
    {
        [Display(Name = "CategoryID", ResourceType = typeof(Resources.ResourceAdmin))]
        public long NewsID { get; set; }

        [StringLength(250, ErrorMessageResourceType = typeof(ResourceAdmin), ErrorMessageResourceName = "TitleLong")]
        public string Name { get; set; }

        [StringLength(250, ErrorMessageResourceType = typeof(ResourceAdmin), ErrorMessageResourceName = "TitleLong")]
        public string Title { get; set; }

        [StringLength(250, ErrorMessageResourceType = typeof(ResourceAdmin), ErrorMessageResourceName = "TitleLong")]
        public string MetaTite { get; set; }

        [StringLength(500)]
        [Display(Name = "Description", ResourceType = typeof(Resources.ResourceAdmin))]
        public string Description { get; set; }
        [StringLength(500)]
        public string Tags { get; set; }
        [StringLength(250)]
        [Display(Name = "Images", ResourceType = typeof(Resources.ResourceAdmin))]
        public string Image { get; set; }

        [StringLength(500)]
        public string CategoryID { get; set; }

        [Display(Name = "Content", ResourceType = typeof(Resources.ResourceAdmin))]
        [Column(TypeName = "ntext")]
        public string ContentHtml { get; set; }

        [Display(Name = "CreatedDate", ResourceType = typeof(Resources.ResourceAdmin))]
        public DateTime CreateDate { get; set; }

        [StringLength(100)]
        [Display(Name = "CreatedBy", ResourceType = typeof(Resources.ResourceAdmin))]
        public string CreateBy { get; set; }

        [StringLength(100)]
        [Display(Name = "UpdatedBy", ResourceType = typeof(Resources.ResourceAdmin))]
        public string ModifiedBy { get; set; }

        [Display(Name = "UpdatedDate", ResourceType = typeof(Resources.ResourceAdmin))]
        public DateTime? ModifiedDate { get; set; }

        [Display(Name = "MetaKeywords", ResourceType = typeof(Resources.ResourceAdmin))]
        [StringLength(250, ErrorMessageResourceType = typeof(ResourceAdmin), ErrorMessageResourceName = "CategoryNameLong")]
        public string MetakeyWords { get; set; }

        [Display(Name = "MetaDescription", ResourceType = typeof(Resources.ResourceAdmin))]
        [StringLength(250, ErrorMessageResourceType = typeof(ResourceAdmin), ErrorMessageResourceName = "CategoryNameLong")]
        public string MetaDescription { get; set; }

        [Display(Name = "Status", ResourceType = typeof(Resources.ResourceAdmin))]
        public int Status { get; set; }

        [Display(Name = "NewsUpTopHot", ResourceType = typeof(ResourceAdmin))]
        public DateTime UpTopHot { get; set; }

        [Display(Name = "NewsUpTopNew", ResourceType = typeof(ResourceAdmin))]
        public DateTime UpTopNew { get; set; }

        [Display(Name = "NewsViewCount", ResourceType = typeof(Resources.ResourceAdmin))]
        public int ViewCount { get; set; }

        [Display(Name = "NewsSource", ResourceType = typeof(Resources.ResourceAdmin))]
        public string Source { get; set; }
        public bool ShowConment { get; set; }

        [StringLength(5)]
        [Display(Name = "LanguageCode", ResourceType = typeof(Resources.ResourceAdmin))]
        public string LanguageID { get; set; }

        public bool ShowShare { get; set; }

        [Display(Name = "NewsPublishedDate", ResourceType = typeof(ResourceAdmin))]
        public DateTime PublishedDate { get; set; }

        [Display(Name = "NewsRelatedNewses", ResourceType = typeof(Resources.ResourceAdmin))]
        public string RelatedNewses { get; set; }
    }
}
