using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VoteSystem.Models
{
    public class CandidateList
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string URLLogo { get; set; }
        [NotMapped]
        public int Votes { get; set; }
    }
}