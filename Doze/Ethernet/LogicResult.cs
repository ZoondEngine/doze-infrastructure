namespace Doze.Ethernet
{
    public class LogicResult
    {
        public bool IsSucceed { get; private set; }
        public string ResultMessage { get; private set; }

        public LogicResult(bool success, string message)
        {
            IsSucceed = success;
            ResultMessage = message;
        }
    }
}
