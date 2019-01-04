namespace DBModel.ET
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Footer")]
    public partial class Footer
    {
        [StringLength(50)]
        public string ID { get; set; }

        [StringLength(100)]
        public string Title { get; set; }

        [Column(TypeName = "ntext")]
        public string ContentHtml { get; set; }

        [StringLength(5)]
        public string LanguageID { get; set; }

        public bool Status { get; set; }
    }
}
