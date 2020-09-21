namespace SM.Core.Exceptions
{
    public interface IHasExceptionErrorCode
    {
        ErrorCode ErrorCode { get; set; }
    }
}