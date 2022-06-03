using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    public class TxtFile : Binnacle
    {
        public void Write(string text)
        {

            string fullPath = Directory.GetCurrentDirectory() + "\\Binnacle.txt";
            try
            {
                if (!File.Exists(fullPath))
                {
                    using (FileStream fs = File.Create(fullPath))
                    {
                    }
                }

                File.AppendAllText(fullPath, text+" -> Fecha"+ DateTime.Now.ToString() + "\n");

                //string readText = File.ReadAllText(fullPath);  
                //Console.WriteLine(readText);             
            }
            catch (Exception Ex)
            {
                //Console.WriteLine(Ex.ToString());
            }
        }
    }
}
