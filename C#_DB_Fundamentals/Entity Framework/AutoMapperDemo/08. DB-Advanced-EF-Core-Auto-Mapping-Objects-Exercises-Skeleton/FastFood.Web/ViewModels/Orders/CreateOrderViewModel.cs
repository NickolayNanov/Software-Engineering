namespace FastFood.Web.ViewModels.Orders
{
    using FastFood.Web.ViewModels.Employees;
    using FastFood.Web.ViewModels.Items;
    using System.Collections.Generic;

    public class CreateOrderViewModel
    {
        public List<int> Items { get; set; }

        public List<int> Employees { get; set; }
    }
}
