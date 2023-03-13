using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirPlane
{
    public class CargoAirPlane : AirPlane
    {
        public Cargo cargo;
        public CargoAirPlane(int clientPlaceCount, double planeSize, double fuelSize) : base(clientPlaceCount, planeSize, fuelSize)
        {
        }

        public override string ToString()
        {
            return $"Client Place Count: {clientPlaceCount}, Plane Size: {planeSize}, Fuel Size: {fuelSize}, Cargo_Size: {cargo.Size}, Cargo_Weight: {cargo.Weight}";
        }
        public override AirPlane ShallowCopy()
        {
            return (AirPlane)this.MemberwiseClone();
        }

        public override AirPlane DeepCopy()
        {
            CargoAirPlane obj = (CargoAirPlane)this.MemberwiseClone();
            obj.cargo = this.cargo.DeepCopy();

            return obj;
        }
    }
}
