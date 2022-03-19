using System;

namespace VentaComputadoras
{
    class InputOuputPeripherial : PeripheralsCreator
    {
        public override Component CreatePeripheral(int code)
        {
            if (code == 0)
            {
                return CreateTouchScreen();
            }
            else
            {
                throw new Exception("Error! Unknown code.");
            }
        }

        public Component CreateTouchScreen()
        {
            Random rand = new Random();

            TouchScreen generic_TouchScreen = new TouchScreen();
            generic_TouchScreen.setName("Generic Touch Screen");
            generic_TouchScreen.Connector = "USB";
            generic_TouchScreen.Puertos = new int[] { 1, 2, 3 };
            generic_TouchScreen.TypePeripheral = "InputOutput";
            generic_TouchScreen.setTypeComponent("Peripheral");
            generic_TouchScreen.setManufacturer("GameFactor");
            generic_TouchScreen.setModel("I dont Know");
            generic_TouchScreen.setPrice((float)(rand.NextDouble() * 100) % 1000);
            return generic_TouchScreen;
        }
    }
}
