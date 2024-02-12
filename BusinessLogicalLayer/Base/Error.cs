namespace BusinessLogicalLayer.Base
{
    public abstract class Error
    {
        public string Message { get; }
        public Code Code { get; }
        public string Description { get; }

        protected Error(string message, Code code, string description)
        {
            Message = message;
            Code = code;
            Description = description;
        }
    }
}
