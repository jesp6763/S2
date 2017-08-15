using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleInheritence.Interfaces;

namespace VehicleInheritence
{
    /// <summary>
    /// Represents a racing bike
    /// </summary>
    public class RacingBike : Bicycle, IGear
    {
        #region Fields
        /// <summary>
        /// How many gears the bicycle has
        /// </summary>
        private int gears;

        /// <summary>
        /// The current gear the bicycle is on
        /// </summary>
        private int currentGear;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of this class
        /// </summary>
        /// <param name="manufacturer">The manufacturer of the bicycle</param>
        /// <param name="model">The model of the bicycle</param>
        /// <param name="weight">The weight of the bicycle</param>
        /// <param name="gears">How many gears the bicycle has</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when attempting to set weight, or gears to something less than 0</exception>
        /// <exception cref="ArgumentException">Thrown when attempting to set Manufacturer or Model, to something that is empty, or has special characters</exception>
        public RacingBike(string manufacturer, string model, float weight, int gears) : base(manufacturer, model, weight)
        {
            Gears = gears;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the gears of the bicycle
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when attempting to set the value to something less than 0</exception>
        public int Gears
        {
            get => gears;
            set
            {
                if (value >= 0)
                {
                    gears = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

        /// <summary>
        /// Gets or sets the current gear
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when attempting to set the value to something less than 0, or greater than the max gears</exception>
        public int CurrentGear
        {
            get => currentGear;
            set
            {
                if (value >= 0 && value <= Gears)
                {
                    currentGear = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Cycles the gears
        /// </summary>
        public void CycleGears()
        {
            if (CurrentGear == Gears)
            {
                CurrentGear = 1;
            }
            else
            {
                CurrentGear++;
            }

            Console.WriteLine($"Gear cycled to {CurrentGear}");
        }
        #endregion
    }
}
