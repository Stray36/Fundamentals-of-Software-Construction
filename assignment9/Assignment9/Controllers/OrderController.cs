using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using assignment9.Models;

namespace assignment9.Controllers
{
    [ApiController]
    [Route("api/order")]
    public class OrderController : ControllerBase
    {
        // 注入OrderService实例，用于处理订单相关的业务逻辑
        private readonly OrderService _orderService;

        // 构造函数，通过依赖注入初始化OrderService
        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
        }

        // GET: api/Order
        // 获取所有订单
        [HttpGet]
        public ActionResult<List<Order>> GetOrders()
        {
            // 调用服务层方法获取所有订单
            return _orderService.GetAllOrders();
        }

        // GET: api/Order/{id}
        // 通过ID获取特定订单
        [HttpGet("{id}")]
        public ActionResult<Order> GetOrder(string id)
        {
            // 调用服务层方法获取指定ID的订单
            var order = _orderService.GetOrder(id);
            // 如果订单不存在，返回404 NotFound
            return order == null ? NotFound() : (ActionResult<Order>)order;
        }

        // POST: api/Order
        // 添加一个新订单
        [HttpPost]
        public ActionResult<Order> AddOrder(Order order)
        {
            try
            {
                // 为新订单生成一个唯一的ID
                order.OrderId = Guid.NewGuid().ToString();
                // 调用服务层方法添加订单
                _orderService.AddOrder(order);
                // 返回201 Created状态码，并包含新订单信息和URI
                return CreatedAtAction(nameof(GetOrder), new { id = order.OrderId }, order);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT: api/Order/{id}
        // 更新指定ID的订单
        [HttpPut("{id}")]
        public ActionResult UpdateOrder(string id, Order order)
        {
            // 如果URL中的ID和订单中的ID不匹配，返回400 BadRequest
            if (id != order.OrderId)
            {
                return BadRequest("ID mismatch");
            }
            try
            {
                // 调用服务层方法更新订单
                _orderService.UpdateOrder(order);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            // 成功更新后返回204 No Content
            return NoContent();
        }

        // DELETE: api/Order/{id}
        // 删除指定ID的订单
        [HttpDelete("{id}")]
        public ActionResult DeleteOrder(string id)
        {
            try
            {
                // 调用服务层方法删除订单
                _orderService.RemoveOrder(id);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            // 成功删除后返回204 No Content
            return NoContent();
        }
    }
}
