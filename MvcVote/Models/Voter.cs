using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
/*
 * This class was written by Husein Fazlić
 */
namespace MvcVote.Models
{
    public class Voter
    {
        // Jedinstveni Matični Broj Građanina (JMBG)
        [Required]
		//[StringLength(13, ErrorMessage = "JMBG sadrži 13 cifara", MinimumLength = 13)]
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
        // Da li je osoba već glasala ili ne?
        [Display(Name = "Glasala / Гласала")]
        public bool didVote { get; set; }
    }
}
