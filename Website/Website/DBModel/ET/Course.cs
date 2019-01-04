namespace DBModel.ET
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Course")]
    public partial class Course
    {
        public int CourseID { get; set; }

        [StringLength(50)]
        public string CourseName { get; set; }

        public int YearStart { get; set; }

        public int YearEnd { get; set; }

        [StringLength(100)]
        public string Note { get; set; }

        public DateTime CreateDate { get; set; }

        [StringLength(100)]
        public string CreatedBy { get; set; }

        public int DisplayOrder { get; set; }

        public bool IsActived { get; set; }
    }
}
