using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PageCMS2.Models
{
    public class Section
    {
        public int ID { get; set; }
        public int Position { get; set; }
        [DataType(DataType.MultilineText)]
        public string Value { get; set; }

        public virtual Page Page { get; set; }
    }
}