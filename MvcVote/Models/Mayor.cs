using System;
using System.Collections;
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
    public class Mayor
    {   
        [StringLength(13, ErrorMessage = "JMBG sadrži 13 cifara", MinimumLength = 13)]
        [Display(Name = "JMBG / ЈМБГ")]
        [RegularExpression("^[0-9]{13}?")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public string Id { get; set; }
        
        // Ime
        [Display(Name = "Ime / Име")]
        public string Name { get; set; }
        
        // Prezime  
        [Display(Name = "Prezime / Презиме")]
        public string Surname { get; set; }
        
        // Općina
        [Display(Name = "Općina / Општина")]
        public string Municipality { get; set; }
        
        // Partija  
        [Display(Name = "Partija / Партија")]
        public string Party { get; set; }
        
        // Broj glasova
        [Display(Name = "Broj glasova / Број гласова")]
        public int VoteCount { get; set; }
    }
}