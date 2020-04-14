using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MvcVote.Models
{
    public class Mayor
    {
        [Required]
        //[StringLength(13, ErrorMessage = "JMBG sadrži 13 cifara", MinimumLength = 13)]
        [Display(Name = "JMBG / ЈМБГ")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public long Id { get; set; }
        // Ime
        [Required]
        [Display(Name = "Ime / Име")]
        public string Name { get; set; }
        // Prezime
        [Required]
        [Display(Name = "Prezime / Презиме")]
        public string Surname { get; set; }
        // Općina
        [Required]
        [Display(Name = "Općina / Општина")]
        public string Municipality { get; set; }
        // Partija
        [Required]
        [Display(Name = "Partija / Партија")]
        public string Party { get; set; }
        // Broj glasova
        [Required]
        [Display(Name = "Broj glasova / Број гласова")]
        public int VoteCount { get; set; }
    }
}
