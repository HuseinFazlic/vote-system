using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using VoteSystem.Models;

namespace VoteSystem
{
    public class sql:DbContext
    {
        public sql() : base("con") { }
        public DbSet<Person> Person { get; set; }
        public DbSet<CandidateList> CandidateList { get; set; }
        public DbSet<CandidateListCandidate> CandidateListCandidate { get; set; }
        public DbSet<Vote> Vote { get; set; }
    }
}