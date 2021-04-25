namespace GigHub.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddFollowersTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Followers",
                c => new
                {
                    UserId = c.String(nullable: false, maxLength: 128),
                    FolloweeId = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => new { t.UserId, t.FolloweeId })
                .ForeignKey("dbo.AspNetUsers", t => t.FolloweeId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.FolloweeId);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Followers", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Followers", "FolloweeId", "dbo.AspNetUsers");
            DropIndex("dbo.Followers", new[] { "FolloweeId" });
            DropIndex("dbo.Followers", new[] { "UserId" });
            DropTable("dbo.Followers");
        }
    }
}
