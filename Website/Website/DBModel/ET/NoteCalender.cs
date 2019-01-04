namespace DBModel.ET
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NoteCalender")]
    public partial class NoteCalender
    {
        [Key]
        public long NoteID { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Detail { get; set; }

        [StringLength(10)]
        public string Year { get; set; }

        public byte Week { get; set; }

        public DateTime CreateDate { get; set; }

        [StringLength(100)]
        public string CreatedBy { get; set; }

        [StringLength(100)]
        public string ModifiedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        public bool Status { get; set; }
    }
}
