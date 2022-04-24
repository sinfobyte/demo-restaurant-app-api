using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using FOOD_APP_API_DEMO.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FOOD_APP_API_DEMO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderStatusController : ControllerBase
    {
        Random random;
        public OrderStatusController()
        {
            random = new Random();
        }
        /// <summary>
        /// Retrives order status in JSON format. For demo purpose it will return different status randomly
        /// </summary>
        /// <remarks>
        ///  <remark>**Order Status:**</remark>
        ///  <remark></remark>
        ///  <remark>Restaurant yet to accept order</remark>
        ///  <remark>Your Food is being cooked</remark>
        ///  <remark>Your Food is ready for pickup</remark>
        ///  <remark>Bob will deliver you food</remark>
        ///  <remark>Bob has picked-up for delivery</remark>
        /// </remarks>
        [HttpPost]
        public ActionResult<OrderStatusResponse> Post(Order order)
        {
            if (string.IsNullOrEmpty(order.order_id))
                Response.StatusCode = Convert.ToInt32(HttpStatusCode.BadRequest);
            return GetOrderResponse(order);
        }

        private bool ValidateId(string id)
        {
            if (id.Length != 10) return false;
            Regex regex = new Regex("(([a-zA-Z]{3})[0-9]{7})");
            return regex.IsMatch(id);
        }
        private OrderStatusResponse GetOrderResponse(Order order)
        {
            int randomStatus = random.Next(1, 7);
            OrderStatusResponse orderStatusResponse = new OrderStatusResponse()
            {
                status_code = Convert.ToInt32(HttpStatusCode.OK),
                live_location = false,
                order_id = order.order_id
            };
            if (!ValidateId(order.order_id))
            {
                randomStatus = 7;
                Response.StatusCode = Convert.ToInt32(HttpStatusCode.BadRequest);
                orderStatusResponse.status_code = Response.StatusCode;
            }
            if(!ValidateId(order.restaurant_id))
            {
                randomStatus = 8;
                Response.StatusCode = Convert.ToInt32(HttpStatusCode.BadRequest);
                orderStatusResponse.status_code = Response.StatusCode;
            }
            switch (randomStatus)
            {
                case 1:
                    orderStatusResponse.message = OrderStatusMessages.YET_TO_ACCEPT_ORDER;
                    break;
                case 2:
                    orderStatusResponse.message = OrderStatusMessages.FOOD_BEING_COOKED;
                    break;
                case 3:
                    orderStatusResponse.message = OrderStatusMessages.FOOD_READY_FOR_PICKUP;
                    break;
                case 4:
                    orderStatusResponse.message = OrderStatusMessages.MR_WILL_DELIVER_YOR_FOOD;
                    break;
                case 5:
                    orderStatusResponse.message = OrderStatusMessages.PICKED_UP_FOR_DELIVERY;
                    break;
                case 6:
                    orderStatusResponse.live_location = true;
                    orderStatusResponse.location_info = new LocationInfo()
                    {
                        lat = 19.186364,
                        lng = 72.824844,
                        zoom_control = false,
                        zoom_level = 3
                    };
                    break;
                case 7:
                    orderStatusResponse.message = "Invalid Order ID";
                    break;
                case 8:
                    orderStatusResponse.message = "Invalid Restaurant ID";
                    break;
            }
            return orderStatusResponse;
        }
        
    }
}