using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALUMNI_APP
{
    class YamlToJson : IDataAdapter
    {
        private Yaml yaml;
        public YamlToJson(Yaml yaml)
        {
            this.yaml = yaml;
        }
        public string convert()
        {
            return yaml.convertToJson();
        }

    }
}
