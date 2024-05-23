namespace InternManagementBusiness
{
    public interface IInternManagementResult
    {
        public int Status { get; set; }
        public string? Message { get; set; }
        public object? Data { get; set; }
    }
    public class BaseResult :IInternManagementResult
    {
        public int Status { get; set; }
        public string? Message { get; set; }
        public object? Data { get; set; }
        public BaseResult() {
            Status = -1;
            Message = "Action fall";
        }
        public BaseResult(int status, string message)
        {
            Status = status;
            Message = message;
        }
        public BaseResult(int status, string message, object data)
        {
            Status = status;
            Message = message;
            Data = data;
        }
    }
}
