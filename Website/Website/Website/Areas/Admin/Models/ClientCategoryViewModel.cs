
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website.Areas.Models
{
    public class ClientCategoryViewModel
    {
        public long ID { get; set; }
        public string Text { get; set; }
        public string Decription { get; set; }
        public int Order { set; get; }
        public bool IsLocked { set; get; }
        public DateTime CreatedDate { set; get; }
    }
}