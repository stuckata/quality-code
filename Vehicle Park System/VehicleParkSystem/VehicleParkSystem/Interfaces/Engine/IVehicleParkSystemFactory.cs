namespace VehicleParkSystem.Interfaces.Engine
{
    using System;

    public interface IVehicleParkSystemFactory
    {
        ICar InsertCar(ICar car, int sector, int placeNumber, DateTime startTime);
        
        IMotorbike InsertMotorbike(IMotorbike motorbike, int sector, int placeNumber, DateTime startTime);
        
        ITruck InsertTruck(ITruck truck, int sector, int placeNumber, DateTime startTime);
        
        IVehicle ExitVehicle(string licensePlate, DateTime endTime, decimal amountPaid);
        
        void GetStatus();
        
        void FindVehicle(string licensePlate);
        
        void FindVehiclesByOwner(string owner);
    }
}