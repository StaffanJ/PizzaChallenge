using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza.DTO
{
    public class Ingredients
    {
        public System.Guid ingredientID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
