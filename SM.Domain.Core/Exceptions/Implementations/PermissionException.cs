using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace SM.Core.Exceptions
{
    [Serializable]
    public class PermissionException : Exception
    {
        public ErrorCode ErrorCode { get; private set; }
        public string PermissionCode { get; private set; }

        public PermissionException() { }
        public PermissionException(string message) : base(message) { }
        public PermissionException(string message, ErrorCode errorCode) : base(message) { this.ErrorCode = errorCode; }
        public PermissionException(string message, string permissionCode) : base(message) {
            PermissionCode = permissionCode;
        }
        public PermissionException(string message, string permissionCode, ErrorCode errorCode) : base(message) { PermissionCode = permissionCode; this.ErrorCode = errorCode; }
        public PermissionException(string message, string permissionCode, Exception inner) : base(message, inner) {
            PermissionCode = permissionCode;
        }
        public PermissionException(string message, string permissionCode, Exception inner, ErrorCode errorCode) : base(message, inner)
        { 
            this.ErrorCode = errorCode;
            this.PermissionCode = permissionCode;
        }
        
        protected PermissionException(
          SerializationInfo info,
          StreamingContext context)
            : base(info, context) { }

        protected PermissionException(
          SerializationInfo info,
          StreamingContext context,
          ErrorCode errorCode)
            : base(info, context) { this.ErrorCode = errorCode; }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
    }
}

