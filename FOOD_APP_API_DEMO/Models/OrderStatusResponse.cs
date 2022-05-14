using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FOOD_APP_API_DEMO.Models
{
    public class OrderStatusResponseBadRequest
    {
        /// <summary>
        /// Placed Order ID
        /// </summary>
        /// <example>ORD4789650</example>
        public string order_id { get; set; }
       
        /// <summary>
        /// Order Status Message
        /// </summary>
        /// <example>Fault Message</example>
        public string message { get; set; }

        /// <summary>
        /// Order Status Response HTTP Status Code
        /// </summary>
        /// <example>400</example>
        public int status_code { get; set; }
       
    }
    public class OrderStatusResponse
    {
        /// <summary>
        /// Placed Order ID
        /// </summary>
        /// <example>ORD4789650</example>
        public string order_id { get; set; }
        /// <summary>
        /// Delivery boy's live location to display on Map
        /// </summary>
        public bool live_location { get; set; }

        /// <summary>
        /// Order Status Message
        /// </summary>
        /// <example>Restaurant yet to accept order</example>
        public string message { get; set; }

        /// <summary>
        /// Order Status Response HTTP Status Code
        /// </summary>
        /// <example>200</example>
        public int status_code { get; set; }

        /// <summary>
        /// Delivery boy's live location Information
        /// </summary>
        public LocationInfo location_info { get; set; }
    }

    public class LocationInfo
    {
        /// <summary>
        /// Delivery boy's live location's latitude value
        /// </summary>
        public double lat { get; set; }

        /// <summary>
        /// Delivery boy's live location's longitude value
        /// </summary>
        public double lng { get; set; }

        /// <summary>
        /// Whether zoom is enabled on Google Map
        /// </summary>
        public bool zoom_control { get; set; }

        /// <summary>
        /// Google Map's zoom level
        /// </summary>
        /// <example>5</example>
        public double zoom_level { get; set; }
    }
}
