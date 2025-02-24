namespace Store.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTableProductAndCategory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "IX_Category_Name");
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Description = c.String(nullable: false, maxLength: 500),
                        ImageUrl = c.String(nullable: false, maxLength: 500),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId)
                .Index(t => t.Name, name: "IX_Product_Name")
                .Index(t => t.Description, name: "IX_Product_Description")
                .Index(t => t.CategoryId, name: "IX_Product_CategoryId");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Products", "IX_Product_CategoryId");
            DropIndex("dbo.Products", "IX_Product_Description");
            DropIndex("dbo.Products", "IX_Product_Name");
            DropIndex("dbo.Categories", "IX_Category_Name");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
