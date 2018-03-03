using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSimApp.BLL.Dtos
{
    public class BouquetDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int SizeId { get; set; }

        public SizeDto Size { get; set; }

        [Required]
        public decimal Price { get; set; }

        private IList<BouquetMaterialDto> _materials = new List<BouquetMaterialDto>();
        public IList<BouquetMaterialDto> Materials
        {
            get { return _materials; }
            set { _materials = value; }
        }
        public void AddMaterial(BouquetMaterialDto material)
        {
            _materials.Add(material);
            material.Bouquet = this;
        }
    }
}
