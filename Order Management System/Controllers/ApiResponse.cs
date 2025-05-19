namespace Order_Management_System.Controllers
{
    public class ApiResponse<T>// Here <T> means jekono data type (Generic Data type) er data pathate pare
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }// T mane jekono data hote pare
        public List<string>? Errors { get; set; }
        public int StatusCode { get; set; }
        public DateTime TimeStamp { get; set; }


        //Constructor for success response

        private ApiResponse(bool success, string message, T? data, List<string>? errors, int statusCode)
        {
            Success = success;
            Message = message;
            Data = data;
            Errors = errors;
            StatusCode = statusCode;
            TimeStamp = DateTime.UtcNow;

        }
        //Ei constructor use korte gele bar bar object create kore use korte hbe . return new Apiresponse<T>()
        // New bar bar use korte na caile amra akta static method bante pari jeta object banabe.
        //tar mane direct constructor use na kore nicher method use kore call korbo
        public static ApiResponse<T> SuccessResponse(T? data, int statusCode, string message = "")
        {
            return new ApiResponse<T>(true, message, data, null, statusCode);
        }

        // Errorresponse method for create constructor for erro
        public static ApiResponse<T> ErrorResponse(List<string> errors, int statusCode, string message = "")
        {
            return new ApiResponse<T>(false, message, default(T), errors, statusCode);
        }



    }
}
