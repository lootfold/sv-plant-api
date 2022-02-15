namespace SVPlant.Core.Exceptions
{
    public interface IAppException
    {
        public string Message { get; }
        public int StatusCode { get; set; }
    }
}
