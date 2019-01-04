namespace DBModel.ET
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StatsInfo")]
    public partial class StatsInfo
    {
        [Key]
        public long StasInfoID { get; set; }

        public int DisplayOrder { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        public int Speed { get; set; }

        public long Number { get; set; }

        [StringLength(50)]
        public string Description { get; set; }

        public DateTime CreateDate { get; set; }

        [StringLength(100)]
        public string CreateBy { get; set; }

        [StringLength(100)]
        public string ModifiedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        [StringLength(5)]
        public string LanguageID { get; set; }

        public bool Status { get; set; }
    }
}
