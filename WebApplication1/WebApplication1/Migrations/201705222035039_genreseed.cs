namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class genreseed : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO GENRES(Id, Name) VALUES(1, 'Action')");
        }
        
        public override void Down()
        {
        }
    }
}
