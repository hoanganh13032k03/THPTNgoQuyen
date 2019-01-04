namespace DBModel.ET
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using Resources;
    using System.ComponentModel;

    [Table("User")]
    public partial class User
    {
        [Key]
        public long LoginID { get; set; }
        [Required(ErrorMessageResourceType = typeof(ResourceAdmin), ErrorMessageResourceName = "UserNameRequired")]
        [StringLength(20, ErrorMessageResourceType = typeof(ResourceAdmin), ErrorMessageResourceName = "UserNameLong")]
        [Display(Name = "UserNameText", ResourceType = typeof(Resources.ResourceAdmin))]
        public string UserName { get; set; }

        [Required(ErrorMessageResourceType = typeof(ResourceAdmin), ErrorMessageResourceName = "PasswordRequired")]
        [MinLength(6, ErrorMessageResourceType = typeof(ResourceAdmin), ErrorMessageResourceName = "PasswordMinLong")]
        [Display(Name = "Password", ResourceType = typeof(Resources.ResourceAdmin))]
        public string Password { get; set; }

        [Required(ErrorMessageResourceType = typeof(ResourceAdmin), ErrorMessageResourceName = "FullNameRequired")]
        [Display(Name = "FullName", ResourceType = typeof(Resources.ResourceAdmin))]
        public string FullName { get; set; }

        [Display(Name = "Address", ResourceType = typeof(Resources.ResourceAdmin))]
        public string Address { get; set; }

        [Required(ErrorMessageResourceType = typeof(ResourceAdmin), ErrorMessageResourceName = "EmailRequired")]
        [Display(Name = "Email", ResourceType = typeof(Resources.ResourceAdmin))]
        public string Email { get; set; }

        [Display(Name = "UserCreatedDate", ResourceType = typeof(Resources.ResourceAdmin))]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "UserCreatedBy", ResourceType = typeof(Resources.ResourceAdmin))]
        public string CreatedBy { get; set; }

        [Display(Name = "UserIsLocked", ResourceType = typeof(Resources.ResourceAdmin))]
        public bool? LockedUser { get; set; }
        public bool? IsDeleted { get; set; }

        [Display(Name = "UserLockedDate", ResourceType = typeof(Resources.ResourceAdmin))]
        public DateTime? LockedDate { get; set; }

        [Display(Name = "UserLockedReason", ResourceType = typeof(Resources.ResourceAdmin))]
        public string LockedReason { get; set; }

        [DisplayName("Ngày đăng nhập")]
        public DateTime LastLogIn { get; set; }

        [DisplayName("Ngày đổi mật khẩu")]
        public DateTime LastChangedPassword { get; set; }

        [Display(Name = "UserDeadline", ResourceType = typeof(ResourceAdmin))]
        public DateTime DeadlineOfUsing { get; set; }

        [Display(Name = "UserBirthDay", ResourceType = typeof(Resources.ResourceAdmin))]
        public DateTime BirthDay { get; set; }

        [Display(Name = "Sex", ResourceType = typeof(Resources.ResourceAdmin))]
        public string Gender { get; set; }

        [DisplayName("Aavata")]
        [StringLength(250)]
        public string Image { get; set; }

        [Required(ErrorMessageResourceType = typeof(ResourceAdmin), ErrorMessageResourceName = "MobileRequired")]
        [Display(Name = "Mobile", ResourceType = typeof(Resources.ResourceAdmin))]
        public string Phone { get; set; }
    }
}
