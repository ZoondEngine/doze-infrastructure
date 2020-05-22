using Network.Packets;

namespace Doze.Ethernet.Packets.Auth
{
    public class AuthRequest : DozeNetworkRequest
    {
        public string Login { get; set; }
        public string PasswordHash { get; set; }
        public string Hardware { get; set; }
        public int Client { get; set; }

        public AuthRequest(string login, string passwordHash, string hardware, int client)
        {
            Login = login;
            PasswordHash = passwordHash;
            Hardware = hardware;
            Client = client;
        }

        public override bool IsValid()
        {
            return Login != ""
                && PasswordHash != ""
                && Hardware != ""
                && Client != -1;
        }
    }
}
