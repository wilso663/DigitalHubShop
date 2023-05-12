namespace API.Errors
{
    public class ApiException : ApiErrorResponse
    {
        public string Details { get; set; }
        public ApiException(int statusCode, string errorMessage = null, string details = null) : base(statusCode, errorMessage)
        {
            Details = details;
        }

    }
}
