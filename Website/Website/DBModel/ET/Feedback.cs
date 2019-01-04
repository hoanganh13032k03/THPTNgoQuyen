namespace DBModel.ET
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Feedback")]
    public partial class Feedback
    {
        public long FeedbackID { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Company { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        [StringLength(500)]
        public string Message { get; set; }

        public DateTime CreateDate { get; set; }

        [StringLength(5)]
        public string LanguageID { get; set; }

        public bool IsReaded { get; set; }
    }
}
