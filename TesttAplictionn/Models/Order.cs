using System;
using System.Collections.Generic;

#nullable disable

namespace TesttAplictionn.Models
{
    public partial class Order
    {
        public int OrderId { get; set; }
        public string OrderName { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderStatus { get; set; }
    }
}
