using Confluent.Kafka;
using System;
using System.Collections.Generic;
using System.Text;

namespace SM.Bus.Kafka.Configuration
{
    public class KafkaOptions
    {
        public ConsumerConfig Consumer { get; set; }
        public ProducerConfig Producer { get; set; }
        public string Topic { get; set; }
        public string Topics { get; set; }
    }
}
