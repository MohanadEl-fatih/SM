using System;
using System.Collections.Generic;
using System.Text;

namespace SM.Bus.RabbitMQ.Configuration
{
    public class RabbitMQOptions
    {
        public String URI { get; set; }
        public String UserName { get; set; }
        public String Password { get; set; }
    }
}
