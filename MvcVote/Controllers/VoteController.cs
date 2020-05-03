using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MvcVote.Data;
using MvcVote.Models;

/*
 * This class was written by Husein Fazlić
 */
namespace MvcVote.Controllers
{
    public class VoteController : Controller
    {
        private readonly MvcVoteContext _context;
        private readonly MvcVoteContext db = null;
        private static string currentVoterId = " ";
        private static string currentVoterMunicipality = " ";
        private static bool isSignedIn = false;

        public VoteController(MvcVoteContext context, MvcVoteContext db)
        {
            _context = context;
            this.db = db;
        }
        /*
         * Written by Husein Fazlić
         * This method is responsible for rendering login to user
         */
        public IActionResult SignIn()
        {
            return View();
        }
        /*
         * Written by Husein Fazlić
         * This method is responsible for ensuring proper sign in (login)
         * Form data from view sent to controller via POST method
         * Database: MvcVoteContext-1; Tables: Voter
         * User input compared to existing records in database
         * If valid proceed to voting page
         * Else message issued
         */
        [HttpPost]
        public IActionResult SignIn(Voter voter)
        {
            // Stores user input in local variables
            string JMBG = voter.Id;
            string name = voter.Name;
            string surname = voter.Surname;
            currentVoterId = JMBG;
            // Sets a new voting session
            bool didVoted = false;
            /* The idea below was taken and modified from https://stackoverflow.com/questions/21302244/check-if-a-record-exists-in-the-database */
            // Connecting to the database
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString =
              "Data Source=(localdb)\\mssqllocaldb;" +
              "Initial Catalog=MvcVoteContext-1;";
            conn.Open();
            // Trying to find this voter in database
            SqlCommand currentVoter = new SqlCommand("SELECT * FROM [Voter] WHERE (([Id] = @currentId) AND ([Name] = @currentName) AND [Surname] = @currentSurname) AND [didVote] = @currentVoteStatus", conn);
            currentVoter.Parameters.AddWithValue("@currentId", JMBG);
            currentVoter.Parameters.AddWithValue("@currentName", name);
            currentVoter.Parameters.AddWithValue("@currentSurname", surname);
            currentVoter.Parameters.AddWithValue("@currentVoteStatus", didVoted);
            // Reading values to be used in generating voter's specific municipality
            SqlDataReader reader = currentVoter.ExecuteReader();
            if (reader.Read())
            {
                // read data to find municipality
                currentVoterMunicipality = reader[3].ToString();
                
                
                isSignedIn = true;
                return RedirectToAction("MayorVote", "Vote");
            }
            else
            {
                return Content("Vi ste već glasali ili ste unijeli pogrešne podatke.");
            }
        }
        /*
         * Written by Husein Fazlić
         * This method is responsible for rendering voting for mayor page to user
         * Database: MvcVoteContext-1; Table: Mayor
         * Mayor: List of mayors is created from appropriate municipality
         */
        public IActionResult MayorVote()
        {
            if (!isSignedIn)
                return RedirectToAction("SignIn", "Vote");

            List<Mayor> model = (from e in db.Mayor
                                 where e.Municipality == currentVoterMunicipality
                                 orderby e.Party
                                 select new Mayor { Id = e.Id, Name = e.Name, Surname = e.Surname, Party = e.Party }).ToList();


            return View(model);
        }
        /*
         * Written by Husein Fazlić
         * This method is responsible for ensuring proper vote for mayor
         * Form data from view sent to controller via POST method
         * Database: MvcVoteContext-1; Tables: Voter, Mayor
         * Voter: Status of voter who voted is changed from not voted to voted
         * Mayor: VoteCount of Mayor who was chosen incremented by one
         */
        [HttpPost]
        public IActionResult MayorVote(string mayorVote)
        {
            string Id = mayorVote;//PROMJENA
            int vCount = 0;
            string sqlString = null;
            bool affected = false;
            // Establish and open connection with a database
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString =
              "Data Source=(localdb)\\mssqllocaldb;" +
              "Initial Catalog=MvcVoteContext-1;" +
              "MultipleActiveResultSets = true";
            conn.Open();
            // Define query
            sqlString = "SELECT* FROM Mayor WHERE Id = @currentId";
            SqlCommand currentMayor1 = new SqlCommand(sqlString, conn);
            currentMayor1.Parameters.AddWithValue("@currentId", Id);

            SqlDataReader reader = currentMayor1.ExecuteReader();
            if (reader.Read())
            {
                vCount = reader.GetInt32(5);
                vCount += 1;
                affected = true;
                reader.Close();
                string JMBG = currentVoterId;
                if (affected)
                {
                    sqlString = "UPDATE Mayor SET VoteCount = @newCount WHERE Id = @newId";
                    currentMayor1.CommandText = sqlString;
                    currentMayor1.Parameters.AddWithValue("@newCount", vCount);
                    currentMayor1.Parameters.AddWithValue("@newId", Id);
                    currentMayor1.ExecuteNonQuery();
                    conn.Close();

                    conn.Open();
                    sqlString = "UPDATE Voter SET didVote = 1 WHERE Id = @voterId";
                    SqlCommand currentVoter = new SqlCommand(sqlString, conn);
                    currentVoter.Parameters.AddWithValue("@voterId", JMBG);
                    currentVoter.ExecuteNonQuery();
                    conn.Close();

                    isSignedIn = false;

                    return RedirectToAction("Aftermath", "Vote");
                }
            }
            return Content("Vi ste već glasali ili ste unijeli pogrešne podatke.");
        }
        /*
         * Written by Husein Fazlić
         * This method is responsible for displaying the aftermath of the voting process
         */
        public IActionResult Aftermath()
        {
            return Content("Hvala Vam na izdvojenom vremenu / Хвала Вам ха издвојеном времену");
        }        
    }
}