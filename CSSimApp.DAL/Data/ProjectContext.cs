using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSSimApp.DAL.Models;

namespace CSSimApp.DAL.Data
{
    class ProjectContext:DbContext
    {
        public ProjectContext():base("name=CSSimApp")
        {
            Database.SetInitializer( new CreateDatabaseIfNotExists<ProjectContext>());
        }


        public DbSet<User> Users { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<BouquetMaterial> BouquetMaterials { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Bouquet> Bouquets { get; set; }
    }
}
