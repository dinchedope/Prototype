using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirPlane
{
    public class AirPlane
    {
        public int clientPlaceCount;
        public double planeSize;
        public double fuelSize;
        public AirPlane(int clientPlaceCount, double planeSize, double fuelSize)
        {
            this.clientPlaceCount = clientPlaceCount;
            this.planeSize = planeSize;
            this.fuelSize = fuelSize;
        }

        public override string ToString()
        {
            return $"Client Place Count: {clientPlaceCount}, Plane Size: {planeSize}, Fuel Size: {fuelSize}";
        }

        public virtual AirPlane ShallowCopy()
        {
            return (AirPlane) this.MemberwiseClone();
        }

        public virtual AirPlane DeepCopy()
        {
            return (AirPlane)this.MemberwiseClone();
        }
          

    }
}
