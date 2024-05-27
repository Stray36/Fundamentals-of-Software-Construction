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
        // ע��OrderServiceʵ�������ڴ�������ص�ҵ���߼�
        private readonly OrderService _orderService;

        // ���캯����ͨ������ע���ʼ��OrderService
        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
        }

        // GET: api/Order
        // ��ȡ���ж���
        [HttpGet]
        public ActionResult<List<Order>> GetOrders()
        {
            // ���÷���㷽����ȡ���ж���
            return _orderService.GetAllOrders();
        }

        // GET: api/Order/{id}
        // ͨ��ID��ȡ�ض�����
        [HttpGet("{id}")]
        public ActionResult<Order> GetOrder(string id)
        {
            // ���÷���㷽����ȡָ��ID�Ķ���
            var order = _orderService.GetOrder(id);
            // ������������ڣ�����404 NotFound
            return order == null ? NotFound() : (ActionResult<Order>)order;
        }

        // POST: api/Order
        // ���һ���¶���
        [HttpPost]
        public ActionResult<Order> AddOrder(Order order)
        {
            try
            {
                // Ϊ�¶�������һ��Ψһ��ID
                order.OrderId = Guid.NewGuid().ToString();
                // ���÷���㷽����Ӷ���
                _orderService.AddOrder(order);
                // ����201 Created״̬�룬�������¶�����Ϣ��URI
                return CreatedAtAction(nameof(GetOrder), new { id = order.OrderId }, order);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT: api/Order/{id}
        // ����ָ��ID�Ķ���
        [HttpPut("{id}")]
        public ActionResult UpdateOrder(string id, Order order)
        {
            // ���URL�е�ID�Ͷ����е�ID��ƥ�䣬����400 BadRequest
            if (id != order.OrderId)
            {
                return BadRequest("ID mismatch");
            }
            try
            {
                // ���÷���㷽�����¶���
                _orderService.UpdateOrder(order);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            // �ɹ����º󷵻�204 No Content
            return NoContent();
        }

        // DELETE: api/Order/{id}
        // ɾ��ָ��ID�Ķ���
        [HttpDelete("{id}")]
        public ActionResult DeleteOrder(string id)
        {
            try
            {
                // ���÷���㷽��ɾ������
                _orderService.RemoveOrder(id);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            // �ɹ�ɾ���󷵻�204 No Content
            return NoContent();
        }
    }
}
