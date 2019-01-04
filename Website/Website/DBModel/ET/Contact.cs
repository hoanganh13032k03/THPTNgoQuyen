namespace DBModel.ET
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Contact")]
    public partial class Contact
    {
        public long ContactID { get; set; }

        [Column(TypeName = "ntext")]
        public string Content { get; set; }

        [StringLength(5)]
        public string LanguageID { get; set; }

        public bool Status { get; set; }
    }
}
