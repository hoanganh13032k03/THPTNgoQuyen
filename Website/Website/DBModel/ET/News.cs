namespace DBModel.ET
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class News
    {
        public long NewsID { get; set; }

        [StringLength(250)]
        public string Title { get; set; }

        [StringLength(250)]
        public string MetaTite { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [StringLength(250)]
        public string Image { get; set; }

        [StringLength(500)]
        public string CategoryID { get; set; }

        [Column(TypeName = "ntext")]
        public string ContentHtml { get; set; }

        public DateTime CreateDate { get; set; }

        [StringLength(100)]
        public string CreateBy { get; set; }

        [StringLength(100)]
        public string ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(250)]
        public string MetakeyWords { get; set; }

        [StringLength(250)]
        public string MetaDescription { get; set; }

        public int Status { get; set; }

        public DateTime UpTopHot { get; set; }

        public DateTime UpTopNew { get; set; }

        public int ViewCount { get; set; }

        public bool ShowConment { get; set; }

        [StringLength(5)]
        public string LanguageID { get; set; }

        public bool ShowShare { get; set; }

        public DateTime PublishedDate { get; set; }

        [StringLength(100)]
        public string RelatedNewses { get; set; }
    }
}
