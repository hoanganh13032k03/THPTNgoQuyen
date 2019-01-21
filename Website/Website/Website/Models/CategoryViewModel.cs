using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models
{
   
    public class CategoryViewModel

    {
        public long CategoryID { get; set; }
        public string Name { get; set; }
        public string MetaTite { get; set; }
        public long? ParentID { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public int DisplayOrder { get; set; }
        public string SeoTite { get; set; }
        public string MetakeyWords { get; set; }
        public string MetaDescription { get; set; }
        public bool Status { get; set; }
        public bool ShowOnHome { get; set; }
        public byte Position { get; set; }
        public string LanguageID { get; set; }
        public List<CategoryViewModel> Children { get; set; }
    }
}