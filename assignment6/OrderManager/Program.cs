using System;

namespace OrderManager
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Program p = new Program();
        }

        private List<Order> QueryFromID(int id, List<Order> orders)
        {
            if (orders ==  null || orders.Count == 0)
            {
                throw new System.NullReferenceException();
            }
            var query = from o in orders
                        where o.ID == id
                        orderby o.TotalPrice
                        select o;
            return query.ToList();
        }

        private List<Order> QueryFromCustomer(string customerName, List<Order> orders)
        {
            if (orders == null || orders.Count == 0)
            {
                throw new System.NullReferenceException();
            }
            var query = orders.Where(o => o.CustomerName == customerName)
                .OrderBy(o => o.TotalPrice);
            return query.ToList();
        }

        private List<Order> QueryFromTotalPrice(int totalPrice, List<Order> orders) 
        {

            if (orders == null || orders.Count == 0)
            {
                throw new System.NullReferenceException();
            }
            var query = orders.Where(o => o.TotalPrice == totalPrice)
                .OrderBy(o => o.TotalPrice);
            return query.ToList();
        }
         
        private List<Order> QueryFromProductName(OrderDetails details, List<Order> orders)
        {
            if (orders == null || orders.Count == 0)
            {
                throw new System.NullReferenceException();
            }
            var query = orders.Where(o => o.Details.Contains(details))
                .OrderBy(o => o.TotalPrice);
            return query.ToList();
        }
    }
}