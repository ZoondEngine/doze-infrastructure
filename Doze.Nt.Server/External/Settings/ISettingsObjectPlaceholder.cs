using Doze.Ini;

namespace Doze.Nt.Server.External.Settings
{
    public interface ISettingsObjectPlaceholder
    {
        string GetName();
        string GetPath();
        Placeholder GetNativeIni();
        T Read<T>(string key, string section);
        void Default();
        void Load();
        T As<T>() where T : ISettingsObjectPlaceholder;
    }
}
