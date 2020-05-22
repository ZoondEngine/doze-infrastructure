using System.Management;

namespace Doze.Nt.Client.Hardware.Components.CollectorMisc.Archetype
{
    public abstract class BaseCaption
    {
        protected ManagementObjectSearcher SearcherInstance;

        public BaseCaption(ManagementObjectSearcher obj)
        {
            SearcherInstance = obj;
        }

        public T Get<T>(string key)
        {
            foreach(var baseObject in SearcherInstance.Get())
            {
                var managementObject = (ManagementObject)baseObject;
                if(managementObject != null)
                {
                    try
                    {
                        return (T)managementObject[key];
                    }
                    catch
                    {
                        return default;
                    }
                }
            }

            return default;
        }

        public ManagementObjectSearcher GetSearcher()
            => SearcherInstance;
    }
}
