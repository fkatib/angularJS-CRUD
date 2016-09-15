using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace angularjs_crud_sample.Models
{
    public class NewsItem
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int NewsItemId { get; set; }
        public string NewsItemText { get; set; }
        public DateTime NewsItemDate { get; set; }
    }
}