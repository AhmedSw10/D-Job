using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DJobA.Models
{
    public class Category
    {
        public int id { get; set; }

        [Required]
        [Display(Name = "Job Category")]
        public String CategoryJob { get; set; }
        [Required]
        [Display(Name = "Job name")]
        public String JobType { get; set; }

        public virtual ICollection<Job> Job { get; set; }
        


    }
}