using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace ALUMNI_APP
{
    class Supervisor : User
    {
        public string Name { get; set; }

        public Supervisor(string ID)
        {

        }
        public override List<string> GetInformation()
        {
            return null;
        }

        public override IEnumerable<JToken> GetCalifications()
        {
            return null;
        }

        public override DataTable GradesToTable()
        {
            return null;
        }
    }
}
