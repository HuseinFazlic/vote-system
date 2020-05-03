using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
/*
 * This class was written by Husein Fazlić
 */
namespace MvcVote.Models
{
    public class Councillor
    {
        // JMBG
        [Required]
        [Display(Name = "JMBG / ЈМБГ")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public string Id { get; set; }
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
        // Broj na listi
        [Required]
        [Display(Name = "Redni broj / Redni broj")]
        public int Position { get; set; }
        [Required]
        [Display(Name = "Broj glasova / Број гласова")]
        public int VoteCount { get; set; }
    }
}
