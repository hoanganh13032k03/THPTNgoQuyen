namespace DBModel.ET
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GroupCalendar")]
    public partial class GroupCalendar
    {
        [Key]
        public long GroupID { get; set; }

        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Note { get; set; }

        public DateTime CreateDate { get; set; }

        [StringLength(100)]
        public string CreatedBy { get; set; }

        public int DisplayOrder { get; set; }

        public bool Status { get; set; }
    }
}
