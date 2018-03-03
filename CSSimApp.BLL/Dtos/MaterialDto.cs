using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSimApp.BLL.Dtos
{
    public class MaterialDto
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public bool Flowery { get; set; }

        [Required]
        public bool Thorny { get; set; }

        [Required]
        public bool Leafy { get; set; }
    }
}
