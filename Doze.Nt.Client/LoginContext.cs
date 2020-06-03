using Doze.Nt.Client.Hardware;
using Doze.Nt.Client.LoginContextData;
using Doze.Nt.Client.Network;
using Doze.Nt.Windows;
using Jareem.Network.Packets;
using System;
using System.Threading.Tasks;

namespace Doze.Nt.Client
{
    public enum LoginAttemptResult
    {
        NetworkError,
        Ok,
        ServerError
    }

    public struct LoginAttemptResultStruct
    {
        public LoginAttemptResult AttemptResult;
        public bool IsAllowed;
        public string Message;

        public LoginAttemptResultStruct(LoginAttemptResult result, string message)
        {
            AttemptResult = result;
            IsAllowed = result == LoginAttemptResult.Ok;
            Message = message;
        }
    }

    public class LoginContext : DozeObject
    {
        private Login LoginForm { get; set; }
        private User AuthorizedUser { get; set; }

        public LoginContext()
        {
            var windowManager = FindObjectOfType<WindowsObject>();
            if(windowManager != null)
            {
                LoginForm = windowManager.GetOriginalObject<Login>("window-general:login");
                if (LoginForm == null)
                    throw new Exception($"Undefined login form for helping her");
            }
        }

        public bool Connect()
        {
            var network = FindObjectOfType<NetworkClientObject>();
            if (network != null)
                return network.Connect();

            return false;
        }

        public User GetUser()
            => AuthorizedUser ?? new User(0L, null, null);

        public async Task<bool> ConnectAsync()
            => await Task.Run(() => Connect());

        public async Task<LoginAttemptResultStruct> LoginAttemptAsync(string login, string password)
        {
            var hardwareObject = FindObjectOfType<HardwareObject>();
            var hardware = await Task.Run(() =>
            {
                return hardwareObject.GetHardwareIdentifier();
            });

            var network = FindObjectOfType<NetworkClientObject>();
            var authenticateResponse = await network.SendAsync<AuthenticateResponse>(new AuthenticateRequest()
            {
                Hardware = hardware,
                Login = login,
                PasswordHash = password,
                LocaleTwoLettersCode = hardwareObject.GetTwoLetterLocaleCode(),
            },
            Packets.AuthenticateResponse);

            if (authenticateResponse == null)
            {
                return new LoginAttemptResultStruct(LoginAttemptResult.NetworkError, "Internal network error");
            }
            else if (authenticateResponse.Result)
            {
                return new LoginAttemptResultStruct(LoginAttemptResult.Ok, "");
            }
            else
            {
                return new LoginAttemptResultStruct(LoginAttemptResult.ServerError, authenticateResponse.Message);
            }
        }
    }
}
