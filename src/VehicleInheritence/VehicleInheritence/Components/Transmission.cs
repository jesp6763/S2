using System;
using System.Collections.Generic;
using VehicleInheritence.Enums;
using VehicleInheritence.Interfaces;

namespace VehicleInheritence.Components
{
    public class Transmission : IGear
    {
        #region Fields
        /// <summary>
        /// How many gears the transmission has
        /// </summary>
        private int gears;

        /// <summary>
        /// The current gear the transmission is on
        /// </summary>
        private int currentGear;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of this class
        /// </summary>
        /// <param name="gears">How many gears the transmission has</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when attempting to set gears to something less than 0</exception>
        public Transmission(int gears)
        {
            Gears = gears;
        }

        /// <summary>
        /// Initializes a new instance of this class
        /// </summary>
        /// <param name="gears">How many gears the transmission has</param>
        /// <param name="transmissionType">The transmission type</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when attempting to set gears to something less than 0</exception>
        public Transmission(int gears, ETransmissionType transmissionType) : this(gears)
        {
            TransmissionType = transmissionType;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the gears of the transmission
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
        /// <exception cref="ArgumentOutOfRangeException">Thrown when attempting to set the value to something less than -1, or greater than the max gears</exception>
        public int CurrentGear
        {
            get => currentGear;
            set
            {
                if (value >= -1 && value <= Gears)
                {
                    currentGear = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

        /// <summary>
        /// Gets or sets the transmission type
        /// </summary>
        public ETransmissionType TransmissionType { get; set; }
        #endregion
    }
}
