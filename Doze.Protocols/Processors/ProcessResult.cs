namespace Doze.Protocols.Processors
{
    public struct ProcessResult
    {
        public ProcessorResult Result;
        public string Message;

        public ProcessResult(ProcessorResult result, string message)
        {
            Result = result;
            Message = message;
        }
    }
}
