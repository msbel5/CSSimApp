namespace CSSimApp.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedMaterialId : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.BouquetMaterials", name: "Material_Id", newName: "MaterialId");
            RenameIndex(table: "dbo.BouquetMaterials", name: "IX_Material_Id", newName: "IX_MaterialId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.BouquetMaterials", name: "IX_MaterialId", newName: "IX_Material_Id");
            RenameColumn(table: "dbo.BouquetMaterials", name: "MaterialId", newName: "Material_Id");
        }
    }
}
