using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcVote.Models;
/*
 * This class was written by Husein Fazlić
 */
namespace MvcVote.Data
{
    public class MvcVoteContext : DbContext
    {
        public MvcVoteContext(DbContextOptions<MvcVoteContext> options)
            : base(options)
        {
        }

        public DbSet<Voter> Voter { get; set; }
        public DbSet<Mayor> Mayor { get; set; }
        public DbSet<Councillor> Councillor { get; set; }
    }
}
