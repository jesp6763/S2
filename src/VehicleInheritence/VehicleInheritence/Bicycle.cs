using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleInheritence
{
    /// <summary>
    /// Represents a bicycle
    /// </summary>
    public abstract class Bicycle : Vehicle
    {
        /// <summary>
        /// Initializes a new instance of this class
        /// </summary>
        /// <param name="manufacturer">The manufacturer of the vehicle</param>
        /// <param name="model">The model of the vehicle</param>
        /// <param name="weight">The weight of the vehicle</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when attempting to set weight to something less than 0</exception>
        /// <exception cref="ArgumentException">Thrown when attempting to set Manufacturer or Model, to something that is empty, or has special characters</exception>
        protected Bicycle(string manufacturer, string model, float weight) : base(manufacturer, model, weight)
        {
        }

        /// <summary>
        /// Accelerates the bicycle
        /// </summary>
        public override void Accelerate()
        {
            Console.WriteLine($"Pedaling my crazy {Manufacturer} {Model} {GetType().Name}");
        }

        /// <summary>
        /// Reversin the bicycle
        /// </summary>
        public override void Reverse()
        {
            Console.WriteLine($"Reversing my crazy {Manufacturer} {Model} {GetType().Name}");
        }
    }
}
