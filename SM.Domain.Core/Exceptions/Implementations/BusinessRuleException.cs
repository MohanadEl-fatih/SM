using System;
using System.Collections.Generic;
using System.Text;

namespace SM.Core.Exceptions
{
    [Serializable]
    public class BusinessRuleException : BaseException
    { 
        public BusinessRuleException(string message) : base(message) { }
        public BusinessRuleException(string message, ErrorCode errorCode)
            : base(message)
        {
            this.ErrorCode = errorCode;
        }

        public BusinessRuleException(string message, Exception inner)
            : base(message, inner) { }

        public BusinessRuleException(string message, Exception inner, ErrorCode errorCode)
            : base(message, inner)
        {
            this.ErrorCode = errorCode;
        }

        protected BusinessRuleException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
