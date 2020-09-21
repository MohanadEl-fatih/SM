using Microsoft.Extensions.Logging;
using SM.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace SM.Core.Extensions
{
    public static class ExceptionExtensions 
    { 
        public static void LogException(this Exception ex)
        {
            var actionName = ex.TargetSite == null ? string.Empty : ex.TargetSite.ToString();
            var message = ex.Message.ToString();

            var innerException = ex.InnerException == null ? string.Empty : ex.InnerException.ToString();

            var innerExceptionMessage = ex.InnerException == null ? string.Empty : ex.InnerException.Message.ToString();
            var stackTrace = ex.StackTrace == null ? string.Empty : ex.StackTrace.ToString();
            var controllerName = string.Empty;
            try
            {
                controllerName = ((System.Reflection.MemberInfo)(ex.TargetSite)).DeclaringType.FullName;
            }
            catch { }

            var sb = new StringBuilder();
            sb.AppendLine();
            sb.AppendLine(string.Format("ControllerName: {0}", controllerName));
            sb.AppendLine(string.Format("ActionName: {0}", actionName));
            sb.AppendLine(string.Format("Message: {0}", message));
            sb.AppendLine(string.Format("InnerException: {0}", innerException));
            sb.AppendLine(string.Format("InnerExceptionMessage: {0}", innerExceptionMessage));
            sb.AppendLine(string.Format("StackTrace: {0}", stackTrace));
            sb.Append(string.Format("DateTime: {0}", DateTime.Now.ToString()));
            sb.AppendLine("=================================");
             
            Trace.TraceError(sb.ToString());
        }

        public static LogLevel GetLogLevel(this Exception exception, LogLevel defaultLevel = LogLevel.Error)
        {
            return (exception as IHasLogLevel)?.LogLevel ?? defaultLevel;
        }

        public static ErrorCode GetErrorCode(this Exception exception, ErrorCode defaultCode = ErrorCode.ErrorCode1)
        {
            return (exception as IHasExceptionErrorCode)?.ErrorCode ?? defaultCode;
        }

        public static string GetErrorDetails(this Exception exception, string defaultDetails = default)
        {
            return (exception as IHasExceptionDetails)?.Details ?? defaultDetails;
        }
    }
}
