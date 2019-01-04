namespace DBModel.ET
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Former")]
    public partial class Former
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long FormerID { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long TeacherID { get; set; }

        public int CourseID { get; set; }

        [StringLength(30)]
        public string UserName { get; set; }

        [StringLength(100)]
        public string Password { get; set; }

        [StringLength(100)]
        public string FullName { get; set; }

        [StringLength(100)]
        public string Company { get; set; }

        [StringLength(100)]
        public string Class { get; set; }

        [StringLength(100)]
        public string Job { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        public DateTime CreatedDate { get; set; }

        public bool IsDeleted { get; set; }

        public bool LockedUser { get; set; }

        public DateTime LockedDate { get; set; }

        [StringLength(100)]
        public string LockedReason { get; set; }

        public DateTime LastLogIn { get; set; }

        public DateTime LastChangedPassword { get; set; }

        public DateTime DeadlineOfUsing { get; set; }

        public DateTime BirthDay { get; set; }

        [StringLength(50)]
        public string Gender { get; set; }

        [StringLength(250)]
        public string Image { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [StringLength(50)]
        public string Sate { get; set; }

        [StringLength(20)]
        public string Region { get; set; }

        [StringLength(20)]
        public string Zip { get; set; }

        [StringLength(50)]
        public string Country { get; set; }

        [StringLength(100)]
        public string Fax { get; set; }

        [StringLength(100)]
        public string Phone { get; set; }

        public bool EmailVerifled { get; set; }

        [StringLength(20)]
        public string VerificationCode { get; set; }

        [StringLength(50)]
        public string IPLogin { get; set; }

        [StringLength(100)]
        public string Note { get; set; }
    }
}
