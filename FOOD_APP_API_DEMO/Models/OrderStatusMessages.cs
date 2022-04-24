using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FOOD_APP_API_DEMO.Models
{
    public static class OrderStatusMessages
    {
        public static string YET_TO_ACCEPT_ORDER = "Restaurant yet to accept order";
        public static string FOOD_BEING_COOKED = "Your Food is being cooked";
        public static string FOOD_READY_FOR_PICKUP = "Your Food is ready for pickup";
        public static string MR_WILL_DELIVER_YOR_FOOD = "Bob will deliver you food";
        public static string PICKED_UP_FOR_DELIVERY = "Bob has picked-up for delivery";
        public static string ON_THE_WAY_FOR_DELIVERY = "Bob is on the way for delivery";
    }
}
