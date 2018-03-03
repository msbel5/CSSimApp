using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CSSimApp.BLL.Dtos;

namespace CSSimApp.UI.ViewModels
{
    public class BouquetFormViewModel
    {
        public BouquetDto Bouquet { get; set; }

        public SelectList SizeList { get; set; }

        public List<BouquetMaterialDto> BouquetMaterials { get; set; }

        public string Title
        {
            get
            {
                if (Bouquet != null && Bouquet.Id != 0)
                    return "Edit Bouquet";

                return "New Bouquet";

            }
        }
    }
}