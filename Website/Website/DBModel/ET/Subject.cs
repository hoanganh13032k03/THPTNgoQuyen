namespace DBModel.ET
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Subject")]
    public partial class Subject
    {
        [Key]
        public int SubiectID { get; set; }

        [StringLength(50)]
        public string SubjectName { get; set; }

        [StringLength(100)]
        public string Note { get; set; }

        public DateTime? CreateDate { get; set; }

        [StringLength(100)]
        public string CreatedBy { get; set; }

        public int? DisplayOrder { get; set; }

        public bool? IsActived { get; set; }
    }
}
