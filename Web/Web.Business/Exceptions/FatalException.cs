namespace Web.Business.Exceptions
{
    /// <summary>
    /// Exception that should be logged as fatal.
    /// </summary>
    public class FatalException : Exception
    {
        public FatalException(string message) : base(message)
        {
        }

        public FatalException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
