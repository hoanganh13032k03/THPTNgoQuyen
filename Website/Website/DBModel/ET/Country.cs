namespace DBModel.ET
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Country
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [StringLength(10)]
        public string SortName { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(11)]
        public string PhoneCode { get; set; }
    }
}
