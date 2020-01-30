namespace LibraryManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Address",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AddressLine1 = c.String(nullable: false),
                        AddressLine2 = c.String(),
                        City = c.String(nullable: false),
                        State = c.String(nullable: false),
                        Country = c.String(nullable: false),
                        Pincode = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Publisher",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        AddressId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Address", t => t.AddressId, cascadeDelete: true)
                .Index(t => t.AddressId);
            
            CreateTable(
                "dbo.Book",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        AuthorId = c.Int(nullable: false),
                        PublisherId = c.Int(nullable: false),
                        TotalCount = c.Int(nullable: false),
                        AvailableCount = c.Int(nullable: false),
                        BorrowedCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Author", t => t.AuthorId, cascadeDelete: true)
                .ForeignKey("dbo.Publisher", t => t.PublisherId, cascadeDelete: true)
                .Index(t => t.AuthorId)
                .Index(t => t.PublisherId);
            
            CreateTable(
                "dbo.Author",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Specification = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BorrowedBy",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IssueDate = c.DateTime(nullable: false),
                        ReturnDate = c.DateTime(nullable: false),
                        IsReturned = c.Boolean(nullable: false),
                        MemberId = c.Int(nullable: false),
                        BookId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Book", t => t.BookId, cascadeDelete: true)
                .ForeignKey("dbo.Member", t => t.MemberId, cascadeDelete: true)
                .Index(t => t.MemberId)
                .Index(t => t.BookId);
            
            CreateTable(
                "dbo.Member",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TypeOfMembership = c.Int(nullable: false),
                        IsStudent = c.Boolean(nullable: false),
                        ExpiryDate = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        MobileNumber = c.String(),
                        AddressId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        LoginDetailId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Address", t => t.AddressId, cascadeDelete: false)
                .ForeignKey("dbo.LoginDetail", t => t.LoginDetailId, cascadeDelete: true)
                .Index(t => t.AddressId)
                .Index(t => t.LoginDetailId);
            
            CreateTable(
                "dbo.LoginDetail",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LoginName = c.String(),
                        Password = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Book", "PublisherId", "dbo.Publisher");
            DropForeignKey("dbo.Member", "UserId", "dbo.User");
            DropForeignKey("dbo.User", "LoginDetailId", "dbo.LoginDetail");
            DropForeignKey("dbo.User", "AddressId", "dbo.Address");
            DropForeignKey("dbo.BorrowedBy", "MemberId", "dbo.Member");
            DropForeignKey("dbo.BorrowedBy", "BookId", "dbo.Book");
            DropForeignKey("dbo.Book", "AuthorId", "dbo.Author");
            DropForeignKey("dbo.Publisher", "AddressId", "dbo.Address");
            DropIndex("dbo.User", new[] { "LoginDetailId" });
            DropIndex("dbo.User", new[] { "AddressId" });
            DropIndex("dbo.Member", new[] { "UserId" });
            DropIndex("dbo.BorrowedBy", new[] { "BookId" });
            DropIndex("dbo.BorrowedBy", new[] { "MemberId" });
            DropIndex("dbo.Book", new[] { "PublisherId" });
            DropIndex("dbo.Book", new[] { "AuthorId" });
            DropIndex("dbo.Publisher", new[] { "AddressId" });
            DropTable("dbo.LoginDetail");
            DropTable("dbo.User");
            DropTable("dbo.Member");
            DropTable("dbo.BorrowedBy");
            DropTable("dbo.Author");
            DropTable("dbo.Book");
            DropTable("dbo.Publisher");
            DropTable("dbo.Address");
        }
    }
}
