namespace FormDesing.Models
{
    public class Response
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public Response()
        {
            Success = false;
            Message = string.Empty;
        }

        public Response(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public Response(bool success, string message, object data)
        {
            Success = success;
            Message = message;
            Data = data;
        }

    }
}
