using System;

namespace VentaComputadoras
{
    class InputPeripheral : PeripheralsCreator
    {
        public override Component CreatePeripheral(int code)
        {
            if (code == 0)
            {
                return CreateMouse();
            }
            else if (code == 1)
            {
                return CreateKeyboard();
            }else if(code == 2)
            {
                return CreateGraphicTablet();
            }
            else
            {
                throw new Exception("Error! Unknown code.");
            }
        }

        
        public Component CreateMouse()
        {
            Random rand = new Random();

            Mouse generic_mouse = new Mouse();
            generic_mouse.setName("Generic Mouse");
            generic_mouse.Connector = "USB";
            generic_mouse.Puertos = new int[] { 1, 2, 3 };
            generic_mouse.TypePeripheral = "Input";
            generic_mouse.setTypeComponent("Peripheral");
            generic_mouse.setManufacturer("Razer");
            generic_mouse.setModel("DeathAdder");
            generic_mouse.setPrice((float)(rand.NextDouble()*100) %1000);
            return generic_mouse;
        }

        public Component CreateKeyboard()
        {
            Random rand = new Random();

            Keyboard generic_keyboard = new Keyboard();
            generic_keyboard.setName("Generic Keyboard");
            generic_keyboard.Connector = "USB";
            generic_keyboard.Puertos = new int[] { 1, 2, 3 };
            generic_keyboard.TypePeripheral = "Input";
            generic_keyboard.setTypeComponent("Peripheral");
            generic_keyboard.setManufacturer("Razer");
            generic_keyboard.setModel(" I don't know ");
            generic_keyboard.setPrice((float)(rand.NextDouble() * 100) % 1000);
            return generic_keyboard;
        }

        public Component CreateGraphicTablet()
        {
            Random rand = new Random();

            GraphicTablet generic_GraficTablet = new GraphicTablet();
            generic_GraficTablet.setName("Generic Graphic Tablet");
            generic_GraficTablet.Connector = "USB";
            generic_GraficTablet.Puertos = new int[] { 1, 2, 3 };
            generic_GraficTablet.TypePeripheral = "Input";
            generic_GraficTablet.setTypeComponent("Peripheral");
            generic_GraficTablet.setManufacturer("Wacom");
            generic_GraficTablet.setModel(" I don't know ");
            generic_GraficTablet.setPrice((float)(rand.NextDouble() * 100) % 1000);
            return generic_GraficTablet;
        }
    }
}
