namespace DBModel.ET
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Calender")]
    public partial class Calender
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long CalenderID { get; set; }

        public long GroupID { get; set; }

        [StringLength(250)]
        public string Image { get; set; }

        [StringLength(250)]
        public string Tite { get; set; }

        public DateTime Date_Start { get; set; }

        public int Hour_Start { get; set; }

        public int Minutes_Start { get; set; }

        public int Status_Start { get; set; }

        public DateTime Date_End { get; set; }

        public int Hour_End { get; set; }

        public int Minutes_End { get; set; }

        public int Status_End { get; set; }

        [Column(TypeName = "ntext")]
        public string Detail { get; set; }

        [StringLength(255)]
        public string Place { get; set; }

        [StringLength(255)]
        public string Organization { get; set; }

        [StringLength(255)]
        public string Prepared { get; set; }

        [StringLength(255)]
        public string Files { get; set; }

        public byte Options { get; set; }

        public DateTime CreateDate { get; set; }

        [StringLength(100)]
        public string CreateBy { get; set; }

        [StringLength(100)]
        public string ModifiedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        [StringLength(250)]
        public string MetakeyWords { get; set; }

        [Required]
        [StringLength(250)]
        public string MetaDescription { get; set; }

        public bool Active { get; set; }

        public DateTime ActiveDate { get; set; }

        public bool Publish { get; set; }

        public DateTime PublishDate { get; set; }

        public bool ShowOnHome { get; set; }

        [StringLength(5)]
        public string LanguageID { get; set; }
    }
}
