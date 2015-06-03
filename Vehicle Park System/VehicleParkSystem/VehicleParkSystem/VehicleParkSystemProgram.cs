namespace VehicleParkSystem
{
    using System.Globalization;
    using System.Threading;
    using VehicleParkSystem2;

    public class VehicleParkSystemProgram
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            var engine = new Mecanismo();
            engine.Runrunrunrunrun();
        }
    }
}