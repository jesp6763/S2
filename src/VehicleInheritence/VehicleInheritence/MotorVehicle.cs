using System;
using System.Collections.Generic;
using VehicleInheritence.Components;
using VehicleInheritence.Enums;
using VehicleInheritence.Interfaces;

namespace VehicleInheritence
{
    /// <summary>
    /// Represents a motorized vehicle
    /// </summary>
    public class MotorVehicle : Vehicle
    {
        #region Fields
        /// <summary>
        /// The fuel capacity(litres) of the vehicle
        /// </summary>
        private float fuelCapacity;

        /// <summary>
        /// The top speed of the vehicle
        /// </summary>
        private int topSpeed;
        #endregion

        #region Constructors
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
        public MotorVehicle(string manufacturer, string model, float weight, float fuelCapacity, int topSpeed, Powertrain powertrain) : base(manufacturer, model, weight)
        {
            FuelCapacity = fuelCapacity;
            TopSpeed = topSpeed;
            Powertrain = powertrain;
        }

        /// <summary>
        /// Initializes a new instance of this class
        /// </summary>
        /// <param name="manufacturer">The manufacturer of the vehicle</param>
        /// <param name="model">The model of the vehicle</param>
        /// <param name="weight">The weight of the vehicle</param>
        /// <param name="fuelCapacity">The fuel capacity of the vehicle</param>
        /// <param name="topSpeed">The top speed of the vehicle</param>
        /// <param name="fuelType">The type of fuel the vehicle uses</param>
        /// <param name="powertrain">The powertrain of the vehicle</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when attempting to set weight, fuel capacity, or top speed to something less than 0</exception>
        /// <exception cref="ArgumentException">Thrown when attempting to set Manufacturer or Model, to something that is empty, or has special characters</exception>
        public MotorVehicle(string manufacturer, string model, float weight, float fuelCapacity, int topSpeed, Powertrain powertrain, EFuelType fuelType) : this(manufacturer, model, weight, fuelCapacity, topSpeed, powertrain)
        {
            FuelType = fuelType;
        }

        /// <summary>
        /// Initializes a new instance of this class
        /// </summary>
        /// <param name="manufacturer">The manufacturer of the vehicle</param>
        /// <param name="model">The model of the vehicle</param>
        /// <param name="weight">The weight of the vehicle</param>
        /// <param name="fuelCapacity">The fuel capacity of the vehicle</param>
        /// <param name="topSpeed">The top speed of the vehicle</param>
        /// <param name="fuelType">The type of fuel the vehicle uses</param>
        /// <param name="wheelDrive">The wheel-drive layout the vehicle uses</param>
        /// <param name="powertrain">The powertrain of the vehicle</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when attempting to set weight, fuel capacity, or top speed to something less than 0</exception>
        /// <exception cref="ArgumentException">Thrown when attempting to set Manufacturer or Model, to something that is empty, or has special characters</exception>
        public MotorVehicle(string manufacturer, string model, float weight, float fuelCapacity, int topSpeed, Powertrain powertrain, EFuelType fuelType, EWheelDrive wheelDrive) : this(manufacturer, model, weight, fuelCapacity, topSpeed, powertrain, fuelType)
        {
            WheelDrive = wheelDrive;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the fuel capacity(litres)
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when attempting to set the value to something less than or equal to 0</exception>
        public float FuelCapacity
        {
            get => fuelCapacity;
            set
            {
                if (value > 0d)
                {
                    fuelCapacity = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

        /// <summary>
        /// Gets or sets the wheel-drive layout
        /// </summary>
        public EWheelDrive WheelDrive { get; set; }

        /// <summary>
        /// Gets or sets the fuel type
        /// </summary>
        public EFuelType FuelType { get; set; }

        /// <summary>
        /// Gets or sets the top speed of the vehicle
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when attempting to set the value to something less than or equal to 0</exception>
        public int TopSpeed
        {
            get => topSpeed;
            set
            {
                if (value > 0)
                {
                    topSpeed = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

        /// <summary>
        /// Gets or sets the vehicle's powertrain
        /// </summary>
        public Powertrain Powertrain { get; set; }

        /// <summary>
        /// Gets or sets the clutch's state
        /// </summary>
        public bool IsClutchDown { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Accelerates the vehicle
        /// </summary>
        public override void Accelerate()
        {
            if(Powertrain.Transmission.CurrentGear > 0)
            {
                Console.WriteLine($"Accelerating my crazy {Manufacturer} {Model} vehicle");
            }
            else
            {
                string gearName = Powertrain.Transmission.CurrentGear == 0 ? "neutral" : "reverse";
                Console.WriteLine($"You can't accelerate in {gearName} gear, you have to shift out of {gearName} gear to be able to accelerate");
            }
        }

        /// <summary>
        /// Reverses the vehicle
        /// </summary>
        public override void Reverse()
        {
            if(Powertrain.Transmission.CurrentGear == -1)
            {
                Console.WriteLine($"Reversing my crazy {Manufacturer} {Model} vehicle");
            }
            else
            {
                Console.WriteLine("You have to be in reverse gear to be able to reverse");
            }
        }

        /// <summary>
        /// Changes the clutch state
        /// </summary>
        /// <param name="clutch">The clutch state</param>
        public void Clutch(bool clutch)
        {
            IsClutchDown = clutch;
        }

        /// <summary>
        /// Shifts up a gear
        /// </summary>
        public void ShiftGear(int gear)
        {
            if (IsClutchDown || Powertrain.Transmission.TransmissionType == ETransmissionType.Automatic)
            {
                Powertrain.Transmission.CurrentGear = gear;
                Console.WriteLine($"Gear shifted to {gear}");
            }
            else
            {
                Console.WriteLine("Use your clutch before shifting");
            }
        }

        /// <summary>
        /// Makes the vehicle say doot!
        /// </summary>
        public void UseHorn()
        {
            Console.WriteLine($"{Manufacturer} {Model} says doot!");
        }
        #endregion
    }
}