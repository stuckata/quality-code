using System;



using System.Collections.Generic;
using VehiclePark3;






interface IUserInterface
{
    string ReadLine();
    void WriteLine(string format, params string[] args);
}































public interface IVehicle
{











    string
    LicensePlate
    { get; }
    string
    Owner
    { get; }
    decimal
    RegularRate
    { get; }
    decimal
    OvertimeRate
    { get; }
    int
    ReservedHours























    { get; }
}