namespace DBModel.ET
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Menu")]
    public partial class Menu
    {
        public int MenuID { get; set; }

        public long? ParentID { get; set; }

        [StringLength(250)]
        public string Image { get; set; }

        [StringLength(50)]
        public string GroupID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(250)]
        public string Text { get; set; }

        public int DisplayOrder { get; set; }

        [StringLength(250)]
        public string Link { get; set; }

        [StringLength(50)]
        public string Target { get; set; }

        [StringLength(100)]
        public string Description { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsActived { get; set; }

        [Required]
        [StringLength(5)]
        public string LanguageID { get; set; }

        public DateTime CreatedDate { get; set; }

        [StringLength(100)]
        public string CreatedBy { get; set; }

        [StringLength(100)]
        public string UpdatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        [MaxLength(50)]
        public byte[] CssClass { get; set; }
    }
}
