using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CSSimApp.BLL.Dtos;

namespace CSSimApp.UI.ViewModels
{
    public class SizeFormViewModel
    {
        public SizeDto Size { get; set; }

        public string Title
        {
            get
            {
                if (Size != null && Size.Id != 0)
                    return "Edit Size";

                return "New Size";

            }
        }
    }
}