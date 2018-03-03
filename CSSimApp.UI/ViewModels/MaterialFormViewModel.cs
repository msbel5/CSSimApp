using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CSSimApp.BLL.Dtos;

namespace CSSimApp.UI.ViewModels
{
    public class MaterialFormViewModel
    {
        public MaterialDto Material { get; set; }

        public string Title
        {
            get
            {
                if (Material != null && Material.Id != 0)
                    return "Edit Material";

                return "New Material";

            }
        }
    }
}