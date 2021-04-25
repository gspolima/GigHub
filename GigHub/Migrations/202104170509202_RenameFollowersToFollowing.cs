namespace GigHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameFollowersToFollowing : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Followers", "FolloweeId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Followers", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Followers", new[] { "UserId" });
            DropIndex("dbo.Followers", new[] { "FolloweeId" });
            CreateTable(
                "dbo.Followings",
                c => new
                    {
                        FollowerId = c.String(nullable: false, maxLength: 128),
                        FolloweeId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.FollowerId, t.FolloweeId })
                .ForeignKey("dbo.AspNetUsers", t => t.FollowerId)
                .ForeignKey("dbo.AspNetUsers", t => t.FolloweeId)
                .Index(t => t.FollowerId)
                .Index(t => t.FolloweeId);
            
            DropTable("dbo.Followers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Followers",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        FolloweeId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.FolloweeId });
            
            DropForeignKey("dbo.Followings", "FolloweeId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Followings", "FollowerId", "dbo.AspNetUsers");
            DropIndex("dbo.Followings", new[] { "FolloweeId" });
            DropIndex("dbo.Followings", new[] { "FollowerId" });
            DropTable("dbo.Followings");
            CreateIndex("dbo.Followers", "FolloweeId");
            CreateIndex("dbo.Followers", "UserId");
            AddForeignKey("dbo.Followers", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Followers", "FolloweeId", "dbo.AspNetUsers", "Id");
        }
    }
}
