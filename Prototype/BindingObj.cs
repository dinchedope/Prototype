using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    public class BindingObj
    {
        public AirPlane.AirPlane airPlane;
        public string description;

        public BindingObj(AirPlane.AirPlane airPlane, string description)
        {
            this.airPlane = airPlane;
            this.description = description;
        }
    }
}
