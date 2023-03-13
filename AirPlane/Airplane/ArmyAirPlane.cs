using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirPlane
{
    public class ArmyAirPlane : AirPlane
    {
        public Ammo ammo;
        public ArmyAirPlane(int clientPlaceCount, double planeSize, double fuelSize) : base(clientPlaceCount, planeSize, fuelSize)
        {

        }

        public override string ToString()
        {
            return $"Client Place Count: {clientPlaceCount}, Plane Size: {planeSize}, Fuel Size: {fuelSize}, Ammo_Description: {ammo.Description}, Ammo_Count: {ammo.count}";
        }

        public override AirPlane ShallowCopy()
        {
            return (AirPlane)this.MemberwiseClone();
        }

        public override AirPlane DeepCopy()
        {
            ArmyAirPlane obj = (ArmyAirPlane)this.MemberwiseClone();
            obj.ammo = this.ammo.DeepCopy();

            return obj;
        }
    }
}
