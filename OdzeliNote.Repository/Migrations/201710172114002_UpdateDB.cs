namespace OdzeliNote.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDB : DbMigration
    {
        public override void Up()
        {
            AlterColumn("odzeliNote.Note", "Created", c => c.DateTime());
            AlterColumn("odzeliNote.Note", "Changed", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("odzeliNote.Note", "Changed", c => c.DateTime(nullable: false));
            AlterColumn("odzeliNote.Note", "Created", c => c.DateTime(nullable: false));
        }
    }
}
