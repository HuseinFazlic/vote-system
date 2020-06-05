//The following code was written by Nejra Trle
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VoteSystem.Models;

namespace VoteSystem.DAO
{
    public class CandidateListDAO
    {
        sql s = new sql();
        public List<CandidateList> GetAll()
        {
            return s.CandidateList.ToList();
        }
    }
}
