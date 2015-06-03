namespace VehicleParkSystem.Interfaces.Engine
{
    public interface IUserInterface
    {
        void ReadLine();
        void WriteLine(string format, params string[] args);
    }
}