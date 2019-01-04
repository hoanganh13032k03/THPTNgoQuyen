namespace DBModel.ET
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SupportGroup")]
    public partial class SupportGroup
    {
        public int SupportGroupID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }
    }
}
