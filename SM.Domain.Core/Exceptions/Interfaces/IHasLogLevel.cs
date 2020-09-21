using Microsoft.Extensions.Logging;

namespace SM.Core.Exceptions
{
    public interface IHasLogLevel
    {
        LogLevel LogLevel { get; set; }
    }
}
