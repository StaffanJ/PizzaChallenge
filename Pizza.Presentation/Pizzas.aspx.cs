using System;
using Pizza.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pizza.Presentation
{
    public partial class Pizzas : System.Web.UI.Page
    {
        PizzaManager pizzaManager = new PizzaManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
                getPizzas();
        }
        private void getPizzas()
        {
            var pizzas = pizzaManager.GetPizzas();
            var uncompletedOrder = new List<DTO.Pizzas>();

            foreach (var pizza in pizzas)
            {
                if(pizza.Completed == 0)
                {
                    uncompletedOrder.Add(pizza);
                }
            }

            pizzaGridView.DataSource = uncompletedOrder;
            
            pizzaGridView.DataBind();
        }
        protected void pizzaGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = pizzaGridView.Rows[index];

            var value = row.Cells[1].Text.ToString();

            Guid pizzaId = Guid.Parse(row.Cells[1].Text.ToString());

            pizzaManager.UpdatePizza(pizzaId);
            getPizzas();
        }
    }
}