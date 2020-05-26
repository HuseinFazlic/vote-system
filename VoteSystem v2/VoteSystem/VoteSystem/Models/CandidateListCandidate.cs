using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VoteSystem.Models
{
    public class CandidateListCandidate
    {
        public int Id { get; set; }
        public int CandidateListId { get; set; }
        public CandidateList CandidateList { get; set; }

        public int PersonId { get; set; }
        public Person Person { get; set; }
        public bool Mayor { get; set; }
    }
}