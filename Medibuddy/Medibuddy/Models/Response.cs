namespace Medibuddy.Models
{
    public class Response<T>
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; } = string.Empty;
        public List<T>? Records { get; set; }
        public T? Record { get; set; }
    }
}
