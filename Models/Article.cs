using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project_AutoSuggestion_E_AppointmentApp.Models
{
    public class Article
    {

        [Key]
        public int ArticleId { get; set; }
        [Required(ErrorMessage = "Please enter your article name")]
        [Display(Name = "Article Name")]
        [DataType(DataType.Text)]
        [StringLength(20, MinimumLength = 6)]
        public string ArticleName { get; set; }

        [Required(ErrorMessage = "Please enter your article description!")]
        [Display(Name = "Article Description")]
        [DataType(DataType.MultilineText)]
        [StringLength(500, MinimumLength = 100)]
        public string ArticleDescription { get; set; }


        [Display(Name = "Article Image")]
        public string ArticleImage { get; set; }
    }
}