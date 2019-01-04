namespace DBModel.ET
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Language")]
    public partial class Language
    {
        [StringLength(5)]
        public string ID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Description { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsActived { get; set; }

        public bool IsDefault { get; set; }

        public DateTime CreateDate { get; set; }

        [StringLength(100)]
        public string CreateBy { get; set; }

        [StringLength(100)]
        public string ModifiedBy { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}
