using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VoteSystem.Models;

namespace VoteSystem.DAO
{
    public class CandidateListCandidateDAO
    {
        sql s = new sql();
        public List<CandidateListCandidate> GetCandidateListCandidatesByCandidateListId(int id)
        {
            return s.CandidateListCandidate.Where(x => x.CandidateListId == id).ToList();
        }
        public int GetCandidateIdByCandidateListCandidateId(int id)
        {
            return s.CandidateListCandidate.SingleOrDefault(x => x.PersonId == id).Id;
        }
        public List<CandidateListCandidate> GetAllByCandiudateListsId(int id)
        {
            return s.CandidateListCandidate.Where(x => x.CandidateListId == id).ToList();
        }
    }
}