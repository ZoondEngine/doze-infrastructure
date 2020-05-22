namespace Doze.Ethernet.Packets.Auth
{
    public class AuthResponse : DozeNetworkResponse
    {
        public bool Result { get; set; }
        public string Message { get; set; }
        
        public AuthResponse(AuthRequest request)
            : base(request)
        { }

        public override bool IsValid()
        {
            //Not need because need catch errors
            return true;
        }

        public bool IsSuccess()
            => Result == true && Message == "";
    }
}
