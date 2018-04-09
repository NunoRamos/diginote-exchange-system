using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Common
{
    [Serializable]
    public class OrderNotSatisfiedException : Exception, ISerializable
    {
        public int Quantity { get; }
        public float Value { get; }

        [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
        public OrderNotSatisfiedException(SerializationInfo info, StreamingContext context) : base(info, context) {
            this.Quantity = info.GetInt32("OrderNotSatisfiedException.Quantity");
            this.Value = (float)info.GetDouble("OrderNotSatisfiedException.Value");
        }

        public OrderNotSatisfiedException(string message, int quantity, float value) : base(message)
        {
            Quantity = quantity;
            Value = value;
        }

        [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            info.AddValue("OrderNotSatisfiedException.Quantity", this.Quantity);
            info.AddValue("OrderNotSatisfiedException.Value", this.Value);
        }
    }
}
