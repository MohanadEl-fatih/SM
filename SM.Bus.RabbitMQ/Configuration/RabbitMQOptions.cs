using RawRabbit.Configuration;
using RawRabbit.Configuration.Exchange;
using System;
using System.Collections.Generic;
using System.Text;

namespace SM.Bus.RabbitMQ.RawRabbit.Configuration
{
    public class RabbitMQOptions : RawRabbitConfiguration
    {
        public QueueOptions Queue { get; set; }
        public ExchangeOptions Exchange { get; set; }
    }

    public class QueueOptions : GeneralQueueConfiguration
    {
        public string Name { get; set; }
    }

    public class ExchangeOptions : GeneralExchangeConfiguration
    {
        public string Name { get; set; }
    }
}
