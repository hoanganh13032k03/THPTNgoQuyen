namespace DBModel.ET
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Category")]
    public partial class Category
    {
        public long CategoryID { get; set; }

        [StringLength(250)]
        public string Title { get; set; }

        [StringLength(250)]
        public string MetaTite { get; set; }

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
