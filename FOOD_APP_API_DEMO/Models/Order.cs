using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FOOD_APP_API_DEMO.Models
{
    public class Order
    {
        /// <summary>
        /// Unique ID of restaurant
        /// </summary>
        /// <example>RST5879596</example>
        public string restaurant_id { get; set; }

        /// <summary>
        /// Restaurant's outlet ID
        /// </summary>
        /// <example>01</example>
        public string outlet_id { get; set; }

        /// <summary>
        /// Placed Order ID
        /// </summary>
        /// <example>ORD4789675</example>
        public string order_id { get; set; }
    }
}
