using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doze.Protocols.Proto
{
    public interface IProtoProvider
    {
        T Deserialize<T>(string data);
        Task<T> DeserializeAsync<T>(string data);

        string Serialize<T>(T data);
        Task<string> SerializeAsync<T>(T data);
    }
}
