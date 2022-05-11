using System;
using System.Runtime.Serialization;

namespace MG.TaskManager.BLL.Validation
{
    [Serializable]
    public class BusinessLogicException : Exception
    {
        public BusinessLogicException() { }

        public BusinessLogicException(string message) : base(message) { }

        protected BusinessLogicException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
