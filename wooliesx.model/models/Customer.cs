using System;
using System.Collections.Generic;

namespace wooliesx.model.models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public List<Product> Products { get; set; }
    }
}
