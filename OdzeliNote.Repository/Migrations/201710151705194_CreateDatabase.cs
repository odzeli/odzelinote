namespace OdzeliNote.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "odzeliNote.Note",
                c => new
                    {
                        NoteId = c.Guid(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 500),
                        Text = c.String(),
                        Created = c.DateTime(nullable: false),
                        Changed = c.DateTime(nullable: false),
                        CategoryId = c.Guid(),
                        UserId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.NoteId)
                .ForeignKey("odzeliNote.Category", t => t.CategoryId)
                .ForeignKey("odzeliNote.Users", t => t.UserId)
                .Index(t => t.CategoryId)
                .Index(t => t.UserId);
            
            CreateTable(
                "odzeliNote.Category",
                c => new
                    {
                        CategoryId = c.Guid(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 1000),
                        Note_Id = c.Guid(),
                        UserId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryId)
                .ForeignKey("odzeliNote.Note", t => t.Note_Id)
                .ForeignKey("odzeliNote.Users", t => t.UserId)
                .Index(t => t.Note_Id)
                .Index(t => t.UserId);
            
            CreateTable(
                "odzeliNote.Users",
                c => new
                    {
                        UserId = c.Guid(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 1000),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "odzeliNote.Share",
                c => new
                    {
                        ShareId = c.Guid(nullable: false, identity: true),
                        NoteId = c.Guid(nullable: false),
                        UserId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ShareId)
                .ForeignKey("odzeliNote.Note", t => t.NoteId)
                .ForeignKey("odzeliNote.Users", t => t.UserId)
                .Index(t => t.NoteId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("odzeliNote.Share", "UserId", "odzeliNote.Users");
            DropForeignKey("odzeliNote.Share", "NoteId", "odzeliNote.Note");
            DropForeignKey("odzeliNote.Note", "UserId", "odzeliNote.Users");
            DropForeignKey("odzeliNote.Note", "CategoryId", "odzeliNote.Category");
            DropForeignKey("odzeliNote.Category", "UserId", "odzeliNote.Users");
            DropForeignKey("odzeliNote.Category", "Note_Id", "odzeliNote.Note");
            DropIndex("odzeliNote.Share", new[] { "UserId" });
            DropIndex("odzeliNote.Share", new[] { "NoteId" });
            DropIndex("odzeliNote.Category", new[] { "UserId" });
            DropIndex("odzeliNote.Category", new[] { "Note_Id" });
            DropIndex("odzeliNote.Note", new[] { "UserId" });
            DropIndex("odzeliNote.Note", new[] { "CategoryId" });
            DropTable("odzeliNote.Share");
            DropTable("odzeliNote.Users");
            DropTable("odzeliNote.Category");
            DropTable("odzeliNote.Note");
        }
    }
}
