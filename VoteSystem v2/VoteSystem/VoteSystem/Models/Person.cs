//The following code was written by Nejra Trle 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VoteSystem.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PlaceBirth { get; set; }
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }
        public string Address { get; set; }
        public string Job { get; set; }
       
        public string JMBG { get; set; }
        public bool Candidate { get; set; }
        public bool? Mayor { get; set; }
        public bool? Council { get; set; }
    }
} 
