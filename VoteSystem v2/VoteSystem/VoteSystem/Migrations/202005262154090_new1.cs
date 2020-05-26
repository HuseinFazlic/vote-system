namespace VoteSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CandidateLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        URLLogo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CandidateListCandidates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CandidateListId = c.Int(nullable: false),
                        PersonId = c.Int(nullable: false),
                        Mayor = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CandidateLists", t => t.CandidateListId, cascadeDelete: true)
                .ForeignKey("dbo.People", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.CandidateListId)
                .Index(t => t.PersonId);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        PlaceBirth = c.String(),
                        Gender = c.String(),
                        MaritalStatus = c.String(),
                        Address = c.String(),
                        Job = c.String(),
                        JMBG = c.String(),
                        Candidate = c.Boolean(nullable: false),
                        Mayor = c.Boolean(),
                        Council = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Votes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CandidateListCandidateMyId = c.Int(nullable: false),
                        PersonId = c.Int(nullable: false),
                        CandidateListCandidate_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CandidateListCandidates", t => t.CandidateListCandidate_Id)
                .ForeignKey("dbo.People", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.PersonId)
                .Index(t => t.CandidateListCandidate_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Votes", "PersonId", "dbo.People");
            DropForeignKey("dbo.Votes", "CandidateListCandidate_Id", "dbo.CandidateListCandidates");
            DropForeignKey("dbo.CandidateListCandidates", "PersonId", "dbo.People");
            DropForeignKey("dbo.CandidateListCandidates", "CandidateListId", "dbo.CandidateLists");
            DropIndex("dbo.Votes", new[] { "CandidateListCandidate_Id" });
            DropIndex("dbo.Votes", new[] { "PersonId" });
            DropIndex("dbo.CandidateListCandidates", new[] { "PersonId" });
            DropIndex("dbo.CandidateListCandidates", new[] { "CandidateListId" });
            DropTable("dbo.Votes");
            DropTable("dbo.People");
            DropTable("dbo.CandidateListCandidates");
            DropTable("dbo.CandidateLists");
        }
    }
}
