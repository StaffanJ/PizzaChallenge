using System;
using Pizza.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using System.Data.Entity.Validation;

namespace Pizza.Presentation
{
    public partial class Default : System.Web.UI.Page
    {
        PizzaManager pizzaManager = new PizzaManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                displayInformation();
                displayCustomers();
            }
            resultLabel.Text = gatherInformation();
        }
        private void displayCustomers()
        {
            var customers = pizzaManager.GetCustomers();
            foreach (var customer in customers)
            {
                customerDropDown.Items.Add(new ListItem(customer.Name, customer.customerID.ToString()));
            }

        }
        private void displayInformation()
        {
            var crusts = pizzaManager.GetCrusts();
            var ingredients = pizzaManager.GetIngredients();
            var sizes = pizzaManager.GetSizes();

            foreach (var crust in crusts)
            {
                crustDropDownList.Items.Add(new ListItem(crust.Name, crust.Price.ToString()));
            }
            foreach (var size in sizes)
            {
                sizesDropDownList.Items.Add(new ListItem(size.Name, size.Price.ToString()));
            }
            foreach (var ingredient in ingredients)
            {
                ingredientsCheckBox.Items.Add(new ListItem(ingredient.Name, ingredient.Price.ToString()));
            }
        }
        private string gatherInformation()
        {
           string result = "";

            decimal totalPrice = calculatePrice();

           return result = string.Format("Total cost of the pizza is: {0:C}", totalPrice);
        }

        private decimal calculatePrice()
        {
            decimal crustPrice = 0, sizePrice = 0, ingredientPrice = 0, totalPrice = 0;

            crustPrice = Decimal.Parse(crustDropDownList.SelectedValue);
            sizePrice = Decimal.Parse(sizesDropDownList.SelectedValue);

            for (int i = 0; i < ingredientsCheckBox.Items.Count; i++)
            {
                if (ingredientsCheckBox.Items[i].Selected)
                {
                    ingredientPrice += Decimal.Parse(ingredientsCheckBox.Items[i].Value.ToString());
                }
            }

            return totalPrice = crustPrice + sizePrice + ingredientPrice;
        }

        private DTO.Customer createCustomer()
        {
            var customer = new DTO.Customer()
            {
                customerID = Guid.NewGuid(),
                Name = nameTextBox.Text,
                PostalCode = postalTextBox.Text,
                Phone = phoneTextBox.Text,
                Address = addressTextBox.Text,
            };

            return customer;
        }
        private void AddCustomer()
        {
            var customer = createCustomer();
            string errorMessage = "";

            try
            {
                if (customer.Name == "")
                {
                    errorMessage = "Name cannot be empty";
                    throw new CustomerCheckValidationException(errorMessage);
                }
                if (customer.Address == "")
                {
                    errorMessage = "Address cannot be empty";
                    throw new CustomerCheckValidationException(errorMessage);
                }
                if (customer.PostalCode == "")
                {
                    errorMessage = "Postal code cannot be empty";
                    throw new CustomerCheckValidationException(errorMessage);
                }
                if (customer.Phone == "")
                {
                    errorMessage = "Phonenumber cannot be empty";
                    throw new CustomerCheckValidationException(errorMessage);
                }

                pizzaManager.AddCustomer(customer);

                customerLabel.Text = string.Format("{0} have been added!", customer.Name);
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var validations in ex.EntityValidationErrors)
                {
                    foreach (var validation in validations.ValidationErrors)
                    {
                        customerLabel.Text += string.Format("There was an issue with: {0}", validation.PropertyName);
                    }
                }
            }
            catch (CustomerCheckValidationException ex)
            {
                customerLabel.Text = ex.Message;
            }
            catch (Exception ex)
            {
                customerLabel.Text = string.Format("There was an issue with: {0}", ex.Message);
            }
        }

        private DTO.Pizzas createPizza()
        {
            decimal totalCost = calculatePrice();
            var createPizza = new DTO.Pizzas() {
                pizzaID = Guid.NewGuid(),
                customerID = Guid.Parse(customerDropDown.SelectedValue),
                Price = totalCost,
                Completed = 1
            };
            return createPizza;
        }
        private void AddPizza()
        {
            var pizza = createPizza();
            string errorMessage = "";

            try
            {

                if (pizza.Price.ToString() == "")
                {
                    errorMessage = "There must be a price";
                    throw new PizzaCheckValidationException(errorMessage);
                }

                pizzaManager.AddPizza(pizza);

                resultLabel.Text = "Your order have been added";
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var validations in ex.EntityValidationErrors)
                {
                    foreach (var validation in validations.ValidationErrors)
                    {
                        customerLabel.Text += string.Format("There was an issue with: {0}", validation.PropertyName);
                    }
                }
            }
            catch (PizzaCheckValidationException ex)
            {
                customerLabel.Text = ex.Message;
            }
            catch (Exception ex)
            {
                customerLabel.Text = string.Format("There was an issue with: {0}", ex.Message);
            }
        }
        //Event logic
        protected void addCustomer_Click(object sender, EventArgs e)
        {
            AddCustomer();
        }
        protected void orderButton_Click(object sender, EventArgs e)
        {
             AddPizza();
        }
    }
}