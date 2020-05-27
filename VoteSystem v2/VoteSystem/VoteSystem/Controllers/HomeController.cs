using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VoteSystem.DAO;
using VoteSystem.Models;

namespace VoteSystem.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            CandidateListDAO candidateListDAO = new CandidateListDAO();
            ViewData["NumberCandidateLists"] = candidateListDAO.GetAll();

            int Statistics = -1;
            if (Request.Cookies["Statistics"] != null)
                Statistics = Int32.Parse(Request.Cookies["Statistics"].Value);
           
            CandidateListCandidateDAO candidateListCandidateDAO = new CandidateListCandidateDAO();
            List<CandidateListCandidate> candidateListCandidates = candidateListCandidateDAO.GetAllByCandiudateListsId(Statistics);
            if (candidateListCandidates==null)
                candidateListCandidates = new List<CandidateListCandidate>();
            ViewData["CandidateListCandidate"] = candidateListCandidates.OrderBy(x=>x.Mayor).ToList();

            VoteDAO voteDAO = new VoteDAO();
            List<Vote> voteDAOList = voteDAO.GetVotes();
            if (voteDAOList == null)
                voteDAOList = new List<Vote>();
            ViewData["Vote"] = voteDAOList;

            PersonDAO personDAO = new PersonDAO();
            List<Person> persons = personDAO.GetAllPersons();
            ViewData["Persons"] = persons;

            int StatisticsCandidate = -1;
            if (Request.Cookies["CandidateIdForHome"] != null)
            {
                StatisticsCandidate = Int32.Parse(Request.Cookies["Statistics"].Value);
                int NumberVotes = voteDAO.GetVotesByCandidateId(StatisticsCandidate).Count();
                ViewData["NumberVotes"] = NumberVotes;
            }
            else
                ViewData["NumberVotes"] = 0;


            return View();
        }
        public ActionResult ChangeLanmguage(string id)
        {
            HttpCookie cookie;
            
            switch (id)
            {
                case "ba": cookie = new HttpCookie("language", "ba"); break;
                case "bac": cookie = new HttpCookie("language", "bac"); break;
                case "en": cookie = new HttpCookie("language", "en"); break;
                default: cookie = new HttpCookie("language", "ba"); break;
            }
            cookie.Expires = DateTime.Now.AddYears(1);
            Response.Cookies.Add(cookie);
            return RedirectToAction("Index");
        }

        public ActionResult Statistics(string id)
        {
            HttpCookie cookie = new HttpCookie("Statistics", id);
            cookie.Expires = DateTime.Now.AddMinutes(1);
            Response.Cookies.Add(cookie);
            return RedirectToAction("Index");
        }
        public ActionResult StatisticsCandidate(string id)
        {
            HttpCookie cookie = new HttpCookie("CandidateIdForHome", id);
            cookie.Expires = DateTime.Now.AddMinutes(1);
            Response.Cookies.Add(cookie);
            return RedirectToAction("Index");
        }
    }
}
