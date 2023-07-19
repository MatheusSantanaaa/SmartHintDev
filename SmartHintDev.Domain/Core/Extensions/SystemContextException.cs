namespace SmartHintDev.Domain.Core.Extensions
{
    public class SystemContextException : Exception
    {
        public List<string> Errors { get; set; }

        public SystemContextException(List<string> errors)
        {
            Errors = errors;
        }
    }
}
