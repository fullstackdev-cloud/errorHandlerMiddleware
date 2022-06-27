namespace errorHandlerMiddleware.Exceptions
{
    public class YouDidSomethingStupidException : Exception
    {
        public YouDidSomethingStupidException(string message) : base(message)
        {
        }
    }
}