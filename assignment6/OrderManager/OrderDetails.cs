using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager
{
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
}
