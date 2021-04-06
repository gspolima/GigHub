namespace GigHub.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class InsertGenresIntoGenresTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO GENRES (ID,NAME) VALUES (1, 'Rock')");
            Sql("INSERT INTO GENRES (ID,NAME) VALUES (2, 'Jazz')");
            Sql("INSERT INTO GENRES (ID,NAME) VALUES (3, 'Classic')");
            Sql("INSERT INTO GENRES (ID,NAME) VALUES (4, 'Electronic')");
            Sql("INSERT INTO GENRES (ID,NAME) VALUES (5, 'Country')");
            Sql("INSERT INTO GENRES (ID,NAME) VALUES (6, 'Folk')");
        }

        public override void Down()
        {
            Sql("DELETE FROM GENRES WHERE ID IN (1,2,3,4,5,6)");
        }
    }
}