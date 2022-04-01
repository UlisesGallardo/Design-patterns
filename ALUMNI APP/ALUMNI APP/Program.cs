using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ALUMNI_APP
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

         /*Leer del archivo Json y validar que el usuario ingresado tenga las credenciales.*/
         /*Agregar Singleton*/
            StreamReader r = new StreamReader("data.json");
            string jsonString = r.ReadToEnd();
            JObject json = (JObject)JsonConvert.DeserializeObject(jsonString);
            //Console.WriteLine(json["Students"]);

            var searchResults = from rr in json["Students"]
                                where rr["ID_Student"].ToString() == "0229262"
                                select rr;
            /*
            foreach (var rr in searchResults)
            {
                Console.WriteLine(rr);
            }*/

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
          
        }
    }
}
