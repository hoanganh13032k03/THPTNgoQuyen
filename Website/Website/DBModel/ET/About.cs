namespace DBModel.ET
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("About")]
    public partial class About
    {
        public long AboutID { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(250)]
        public string MetaTite { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [StringLength(250)]
        public string Video { get; set; }

        [StringLength(250)]
        public string Email { get; set; }

        [StringLength(250)]
        public string Phone { get; set; }

        [StringLength(250)]
        public string Facebook { get; set; }

        [StringLength(250)]
        public string Twitter { get; set; }

        [StringLength(250)]
        public string Googleplus { get; set; }

        [StringLength(250)]
        public string Image { get; set; }

        [Column(TypeName = "ntext")]
        public string Detail { get; set; }

        [StringLength(100)]
        public string CreateBy { get; set; }

        public DateTime? CreateDate { get; set; }

        [StringLength(100)]
        public string ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(250)]
        public string MetakeyWords { get; set; }

        [StringLength(250)]
        public string MetaDescription { get; set; }

        [StringLength(5)]
        public string LanguageID { get; set; }

        public bool Status { get; set; }
    }
}
