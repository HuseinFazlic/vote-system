//The following code was written by Almina Rascic//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VoteSystem.Models;

namespace VoteSystem.DAO
{
    public class VoteDAO
    {
        sql s = new sql();
        public bool VoteTry(int userid, int candidateid, string Type)
        {
            List<Vote> votes = s.Vote.Where(x => x.PersonId == userid).ToList();
            CandidateListCandidateDAO candidateListCandidateDAO = new CandidateListCandidateDAO();
            Vote vote = new Vote();
            switch (Type)
            {
                case "Mayors":
                    foreach (var x in votes)
                        if (s.CandidateListCandidate.Where(y => y.CandidateListId == x.CandidateListCandidateMyId && y.Mayor == true).Count() > 0)
                            return false;
                    if (s.Vote.Where(x => x.PersonId == userid).Count() != 0)
                        return false;
                    
                    vote.PersonId = userid;
                    vote.CandidateListCandidateMyId = candidateListCandidateDAO.GetCandidateIdByCandidateListCandidateId(candidateid);
                    s.Vote.Add(vote);
                    s.SaveChanges();
                    return true;
                case "Council":
                    if (votes.Count==0)
                    {
                        vote.PersonId = userid;
                        vote.CandidateListCandidateMyId = candidateListCandidateDAO.GetCandidateIdByCandidateListCandidateId(candidateid);
                        s.Vote.Add(vote);
                        s.SaveChanges();
                        return true;
                    }

                    Vote currentVoteFromDatabase = s.Vote.FirstOrDefault(y => y.PersonId == userid);
                    CandidateListCandidate currentCandidateListCandidateFromDatabase = s.CandidateListCandidate.FirstOrDefault(x => x.Id == currentVoteFromDatabase.CandidateListCandidateMyId);

                    int currentCanadidateId = candidateListCandidateDAO.GetCandidateIdByCandidateListCandidateId(candidateid);
                    CandidateListCandidate currentCandidate = s.CandidateListCandidate.SingleOrDefault(x => x.PersonId == currentCanadidateId);

                    if (currentCandidate!=null)
                    {
                        if (currentCandidateListCandidateFromDatabase.CandidateListId == currentCandidate.CandidateListId)
                        {
                            int id = candidateListCandidateDAO.GetCandidateIdByCandidateListCandidateId(candidateid);
                            Vote findDuplicated = s.Vote.SingleOrDefault(x => x.PersonId == userid && x.CandidateListCandidateMyId == id);

                            if (findDuplicated==null)
                            {
                                vote.PersonId = userid;
                                vote.CandidateListCandidateMyId = id;
                                s.Vote.Add(vote);
                                s.SaveChanges();
                                return true;
                            }
                            return false;
                        }
                    }
                    return false;
                default:
                    return false;
            }
        }
        public List<Vote> GetVotes()
        {
            return s.Vote.ToList();
        }
        public List<Vote> GetVotesByPersonId(int id)
        {
            return s.Vote.Where(x=>x.PersonId==id).ToList();
        }
    }
}