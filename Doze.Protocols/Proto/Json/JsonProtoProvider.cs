using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doze.Protocols.Proto.Json
{
    public class JsonProtoProvider : IProtoProvider
    {
        public T Deserialize<T>(string data)
        {
            throw new NotImplementedException();
        }

        public string Serialize<T>(T data)
        {
            throw new NotImplementedException();
        }

        public async Task<T> DeserializeAsync<T>(string data)
            => await Task.Run(() => Deserialize<T>(data));

        public async Task<string> SerializeAsync<T>(T data)
            => await Task.Run(() => Serialize(data));
    }
}
