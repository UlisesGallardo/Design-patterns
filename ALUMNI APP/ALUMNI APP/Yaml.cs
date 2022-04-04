using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using YamlDotNet.Serialization;
using System.IO;
using System.Runtime.Serialization;


namespace ALUMNI_APP
{
    class Yaml
    {
        public string convertToJson()
        {

            StreamReader r = new StreamReader("data.yaml");
            var deserializer = new DeserializerBuilder().Build();
            var yamlObject = deserializer.Deserialize(r);

            var serializer = new SerializerBuilder()
                .JsonCompatible()
                .Build();

            var json = serializer.Serialize(yamlObject);

            return json;
        }
    }
}
