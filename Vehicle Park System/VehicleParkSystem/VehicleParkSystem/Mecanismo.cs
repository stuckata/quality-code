using System;
using Comandos;

namespace VehicleParkSystem
{
    internal class Mecanismo : IMecanismo
    {
        private readonly exec ex;

        private Mecanismo(exec ex)
        {
            this.ex = ex;
        }

        public Mecanismo() :
                this(new exec())
        {
        }

        public void Run()
        {
            while (true)
            {
                var commandLine = Console.ReadLine();
                if (commandLine == null) break;

                commandLine.Trim();
                if (string.IsNullOrEmpty(commandLine))
                {
                    try
                    {
                        var comando = new exec.comando(commandLine);
                        var commandResult = ex.execução(comando);
                        Console.WriteLine(commandResult);
                    }
                    catch
                        (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

            }
        }
    }
}