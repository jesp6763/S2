using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace VehicleInheritence
{
    /// <summary>
    /// Represents a vehicle
    /// </summary>
    public abstract class Vehicle
    {
        /// <summary>
        /// The manufacturer of the vehicle
        /// </summary>
        private string manufacturer;
        /// <summary>
        /// The model of the vehicle
        /// </summary>
        private string model;

        /// <summary>
        /// The weight(kg) of the vehicle
        /// </summary>
        private float weight;

        // TODO: Add possible exceptions to summary
        /// <summary>
        /// Initializes a new instance of this class
        /// </summary>
        /// <param name="manufacturer">The manufacturer of the vehicle</param>
        /// <param name="model">The model of the vehicle</param>
        /// <param name="weight">The weight of the vehicle</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when attempting to set weight to something less than 0</exception>
        /// <exception cref="ArgumentException">Thrown when attempting to set Manufacturer or Model, to something that is empty, or has special characters</exception>
        protected Vehicle(string manufacturer, string model, float weight)
        {
            Manufacturer = manufacturer;
            Model = model;
            Weight = weight;
        }

        /// <summary>
        /// Gets or sets the manufacturer
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when attempting to set the value to something with characters other than spaces and letters, or if empty</exception>
        public string Manufacturer
        {
            get => manufacturer;
            set
            {
                if (!string.IsNullOrEmpty(value) && Regex.IsMatch(value, "^[ A-Za-z]+$"))
                {
                    manufacturer = value;
                }
                else
                {
                    throw new ArgumentException("Only spaces, letters and numbers is allowed.");
                }
            }
        }

        /// <summary>
        /// Gets or sets the model
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when attempting to set the value to something with characters other than spaces, letters and numbers, or if empty</exception>
        public string Model
        {
            get => model;
            set
            {
                if (!string.IsNullOrEmpty(value) && Regex.IsMatch(value, "^[ A-Za-z0-9-]+$"))
                {
                    model = value;
                }
                else
                {
                    throw new ArgumentException("Only spaces, letters and numbers is allowed.");
                }
            }
        }

        /// <summary>
        /// Gets or sets the weight(kg)
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when attempting to set the value to something less than 0</exception>
        public float Weight
        {
            get => weight;
            set
            {
                if (weight >= 0d)
                {
                    weight = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

        /// <summary>
        /// Accelerates the vehicle
        /// </summary>
        public abstract void Accelerate();

        /// <summary>
        /// Reverse the vehicle
        /// </summary>
        public abstract void Reverse();
    }
}
