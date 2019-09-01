using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace wooliesx.model.models
{
    public class Request
    {
        public List<Product> Products { get; set; }

        public List<Special> Specials { get; set; }

        public List<Qty> Quantities { get; set; }
    }
}
