using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction
{
    internal abstract class Vehicle
    {
        protected abstract void VehicleType(string vehicleType);

        protected abstract void TransmissionType(string transmissionType);

        protected abstract void FuelType(string fuelType);

        protected abstract void AverageSpeed();

        protected abstract void MaximumSpeed();

        internal virtual void DisplayDetails(string vehicleType, string fuelType, string transmissionType)
        {
            VehicleType(vehicleType);
            TransmissionType(transmissionType);
            FuelType(fuelType);
            AverageSpeed();
            MaximumSpeed();
        }

        private protected Vehicle(string vehicle, bool isVehicleForCommercialUse = true) : this(isVehicleForCommercialUse: isVehicleForCommercialUse)
        {
            if (isVehicleForCommercialUse)
            {
                Console.WriteLine($"{vehicle} is for commercial use");
            }
            else
            {
                Console.WriteLine($"{vehicle} is for personal use");
            }
        }

        private Vehicle(bool isVehicleForCommercialUse)
        {
            if (isVehicleForCommercialUse)
            {
                Console.WriteLine($"Total Number of Wheels = 4 OR 6"); 
            }
            else
            {
                Console.WriteLine($"Total Number of Wheels = 4");
            }
        }
    }
}
