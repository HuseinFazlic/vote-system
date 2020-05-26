using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VoteSystem.DAO;
using VoteSystem.Models;

namespace VoteSystem.Controllers
{
    public class VoteController : Controller
    {
        // GET: Vote
        public ActionResult Index(string Error)
        {
            CandidateListDAO candidateListDAO = new CandidateListDAO();
            ViewData["CandidateList"] = candidateListDAO.GetAll();
            ViewData["Error"] = Error;

            int SelectGroup = -1;
            if (Request.Cookies["SelectedGrpup"] != null)
            {
                SelectGroup = Int32.Parse(Request.Cookies["SelectedGrpup"].Value);

                CandidateListCandidateDAO candidateListCandidateDAO = new CandidateListCandidateDAO();
                PersonDAO personDAO = new PersonDAO();
                List<CandidateListCandidate> candidateListCandidates = candidateListCandidateDAO.GetCandidateListCandidatesByCandidateListId(SelectGroup);
                List<Person> persons = new List<Person>();
                foreach (var x in candidateListCandidates)
                {
                    Person p = personDAO.FindPersonById(x.PersonId);
                    persons.Add(p);
                }
                ViewData["Candidates"] = persons.OrderBy(x=>x.Mayor).ToList();
            }
            else
                ViewData["Candidates"] = null;

            return View();
        }
        public ActionResult SelectGroup(int Id)
        {
            HttpCookie cookie = new HttpCookie("SelectedGrpup", Id.ToString());
            cookie.Expires = DateTime.Now.AddYears(1);
            Response.Cookies.Add(cookie);
            return RedirectToAction("Index");
        }
        public ActionResult Vote(int id, string Type)
        {
            int UserId = -1;
            if (Request.Cookies["Person"] != null)
            {
                UserId = Int32.Parse(Request.Cookies["Person"].Value);

                VoteDAO voteDAO = new VoteDAO();
                bool success = voteDAO.VoteTry(UserId, id, Type);
                return RedirectToAction("Index", new { Error = success });
            }
            return RedirectToAction("Index", new { Error = "User not exist." });
        }
        public ActionResult End()
        {
            string[] myCookies = Request.Cookies.AllKeys;
            foreach (string cookie in myCookies)
                Response.Cookies[cookie].Expires = DateTime.Now.AddYears(-2);
            return RedirectToAction("", "Home");
        }
    }
}