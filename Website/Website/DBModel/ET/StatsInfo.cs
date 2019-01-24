namespace DBModel.ET
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using Resources;
    [Table("StatsInfo")]
    public partial class StatsInfo
    {
        [Key]
        [Display(Name = "CategoryID", ResourceType = typeof(Resources.ResourceAdmin))]
        public long StasInfoID { get; set; }

        [Display(Name = "Order", ResourceType = typeof(Resources.ResourceAdmin))]
        public int DisplayOrder { get; set; }

         [StringLength(250, ErrorMessageResourceType = typeof(ResourceAdmin), ErrorMessageResourceName = "TitleLong")]
        [Display(Name = "AlbumName", ResourceType = typeof(Resources.ResourceAdmin))]
        public string Name { get; set; }

        [Display(Name = "StatsInfoSeed", ResourceType = typeof(Resources.ResourceAdmin))]
        public int Speed { get; set; }

        [Display(Name = "StatsInfoNumber", ResourceType = typeof(Resources.ResourceAdmin))]
        public long Number { get; set; }

        [StringLength(250, ErrorMessageResourceType = typeof(ResourceAdmin), ErrorMessageResourceName = "TitleLong")]
        [Display(Name = "AboutDescription", ResourceType = typeof(Resources.ResourceAdmin))]
        public string Description { get; set; }

        [Display(Name = "CreatedDate", ResourceType = typeof(Resources.ResourceAdmin))]
        public DateTime CreateDate { get; set; }

        [StringLength(100)]
        [Display(Name = "CreatedBy", ResourceType = typeof(Resources.ResourceAdmin))]
        public string CreateBy { get; set; }

        [StringLength(100)]
        [Display(Name = "UpdatedBy", ResourceType = typeof(Resources.ResourceAdmin))]
        public string ModifiedBy { get; set; }

        [Display(Name = "UpdatedDate", ResourceType = typeof(Resources.ResourceAdmin))]
        public DateTime ModifiedDate { get; set; }

        [StringLength(5)]
        [Display(Name = "LanguageCode", ResourceType = typeof(Resources.ResourceAdmin))]
        public string LanguageID { get; set; }

        [Display(Name = "Status", ResourceType = typeof(Resources.ResourceAdmin))]
        public bool Status { get; set; }
    }
}
