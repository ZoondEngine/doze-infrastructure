namespace Doze.Ethernet
{
    public static class EthernetFactory
    {
        public static SecureServer CreateSecureServer()
            => new SecureServer();

        public static SecureClient CreateSecureClient()
            => new SecureClient();
    }
}
