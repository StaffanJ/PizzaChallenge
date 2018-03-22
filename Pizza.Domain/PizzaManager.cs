using System;
using Pizza.DTO;
using Pizza.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza.Domain
{
    public class PizzaManager
    {
        PizzaRepository pizzaRepository = new PizzaRepository();
        //Get information from the persistence layer and sends it to the presentation layer
        public List<DTO.Customer> GetCustomers()
        {
            var customers = pizzaRepository.GetCustomers();

            return customers;
        }
        public List<DTO.Crusts> GetCrusts() {
            List<DTO.Crusts> crusts = pizzaRepository.GetCrusts();
            return crusts;
        }
        public List<DTO.Ingredients> GetIngredients()
        {
            List<DTO.Ingredients> ingredients = pizzaRepository.GetIngredients();
            return ingredients;
        }
        public List<DTO.Size> GetSizes()
        {
            List<DTO.Size> sizes = pizzaRepository.GetSize();
            return sizes;
        }
        public List<DTO.Pizzas> GetPizzas()
        {
            var pizzas = pizzaRepository.GetPizzas();

            return pizzas;
        }
        //Add information to the persistence layer.
        public void AddCustomer(DTO.Customer customer)
        {
            pizzaRepository.AddCustomer(customer);
        }
        public void AddPizza(DTO.Pizzas pizza)
        {
            pizzaRepository.AddPizza(pizza);
        }
        public void UpdatePizza(Guid pizza)
        {
            pizzaRepository.UpdatePizza(pizza);
        }
    }
}
