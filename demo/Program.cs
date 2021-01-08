using demo.X.EventBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Framework.EventBus
{
    class Program
    {
        static void Main(string[] args)
        {
            EventBus bus = EventBus.Instance();

            OrderEntity order = new OrderEntity() { OrderId = "20151017001", OrderDateTime = DateTime.Now, OrderAmount = 500 };
            bus.Publish(new OrderAddedEvent() { EventTime = DateTime.Now, Order = order }); // 发布OrderAddedEvent事件,

            OrderEventBus orderEventBus = new OrderEventBus(order);
            orderEventBus.Publish();

            Console.Read();
        }

    }
}
