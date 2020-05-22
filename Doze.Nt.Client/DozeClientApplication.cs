using Doze.Nt.Client.Core.Errors;
using Doze.Nt.Client.Hardware;
using Doze.Nt.Client.Network;
using Doze.Nt.Windows;

namespace Doze.Nt.Client
{
    public enum AppErrorCode : uint
    {
        ServerDestroyed = 0x000000A0,
        ServerBanned = 0x000000A1,
        ServerKick = 0x000000A2,

        UnauthorizedWindowAccess = 0x0000007D,
    }

    public static class DozeClientApplication
    {
        private static bool m_IsForceDebugMode { get; set; }
        private static bool m_IsReportsEnabled { get; set; }

        public static void Run()
        {
            DozeObjectManager.Instantiate();

            m_IsForceDebugMode = false;

            DozeObject.Create<WindowsObject>();
            DozeObject.Create<CoreErrorObject>();
            DozeObject.Create<HardwareObject>();
            DozeObject.Create<NetworkClientObject>();
        }

        public static bool IsForceModeEnabled()
            => m_IsForceDebugMode;

        public static bool IsReportsEnabled()
            => m_IsReportsEnabled;
    }
}
