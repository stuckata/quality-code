namespace VehicleParkSystem.Engine.Factories
{
    using System;
    using VehicleParkSystem.Interfaces;
    using VehicleParkSystem.Interfaces.Engine;

    public class VehicleParkSystemFactory : Interfaces.Engine.IVehicleParkSystemFactory
    {
        public ICar InsertCar(ICar car, int sector, int placeNumber, DateTime startTime)
        {
            throw new NotImplementedException();
        }

        public IMotorbike InsertMotorbike(IMotorbike motorbike, int sector, int placeNumber, DateTime startTime)
        {
            throw new NotImplementedException();
        }

        public ITruck InsertTruck(ITruck truck, int sector, int placeNumber, DateTime startTime)
        {
            throw new NotImplementedException();
        }

        public IVehicle ExitVehicle(string licensePlate, DateTime endTime, decimal amountPaid)
        {
            throw new NotImplementedException();
        }

        public void GetStatus()
        {
            throw new NotImplementedException();
        }

        public void FindVehicle(string licensePlate)
        {
            throw new NotImplementedException();
        }

        public void FindVehiclesByOwner(string owner)
        {
            throw new NotImplementedException();
        }
    }
}