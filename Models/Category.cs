using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PageCMS2.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        [JsonIgnore]
        public virtual ICollection<Page> Pages { get; set; }
    }
}