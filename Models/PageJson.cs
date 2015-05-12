using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PageCMS2.Models
{
    public class PageJson
    {
        public class PageCategoryViewModel
        {
            public int ID { get; set; }

            public string Title { get; set; }
            public string Description { get; set; }

            
            public virtual Category Category { get; set; }
            [JsonIgnore]
            public virtual ICollection<Section> Sections { get; set; }
        }
    }
}