using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace SM.Core.Exceptions
{
    [Serializable]
    public abstract class BaseException : Exception, IBaseException, IHasExceptionErrorCode, IHasExceptionDetails, IHasLogLevel
    {
        public ErrorCode ErrorCode { get; set; }
        public string Details { get; set; }
        public LogLevel LogLevel { get; set; }

        public BaseException(
           string message,
           ErrorCode errorCode = default,
           string details = null,
           Exception innerException = default,
           LogLevel logLevel = LogLevel.Warning)
           : base(message,
                 innerException)
        {
            ErrorCode = errorCode;
            Details = details;
            LogLevel = logLevel;
        }


        public BaseException(SerializationInfo serializationInfo, StreamingContext context)
            : base(serializationInfo, context)
        {

        }

        public BaseException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
