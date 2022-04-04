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
    abstract class User
    {
        public string ID { set; get; }
        public string Password { set; get; }
        public abstract List<string> GetInformation();
        public abstract List<JToken> GetCalifications();
        public abstract DataTable GradesToTable();
    }
}
