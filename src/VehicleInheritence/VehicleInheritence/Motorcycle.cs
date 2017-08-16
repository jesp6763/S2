using System;
using System.Collections.Generic;
using System.Linq;
using VehicleInheritence.Components;

namespace VehicleInheritence
{
    public class Motorcycle : MotorVehicle
    {
        /// <summary>
        /// Initializes a new instance of this class
        /// </summary>
        /// <param name="manufacturer">The manufacturer of the vehicle</param>
        /// <param name="model">The model of the vehicle</param>
        /// <param name="weight">The weight of the vehicle</param>
        /// <param name="fuelCapacity">The fuel capacity of the vehicle</param>
        /// <param name="topSpeed">The top speed of the vehicle</param>
        /// <param name="powertrain">The powertrain of the vehicle</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when attempting to set weight, fuel capacity, or top speed to something less than 0</exception>
        /// <exception cref="ArgumentException">Thrown when attempting to set Manufacturer or Model, to something that is empty, or has special characters</exception>
        public Motorcycle(string manufacturer, string model, float weight, float fuelCapacity, int topSpeed, Powertrain powertrain) : base(manufacturer, model, weight, fuelCapacity, topSpeed, powertrain)
        {

        }
    }
}
