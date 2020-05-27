using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VoteSystem.Models;

namespace VoteSystem.DAO
{
    public class PersonDAO
    {
        sql s = new sql();
        public Person FindPersonByJMBG(string JMBG)
        {
            return s.Person.SingleOrDefault(x => x.JMBG == JMBG);
        }
        public Person FindPersonById(int id)
        {
            return s.Person.SingleOrDefault(x => x.Id == id);
        }
        public void Save(Person person)
        {
            s.Person.Add(person);
            s.SaveChanges();
        }
    }
}
