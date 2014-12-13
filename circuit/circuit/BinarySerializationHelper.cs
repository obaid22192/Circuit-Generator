using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace circuit
{
    public class BinarySerializationHelper
    {
        public void serializeObject(string filename, Circuit circuitToSerialize)
        {
            Stream stream = File.Open(filename, FileMode.Create, FileAccess.Write);
            BinaryFormatter bFormatter = new BinaryFormatter();
            try
            {
                bFormatter.Serialize(stream, circuitToSerialize);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                throw;
            }
            stream.Close();
        }

        public Circuit deSerializeObject(string filename)
        {
            Circuit circuitToSerialize;
            Stream stream = File.Open(filename, FileMode.Open);
            BinaryFormatter bFormatter = new BinaryFormatter();
            circuitToSerialize = (Circuit)bFormatter.Deserialize(stream);
            stream.Close();
            return circuitToSerialize;
        }
    }
}
