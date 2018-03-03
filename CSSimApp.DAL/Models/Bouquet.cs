using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSimApp.DAL.Models
{
    public class Bouquet
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int SizeId { get; set; }

        public Size Size { get; set; }

        [Required]
        public decimal Price { get; set; }

        private IList<BouquetMaterial> _materials = new List<BouquetMaterial>();
        public IList<BouquetMaterial> Materials
        {
            get { return _materials; }
            set { _materials = value; }
        }
        public void AddMaterial(BouquetMaterial material)
        {
            _materials.Add(material);
            material.Bouquet = this;
        }

    }
}
