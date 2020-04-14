using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcVote.Models
{
    public class Councillor
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Municipality { get; set; }
        public string Party { get; set; }
        public int Position { get; set; }
        public int VoteCount { get; set; }
    }
}
