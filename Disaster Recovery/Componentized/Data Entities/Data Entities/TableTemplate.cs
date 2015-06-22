using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Data_Entities
{
    public abstract class TableTemplate
    {
        [DataType(DataType.DateTime)]
        public DateTime Added { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Updated { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Inactivated { get; set; }
        public bool IsActive { get; set; }

    }
}
