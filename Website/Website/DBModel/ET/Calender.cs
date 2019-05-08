namespace DBModel.ET
{
    using Resources;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Calender")]
    public partial class Calender
    {

     
        public long CalenderID { get; set; }

        [Display(Name = "CategoryParentID", ResourceType = typeof(Resources.ResourceAdmin))]
        public long GroupID { get; set; }

        [StringLength(250)]
        [Display(Name = "Images", ResourceType = typeof(Resources.ResourceAdmin))]
        public string Image { get; set; }

        [StringLength(250, ErrorMessageResourceType = typeof(ResourceAdmin), ErrorMessageResourceName = "TitleLong")]
        [Display(Name = "Title", ResourceType = typeof(Resources.ResourceAdmin))]
        public string Tite { get; set; }

        [Display(Name = "Date_Start", ResourceType = typeof(Resources.ResourceAdmin))]
        public DateTime Date_Start { get; set; }

        public int Hour_Start { get; set; }

        public int Minutes_Start { get; set; }

        [DisplayName("Bắt đầu")]
        public int Status_Start { get; set; }

        [Display(Name = "Date_End", ResourceType = typeof(Resources.ResourceAdmin))]
        public DateTime Date_End { get; set; }

        public int Hour_End { get; set; }

        public int Minutes_End { get; set; }

        [DisplayName("Kết thúc")]
        public int Status_End { get; set; }

    
        [DisplayName("Nội dung")]
        public string Detail { get; set; }

        [StringLength(255)]
        [DisplayName("Địa điểm")]
        public string Place { get; set; }

        [StringLength(255)]
        [DisplayName("Thành phần")]
        public string Organization { get; set; }

        [StringLength(255)]
        [DisplayName("Chuẩn bị")]
        public string Prepared { get; set; }

        [StringLength(255)]
        [Display(Name = "File", ResourceType = typeof(Resources.ResourceAdmin))]
        public string Files { get; set; }

        [Display(Name = "Options", ResourceType = typeof(Resources.ResourceAdmin))]
        public byte Options { get; set; }

        [Display(Name = "CreatedDate", ResourceType = typeof(Resources.ResourceAdmin))]
        public DateTime CreateDate { get; set; }

        [StringLength(100)]
        [Display(Name = "CreatedBy", ResourceType = typeof(Resources.ResourceAdmin))]
        public string CreateBy { get; set; }

        [StringLength(100)]
        [Display(Name = "UpdatedBy", ResourceType = typeof(Resources.ResourceAdmin))]
        public string ModifiedBy { get; set; }

        [Display(Name = "UpdatedDate", ResourceType = typeof(Resources.ResourceAdmin))]
        public DateTime ModifiedDate { get; set; }

        [Display(Name = "MetaKeywords", ResourceType = typeof(Resources.ResourceAdmin))]
        [StringLength(250, ErrorMessageResourceType = typeof(ResourceAdmin), ErrorMessageResourceName = "CategoryNameLong")]
        public string MetakeyWords { get; set; }

        [Display(Name = "MetaDescription", ResourceType = typeof(Resources.ResourceAdmin))]
        [StringLength(250, ErrorMessageResourceType = typeof(ResourceAdmin), ErrorMessageResourceName = "CategoryNameLong")]
        public string MetaDescription { get; set; }

        [Display(Name = "Active", ResourceType = typeof(Resources.ResourceAdmin))]
        public bool Active { get; set; }

        [DisplayName("Ngày duyệt")]
        public DateTime ActiveDate { get; set; }

        [Display(Name = "Status", ResourceType = typeof(Resources.ResourceAdmin))]
        public bool Publish { get; set; }

        [DisplayName("Ngày hết hạn")]
        public DateTime PublishDate { get; set; }
        [Display(Name = "ShowOnHome", ResourceType = typeof(Resources.ResourceAdmin))]
        public bool ShowOnHome { get; set; }

        [StringLength(5)]
        [Display(Name = "LanguageCode", ResourceType = typeof(Resources.ResourceAdmin))]
        public string LanguageID { get; set; }
    }
}
