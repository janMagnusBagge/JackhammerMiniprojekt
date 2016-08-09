namespace JackhammerMiniprojekt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateAndCategoryToHighscore : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Highscores", "Category", c => c.Int(nullable: false));
            AddColumn("dbo.Highscores", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Highscores", "Date");
            DropColumn("dbo.Highscores", "Category");
        }
    }
}
