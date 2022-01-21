using System;
using System.Runtime.Serialization;

namespace EXAMS
{
    [Serializable]
    internal class NotWorkingExeption : Exception
    {
        public NotWorkingExeption()
        {
        }

        public NotWorkingExeption(string message) : base(message)
        {
        }

        public NotWorkingExeption(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotWorkingExeption(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}