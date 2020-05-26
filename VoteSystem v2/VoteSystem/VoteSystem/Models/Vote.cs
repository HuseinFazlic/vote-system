using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VoteSystem.Models
{
    public class Vote
    {
        public int Id { get; set; }
        public int CandidateListCandidateMyId { get; set; }
        public CandidateListCandidate CandidateListCandidate { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
        

    }
}