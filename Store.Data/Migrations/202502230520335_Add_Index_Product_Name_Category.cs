namespace Store.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Index_Product_Name_Category : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Products", new[] { "Name", "CategoryId" }, unique: false, name: "IX_Product_Name_Category");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Products", "IX_Product_Name_Category");
        }
    }
}
