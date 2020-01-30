namespace LibraryManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.User", "AddressId", "dbo.Address");
            DropForeignKey("dbo.Book", "PublisherId", "dbo.Publisher");
            DropForeignKey("dbo.Book", "AuthorId", "dbo.Author");
            DropIndex("dbo.Book", new[] { "AuthorId" });
            DropIndex("dbo.Book", new[] { "PublisherId" });
            DropIndex("dbo.User", new[] { "AddressId" });
            AlterColumn("dbo.Book", "AuthorId", c => c.Int());
            AlterColumn("dbo.Book", "PublisherId", c => c.Int());
            AlterColumn("dbo.User", "AddressId", c => c.Int());
            CreateIndex("dbo.Book", "AuthorId");
            CreateIndex("dbo.Book", "PublisherId");
            CreateIndex("dbo.User", "AddressId");
            AddForeignKey("dbo.User", "AddressId", "dbo.Address", "Id");
            AddForeignKey("dbo.Book", "PublisherId", "dbo.Publisher", "Id");
            AddForeignKey("dbo.Book", "AuthorId", "dbo.Author", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Book", "AuthorId", "dbo.Author");
            DropForeignKey("dbo.Book", "PublisherId", "dbo.Publisher");
            DropForeignKey("dbo.User", "AddressId", "dbo.Address");
            DropIndex("dbo.User", new[] { "AddressId" });
            DropIndex("dbo.Book", new[] { "PublisherId" });
            DropIndex("dbo.Book", new[] { "AuthorId" });
            AlterColumn("dbo.User", "AddressId", c => c.Int(nullable: false));
            AlterColumn("dbo.Book", "PublisherId", c => c.Int(nullable: false));
            AlterColumn("dbo.Book", "AuthorId", c => c.Int(nullable: false));
            CreateIndex("dbo.User", "AddressId");
            CreateIndex("dbo.Book", "PublisherId");
            CreateIndex("dbo.Book", "AuthorId");
            AddForeignKey("dbo.Book", "AuthorId", "dbo.Author", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Book", "PublisherId", "dbo.Publisher", "Id", cascadeDelete: true);
            AddForeignKey("dbo.User", "AddressId", "dbo.Address", "Id", cascadeDelete: true);
        }
    }
}
