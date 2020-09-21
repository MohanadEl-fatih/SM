using SM.Core.Extensions;
using System;

namespace SM.Core.Exceptions
{
    internal static class ThrowHelper
    {
        public static T ReThrow<T>(T ex) where T : Exception
        { 
            // TODO: implement any custom exception handling
            ex.LogException(); 
            return ex;
        }

        public static T TryExtractException<T>(Exception ex)
            where T : Exception
        {
            while (ex != null && !(ex is T))
                ex = ex.InnerException;

            return ex as T;
        }
    }
}
