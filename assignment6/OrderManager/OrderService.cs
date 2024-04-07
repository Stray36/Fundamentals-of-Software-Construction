using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager
{
    public class OrderService
    {
        private List<Order> orders = new List<Order>();

        public void AddOrder(Order order)
        {
            foreach (Order o in orders)
            {
                if (o.Equals(order))
                {
                    throw new Exception("Order repeats.");
                }
            }
            orders.Add(order);
        }

        public void RemoveOrder(int id)
        {
            Order? order = orders.Find(x => x.ID == id);

            if (order == null)
            {
                throw new Exception("The order is not existed.");
            }
            orders.Remove(order);
        }

        public void ModifyOrder(Order newOrder)
        {
            Order? order = orders.Find(order => order.ID == newOrder.ID);
            if (order == null)
            {
                throw new Exception("The order is not existed.");
            }
            order.Details = newOrder.Details;
            order.TotalPrice = newOrder.TotalPrice;
        }

        public List<Order> GetOrders()
        {
            return orders;
        }

        public IEnumerable<Order> SortOrders(Func<Order, object> keySelector)
        {
            return orders.OrderBy(keySelector);
        }
    }
}
