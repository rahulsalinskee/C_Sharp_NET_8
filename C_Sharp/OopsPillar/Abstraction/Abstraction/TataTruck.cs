using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction
{
    internal class TataTruck : Vehicle
    {
        internal TataTruck(string vehicle, bool isForCommercialUse) : base(vehicle: vehicle, isVehicleForCommercialUse: isForCommercialUse)
        {
            
        }

        protected override void VehicleType(string vehicleType)
        {
            Console.WriteLine($"Vehicle Type - {vehicleType}");
        }

        protected override void AverageSpeed()
        {
            Console.WriteLine("Average Speed For Tata is - 60 KMPH");
        }

        protected override void FuelType(string fuelType)
        {
            Console.WriteLine($"Fuel Type For Tata Car is - {fuelType}");
        }

        protected override void MaximumSpeed()
        {
            Console.WriteLine("Maximum Speed For Tata is - 160 KMPH");
        }

        protected override void TransmissionType(string transmissionType)
        {
            Console.WriteLine($"Transmission Type For Tata Car is - {transmissionType}");
        }

        internal new void DisplayDetails(string vehicleType, string fuelType, string transmissionType)
        {
            VehicleType(vehicleType);
            TransmissionType(transmissionType);
            FuelType(fuelType);
            AverageSpeed();
            MaximumSpeed();
        }
    }
}
