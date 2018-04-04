using System;
using System.Runtime.Serialization;

namespace Common
{
    [Serializable]
    public class OrderNotSatisfiedException : Exception, ISerializable
    {
        public int Quantity { get; }
        public float Value { get; }

        public OrderNotSatisfiedException(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public OrderNotSatisfiedException(string message, int quantity, float value) : base(message)
        {
            Quantity = quantity;
            Value = value;
        }
    }
}
