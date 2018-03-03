namespace CSSimApp.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSizeId : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Bouquets", name: "Size_Id", newName: "SizeId");
            RenameIndex(table: "dbo.Bouquets", name: "IX_Size_Id", newName: "IX_SizeId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Bouquets", name: "IX_SizeId", newName: "IX_Size_Id");
            RenameColumn(table: "dbo.Bouquets", name: "SizeId", newName: "Size_Id");
        }
    }
}
