namespace DBModel.ET
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using Resources;

    [Table("Video")]
    public partial class Video
    {
        [Key]
        [Display(Name = "CategoryID", ResourceType = typeof(Resources.ResourceAdmin))]
        public long VideosID { get; set; }

        [StringLength(250, ErrorMessageResourceType = typeof(ResourceAdmin), ErrorMessageResourceName = "TitleLong")]
        [Display(Name = "AlbumName", ResourceType = typeof(Resources.ResourceAdmin))]
        public string Name { get; set; }

        [StringLength(250, ErrorMessageResourceType = typeof(ResourceAdmin), ErrorMessageResourceName = "TitleLong")]
        [Display(Name = "Images", ResourceType = typeof(Resources.ResourceAdmin))]
        public string Image { get; set; }

        [Display(Name = "Order", ResourceType = typeof(Resources.ResourceAdmin))]
        public int? DisplayOrder { get; set; }

        [Required(ErrorMessageResourceType = typeof(ResourceAdmin), ErrorMessageResourceName = "MenuUrlRequired")]
        [StringLength(250, ErrorMessageResourceType = typeof(ResourceAdmin), ErrorMessageResourceName = "TitleLong")]
        [Display(Name = "FunctionUrl", ResourceType = typeof(Resources.ResourceAdmin))]
        public string Link { get; set; }

        [StringLength(50)]
        public string Target { get; set; }

        [StringLength(50, ErrorMessageResourceType = typeof(ResourceAdmin), ErrorMessageResourceName = "TitleLong")]
        [Display(Name = "AboutDescription", ResourceType = typeof(Resources.ResourceAdmin))]
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
        public bool Status { get; set; }
    }
}
