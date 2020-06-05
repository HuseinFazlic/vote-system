//The following code was written by Almina Rascic//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VoteSystem.DAO;
using VoteSystem.Models;

namespace VoteSystem.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        public ActionResult Index(string error)
        {
            ViewData["err"] = error;
            return View();
        }
        public ActionResult Save(string FirstName, string LastName, string PlaceBirth, string Gender, string Marttial, string Address, string Job, string WorkPlace, string JMBG)
        {
            PersonDAO personDAO = new PersonDAO();
            Person person = personDAO.FindPersonByJMBG(JMBG);
            if (person != null)
            {
                VoteDAO voteDAO = new VoteDAO();
                List<Vote> votes = voteDAO.GetVotesByPersonId(person.Id);
                if (votes.Count()==0)
                {
                    HttpCookie cookie = new HttpCookie("Person", person.Id.ToString());
                    cookie.Expires = DateTime.Now.AddYears(1);
                    Response.Cookies.Add(cookie);

                    return RedirectToAction("", "Vote");
                }
                return View("Index", new { error = "Person is created in database." });
            }
            else
            {
                person = new Person();
                person.FirstName = FirstName;
                person.LastName = LastName;
                person.PlaceBirth = PlaceBirth;
                person.Gender = Gender;
                person.MaritalStatus = Marttial;
                person.Address = Address;
                person.Job = Job;
                person.WorkPlace = WorkPlace;
                person.JMBG = JMBG;
                person.Candidate = true;
                personDAO.Save(person);

                HttpCookie cookie = new HttpCookie("Person", person.Id.ToString());
                cookie.Expires = DateTime.Now.AddYears(1);
                Response.Cookies.Add(cookie);

                return RedirectToAction("", "Vote");
            }
        }
    }
}