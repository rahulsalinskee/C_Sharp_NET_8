using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction
{
    internal class TataMotor
    {
        private Vehicle vehicle = new TataPetrolCar(vehicle: "Petrol Car", isForCommercialUse: false);
        
        internal void DisplayTataVehicleDetails()
        {
            vehicle.DisplayDetails(fuelType: "Petrol", vehicleType: "Car", transmissionType: "Automatic");
        }
    }
}
