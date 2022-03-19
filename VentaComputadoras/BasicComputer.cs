using System;
using System.Collections.Generic;

namespace VentaComputadoras 
{
    class BasicComputer : ComputerBuilder
    {
        private Computer _basicComputer = new Computer();
        private PeripheralsCreator _peripheralscreator;
        public override void CentralUnit()
        {
            Random rand = new Random();

            CentralUnit centalunit = new CentralUnit();
            centalunit.setTypeComponent("CentralUnit");
            centalunit.setManufacturer("Apple");
            centalunit.setModel("I dont Know");
            centalunit.setPrice((float)(rand.NextDouble() * 100) % 1000);
            _basicComputer.AddComponent(centalunit);
        }

        public override void BuildPeripheral()
        {
            _peripheralscreator = new InputPeripheral();
            Component mouse = _peripheralscreator.CreatePeripheral(0);
            _basicComputer.AddComponent(mouse);
            Component keyboard = _peripheralscreator.CreatePeripheral(1);
            _basicComputer.AddComponent(keyboard);
            _peripheralscreator = new OutputPeripheral();
            Component screen = _peripheralscreator.CreatePeripheral(0);
            _basicComputer.AddComponent(screen);
        }

        public override void BuildSpecificPeripheral(int code)
        {
            if(code == 1)
            {
                _peripheralscreator = new InputPeripheral();
                Component mouse = _peripheralscreator.CreatePeripheral(0);
                _basicComputer.AddComponent(mouse);
            }else if(code == 2)
            {
                _peripheralscreator = new InputPeripheral();
                Component keyboard = _peripheralscreator.CreatePeripheral(1);
                _basicComputer.AddComponent(keyboard);
            }else if(code == 3)
            {
                _peripheralscreator = new InputPeripheral();
                Component Tablet = _peripheralscreator.CreatePeripheral(2);
                _basicComputer.AddComponent(Tablet);
            }else if(code == 4)
            {
                _peripheralscreator = new OutputPeripheral();
                Component screen = _peripheralscreator.CreatePeripheral(0);
                _basicComputer.AddComponent(screen);
            }else if(code == 5)
            {
                _peripheralscreator = new OutputPeripheral();
                Component printer = _peripheralscreator.CreatePeripheral(1);
                _basicComputer.AddComponent(printer);
            }else if(code == 6){
                _peripheralscreator = new InputOuputPeripherial();
                Component TouchScreen = _peripheralscreator.CreatePeripheral(0);
                _basicComputer.AddComponent(TouchScreen);
            }

            Console.WriteLine("Added component Correctly!");
        }


        public override void ModifyPeripheral(Dictionary<Component, Component> new_components)
        {
            // Qué componente modificar y cuál caracteristica será modificada?
            _basicComputer.SetComponents(new_components);
        }

        public override Dictionary<Component, Component> ShowComponents()
        {
            return _basicComputer.ShowComponents();
        }

        public override Computer GetComputer()
        {
            return _basicComputer;
        }

    }
}
