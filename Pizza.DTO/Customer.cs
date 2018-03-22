using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza.DTO
{
    public class Customer
    { 
    public System.Guid customerID { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string PostalCode { get; set; }
    public string Phone { get; set; }
    }
}
