using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace projektBSI.Models
{
    public class PostModel
    {
        public int Id { get; set; }
        [Display(Name = "Tytuł")]
        public string Title { get; set; }
        public string Article { get; set; }
        public DateTime DateOfPublication { get; set; }
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }
        [Display(Name = "Autor")]
        public string Signature { get; set; }
    }
}