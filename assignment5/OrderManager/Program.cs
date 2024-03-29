using System;

namespace Classes
{
    public class Customer
    {
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }

    public class Order
    {
        // 订单号
        public int ID { get; set; }
        // 订单金额
        public decimal TotalPrice { get; set; }
        // 客户名称
        public string CustomerName { get; set; }
        // 订单明细
        public List<OrderDetails> Details { get; set; }

        public override bool Equals(object? obj)
        {
            Order order = obj as Order;
            return order != null && order.ID == ID;
        }

        public override string ToString()
        {
            return $"OrderID: {ID}, TotalPrice: {TotalPrice}, CustomerName: {CustomerName}";
        }

        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }

        public void AddOrderDetail(OrderDetails detail)
        {
            foreach (OrderDetails d in Details)
            {
                if (Details.Count(od => od.Equals(detail)) > 1)
                {
                    throw new Exception("OrderDetails repeats.");
                }
            }
            Details.Add(detail);
        }
    }

    public class OrderDetails
    {
        public int id { get; set; }
        public decimal Price { get; set; }
        public string ProductName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public override bool Equals(object? obj)
        {
            OrderDetails? details = obj as OrderDetails;
            return details != null && details.id == id;
        }

        public override string ToString()
        {
            return $"id: {id}, price: {Price}, CreatedDate: {CreatedDate}, UpdatedDate: {UpdatedDate}";
        }
    }

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