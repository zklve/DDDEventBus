using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 

namespace Framework.EventBus
{
    /// <summary>
    /// 实现了IEventHandler<OrderAddedEvent>接口，就是订阅了OrderAddedEvent事件
    /// </summary>
    public class OrderAddedEventHandler1 : IEventHandler<OrderAddedEvent>
    {
        public void Handle(OrderAddedEvent eventData)
        {

            Console.WriteLine("\r\n");
            Console.WriteLine("订单的数据是：" );
            Console.WriteLine("  订单号：" + eventData.Order.OrderId);
            Console.WriteLine("  订单金额：" + eventData.Order.OrderAmount);
            Console.WriteLine("  下单时间：" + eventData.Order.OrderDateTime);

        }
    }
}
