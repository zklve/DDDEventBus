using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 

namespace Framework.EventBus
{
    public class OrderAddedEventHandler2 : IEventHandler<OrderAddedEvent>
    {
        public void Handle(OrderAddedEvent eventData)
        {
            Console.WriteLine("\r\n");
            Console.WriteLine("事件发生的时间是：" + eventData.EventTime);
            Console.WriteLine("发送邮件给客户");

        }
    }
}
