using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSimApp.DAL.Models
{
    public class BouquetMaterial
    {
        public int Id { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public int MaterialId { get; set; }
        public Material Material { get; set; }

        [Required]
        public int BouquetId { get; set; }

        public Bouquet Bouquet { get; set; }
    }
}
