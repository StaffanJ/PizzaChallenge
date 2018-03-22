using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza.Persistence
{
    public class PizzaRepository
    {
        PizzaEntities db = new PizzaEntities();
        //Get information from the database and sends it to the domain level.
        public List<DTO.Customer> GetCustomers()
        {
            var customers = db.Customer;
            var dtoCustomers = new List<DTO.Customer>();

            foreach (var customer in customers)
            {
                var dtoCustomer = new DTO.Customer() {
                    customerID = customer.customerID,
                    Name = customer.Name,
                    Address = customer.Address,
                    Phone = customer.Phone,
                    PostalCode = customer.PostalCode
                };

                dtoCustomers.Add(dtoCustomer);
            }

            return dtoCustomers;
        }
        public List<DTO.Crusts> GetCrusts()
        {
            var crusts = db.Crusts;
            var dtoCrusts = new List<DTO.Crusts>();

            foreach (var crust in crusts)
            {
                var dtoCrust = new DTO.Crusts() {
                    Name = crust.Name,
                    Price = crust.Price
                };

                dtoCrusts.Add(dtoCrust);
            }

            return dtoCrusts;
        }
        public List<DTO.Ingredients> GetIngredients()
        {
            var ingredients = db.Ingredients;
            var dtoIngredients = new List<DTO.Ingredients>();

            foreach (var ingridient in ingredients)
            {
                var dtoIngridient = new DTO.Ingredients() {
                    Name = ingridient.Name,
                    Price = ingridient.Price
                };

                dtoIngredients.Add(dtoIngridient);
            }

            return dtoIngredients;
        }
        public List<DTO.Size> GetSize()
        {
            var sizes = db.Size;
            var dtoSizes = new List<DTO.Size>();

            foreach (var size in sizes)
            {
                var dtoSize = new DTO.Size() {
                    Name = size.Name,
                    Price = size.Price
                };

                dtoSizes.Add(dtoSize);
            }

            return dtoSizes;
        }
        public List<DTO.Pizzas> GetPizzas()
        {
            var pizzas = db.Pizzas;
            var dtoPizzas = new List<DTO.Pizzas>();

            foreach (var pizza in pizzas)
            {
                var dtoPizza = new DTO.Pizzas()
                {
                    pizzaID = pizza.pizzaID,
                    customerID = pizza.customerID,
                    Price = pizza.Price,
                    Completed = pizza.Completed
                };

                dtoPizzas.Add(dtoPizza);
            }

            return dtoPizzas;
        }
        //Add information to the database
        public void AddCustomer(DTO.Customer newCustomer)
        {
            var customer = new Customer()
            {
                customerID = newCustomer.customerID,
                Name = newCustomer.Name,
                Address = newCustomer.Address,
                PostalCode = newCustomer.PostalCode,
                Phone = newCustomer.Phone
            };

            var dbCustomer = db.Customer;

            dbCustomer.Add(customer);

            db.SaveChanges();
        }
        public void AddPizza(DTO.Pizzas pizza)
        {
            var pizzas = new Pizzas() {
                pizzaID = pizza.pizzaID,
                customerID = pizza.customerID,
                Price = pizza.Price,
                Completed = pizza.Completed
            };

            var dbPizza = db.Pizzas;

            dbPizza.Add(pizzas);

            db.SaveChanges();
        }
        //Update information to the dabase
        public void UpdatePizza(Guid pizza)
        {
            var pizzas = db.Pizzas.Find(pizza);

            pizzas.Completed = 1;

            db.SaveChanges();

        }
    }
}
