using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSSimApp.DAL.Data;
using CSSimApp.DAL.Models;

namespace CSSimApp.DAL.Repositories
{
    public class BouquetRepository:Repository<Bouquet>
    {

        public IEnumerable<Bouquet> EagerGetAll()
        {
            ProjectContext eagerDbContext = new ProjectContext();
            return eagerDbContext.Bouquets.Include(s => s.Size).Include(m => m.Materials.Select(z=>z.Material)).ToList();
        }
    }
}
