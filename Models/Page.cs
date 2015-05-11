using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PageCMS2.Models
{
    public class Page
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }


        public virtual Category Category { get; set; }
        public virtual ICollection<Section> Sections { get; set; }
    }
}