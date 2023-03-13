using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirPlane
{
    public class Ammo
    {
        public string Description;
        public int count;

        public Ammo(string description, int count )
        {
            Description = description;
            this.count = count;
        }

        public override string ToString()
        {
            return $"Description: {Description}, Count: {count}";
        }

        public Ammo DeepCopy()
        {
            return (Ammo)this.MemberwiseClone();
        }
    }
}
