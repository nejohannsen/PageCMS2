using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PageCMS2.Models
{
    public class PageCategoryViewModel
    {
        public int ID { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_]+$", ErrorMessage = "Title can not have space of special charters except underscores")]
        public string Title { get; set; }
        public string Description { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_]+$", ErrorMessage = "Category can not have space of special charters except underscores")]
        public string Category { get; set; }
    }

    public class SectionForPage
    {
        public int ID { get; set; }

        public string Position { get; set; }
        public string Value { get; set; }
        public string Page { get; set; }
    }
}