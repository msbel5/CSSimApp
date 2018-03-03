namespace CSSimApp.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialCreation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BouquetMaterials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        BouquetId = c.Int(nullable: false),
                        Material_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bouquets", t => t.BouquetId, cascadeDelete: true)
                .ForeignKey("dbo.Materials", t => t.Material_Id, cascadeDelete: true)
                .Index(t => t.BouquetId)
                .Index(t => t.Material_Id);
            
            CreateTable(
                "dbo.Bouquets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Size_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sizes", t => t.Size_Id, cascadeDelete: true)
                .Index(t => t.Size_Id);
            
            CreateTable(
                "dbo.Sizes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Materials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Flowery = c.Boolean(nullable: false),
                        Thorny = c.Boolean(nullable: false),
                        Leafy = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        RememberMe = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BouquetMaterials", "Material_Id", "dbo.Materials");
            DropForeignKey("dbo.Bouquets", "Size_Id", "dbo.Sizes");
            DropForeignKey("dbo.BouquetMaterials", "BouquetId", "dbo.Bouquets");
            DropIndex("dbo.Bouquets", new[] { "Size_Id" });
            DropIndex("dbo.BouquetMaterials", new[] { "Material_Id" });
            DropIndex("dbo.BouquetMaterials", new[] { "BouquetId" });
            DropTable("dbo.Users");
            DropTable("dbo.Materials");
            DropTable("dbo.Sizes");
            DropTable("dbo.Bouquets");
            DropTable("dbo.BouquetMaterials");
        }
    }
}
