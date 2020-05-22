using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Doze.Protocols.Proto.Binary
{
    public class BinaryProtoProvider : IProtoProvider
    {
        public T Deserialize<T>(string data)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                return (T)formatter.Deserialize(ms);
            }
        }

        public string Serialize<T>(T data)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                formatter.Serialize(ms, data);
                return Encoding.UTF8.GetString(ms.ToArray());
            }
        }

        public async Task<T> DeserializeAsync<T>(string data)
            => await Task.Run(() => Deserialize<T>(data));

        public async Task<string> SerializeAsync<T>(T data)
            => await Task.Run(() => Serialize(data));
    }
}
