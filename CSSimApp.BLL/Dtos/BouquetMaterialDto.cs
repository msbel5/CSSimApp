using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSimApp.BLL.Dtos
{
    public class BouquetMaterialDto
    {
        public int Id { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public int MaterialId { get; set; }
        public MaterialDto Material { get; set; }

        [Required]
        public int BouquetId { get; set; }

        public BouquetDto Bouquet { get; set; }
    }
}
