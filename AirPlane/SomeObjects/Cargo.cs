using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirPlane
{
    public class Cargo
    {
        public double Weight;
        public double Size;

        public Cargo(double weight, double size)
        {
            Weight = weight;
            Size = size;
        }

        public override string ToString()
        {
            return $"Weight: {Weight}, Size: {Size}";
        }

        public Cargo DeepCopy()
        {
            return (Cargo)this.MemberwiseClone();
        }
    }
}
