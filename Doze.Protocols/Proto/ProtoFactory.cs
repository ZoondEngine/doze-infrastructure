using Doze.Protocols.Proto.Google;
using Doze.Protocols.Proto.Json;
using Doze.Protocols.Proto.Xml;
using System;
using System.Linq;
using System.Reflection;

namespace Doze.Protocols.Proto
{
    public static class ProtoFactory
    {
        public static GoogleProtoProvider CreateGoogleProtoProvider()
            => new GoogleProtoProvider();

        public static JsonProtoProvider CreateJsonProtoProvider()
            => new JsonProtoProvider();

        public static XmlProtoProvider CreateXmlProtoProvider()
            => new XmlProtoProvider();

        /// <summary>
        /// Create a custom provider from class name.
        /// That mechanism search class for first characters entry name of class
        /// ex. CreateCustomProvider("json"); for search <see cref="JsonProtoProvider"/>.
        /// If protocol class not found return default protocol if 'useDefaults' == true.
        /// </summary>
        /// <param name="providerName"></param>
        /// <param name="useDefaults">Return default if fail while searching(default = JsonProtoProvider)</param>
        /// <returns></returns>
        public static IProtoProvider CreateCustomProtoProvider(string providerName, bool useDefaults = true)
        {
            if(providerName.ToLower().Contains("proto") || providerName.ToLower().Contains("provider"))
            {
                throw new Exception($"Bad argument");
            }

            var providers = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(m => m.GetInterfaces().Contains(typeof(IProtoProvider)) & m.Name.ToLower().Contains(providerName.ToLower()))
                .Select(m => m.GetConstructor(Type.EmptyTypes).Invoke(null) as IProtoProvider)
                .ToList();

            if (providers.Count > 0)
                return providers.First();

            return useDefaults == true 
                ? CreateJsonProtoProvider() 
                : null; 
        }
    }
}
