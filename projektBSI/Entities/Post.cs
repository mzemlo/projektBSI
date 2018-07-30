using projektBSI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace projektBSI.Entities
{
    public class Post
    {
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Pole nie może być puste")]
        [Display(Name = "Tytuł")]
        public string Title { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Pole nie może być puste")]
        [Display(Name = "Treść")]
        public string Article { get; set; }
        public DateTime DateOfPublication { get; set; }
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }

    }
}