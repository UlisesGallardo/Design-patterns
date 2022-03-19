using System;
using System.Collections.Generic;

namespace VentaComputadoras
{
    class ComputerDirector
    {
		public ComputerBuilder Construct(ComputerBuilder builder)
		{
			builder.CentralUnit();
			builder.BuildPeripheral();

			Console.WriteLine("Current Parts");
			Dictionary<Component, Component> _parts_4 = builder.ShowComponents();
			foreach (KeyValuePair<Component, Component> entry in _parts_4)
			{
				Console.WriteLine(entry.Value.ToString() + " price ->" + (entry).Value.GetPrice());
			}

			bool exit = true;
            while (exit)
            {
				Console.WriteLine("\nAvailable Options:");
				Console.WriteLine("+Add Peripheral    (1):");
				Console.WriteLine("~Modify Peripheral (2):");
				Console.WriteLine("-Delete Peripheral (3):");
				Console.WriteLine("-Details of Current Components (4):");
				Console.WriteLine("Exit		   (5):");
				int choice = Convert.ToInt32(Console.ReadLine());
				switch (choice)
				{
					case 1:

						Console.WriteLine("Choose new peripheral:");
						Console.WriteLine("1 Mouse\n2 Keyboard\n3 GraphicTablet\n4 Screen\n5 Printer\n6 TouchScreen");
						int choiceed = Convert.ToInt32(Console.ReadLine());

                        switch (choiceed)
                        {
							case 1:
								builder.BuildSpecificPeripheral(1);
								break;
							case 2:
								builder.BuildSpecificPeripheral(2);
								break;
							case 3:
								builder.BuildSpecificPeripheral(3);
								break;
							case 4:
								builder.BuildSpecificPeripheral(4);
								break;
							case 5:
								builder.BuildSpecificPeripheral(5);
								break;
							case 6:
								builder.BuildSpecificPeripheral(6);
								break;
							default:
								Console.WriteLine("Incorrect number of Peripheral, Try again!");
								break;
						}		

						break;
					case 2:
						string name, model;
						Dictionary<Component, Component> _parts = builder.ShowComponents(); 
						int size = _parts.Count;
						int n = 0;
						int component = -1;
						Console.WriteLine("Entrando" + size);
						while (!(component <= size &&  component >= 0))
						{
							Console.WriteLine("select a peripheral:");
							foreach (KeyValuePair<Component, Component> entry in _parts)
							{
								Console.WriteLine("(" + (n).ToString() + ") " + entry.Value.ToString());
								n++;
							}
							component = Convert.ToInt32(Console.ReadLine());
							Console.WriteLine("Enter a new name:");
							name = Console.ReadLine();
							Console.WriteLine("Enter a new model:");
							model = Console.ReadLine();

							int nn = 0;
							foreach (KeyValuePair<Component, Component> entry in _parts)
							{
								if(nn == component)
                                {
									_parts[entry.Value].Modify(name, model);
									builder.ModifyPeripheral(_parts);
									break;
                                }
								nn++;
							}
						}
						
						break;
					case 3:
						//Eliminar componentes de entrada y salida
						Dictionary<Component, Component> _parts_2 = builder.ShowComponents();
						int Input_peripherals, Output_peripheral, Input_Output_peripheral;
						Input_peripherals = 0;
						Output_peripheral = 0;
						Input_Output_peripheral = 0;

						//Extraer perifericos (componentes) de la computadora, y separarlos por su tipo de periferico.

						List<Component> Input = new List<Component>();
						List<Component> Output = new List<Component>();
						List<Component> InputOutput = new List<Component>();

						Console.WriteLine("List of Components");

						foreach (KeyValuePair<Component, Component> entry in _parts_2)
						{
                            if (entry.Value.GetTypeComponent() == "Peripheral")
                            {
								Peripheral _peripheral = (Peripheral)entry.Value;
								if (_peripheral.TypePeripheral == "Input")
								{
									Input_peripherals++;
									Input.Add(entry.Value);
								}else if (_peripheral.TypePeripheral == "Output")
                                {
									Output_peripheral++;
									Output.Add(entry.Value);
								}
								else if (_peripheral.TypePeripheral == "InputOutput")
                                {
									Input_Output_peripheral++;
									InputOutput.Add(entry.Value);
								}
							}
						}

						//Mostrar cada periferico dependiendo de su tipo 

						for (int i = 0; i < Input.Count; i++)
						{
							Console.WriteLine("		InputPeripheral#{0} = {1}", i, Input[i]);
						}

						for (int i = 0; i < Output.Count; i++)
						{
							Console.WriteLine("		OutputPeripheral#{0} = {1}", i, Output[i]);
						}

						for (int i = 0; i < InputOutput.Count; i++)
						{
							Console.WriteLine("		InputOutputPeripheral#{0} = {1}", i, InputOutput[i]);
						}
						Console.WriteLine("Select Type Peripheral:");
						Console.WriteLine(" (1) for InputPeripheral");
						Console.WriteLine(" (2) for OutputPeripheral");
						Console.WriteLine(" (3) for InputOutputPeripheral");
						int type_peripheral = Convert.ToInt32(Console.ReadLine());
						Console.WriteLine("Select Peripheral:");
						int selected_peripheral = Convert.ToInt32(Console.ReadLine());

						//Validar Eliminación 

						


						switch (type_peripheral)
                        {
							case 1:
								if (Input_peripherals == 0) { Console.WriteLine("There are no peripheral of that type");  break; }
								if(Input_peripherals == 1 && Input_Output_peripheral == 0) { Console.WriteLine("Impossible to eliminate, you need at least one input peripheral");}
                                else
                                {
									if (selected_peripheral>=0 && selected_peripheral <= Input.Count) _parts_2.Remove(Input[selected_peripheral]);
									else Console.WriteLine("Invalid Number!");
								}
								break;
							case 2:
								if (Output_peripheral == 0) { Console.WriteLine("There are no peripheral of that type"); break; }
								if (Output_peripheral == 1 && Input_Output_peripheral == 0) { Console.WriteLine("Impossible to eliminate, you need at least one output peripheral"); }
								else
								{
									if (selected_peripheral >= 0 && selected_peripheral <= Output.Count) _parts_2.Remove(Output[selected_peripheral]);
									else Console.WriteLine("Invalid Number!");
								}
								break;
							case 3:
								if (Input_Output_peripheral == 0) { Console.WriteLine("There are no peripheral of that type"); break; }
								if (Input_Output_peripheral == 1 && (Output_peripheral < 1 || Input_peripherals < 1)) { Console.WriteLine("Impossible to eliminate, you need at least one input and one output peripheral"); }
								else
								{
									if (selected_peripheral >= 0 && selected_peripheral <= InputOutput.Count) _parts_2.Remove(InputOutput[selected_peripheral]);
									else Console.WriteLine("Invalid Number!");
								}
								break;
							default:
								Console.WriteLine("Incorrect Type of Peripheral, Try again!");
								break;
						}

						builder.ModifyPeripheral(_parts_2);
						Console.WriteLine("Component removed successfully! ");
						break;
					case 4:
						Dictionary<Component, Component> _parts_3 = builder.ShowComponents();
						foreach (KeyValuePair<Component, Component> entry in _parts_3)
                        {
							Console.WriteLine(entry.Value.ToString()+" price ->"+ (entry).Value.GetPrice());
						}
						break;
					case 5:
						exit = false;
						break;
					default:
						Console.WriteLine("Invalid Option, try again\n");
						break;
                }
			}
			
			return builder;
		}

	}
}
