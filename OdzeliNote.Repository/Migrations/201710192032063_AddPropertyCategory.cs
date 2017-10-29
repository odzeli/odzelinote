namespace OdzeliNote.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPropertyCategory : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "odzeliNote.Category", name: "Note_Id", newName: "NoteId");
            RenameIndex(table: "odzeliNote.Category", name: "IX_Note_Id", newName: "IX_NoteId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "odzeliNote.Category", name: "IX_NoteId", newName: "IX_Note_Id");
            RenameColumn(table: "odzeliNote.Category", name: "NoteId", newName: "Note_Id");
        }
    }
}
