using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza.DTO
{
    public class Size
    {
        public System.Guid sizeID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
