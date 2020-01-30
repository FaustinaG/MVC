namespace LibraryManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Publisher", "AddressId", "dbo.Address");
            DropIndex("dbo.Publisher", new[] { "AddressId" });
            AlterColumn("dbo.Publisher", "AddressId", c => c.Int());
            CreateIndex("dbo.Publisher", "AddressId");
            AddForeignKey("dbo.Publisher", "AddressId", "dbo.Address", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Publisher", "AddressId", "dbo.Address");
            DropIndex("dbo.Publisher", new[] { "AddressId" });
            AlterColumn("dbo.Publisher", "AddressId", c => c.Int(nullable: false));
            CreateIndex("dbo.Publisher", "AddressId");
            AddForeignKey("dbo.Publisher", "AddressId", "dbo.Address", "Id", cascadeDelete: true);
        }
    }
}
