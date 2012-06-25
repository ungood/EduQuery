using System;
using System.Collections.Generic;
using System.Linq;

namespace EduQuery.Test.Model
{
    public class Order : IEquatable<Order>
    {
        public int Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CustomerName { get; set; }

        public override string ToString()
        {
            return string.Format("{0:00} [{1:yyyyMMdd}] {2}", Id, CreatedDate, CustomerName);
        }

        public bool Equals(Order other)
        {
            if(ReferenceEquals(null, other))
            {
                return false;
            }
            if(ReferenceEquals(this, other))
            {
                return true;
            }
            return other.Id == Id && other.CreatedDate.Equals(CreatedDate) && Equals(other.CustomerName, CustomerName);
        }

        public override bool Equals(object obj)
        {
            if(ReferenceEquals(null, obj))
            {
                return false;
            }
            if(ReferenceEquals(this, obj))
            {
                return true;
            }
            if(obj.GetType() != typeof(Order))
            {
                return false;
            }
            return Equals((Order)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = Id;
                result = (result * 397) ^ CreatedDate.GetHashCode();
                result = (result * 397) ^ (CustomerName != null ? CustomerName.GetHashCode() : 0);
                return result;
            }
        }
    }
}
