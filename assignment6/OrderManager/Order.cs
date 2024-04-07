using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager
{
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
}
