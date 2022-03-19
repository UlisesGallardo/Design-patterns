using System;
using System.Collections.Generic;


namespace VentaComputadoras
{
    class Program
    {
        static void Main(string[] args)
        {
            ComputerDirector director = new ComputerDirector();
            ComputerBuilder builder1 = new BasicComputer();
            builder1 = director.Construct(builder1);

			Computer new_PC = builder1.GetComputer();
            Console.WriteLine("Final Components of the computer:\n" + new_PC.ToString());
        }
    }
}
