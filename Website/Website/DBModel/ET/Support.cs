namespace DBModel.ET
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Support")]
    public partial class Support
    {
        public int SupportID { get; set; }

        public int SupportGroupID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        public DateTime CreateDate { get; set; }

        public int? DisplayOrder { get; set; }

        [StringLength(5)]
        public string LanguageID { get; set; }

        public bool Status { get; set; }

        [StringLength(10)]
        public string Type { get; set; }
    }
}
