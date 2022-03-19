using System;

namespace VentaComputadoras
{
    class OutputPeripheral : PeripheralsCreator
    {
        public override Component CreatePeripheral(int code)
        {
            if (code == 0)
            {
                return CreateScreen();
            }
            else if (code == 1)
            {
                return CreatePrinter();
            }
            else
            {
                throw new Exception("Error! Unknown code.");
            }
        }

        public Component CreateScreen()
        {
            Random rand = new Random();

            Screen generic_screen = new Screen();
            generic_screen.setName("Generic Screen");
            generic_screen.Connector = "HDMI, DisplayPort";
            generic_screen.Puertos = new int[] { 1, 2, 3 };
            generic_screen.TypePeripheral = "Output";
            generic_screen.setTypeComponent("Peripheral");
            generic_screen.setManufacturer("GameFactor");
            generic_screen.setModel("I dont Know");
            generic_screen.setPrice((float)(rand.NextDouble() * 100) % 1000);
            return generic_screen;
        }

        public Component CreatePrinter()
        {
            Random rand = new Random();

            //PrinterType
            Printer generic_printer = new Printer();
            generic_printer.setName("Generic Printer");
            generic_printer.Connector = "USB, Bluetooth";
            generic_printer.Puertos = new int[] { 1, 2, 3 };

            Console.WriteLine("Which type of printer?");
            generic_printer.PrinterType = Console.ReadLine();
            Console.WriteLine("Which type of toner?");
            generic_printer.Toner = Console.ReadLine();
            generic_printer.TypePeripheral = "Output";
            generic_printer.setTypeComponent("Peripheral");
            generic_printer.setManufacturer("Razer");
            generic_printer.setModel("I dont Know");
            generic_printer.setPrice((float)(rand.NextDouble() * 100) % 1000);
            return generic_printer;
        }
    }
}
