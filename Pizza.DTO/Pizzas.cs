using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza.DTO
{
    public class Pizzas
    {
        public System.Guid pizzaID { get; set; }
        public System.Guid customerID { get; set; }
        public decimal Price { get; set; }
        public Nullable<int> Completed { get; set; }
    }
}
