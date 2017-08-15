namespace VehicleInheritence.Components
{
    /// <summary>
    /// Represents the powertrain of a vehicle
    /// </summary>
    public struct Powertrain
    {
        #region Constructors
        public Powertrain(Transmission transmission)
        {
            Transmission = transmission;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the transmission type
        /// </summary>
        public Transmission Transmission { get; set; }
        #endregion
    }
}
