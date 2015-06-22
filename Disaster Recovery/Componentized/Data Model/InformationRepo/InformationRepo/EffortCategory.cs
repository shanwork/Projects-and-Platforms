using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformationRepo
{
    class EffortCategory: DataObjectsBase
    {
        public int EffortCategoryID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
